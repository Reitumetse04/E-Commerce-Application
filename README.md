# ClearCart API

The ClearCart API is part of a team e-commerce system. It is responsible for clearing all items from a specific user's shopping cart. 
This API is built with **ASP.NET Core** and uses **Entity Framework Core** with a PostgreSQL database.

---
##  What this API does

- Accepts a `userId` and removes all cart items belonging to that user from the database.
- Allows adding new cart items for testing and development purposes.
- Can list all current cart items in the database.

---
## 🛠 Technologies Used

- .NET 9
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL (Neon cloud database)
- Visual Studio Code
- Postman (for testing)

---

## Project Structure
ClearCartApi/
├── Controllers/
│   └── ClearCartController.cs         # Handles incoming HTTP requests for clearing and adding to cart
│
├── Database/
│   ├── ShoppingCartContext.cs        # EF Core DbContext for database connection
│   └── CartItem.cs                   # Model representing a shopping cart item
│
├── Migrations/                       # Auto-generated EF Core migration files
│
├── appsettings.json                  # Stores configuration settings like connection string
├── Program.cs                        # Entry point for the app; sets up services and middleware
├── README.md                         # Project documentation (this file)


