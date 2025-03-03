# 🚀 Banking Transaction System

## 🌟 Overview
Welcome to the **Banking Transaction System**! This is a powerful and secure backend service that enables users to authenticate, manage transactions, and transfer funds seamlessly. Built with **.NET 9** and **SQL Server**, this system ensures reliable banking operations with top-notch security. 🔒💰

## 🛠️ Tech Stack
- **Framework:** .NET 9.0 ⚡
- **Database:** SQL Server 🗄️
- **Authentication:** JWT (JSON Web Token) 🔑
- **Logging:** .NET built-in logging 📝

## 📁 Project Structure
```
📦 Collection_BankingSystem  
 ┣ 📂 Controllers        # API endpoints  
 ┣ 📂 DTOs              # Data Transfer Objects  
 ┣ 📂 DataBase          # Database configurations  
 ┣ 📂 DataInstanse      # Data models & context  
 ┣ 📂 Migrations        # Entity Framework migrations  
 ┣ 📂 Properties        # Project properties  
 ┣ 📂 Services          # Business logic services  
 ┣ 📂 Validation        # Input validation logic  
 ┗ 📜 README.md         # Project documentation  
```

## ✅ Prerequisites
Before you get started, make sure you have:
- 🔧 **.NET 9.0 SDK** installed
- 🏦 **SQL Server** running
- 📦 Required NuGet Packages:
  - `Microsoft.AspNetCore.Authentication.JwtBearer` 🛡️
  - `Microsoft.AspNetCore.OpenApi` 📜
  - `Microsoft.EntityFrameworkCore` 🏗️
  - `Microsoft.EntityFrameworkCore.SqlServer` 🖥️
  - `Microsoft.EntityFrameworkCore.Tools` 🔧

## 🚀 Installation & Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo-url.git
   cd Collection_BankingSystem
   ```
2. Configure the database connection in `appsettings.json`. 🛠️
3. Apply migrations:
   ```bash
   dotnet ef database update
   ```
4. Run the application:
   ```bash
   dotnet run
   ```

## 🔗 API Endpoints

### 👤 User Authentication
- `POST /api/user/register` → 📝 Register a new user
- `GET /api/user/login` → 🔐 Log in and receive a JWT token

### 💳 Transaction History
- `GET /api/transactionrecord/AllTransaction,{username}` → 📜 Get all transactions
- `GET /api/transactionrecord/sendTransaction,{username}` → 💸 View sent transactions
- `GET /api/transactionrecord/receiveTransaction,{username}` → 💰 View received transactions

### 💵 Cash Transfer
- `PUT /api/cash/sendCash` → 🚀 Send money securely to another user

## 🎯 Running the Project
To start the application, simply run:
```bash
dotnet run
```

## 🤝 Contributing
We welcome contributions! If you have ideas or improvements, feel free to submit a pull request. Let's build something great together! 🚀✨

---
This project is developed using **.NET 9** and **SQL Server** to ensure secure and seamless banking transactions. 🌍💵

