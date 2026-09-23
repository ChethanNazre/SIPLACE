# SIPLACE Setup Report Generator

## Overview

SIPLACE Setup Report Generator is a Windows Forms application developed in C# for importing SIPLACE XML recipe files, storing recipe and setup data in SQL Server, and generating setup reports in Excel and PDF formats.

## Features

- Import one or more SIPLACE XML recipe files
- Parse recipe and setup information from XML
- Store recipe and setup data in SQL Server
- Support multiple XML imports
- Display imported recipes in the application
- Select a recipe for report generation
- Generate Excel setup reports
- Generate PDF setup reports
- Group setup records based on the required grouping criteria

## Technology

- C#
- .NET 8
- Windows Forms
- SQL Server Express
- Entity Framework Core
- LINQ to XML
- ClosedXML
- QuestPDF

## Application Workflow

```text
SIPLACE XML Files
       ↓
   XML Parsing
       ↓
Recipe and Setup Data
       ↓
    SQL Server
       ↓
 Recipe Selection
       ↓
 Report Generation
       ↓
 ┌──────────────┐
 │              │
Excel          PDF
Report         Report
```

## Database Setup

1. Install SQL Server Express and SQL Server Management Studio (SSMS), if required.
2. Open `CreateTables.sql` in SSMS.
3. Create the required SIPLACE database and tables using the SQL script.
4. Configure the application connection string for the SQL Server instance being used.
5. Execute the SQL script and verify that the required tables have been created.
6. Run the application and verify that it can connect to the database.

## How to Run from Source

1. Install the .NET 8 SDK.
2. Ensure SQL Server is available and the required database has been created.
3. Configure the SQL Server connection string used by the application.
4. Open the solution in Visual Studio or a compatible IDE.
5. Restore the NuGet packages.
6. Build the solution in Release configuration.
7. Run the application.
8. Import one or more SIPLACE XML recipe files.
9. Select an imported recipe.
10. Generate an Excel or PDF report.

## Running the Published Application

A self-contained Windows x64 build can be created using:

```bash
dotnet publish -c Release -r win-x64 --self-contained true
```

The published files are generated under:

```text
bin\Release\net8.0-windows\win-x64\publish
```

To run the published application, copy the complete contents of the `publish` folder to the target Windows system and launch the application executable.

The application still requires access to the configured SQL Server database.

## Report Generation

The application generates two report formats from the processed setup data.

### Excel

Excel reports are generated using **ClosedXML** and contain the recipe information and grouped setup details.

### PDF

PDF reports are generated using **QuestPDF** and contain the same recipe and setup information in a formatted, printable layout.

## Project Structure

```text
SIPLACE Setup Report Generator
│
├── Models
│   ├── Recipe.cs
│   └── SetupDetail.cs
│
├── Services
│   ├── XMLParser.cs
│   ├── ReportGenerator.cs
│   ├── ExcelExporter.cs
│   └── PdfExporter.cs
│
├── Data
│   └── SiplaceContext.cs
│
├── SQL
│   └── CreateTables.sql
│
├── MainForm.cs
├── MainForm.Designer.cs
├── Program.cs
└── SiplaceApp.csproj
```

## SQL Database

The application uses two main tables:

- **Recipes** — stores recipe header information.
- **SetupDetails** — stores setup detail information associated with a recipe.

The relationship between the tables is maintained using `RecipeId`.

## Documentation

The complete application documentation contains additional information about:

- Application structure
- System workflow
- XML parsing
- Database design
- Setup data grouping
- Report generation
- User interface
- Testing
- Deployment

## Project Deliverables

The submission includes:

- Visual Studio solution and source code
- SQL database script
- Windows x64 executable build
- Application documentation
