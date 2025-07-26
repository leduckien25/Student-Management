# Student Management System

A lightweight ASP.NET Core MVC web application for managing student records with SQL Server integration.

## ✨ Features

* Display student list with profile images
* Add new students with form validation
* Edit existing student details
* Delete students from the database
* Upload and display student images
* Save data using SQL Server

## 🛠 Technologies Used

* ASP.NET Core MVC (.NET 9)
* Razor Views
* SQL Server
* Dapper ORM
* HTML, CSS

## ⚙️ Getting Started

### 1. Configure the Database

Edit your `appsettings.json` with your SQL Server connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=StudentDB;Trusted_Connection=True;"
}
```
