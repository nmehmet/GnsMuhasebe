# 📈 GnsMuhasebe (GnsAccounting)

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat&logo=dotnet)
![Architecture](https://img.shields.io/badge/Architecture-Clean%20Architecture-blue)
![Pattern](https://img.shields.io/badge/Pattern-CQRS%20%2F%20DDD-green)
![Testing](https://img.shields.io/badge/Testing-xUnit%20%7C%20Moq-yellowgreen)
![License](https://img.shields.io/badge/License-MIT-lightgrey)

**GnsMuhasebe** is a robust, scalable backend application designed for pre-accounting and stock management operations. Built with **.NET 8**, it strictly follows **Domain-Driven Design (DDD)** principles and **Clean Architecture**.

This project demonstrates professional backend development practices, including handling complex business rules, automated testing, and CI/CD pipelines.

---

## 🏗️ Architecture & Design

The solution is structured based on **Onion Architecture** to ensure separation of concerns and maintainability.

* **CORE**
    * **Domain:** The heart of the application. Contains Entities (`Product`, `Category`), Value Objects, Enums, and Custom Exceptions. *No external dependencies.*
    * **Application:** Orchestrates logic using **CQRS** (Command Query Responsibility Segregation). Contains MediatR Handlers, Validators, and DTOs.
* **INFRASTRUCTURE**
    * **Infrastructure:** Implementation of interfaces (Repositories, Database Context, Migrations). Uses EF Core.
* **PRESENTATION**
    * **Host (API):** The entry point. Contains Controllers and Middleware configuration.

---

## 🚀 Key Features

* **CQRS Pattern:** Implementation of Command and Query separation using **MediatR**.
* **Domain-Driven Design (DDD):** Rich domain models with encapsulated business logic (e.g., `Product.DecreaseStock` rules) instead of Anemic Models.
* **Global Exception Handling:** A centralized middleware that catches custom exceptions (`BusinessException`) and returns localized, client-friendly JSON responses without exposing stack traces.
* **Validation Pipeline:** Request validation using **FluentValidation** integrated into the MediatR pipeline.
* **Unit Testing:** Comprehensive unit tests for Domain logic and Application handlers using **xUnit** and **Moq**.
* **CI/CD:** Automated testing pipeline via **GitHub Actions** that runs on every push to the main branch.
* **Localization:** Multi-language support for error messages (via `.resx` resources).

---

## 🛠️ Tech Stack

* **Framework:** .NET 8 Core
* **Language:** C#
* **Data Access:** Entity Framework Core (Code First)
* **Database:** SQL Server
* **Mediation:** MediatR
* **Validation:** FluentValidation
* **Testing:** xUnit, Moq
* **Documentation:** Swagger / OpenAPI

---

## ⚙️ Getting Started

### Prerequisites
* .NET 8 SDK installed.
* SQL Server (LocalDB or Docker).

### Installation

1.  **Clone the repository**
    ```bash
    git clone [https://github.com/](https://github.com/)[GITHUB_KULLANICI_ADIN]/GnsMuhasebe.git
    cd GnsMuhasebe
    ```

2.  **Configure Database**
    Update the `ConnectionStrings` in `appsettings.json` located in the `GnsMuhasebe.Host` project.

3.  **Apply Migrations**
    Run the following command to create the database:
    ```bash
    dotnet ef database update --project GnsMuhasebe.Infrastructure --startup-project GnsMuhasebe.Host
    ```

4.  **Run the Application**
    ```bash
    dotnet run --project GnsMuhasebe.Host
    ```

5.  **Explore API**
    Navigate to `https://localhost:5001/swagger` (or your local port) to view the API documentation.

---

## 🧪 Running Tests

This project enforces high code quality with Unit Tests covering both happy paths and edge cases.

To run tests manually:
```bash
dotnet test
```

📝 Code Examples
Global Error Handling Response
If a user tries to perform an invalid operation, the system returns a structured JSON:

## JSON
````
{
  "error": true,
  "code": 2002,
  "message": "Stok yetersiz."
}
````
Business Logic (DDD)
Example of protecting domain invariants within the Entity:

## C#
```
public void DecreaseStock(int quantity)
{
    if (quantity <= 0) throw new BusinessException(BusinessErrorCode.InvalidQuantity);
    if (Stock < quantity) throw new BusinessException(BusinessErrorCode.StockInsufficient);
    
    Stock -= quantity;
}
```
👤 Author
[NECDET MEHMET GÜNEŞ]

🔗 [LinkedIn Profilim](https://www.linkedin.com/in/nmehmet093/)

💻 [GitHub Profilim](https://github.com/nmehmet)
