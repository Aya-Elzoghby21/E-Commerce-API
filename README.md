# 🛒 E-Commerce RESTful API

This is a full-featured **E-Commerce Backend Web API** built using **ASP.NET Core**, following best practices like **JWT Authentication**, **Role-based Authorization**, **Clean Architecture**, **Service Layer**, **Generic Repository Pattern**, and **DTOs**.

---

## 🚀 Features

- 🔐 JWT Authentication with ASP.NET Identity  
- 👥 Role-Based Authorization (Admin / User)  
- 🛍️ Products CRUD with Pagination  
- 📂 Category Management  
- 👤 User Management (Admin only)  
- 🧾 Orders Management (User & Admin access)  
- 🧰 Clean Architecture with Services & Generic Repositories  
- 🖼️ Product Image Upload via URL  
- 🧠 DTOs, AutoMapper, and Fluent Validation  

---

## 📁 Project Structure
E-commerce/
│
├── Controllers/
├── Models/
├── DTOs/
├── Services/
├── Repository/
├── models/
├── wwwroot/images/
├── Program.cs
├── appsettings.json


---

## 🧑‍💻 Technologies Used

- ASP.NET Core Web API  
- Entity Framework Core (Code First)  
- ASP.NET Identity  
- JWT Tokens  
- AutoMapper  
- SQL Server  
- C#  

---

## 🔐 Authentication

- **Register:** `POST /api/Auth/register`  
- **Login:** `POST /api/Auth/login`  
  → Returns a JWT token for authentication.

---

## 📦 API Endpoints

### 👤 Users (Admin Only)

- `GET /api/Users`  
- `GET /api/Users/{id}`  
- `PUT /api/Users/{id}`  
- `DELETE /api/Users/{id}`  

### 🛍️ Products

- `GET /api/Products?page=1&pageSize=10`  
- `GET /api/Products/{id}`  
- `POST /api/Products`  
- `PUT /api/Products/{id}`  
- `DELETE /api/Products/{id}`  

### 📂 Categories (if implemented)

- `GET /api/Categories`  
- `GET /api/Categories/{id}`  
- `POST /api/Categories`  
- `PUT /api/Categories/{id}`  
- `DELETE /api/Categories/{id}`  

### 🧾 Orders

- `GET /api/Orders/all-orders` (Admin only)  
- `GET /api/Orders/user-orders/{userId}`  
- `GET /api/Orders/latest-orders` (Admin only)  

---

## 🧪 Testing

You can test the API using tools like **Postman** or **Swagger UI**.  
Make sure to include the **JWT token** in the `Authorization` header using the **Bearer** scheme.

---

## 🔧 How to Run the Project

1. Clone the repository:
git clone https://github.com/Aya-Elzoghby21/ecommerce-api.git

2. Set up SQL Server and update your `appsettings.json` connection string.

3. Apply migrations: 
dotnet ef database update

4. Run the project

---

## 👤 Admin Credentials (for testing)

You can manually create an Admin or seed one:

{
"UserName": "admin",
"Password": "Admin@123",
"Roles": ["Admin"]
}

---
## 📌 Future Enhancements

⬜ Cart & Wishlist APIs

⬜ Payment gateway integration (e.g., Stripe)

⬜ Unit & Integration Testing

⬜ Deployment (e.g., Azure, Render)

⭐️ Star this repository if you find it helpful!

