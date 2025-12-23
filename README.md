# Smart Expense Tracker

## 📌 Overview
Smart Expense Tracker is a backend-focused application built using C# and .NET.  
The project demonstrates clean architecture, SOLID principles, EF Core, SQL optimization, and asynchronous programming.

The initial version is a console application and is designed to be extended into an ASP.NET Web API.

---

## 🛠 Tech Stack
- C#
- .NET 10
- Entity Framework Core
- SQL Server
- LINQ
- Dependency Injection

---

## 🏗 Architecture
This project follows Clean Architecture principles:

- **Domain** – Core entities & interfaces
- **Application** – Business logic
- **Infrastructure** – EF Core & database access
- **ConsoleApp** – Presentation layer

---

## ✨ Features
- Add, update, delete expenses
- Categorize expenses
- Monthly & category-wise reports
- Budget monitoring using events
- Optimized SQL queries
- Async database operations

---

## 📂 Project Structure
src/
├── Domain
├── Application
├── Infrastructure
└── ConsoleApp
