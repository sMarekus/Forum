# Forum

## Overview
The Forum project is a web-based application designed to provide a platform for user interactions through posts and discussions. It is built using a combination of technologies including Blazor WebAssembly, Entity Framework Core (EFC), and ASP.NET Core Web API.

## Key Features
- **User Authentication and Authorization:** Custom authentication and authorization logic to manage user access.
- **Post Creation and Management:** Users can create, view, and interact with posts.
- **Search Functionality:** Advanced search capabilities for posts and users.
- **Responsive Web Design:** A user-friendly interface that adapts to different screen sizes.

## Technologies
- **Blazor WebAssembly:** For building interactive web UIs using C# instead of JavaScript.
- **Entity Framework Core (EFC):** For database operations and object-relational mapping.
- **ASP.NET Core Web API:** For backend services and API development.

## Project Structure
- `Application`: Contains business logic and data access interfaces.
- `BlazorWASM`: The client-side application built with Blazor WebAssembly.
- `Domain`: Defines data transfer objects (DTOs) and models.
- `EfcDataAccess`: Implements data access using Entity Framework Core.
- `FileData`: Alternative data access implementation using file storage.
- `HttpClients`: Contains HTTP client implementations for API communication.
- `WebAPI`: ASP.NET Core Web API project for backend services.

## Getting Started
To run this project, you will need .NET SDK and an appropriate IDE like Visual Studio. Follow these steps:
1. Clone the repository.
2. Open the solution in your IDE.
3. Restore NuGet packages.
4. Run the `BlazorWASM` project for the frontend and `WebAPI` project for the backend.

## Contribution
Contributions to the project are welcome. Please follow the standard fork-and-pull request workflow.
