# BackEndAPI - Backend & Pagination API Projects

This repository hosts the two main ASP.NET Core API services for the DELTA MS project: the **Pagination API** and the **Backend (Database Connection) API**.

Both services are developed under the same solution and share a common infrastructure.

---

## 📦 Project Structure

The project root directory contains two main folders:

| Folder Name | Description |
| :--- | :--- |
| **`PaginationApi/`** | The main API service responsible for managing pagination and filtering operations on data sets. |
| **`backEndDbConnection/`** | The API service that contains the application's primary database connection and core business logic. |

---

## 🛠️ Setup and Running

### Prerequisites

* .NET Core SDK (6.0 or higher)
* Preferred IDE (Visual Studio, VS Code, etc.)

### Steps

1.  **Clone the Repository:**
    ```bash
    git clone <your_repo_url>
    ```

2.  **Restore Dependencies:**
    Navigate to the directory containing the solution file (or the `src` folder) and restore dependencies.
    ```bash
    dotnet restore
    ```

3.  **Database Configuration:**
    Check the `appsettings.json` files (for both projects) and update the database connection strings (`ConnectionStrings`) to match your local environment.

4.  **Run the Project:**
    You can run the entire solution:
    ```bash
    dotnet run --project <Path_to_Solution_File_or_Project_Name>
    # Or start debugging via Visual Studio/VS Code.
    ```
    **Note:** You might need to use the exact name of your projects or your solution file in this command.

---

## 🔗 API Endpoints

Once the application is running, you can access the endpoints via the Swagger/OpenAPI UI.

* **PaginationApi:** `https://localhost:XXXX/swagger`
* **BackEndDbConnection:** `https://localhost:YYYY/swagger`

*(XXXX and YYYY will be the port numbers configured for your projects.)*

---

## 🤝 Contributing

Feel free to open a new **Issue** for bug reports and development suggestions.
