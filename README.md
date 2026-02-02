
## <img src="https://www.quavered.com/wp-content/uploads/2020/01/00_QuaverEd_Logo_-e1585238605757.png" alt="logo"/>
## Popular C# Repositories on GitHub

## Overview
This application retrieves the top 100 most-starred public C# repositories from the GitHub API, stores them in a relational database, and provides a web interface for viewing the repository list and detailed information for each repository.

The project is implemented as a full-stack application with an ASP.NET Core backend and a Vue.js frontend.

---

## Architecture

### Backend
The backend is built using **ASP.NET Core** with **Entity Framework Core** and **MySQL**.

Key responsibilities:
- Retrieve repository data from the GitHub Search API
- Persist repository data to the database
- Expose REST endpoints for frontend consumption

Architecture choices:
- **Controller–Service pattern** is used to separate HTTP concerns from business logic
- **Entity Framework Core** is used for data access and schema management
- **DTOs** are used to separate external API models (GitHub) from internal database entities
- Repository synchronization uses an **upsert strategy** (insert or update) to keep the database in sync efficiently

Main endpoints:
- `POST /Repositories/sync` – Fetches and synchronizes the top 100 C# repositories from GitHub
- `GET /Repositories` – Returns all stored repositories
- `GET /Repositories/{id}` – Returns details for a single repository

GitHub authentication is optional and can be configured via a personal access token to increase API rate limits.

---

### Frontend
The frontend is built using **Vue 3** with **Vite** and **Bootstrap 5**.

Key responsibilities:
- Display a list of repositories
- Allow users to navigate to a detailed view for each repository

Architecture choices:
- **Vue Router** is used for client-side routing
- Views are separated into list and detail pages
- The frontend communicates with the backend using REST APIs
- During development, API requests are proxied through Vite to avoid CORS issues

Routes:
- `/` – Home page
- `/repositories` – Repository list view
- `/repositories/:id` – Repository detail view

---

## Data Flow
1. The backend sync endpoint calls the GitHub API and stores repository data in the database.
2. The frontend requests repository data from the backend using REST endpoints.
3. The list view fetches all repositories.
4. The detail view fetches data for a single repository by ID.
5. Data is rendered using Bootstrap components for a simple, responsive UI.

---

## Installation and Running Locally

### Prerequisites
- .NET 8 SDK
- Node.js (LTS recommended)
- MySQL (local instance)
- Git

### Backend Setup
1. Clone the repository.
2. Configure the database connection string in `appsettings.json`.
3. (Optional) Configure a GitHub personal access token using .NET user secrets:
   dotnet user-secrets set "GitHub:Token" "<your-token>"
4. Apply database migrations:
    dotnet ef database update
5. Run the backend:
    dotnet run

### Frontend Setup
1. Navigate to the client directory
2. Install dependencies:
    npm install
3. Run the development server:
    npm run dev
### The frontend is served via a development proxy when running through the backend, or directly via the Vite dev server.


