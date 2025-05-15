# Reactivities App 🧠⚙️

A full-stack CRUD application built with:

- **.NET 8 Web API**
- **Entity Framework Core with SQLite**
- **React.js frontend (planned integration)**
- **Domain-Driven Design (DDD) structure**

## 📁 Project Structure

Reactivities/
├── API/ # ASP.NET Core API project
├── Application/ # Application layer for use cases
├── Domain/ # Entity models
├── Persistence/ # EF Core DbContext and Migrations

## 🧪 Features

- Activity management (Create, Read, Update, Delete)
- Clean architecture
- EF Core migrations and data seeding
- Auto-applied migrations on startup


## 🛠️ How to Run

1. Clone the repo:
   ```bash
   git clone https://github.com/YOUR_USERNAME/Reactivities.git

2. Apply migrations:

dotnet ef database update -p Persistence -s API

3.Run the project:

dotnet watch run --project API



