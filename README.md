# Blog.Web - ASP.NET 8 MVC Blog with Razor

Welcome to Blog.Web, an open-source ASP.NET MVC project that serves as a fully-featured Blog using Razor Pages. This project is built on the latest ASP.NET version 8, providing a modern and efficient platform for developing web applications.

## Table of Contents
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Database Setup](#database-setup)
- [Contributing](#contributing)
- [License](#license)

## Features

- **Razor Pages**: Utilizing the power of Razor syntax, Blog.Web offers a dynamic and expressive way to create your blog pages.
  
- **ASP.NET MVC**: Built on the robust MVC architecture, this project provides a clean separation of concerns and extensibility.

- **Database Integration**: Seamlessly connect your blog to a SQL Server database to store and manage posts and user data.

- **Responsive Design**: The project is designed to be responsive with Bootstrap, ensuring a consistent and user-friendly experience across various devices.

- **Customization**: Easily customize the appearance and behavior of your blog to suit your preferences.

## Getting Started

### Prerequisites

Make sure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) version 8 or later.
- [Visual Studio](https://visualstudio.microsoft.com/) or any other code editor of your choice.

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/your-username/Blog.Web.git
    ```

2. Navigate to the project directory:

    ```bash
    cd Blog.Web
    ```

3. Build and run the application:

    ```bash
    dotnet build
    dotnet run
    ```

4. Open your web browser and visit `http://localhost:5000` to see your blog in action.

### Database Setup

This project uses SQL Server as the database. Follow these steps to set up your database:

1. Open the `appsettings.json` file in the project.

2. Locate the `"ConnectionStrings"` section and update the `"BlogDbConnectionString"` connection string with your SQL Server connection details.

   ```json
   "ConnectionStrings": {
     "BlogDbConnectionString": "Server=your-server;Database=your-database;User=your-username;Password=your-password;"
   }
