# FAQ Assistant – ASP.NET Core (.NET 8)

A backend system for managing FAQs with search, categorization, tagging, and AI-generated draft answers using the OpenRouter API.

## Features

- CRUD operations for:
  - FAQs  
  - Categories  
  - Tags  
  - Users  
- Search & filtering support  
- Many-to-many tags per FAQ  
- AI draft answer generator (OpenRouter API)  
- SQL Server + EF Core Migrations  
- AutoMapper for clean mapping  
- Unit-test ready clean architecture  
- Swagger UI enabled  


## Requirements

- **Visual Studio 2022**
- **.NET 8 SDK**
- **SQL Server** (LocalDB or full)
- **OpenRouter API Key** (for AI endpoint)


## Project Setup

- git clone https://github.com/saikalyankadali/FaqAssistant.git
- cd FaqAssistant
- Configure appsettings.json as "DefaultConnection": "Server=.;Database=FaqAssistantDb;Trusted_Connection=True;TrustServerCertificate=True;"
- Replace YOUR_KEY_HERE with your real OpenRouter API Key. in appsettings.json

## Apply EF Core Migrations

- Using Visual Studio Package Manager Console: Update-Database
- Or using .NET CLI: dotnet ef database update
- This will create the database FaqAssistantDb with all tables.

## Run the API

- dotnet run
