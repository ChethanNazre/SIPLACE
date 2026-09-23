# SIPLACE Setup Report Generator

## Overview
SIPLACE Setup Report Generator is a Windows Forms application for importing SIPLACE XML recipes, storing recipe and setup data in SQL Server, and generating Excel and PDF reports.

## Features
- Import SIPLACE XML recipes
- Store recipe and setup data in SQL Server
- Support multiple XML imports
- Display imported recipes
- Generate Excel reports
- Generate PDF reports

## Technology
- C#
- .NET 8
- Windows Forms
- SQL Server Express
- Entity Framework Core
- LINQ to XML
- ClosedXML
- QuestPDF

## Database Setup
1. Install SQL Server Express and SQL Server Management Studio (SSMS), if they are not already installed.
2. Open `CreateTables.sql` in SSMS.
3. Update the script or application connection string with the appropriate SQL Server instance and database settings.
4. Execute the script to create the required database tables.
5. Verify that the application connection string points to the configured SQL Server database.

## How to Run
1. Install the .NET 8 SDK or runtime required by the application.
2. Configure the SQL Server connection string in the application settings.
3. Open the solution in Visual Studio 2022 or a compatible IDE.
4. Restore NuGet packages and build the solution.
5. Run the application.
6. Import one or more SIPLACE XML recipe files and use the reporting features to generate Excel or PDF reports.

## Report Generation
The application reads imported recipe and setup data from SQL Server and uses it to generate reports:

- **Excel reports:** Generated with ClosedXML and suitable for further analysis and editing.
- **PDF reports:** Generated with QuestPDF for formatted, printable output.

## Project Structure
- `CreateTables.sql` — SQL script for creating the application database tables.
- `*.sln` — Visual Studio solution file.
- Application project folders — Windows Forms UI, XML import logic, data models, database access, and report-generation functionality.
- `README.md` — Project setup and usage documentation.

## Documentation
See the project documentation and source code for additional details about configuration, XML formats, database entities, and report layouts.
