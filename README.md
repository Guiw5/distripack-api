# Distripack API

A robust REST API built with .NET Core for managing distributors and packages. This API provides a scalable and maintainable solution for distribution management systems.

> **Note**: This is a completed project that served as a demonstration of clean architecture and best practices in .NET Core development. While the code is available for reference and learning purposes, it is no longer actively maintained.

## 🚀 Features

- Clean Architecture implementation
- Docker containerization support
- Heroku deployment ready
- Centralized exception handling
- Database migrations
- Controller/Services/Repositories
- RESTful API design
- Environment-based configuration

## 🛠️ Tech Stack

- .NET Core 2.1.12
- Entity Framework Core 2.1.11
- Docker 19.03
- Heroku
- SQL Server
- Swagger/OpenAPI 4.0.7
- AutoMapper 7.0.1
- JWT Authentication

## 📋 Prerequisites

- .NET Core SDK 2.1.12 or later
- Docker 19.03 (optional)
- SQL Server (recommended) or any Entity Framework Core compatible database
- Git 2.23.0 or later

## 🔧 Installation

1. Clone the repository:
```bash
git clone [REPOSITORY_URL]
```

2. Navigate to the project directory:
```bash
cd distripack-api
```

3. Copy the example configuration file:
```bash
cp appsettings.example.json appsettings.Development.json
```

4. Configure your database connection string in `appsettings.Development.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=distripack;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

5. Restore dependencies:
```bash
dotnet restore
```

6. Run database migrations:
```bash
dotnet ef database update
```

7. Run the project:
```bash
dotnet run
```

## 🔐 Environment Variables

The following environment variables are required:

- `ASPNETCORE_ENVIRONMENT`: Set to "Development" for local development
- `ConnectionStrings__DefaultConnection`: Database connection string
- `JWT__Secret`: Secret key for JWT token generation
- `JWT__Issuer`: JWT token issuer
- `JWT__Audience`: JWT token audience
- `JWT__ExpirationInMinutes`: Token expiration time in minutes

## 📝 API Examples

Here are some example API calls:

```bash
# Get all clients
curl -X GET https://localhost:5001/api/clients

# Get client by ID
curl -X GET https://localhost:5001/api/clients/1

# Create new client
curl -X POST https://localhost:5001/api/clients \
  -H "Content-Type: application/json" \
  -d '{"name": "John Doe", "email": "john@example.com"}'

# Get client transactions
curl -X GET https://localhost:5001/api/transactions/1
```

## 🐳 Docker Support

Build and run the application using Docker:

```bash
# Build the image
docker build -t distripack-api .

# Run the container
docker run -p 5000:80 -e ASPNETCORE_ENVIRONMENT=Development distripack-api
```

## 🌐 Heroku Deployment

The project is configured for Heroku deployment. Before deploying:

1. Create a Heroku account
2. Install Heroku CLI
3. Configure environment variables in Heroku dashboard
4. Deploy using Heroku CLI or GitHub integration

## 📁 Project Structure

```
distripack-api/
├── Controllers/    # API Controllers
├── Models/         # Data Models
├── Services/       # Business Logic
├── Persistence/    # Data Access Layer
├── Migrations/     # Database Migrations
├── Helper/         # Utility Classes
└── Properties/     # Project Properties
```

## 🔒 Security

- All sensitive credentials and configurations are managed through environment variables
- `appsettings.json` should never be committed to the repository
- JWT authentication implementation
- HTTPS enforcement in production
- Input validation and sanitization
- CORS policies configured
- Rate limiting implemented

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👥 Contributing

While this project is no longer actively maintained, we welcome:
- Bug reports
- Documentation improvements
- Code quality suggestions

Please note that feature requests or major changes may not be implemented as this is a completed project.

## 📞 Support

As this is a completed project, support is limited to:
- Documentation review
- Code review for learning purposes
- Bug reports

For any inquiries, please:
- Open an issue in the repository
- Contact wagner.guido.5@gmail.com
- Check the [documentation](docs/README.md)

## 🔍 API Documentation

Once the application is running, you can access the Swagger documentation at:
```
https://localhost:5001/swagger
```

The Swagger UI provides interactive documentation for all API endpoints, including:
- Request/response schemas
- Authentication requirements
- Example requests
- Try-it-out functionality

Note: Swagger is only available in Development environment.

## 🧪 Testing

Run the test suite:
```bash
dotnet test
```

## 📦 Dependencies

Key NuGet packages used in this project:
- Microsoft.EntityFrameworkCore (2.1.11)
- Microsoft.EntityFrameworkCore.SqlServer (2.1.11)
- Microsoft.EntityFrameworkCore.Tools (2.1.11)
- AutoMapper (7.0.1)
- AutoMapper.Extensions.Microsoft.DependencyInjection (5.0.1)
- Microsoft.VisualStudio.Web.CodeGeneration.Design (2.1.9)
- Microsoft.AspNetCore.App
- Swashbuckle.AspNetCore (4.0.7)

## 🎯 Project Status

This project was completed in 2019 and serves as a demonstration of:
- Clean Architecture principles
- .NET Core best practices
- RESTful API design
- Docker containerization
- CI/CD implementation
- Database management with Entity Framework Core
- Security best practices
- Testing methodologies

While the code is available for reference and learning purposes, it is no longer actively maintained or updated.
