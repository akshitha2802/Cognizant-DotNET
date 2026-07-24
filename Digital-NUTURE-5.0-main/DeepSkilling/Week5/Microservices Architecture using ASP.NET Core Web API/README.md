# Week 5 – Microservices Architecture using ASP.NET Core Web API

## 📚 Topic
**Authentication and Authorization using JWT (JSON Web Tokens)**

This week focuses on implementing secure authentication and authorization in ASP.NET Core Web API using JSON Web Tokens (JWT). The project demonstrates user authentication, protected API endpoints, role-based authorization, and JWT token validation.

---

## 🛠️ Technologies Used

- ASP.NET Core Web API (.NET 10)
- C#
- JWT (JSON Web Tokens)
- Swagger (OpenAPI)
- Microsoft.AspNetCore.Authentication.JwtBearer
- Visual Studio Code
- .NET CLI

---

## 📁 Folder Structure

```text
Week5
│
├── Microservices Architecture using ASP.NET Core Web API
│   │
│   ├── 1. JWT Authentication
│   │   │
│   │   ├── JWTAuthenticationAPI
│   │   │   ├── Controllers
│   │   │   ├── Models
│   │   │   ├── Properties
│   │   │   ├── Program.cs
│   │   │   ├── appsettings.json
│   │   │   └── JWTAuthenticationAPI.csproj
│   │   │
│   │   └── README.md
│   │
│   └── README.md
```

---

## ✅ Hands-on Completed

### Question 1 – Implement JWT Authentication

- Created ASP.NET Core Web API project
- Configured JWT Authentication
- Implemented Login API
- Generated JWT Token after successful login

---

### Question 2 – Secure API Endpoint

- Protected API using `[Authorize]`
- Allowed only authenticated users to access secure resources

---

### Question 3 – Role-Based Authorization

- Added Role claims inside JWT
- Implemented Admin-only endpoint using

```csharp
[Authorize(Roles = "Admin")]
```

---

### Question 4 – JWT Token Validation

- Configured JWT validation
- Implemented expired token handling
- Added custom response header for expired tokens

---

## 📌 API Endpoints

| Method | Endpoint | Description |
|---------|----------|-------------|
| POST | `/api/Auth/login` | Generate JWT Token |
| GET | `/api/Secure/data` | Protected Endpoint |
| GET | `/api/Admin/dashboard` | Admin Only Endpoint |

---

## 🔐 JWT Authentication Flow

1. User sends Username and Password.
2. Server validates credentials.
3. JWT Token is generated.
4. Client stores the token.
5. Client sends the token in the Authorization header.
6. Protected endpoints validate the JWT before granting access.

---

## 📷 Output

- Swagger UI
- Successful Login
- JWT Token Generation
- Protected API Response
- Admin Dashboard Response

---

## 🎯 Learning Outcomes

- ASP.NET Core Web API Development
- JWT Authentication
- Authorization using Attributes
- Role-Based Authorization
- Token Validation
- Claims-Based Identity
- Secure API Development
- Swagger API Testing

---

## 📖 References

- Microsoft ASP.NET Core Documentation
- JWT Authentication Documentation
- Cognizant Deep Skilling Program

---

## ✅ Status

**Completed Successfully ✔**