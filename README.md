# 🧾 Clothing Store Payments API

This is a simle RESTful API built with **ASP.NET Core** and **Entity Framework Core** that handles payments for an online clothing store. It calculates and processes the total payment from a user's shopping cart, storing the transaction securely in a **PostgreSQL database** hosted on **Neon**.

---
# Features

-  Accepts payment totals via a secure endpoint
- Saves payment records to a PostgreSQL database
- Designed for testing with Postman

---

##  Packages used

- ASP.NET Core Web API (.NET 6+)
- Entity Framework Core
- PostgreSQL (hosted on Neon.tech)
- Postman (for manual testing)

---

##  API Endpoint

### `POST /api/payments`

**Description:** Submits a total payment amount to be saved.
