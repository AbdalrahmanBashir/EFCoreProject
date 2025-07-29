# Pharmacy Management System API

A comprehensive REST API for managing pharmacy operations, prescriptions, and pharmaceutical company relationships built with ASP.NET Core 8 and Entity Framework Core.

## Project Overview

This Pharmacy Management System API provides a robust backend solution for managing pharmacy operations including prescription tracking, drug inventory, doctor and patient management, and pharmaceutical company contracts. The system is designed with a clean architecture pattern using database-first approach with PostgreSQL and deployed on Azure.

## Architecture

The project follows a clean architecture pattern with the following layers:

- **EFCoreProject.API**: REST API controllers and application configuration
- **EFCoreProject.Domain**: Business models, DTOs, and repository contracts
- **EFCoreProject.Infrastructure**: Data access layer with Entity Framework Core and PostgreSQL
- **EFCoreProject.API.UnitTests**: Unit tests for API controllers

## Database Schema

The system uses a normalized SQL schema with the following core entities:

### Core Entities
- **Pharmacy**: Manages pharmacy information (name, address, phone)
- **Doctor**: Healthcare providers with specialties and experience
- **Patient**: Individuals receiving prescriptions
- **Drug**: Pharmaceutical products with formulas and company associations
- **Prescription**: Medical prescriptions linking doctors, patients, and drugs
- **PharmaceuticalCompany**: Drug manufacturers
- **Contract**: Agreements between pharmacies and pharmaceutical companies
- **Sale**: Transaction records for drug sales
- **Supervisor**: Contract oversight personnel

### Key Relationships
- Doctors can prescribe multiple drugs to patients
- Pharmacies have contracts with pharmaceutical companies
- Drugs are manufactured by pharmaceutical companies
- Sales track pharmacy transactions

## Features

### Pharmacy Management
- CRUD operations for pharmacy entities
- Search pharmacies by name, address, or condition
- Retrieve pharmacy contracts and sales data
- Top pharmacies by sales performance
- Total sales calculation per pharmacy

### Doctor Management
- Complete doctor profile management
- Specialty and experience tracking
- Prescription history

### Pharmaceutical Company Operations
- Company profile management
- Contract management with pharmacies
- Drug portfolio tracking

### Prescription System
- Prescription creation and management
- Doctor-patient-drug relationships
- Quantity and date tracking

## Technology Stack

- **Framework**: ASP.NET Core 8.0
- **Database**: PostgreSQL with Entity Framework Core
- **ORM**: Entity Framework Core (Database-First approach)
- **Documentation**: Swagger/OpenAPI
- **Cloud Platform**: Azure (deployment and database)
- **CI/CD**: GitHub Actions
- **API Testing**: Postman integration

## Prerequisites

- .NET 8.0 SDK
- PostgreSQL Database
- Visual Studio 2022 or VS Code
- Git

## Installation & Setup

### 1. Clone the Repository
```bash
git clone https://github.com/AbdalrahmanBashir/EFCoreProject.git
cd EFCoreProject
```

### 2. Database Setup
1. Install PostgreSQL
2. Create a database named `PharmacyPrescriptionManagementSystem`
3. Update connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "PostgreSQLConnection": "Host=localhost;Database=PharmacyPrescriptionManagementSystem;Username=your_username;Password=your_password"
  }
}
```

### 3. Build and Run
```bash
# Restore packages
dotnet restore

# Build the solution
dotnet build

# Run the API
cd EFCoreProject.API
dotnet run
```

### 4. Access the API
- API Base URL: `https://localhost:7001` or `http://localhost:5000`
- Swagger Documentation: `https://localhost:7001/swagger`

## API Endpoints

### Pharmacy Endpoints
```
GET    /api/Pharmacy                    # Get all pharmacies
GET    /api/Pharmacy/{pharmacyId}       # Get pharmacy by ID
POST   /api/Pharmacy                    # Create new pharmacy
PUT    /api/Pharmacy/{pharmacyId}       # Update pharmacy
DELETE /api/Pharmacy/{pharmacyId}       # Delete pharmacy
GET    /api/Pharmacy/search             # Search pharmacies
GET    /api/Pharmacy/searchByAddress    # Search by address
GET    /api/Pharmacy/searchByName       # Search by condition
GET    /api/Pharmacy/{pharmacyId}/contracts  # Get pharmacy contracts
GET    /api/Pharmacy/{pharmacyId}/sales      # Get pharmacy sales
GET    /api/Pharmacy/top/{topCount}     # Get top pharmacies by sales
GET    /api/Pharmacy/{pharmacyId}/totalSales # Get total sales
```

### Doctor Endpoints
```
GET    /api/Doctor                      # Get all doctors
GET    /api/Doctor/{doctorId}           # Get doctor by ID
POST   /api/Doctor                      # Create new doctor
PUT    /api/Doctor/{doctorId}           # Update doctor
DELETE /api/Doctor/{doctorId}           # Delete doctor
```

### Pharmaceutical Company Endpoints
```
GET    /api/PharmaceuticalCompany                    # Get all companies
GET    /api/PharmaceuticalCompany/{companyId}       # Get company by ID
POST   /api/PharmaceuticalCompany                    # Create new company
PUT    /api/PharmaceuticalCompany/{companyId}       # Update company
DELETE /api/PharmaceuticalCompany/{companyId}       # Delete company
GET    /api/PharmaceuticalCompany/Contracts/{companyName} # Get company contracts
```


### API Testing with Postman
Import the provided HTTP file (`EFCoreProject.API.http`) into Postman for pre-configured API requests.


## Documentation

The API documentation is automatically generated using Swagger/OpenAPI and is available at:
- Development: `https://localhost:7001/swagger`
- Production: `{base-url}/swagger`
- Pomstman: `https://documenter.getpostman.com/view/14481454/2sA35G21xj`

## Deployment

### Azure Deployment
The application is configured for Azure deployment with:
- Azure Database for PostgreSQL
- Azure App Service for hosting
- GitHub Actions for CI/CD pipeline

### Environment Configuration
```json
{
  "ConnectionStrings": {
    "PostgreSQLConnection": "Azure PostgreSQL Connection String"
  }
}
```

## Performance Optimizations

- Entity Framework Core query optimization
- Normalized database schema for efficient queries
- Async operations for better scalability
- Connection pooling for database efficiency

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests for new functionality
5. Submit a pull request

## License

This project is licensed under the MIT License.