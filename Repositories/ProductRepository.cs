using Microsoft.Data.SqlClient;
using PaginationApi.Models;
using System.Data;

namespace PaginationApi.Repositories
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<(IEnumerable<Product> Products, int TotalCount)> GetPaginatedProductsAsync(int pageNumber, int pageSize)
        {
            var products = new List<Product>();
            int totalCount = 0;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("sp_GetProductsPaginated", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        // İlk resultset: Ürünler
                        while (await reader.ReadAsync())
                        {
                            products.Add(new Product
                            {
                                ProductId = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                Price = reader.GetDecimal(2),
                                CreatedDate = reader.GetDateTime(3)
                            });
                        }

                        // İkinci resultset: Toplam sayı
                        await reader.NextResultAsync();
                        if (await reader.ReadAsync())
                        {
                            totalCount = reader.GetInt32(0);
                        }
                    }
                }
            }

            return (products, totalCount);
        }
    }
}
