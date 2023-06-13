# Task Planner API

This is a sample API project for a task planner application. It provides endpoints to manage tasks and categories.

## Technologies Used

- .NET Core
- Entity Framework Core
- SQL Server

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- SQL Server (local or remote)

## Getting Started

1. Clone the repository:
    ```bash
    git clone <repository_url>
    ```
2. Navigate to the project directory:
    ```bash
    cd task-planner-api
    ```
3. Restore the dependencies:
    ```bash
    dotnet restore
    ```
4. Update the database connection string in the appsettings.json file.

5. Apply the database migrations:
    ```bash
    dotnet ef database update
    ```
6. Run the API
    ```bash
    dotnet run
    ```
The API will be available at http://localhost:5000.

# API Endpoints
## Categories
- GET /api/categories: Get all categories.
- PUT /api/categories/{id}: Update a category by ID.
- DELETE /api/categories/{id}: Delete a category by ID.
- POST /api/categories: Create a new category.
## Task Items
- GET /api/taskitems: Get all task items.
- GET /api/taskitems/{id}: Get a task item by ID.
- GET /api/taskitems/GetTasksByCategoryId?id={categoryId}: Get all task items by category ID.
- POST /api/taskitems: Create a new task item.
- DELETE /api/taskitems/{id}: Delete a task item by ID.
- PUT /api/taskitems: Update a task item.
## Folder Structure
The repository has the following folder structure:

- Controllers: Contains the API controllers for categories and task items.
- Data: Contains the database context and migrations.
- Dtos: Contains the data transfer objects used for API input/output.
- Extensions: Contains extension methods.
- Models: Contains the entity models for categories and task items.
- Repositories: Contains the repository classes for accessing data.
- Repositories.Contracts: Contains the repository interfaces.
## Contributing
Contributions are welcome! If you find a bug or have a feature request, please open an issue or submit a pull request with your changes.
