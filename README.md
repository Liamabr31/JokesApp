# JokesApp

This is a recreated beginner-friendly ASP.NET Core MVC jokes application based on the structure and features demonstrated in the video:

ASP.NET Core Crash Course - C# App in One Hour

The tutorial demonstrates MVC, Entity Framework, models, Razor forms, Bootstrap/CSS, CRUD operations and a joke search feature.

## Included

- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- Joke model
- Joke database context
- Home page
- Jokes list
- Create joke
- Edit joke
- Delete joke
- Joke details
- Search jokes
- `ShowSearchForm`
- Bootstrap-style Razor forms
- Automatic database creation
- Sample jokes

## Important

This recreation uses .NET 8 so it is easier to run on a current development environment. The original tutorial is older, so some project startup/package details differ from the video.

## Requirements

Install:

1. Visual Studio 2022 with ASP.NET and web development
2. .NET 8 SDK
3. SQL Server LocalDB or SQL Server

## Run

1. Extract the ZIP.
2. Open `JokesApp.sln` in Visual Studio.
3. Let Visual Studio restore NuGet packages.
4. Check `appsettings.json`.
5. Press F5 or Ctrl+F5.

The default connection string uses:

Server=(localdb)\\MSSQLLocalDB

If you use a normal SQL Server instance, change it to something like:

Server=localhost;Database=JokesAppDb;Trusted_Connection=True;TrustServerCertificate=True

The application calls `EnsureCreated()` when it starts and creates the database/table automatically.

## Main files

Models/Joke.cs
Data/ApplicationDbContext.cs
Data/DbInitializer.cs
Controllers/JokesController.cs
Views/Jokes/Index.cshtml
Views/Jokes/Create.cshtml
Views/Jokes/Edit.cshtml
Views/Jokes/Delete.cshtml
Views/Jokes/Details.cshtml
Views/Jokes/ShowSearchForm.cshtml

## The form from the screenshot

The recreated search page is:

Views/Jokes/ShowSearchForm.cshtml

It posts to:

ShowSearchResults

The CRUD create page is:

Views/Jokes/Create.cshtml

and follows the same Razor form pattern shown in the tutorial.

## If you want the form named ShowJokesForm

The screenshot you supplied contains:

<form asp-action="ShowSearchForm">

If your assignment specifically requires the action/page to be called `ShowJokesForm`, rename the action and form target consistently in `JokesController.cs` and the relevant `.cshtml` file.

## Notes

This project is intended as a learning/assignment starter and keeps the code straightforward rather than adding advanced architecture.
