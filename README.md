# Escolaris 5.0 - University Management System

[![.NET 8](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-brightgreen.svg)](https://docs.microsoft.com/aspnet/core)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2019+-orange.svg)](https://www.microsoft.com/sql-server)

A modern university management system built with ASP.NET Core 8.0 and Razor Pages, implementing Clean Architecture principles for academic program enrollment and management.

## ?? Features

### Core Functionality
- **Academic Program Management**: Create, edit, and manage academic programs
- **Category Organization**: Organize programs by categories
- **Student Enrollment System**: Handle student registrations with real-time validation
- **Transaction Tracking**: Complete audit trail of all enrollment activities
- **User Authentication**: Secure login system with ASP.NET Core Identity
- **Role-Based Authorization**: Different access levels for Secretary and Register roles

### User Interface
- **Responsive Design**: Bootstrap-powered responsive UI
- **Real-time Updates**: Dynamic content loading with jQuery/AJAX
- **Intuitive Navigation**: Clean, user-friendly interface
- **Multi-language Support**: Prepared for internationalization

## ??? Architecture

This project follows **Clean Architecture** principles with clear separation of concerns:

```
??? src/
?   ??? WebApp/                    # Presentation Layer (Razor Pages)
?   ??? UseCases/                  # Application Layer (Business Logic)
?   ??? CoreBusiness/              # Domain Layer (Entities)
?   ??? Plugins.DataStore.SQL/     # Infrastructure Layer (Data Access)
```

### Architecture Layers

- **?? Presentation Layer** (`WebApp`): ASP.NET Core Razor Pages with MVC controllers
- **?? Application Layer** (`UseCases`): Business use cases and interfaces
- **?? Domain Layer** (`CoreBusiness`): Core business entities and rules
- **??? Infrastructure Layer** (`Plugins.DataStore.SQL`): Entity Framework Core data access

## ?? Technologies

- **Framework**: .NET 8.0
- **Web Framework**: ASP.NET Core 8.0 with Razor Pages
- **Database**: SQL Server with Entity Framework Core 8.0
- **Authentication**: ASP.NET Core Identity
- **UI Framework**: Bootstrap 5
- **JavaScript**: jQuery for dynamic interactions
- **Architecture Pattern**: Clean Architecture
- **Dependency Injection**: Built-in .NET DI Container

## ?? Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server 2019+](https://www.microsoft.com/sql-server) or SQL Server Express
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

## ? Quick Start

### 1. Clone the Repository
```bash
git clone https://github.com/hectorlaris/EscolarisOnWeb.git
cd EscolarisOnWeb
```

### 2. Configure Database Connection
Update the connection strings in `src/WebApp/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "EscolarisMVC": "Server=localhost;Database=EscolarisDB;Trusted_Connection=true;TrustServerCertificate=true;",
    "IdentifyMVC": "Server=localhost;Database=EscolarisIdentityDB;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

### 3. Apply Database Migrations
```bash
cd src/WebApp
dotnet ef database update
```

### 4. Run the Application
```bash
dotnet run
```

Navigate to `https://localhost:5001` or `http://localhost:5000`

## ??? Database Schema

### Core Entities

- **Categories**: Academic program categories
- **AcadPrograms**: Academic programs with pricing and quotas
- **Transactions**: Enrollment transaction history
- **Identity Tables**: User authentication and authorization

### Key Relationships
- Categories ? AcadPrograms (One-to-Many)
- AcadPrograms ? Transactions (One-to-Many)

## ?? Security & Authorization

### Authentication
- ASP.NET Core Identity integration
- Email confirmation requirement
- Secure password policies

### Authorization Policies
- **Secretary Policy**: Administrative access to manage categories and programs
- **Register Policy**: Access to enrollment and transaction management

## ?? Usage

### For Administrators (Secretary Role)
1. **Manage Categories**: Create and organize program categories
2. **Manage Programs**: Add academic programs with quotas and pricing
3. **View Reports**: Monitor enrollment statistics

### For Staff (Register Role)
1. **Process Enrollments**: Handle student registrations
2. **View Transactions**: Track daily enrollment activities
3. **Generate Reports**: Export enrollment data

### Enrollment Workflow
1. Select academic category
2. Choose specific program
3. Enter enrollment quantity
4. Submit registration
5. View confirmation and transaction record

## ??? Development

### Project Structure
```
EscolarisOnWeb/
??? src/
?   ??? WebApp/                 # Main web application
?   ?   ??? Controllers/        # MVC Controllers
?   ?   ??? Views/             # Razor Views
?   ?   ??? ViewModels/        # View Models
?   ?   ??? Data/              # Identity DbContext
?   ?   ??? wwwroot/           # Static files
?   ??? CoreBusiness/          # Domain entities
?   ??? UseCases/              # Business logic
?   ??? Plugins.DataStore.SQL/ # Data access layer
??? EscolarisOnWeb/            # Additional project (if applicable)
??? .azure/                    # Azure deployment templates
```

### Running Tests
```bash
dotnet test
```

### Building for Production
```bash
dotnet build --configuration Release
dotnet publish --configuration Release
```

## ?? Deployment

### Azure App Service
The project includes Azure Bicep templates for easy deployment:

```bash
# Deploy to Azure using Bicep templates
az deployment group create --resource-group myResourceGroup --template-file .azure/bicep/webapp.bicep
```

### Docker Support
```dockerfile
# Build and run with Docker
docker build -t escolaris-web .
docker run -p 8080:80 escolaris-web
```

## ?? Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Development Guidelines
- Follow Clean Architecture principles
- Write unit tests for business logic
- Use meaningful commit messages
- Update documentation for new features

## ?? License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## ????? Author

**Hector Laris**
- GitHub: [@hectorlaris](https://github.com/hectorlaris)
- Email: [your.email@example.com]

## ?? Acknowledgments

- Built with [ASP.NET Core](https://docs.microsoft.com/aspnet/core)
- UI components from [Bootstrap](https://getbootstrap.com/)
- Clean Architecture pattern inspired by [Uncle Bob](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

## ?? Support

For support and questions:
- Open an issue on [GitHub Issues](https://github.com/hectorlaris/EscolarisOnWeb/issues)
- Check the [Wiki](https://github.com/hectorlaris/EscolarisOnWeb/wiki) for detailed documentation

---

**Made with ?? for educational institutions**