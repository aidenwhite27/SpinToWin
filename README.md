# SpinToWin

This is a web app designed after a casino kiosk game.

Disclaimer: This is not configured for production deployment, only for running in a local development environment.

Also, it was my first time using Blazor, EntityFramework, and creating an ASP.Net Core Web API so I apologize for any messes and misconfigurations.

This was built using .NET 9.0

# Overview

* Client/ => This is a Blazor WASM project
  
    *  Client/Pages/ => These are the UI views
 
* Model/ => These are the EntityFramework models (shared by frontend & backend)

    * Model/Migrations/ => Database migrations are here
 
* Server/ => This is an ASP.Net Core Web API project

    * Controllers/ => HTTP endpoints are defined by model here
 
    * Program.cs => Server setup and configurations
 
* Tests/ => These are unit tests for each model that should all be passing
  
* spintowin.db => This is a SQLite database file that contains a bit of data for testing

# Requirements

* .NET 9.0 SDK

* Blazor

* Entity Framework

* xUnit

* probably something else I'm forgetting

For more detailed information including versions of the above, see the .csproj files in each directory.


# Run

Start the API server and the Blazor server (no particular order)

`cd Server && dotnet run`

(in another shell from the base directory)

`cd Client && dotnet run`

If both start successfully, you should be able to access the app from [](http://localhost:5110/).

You can change the ports and http/https profiles in Server/Properties/launchsettings.json and Client/Properties/launchsettings.json

You may try accepting the dev certs, but I seemed to have no luck with that, so I just used http:

`dotnet dev-certs https --trust`

# Tests

If you're using VS Code or Visual Studio, you should be able to run all of unit tests and they should pass. They use an In-Memory database context separate from the SQLite context.

# Swagger

I seem to have messed up the Swagger auto generation, but it was working for me previously. If you can fix it, it may be pretty useful for playing with the data API.

---

That's all for now. Feel free to comment or contribute.
