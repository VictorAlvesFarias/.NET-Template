<h1>.NET-Template</h1>

## Overview

The .NET Template is a robust and scalable foundation for building modern ASP.NET Core Web APIs, leveraging Clean Architecture principles for efficient separation of concerns and maintainability. Designed with a modular layered architecture, it ensures reusability and easy scalability, while its flexible structure adapts to various project needs. With a focus on performance optimization and security, it enables smooth API development and authentication handling, making it an ideal starting point for developing robust and maintainable .NET applications.

## Table of Contents

- [Overview](#overview)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Configuration](#configuration)
  - [Database Setup](#database-setup)
  - [Running the Application](#running-the-application)
- [Main Features](#main-features)
  - [Architecture](#architecture)
    - [Clean Architecture Layers](#clean-architecture-layers)
  - [Authentication & Authorization](#authentication--authorization)
    - [JWT Configuration](#jwt-configuration)
    - [Identity Management](#identity-management)
  - [API Endpoints](#api-endpoints)
    - [User Management](#user-management)
  - [Database Management](#database-management)
    - [Entity Framework Core](#entity-framework-core)
    - [Migrations](#migrations)
  - [Dependency Injection](#dependency-injection)
    - [Service Registration](#service-registration)
  - [Response Handling](#response-handling)
    - [Standardized Responses](#standardized-responses)

## Project Structure

```
.NET-Template/
├── Api/                          # Presentation Layer
│   ├── Controllers/              # API Controllers
│   │   └── UserController.cs     # User management endpoints
│   ├── Extensions/               # Controller extensions
│   │   └── ControllerBaseExtensions.cs
│   ├── Ioc/                      # Dependency Injection setup
│   │   └── NativeInjectorConfig.cs
│   ├── Setups/                   # Application configurations
│   │   ├── AuthenticationSetup.cs
│   │   └── SwaggerSetup.cs
│   ├── appsettings.json          # Application configuration
│   ├── appsettings.Development.json
│   ├── Api.csproj
│   └── Program.cs                # Application entry point
├── Application/                  # Application Layer
│   ├── Configuration/            # Application configurations
│   │   └── JwtOptions.cs
│   ├── Dtos/                     # Data Transfer Objects
│   │   ├── Default/              # Base response DTOs
│   │   └── User/                 # User-specific DTOs
│   ├── Extensions/               # Application extensions
│   ├── Services/                 # Application services
│   │   └── Identity/
│   │       ├── IdentityService.cs
│   │       └── IIdentityService.cs
│   └── Application.csproj
├── Domain/                       # Domain Layer
│   ├── Entitites/                # Domain entities
│   │   ├── ApplicationUser.cs
│   │   ├── BaseEntity.cs
│   │   ├── BaseEntityForUserRelation.cs
│   │   └── BaseEntityIdentity.cs
│   └── Domain.csproj
├── Infrastructure/               # Infrastructure Layer
│   ├── Context/                  # Database context
│   │   └── ApplicationContext.cs
│   ├── Factories/                # Database factories
│   │   └── DbContextFactory/
│   ├── Migrations/               # Entity Framework migrations
│   ├── Repositories/             # Data access layer
│   │   └── BaseRepository/
│   └── Infrastructure.csproj
└── .NET-Template.sln             # Solution file
```

## Getting Started

### Prerequisites

Before getting started with .NET Template, ensure your development environment meets the following requirements:

- **.NET 6.0 SDK:** https://dotnet.microsoft.com/download/dotnet/6.0
- **SQL Server:** Local or remote SQL Server instance
- **Visual Studio 2022** or **Visual Studio Code** with C# extension

### Installation

Install .NET Template using one of the following methods:

**Clone from repository:**
```sh
git clone https://github.com/your-repo/.NET-Template
cd .NET-Template
```

### Configuration

1. **Database Connection String**
   
   Update the connection string in `Api/appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=your-server;Database=your-database;TrustServerCertificate=True;User Id=your-user;Password=your-password;"
     }
   }
   ```

2. **JWT Configuration**
   
   Configure JWT settings in `Api/appsettings.json`:
   ```json
   {
     "JwtOptions": {
       "Issuer": "https://your-domain.com",
       "Audience": "YourAudience",
       "SecurityKey": "your-secret-key-at-least-32-characters-long",
       "AccessTokenExpiration": 3600
     }
   }
   ```

### Database Setup

1. **Create Database**
   ```sh
   dotnet ef database update --project Infrastructure --startup-project Api
   ```

2. **Generate New Migration** (when entity changes)
   ```sh
   dotnet ef migrations add MigrationName --project Infrastructure --startup-project Api
   ```

### Running the Application

Run the application using the following commands:

```sh
# Navigate to API project
cd Api

# Restore packages
dotnet restore

# Run in development mode
dotnet run
```

Or run from solution root:
```sh
dotnet run --project Api
```

The API will be available at:
- **API:** https://localhost:7001
- **Swagger UI:** https://localhost:7001/swagger

## Main Features

### Architecture

The project follows Clean Architecture principles with clear separation of concerns across four main layers:

#### Clean Architecture Layers

1. **Api (Presentation Layer)**
   - Controllers handling HTTP requests
   - API configurations and middleware setup
   - Dependency injection configuration
   - Swagger documentation

2. **Application (Application Layer)**
   - Business logic and use cases
   - DTOs for data transfer
   - Service interfaces and implementations
   - Application-specific configurations

3. **Domain (Domain Layer)**
   - Core business entities
   - Domain logic and rules
   - Base entity classes
   - Identity management entities

4. **Infrastructure (Infrastructure Layer)**
   - Data access implementation
   - Database context and migrations
   - Repository implementations
   - External service integrations

### Authentication & Authorization

#### JWT Configuration

The application uses JWT (JSON Web Tokens) for authentication with configurable options:

```csharp
public class JwtOptions {
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int AccessTokenExpiration { get; set; }
    public string SecurityKey { get; set; }
    public SigningCredentials SigningCredentials { get; set; }
}
```

#### Identity Management

Built-in ASP.NET Core Identity for user management with:
- User registration and authentication
- Password management
- Email and username validation
- Account deletion and updates

### API Endpoints

#### User Management

The `UserController` provides comprehensive user management endpoints:

- **POST /create-user** - Register new user
- **POST /sign-in** - User authentication
- **DELETE /delete-account** - Delete user account (requires authorization)
- **PUT /update-account** - Update user information (requires authorization)
- **POST /validade-email** - Validate email availability
- **POST /validate-username** - Validate username availability
- **POST /change-password** - Change user password (requires authorization)

### Database Management

#### Entity Framework Core

The project uses Entity Framework Core with SQL Server for data persistence:

- **ApplicationContext:** Main database context
- **BaseRepository:** Generic repository pattern implementation
- **Migrations:** Database schema versioning

#### Migrations

Manage database schema changes:

```sh
# Create new migration
dotnet ef migrations add MigrationName --project Infrastructure --startup-project Api

# Update database
dotnet ef database update --project Infrastructure --startup-project Api

# Remove last migration
dotnet ef migrations remove --project Infrastructure --startup-project Api
```

### Dependency Injection

#### Service Registration

Services are registered in `NativeInjectorConfig.cs` following dependency injection best practices:

```csharp
public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
{
    // Register application services
    services.AddScoped<IIdentityService, IdentityService>();
    
    // Register repositories
    services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
}
```

### Service Response Patterns

Services should return standardized response objects. Here's how to implement them:

**Success Response Example:**
```csharp
public async Task<BaseResponse<LoginUserResponse>> LoginAsync(LoginUserRequest request)
{
    var response = new BaseResponse<LoginUserResponse>();
    
    // Business logic here
    var user = await _userManager.FindByEmailAsync(request.Email);
    if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
    {
        response.Success = true;
        response.Data = new LoginUserResponse 
        { 
            Token = GenerateJwtToken(user),
            UserId = user.Id 
        };
        return response;
    }
    
    response.AddError(new ErrorMessage("Invalid email or password", 401));
    return response;
}
```

**Error Response Example:**
```csharp
public async Task<DefaultResponse> ValidateEmailAsync(string email)
{
    var response = new DefaultResponse();
    
    if (string.IsNullOrEmpty(email))
    {
        response.AddError(new ErrorMessage("Email is required", 400, "EMAIL_REQUIRED"));
        return response;
    }
    
    var existingUser = await _userManager.FindByEmailAsync(email);
    if (existingUser != null)
    {
        response.AddError(new ErrorMessage("Email already exists", 400, "EMAIL_EXISTS"));
        return response;
    }
    
    response.Success = true;
    return response;
}
```

**Exception Handling Example:**
```csharp
public async Task<DefaultResponse> CreateUserAsync(CreateUserRequest request)
{
    var response = new DefaultResponse();
    
    try
    {
        // Business logic that might throw exceptions
        var user = new ApplicationUser { UserName = request.Username, Email = request.Email };
        var result = await _userManager.CreateAsync(user, request.Password);
        
        if (result.Succeeded)
        {
            response.Success = true;
            return response;
        }
        
        foreach (var error in result.Errors)
        {
            response.AddError(new ErrorMessage(error.Description, 400));
        }
    }
    catch (Exception ex)
    {
        response.AddException(new ErrorMessage("An error occurred while creating the user", 500));
        // Log the actual exception details
    }
    
    return response;
}
```

### Response Handling

#### Standardized Responses

The application implements a comprehensive standardized response system for consistent API responses across all endpoints:

**Response Classes Hierarchy:**
- **DataResponse:** Base class containing error handling and success status
- **BaseResponse<T>:** Generic typed responses with data payload
- **DefaultResponse:** Simple success/error responses without data
- **FileResponse:** Specialized responses for file downloads

**Response Structure:**
```json
{
  "success": true,
  "data": { /* response data */ },
  "errors": [],
  "exceptions": []
}
```

**Error Response Structure:**
```json
{
  "success": false,
  "data": null,
  "errors": [
    {
      "message": "Validation error message",
      "code": "VALIDATION_ERROR",
      "statusCode": 400
    }
  ],
  "exceptions": [
    {
      "message": "Internal server error details",
      "code": "INTERNAL_ERROR",
      "statusCode": 500
    }
  ]
}
```

#### Controller Extensions

The `ControllerBaseExtensions` provides standardized response methods for controllers:

**Result<T> Method:**
```csharp
public static ActionResult<BaseResponse<T>> Result<T>(this ControllerBase controller, BaseResponse<T> result)
```
- Automatically handles success responses (200 OK)
- Maps error responses to appropriate HTTP status codes
- Provides exception handling with internal server error responses

**DefaultResult Method:**
```csharp
public static ActionResult<DefaultResponse> DefaultResult(this ControllerBase controller, DefaultResponse result)
```
- Handles simple success/error responses without data payload
- Same error handling and status code mapping as Result<T>

**Usage Example:**
```csharp
[HttpPost("/sign-in")]
public async Task<ActionResult<BaseResponse<LoginUserResponse>>> LoginUser([FromBody] LoginUserRequest loginData)
{
    var result = await _identityService.LoginAsync(loginData);
    return this.Result<LoginUserResponse>(result);
}
```

#### Error Handling System

**ErrorMessage Class:**
```csharp
public class ErrorMessage
{
    public string Message { get; set; }
    public string Code { get; set; }
    public int StatusCode { get; set; } = StatusCodes.Status400BadRequest;
}
```

**Error Management Methods:**
- `AddError(ErrorMessage error)` - Add single error
- `AddErrors(List<ErrorMessage> errors)` - Add multiple errors
- `AddException(ErrorMessage error)` - Add exception (automatically sets Success = false)
- `AddExceptions(List<ErrorMessage> errors)` - Add multiple exceptions

**HTTP Status Code Mapping:**
- **200 OK:** Successful operations
- **400 Bad Request:** Validation errors, invalid input
- **401 Unauthorized:** Authentication required
- **403 Forbidden:** Authorization denied
- **404 Not Found:** Resource not found
- **500 Internal Server Error:** Server exceptions

### Additional Extensions

The template includes several utility extensions to enhance development productivity:

#### String Extensions

**Document Formatting:**
```csharp
// Format CPF/CNPJ
string cpf = "12345678901".ToDocument("br"); // Returns: "12.345.678-90"
string cnpj = "12345678000199".ToDocument("br"); // Returns: "12.345.678/0001-99"
```

**Phone Number Formatting:**
```csharp
// Format Brazilian phone numbers
string phone1 = "11987654321".ToPhone("br"); // Returns: "(11) 98765-4321"
string phone2 = "1187654321".ToPhone("br"); // Returns: "(11) 8765-4321"
```

#### Query Extensions

**Pagination Support:**
```csharp
public static IQueryable<T> Pagination<T>(this IQueryable<T> query, BaseGetRequest baseParams)
```

**Usage Example:**
```csharp
var users = _context.Users
    .Where(u => u.IsActive)
    .Pagination(new BaseGetRequest { Page = 1, PageSize = 10 });
```

**BaseGetRequest Properties:**
- `Page`: Current page number (1-based)
- `PageSize`: Number of items per page
- `SearchInput`: Optional search term

#### Database Transaction Extensions

**Simplified Transaction Management:**
```csharp
// Commit and dispose in one call
context.CommitDispose();

// Rollback and dispose in one call
context.RollbackDispose();
```

**Usage Example:**
```csharp
using var transaction = await _context.Database.BeginTransactionAsync();
try
{
    // Database operations
    await _context.SaveChangesAsync();
    transaction.CommitDispose();
}
catch
{
    transaction.RollbackDispose();
    throw;
}
```

## Development Guidelines

### Adding New Features

1. **Create Domain Entity** in `Domain/Entities/`
2. **Add DTOs** in `Application/Dtos/`
3. **Implement Service** in `Application/Services/`
4. **Create Repository** in `Infrastructure/Repositories/`
5. **Add Controller** in `Api/Controllers/`
6. **Register Services** in `NativeInjectorConfig.cs`

### Code Organization

- Follow Clean Architecture principles
- Use dependency injection for loose coupling
- Implement repository pattern for data access
- Use DTOs for data transfer
- Follow C# naming conventions
- Add XML documentation for public APIs

### Testing

The template is designed to support unit testing and integration testing:

```sh
# Run tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"
```

## Deployment

### Production Configuration

1. Update connection strings for production database
2. Configure proper JWT security keys
3. Set up HTTPS certificates
4. Configure logging for production environment
5. Set up proper CORS policies

### Docker Support

The project can be containerized using Docker:

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api/Api.csproj", "Api/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "Api/Api.csproj"
COPY . .
WORKDIR "/src/Api"
RUN dotnet build "Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
```

## License

This project is licensed under the MIT License - see the LICENSE file for details. 
