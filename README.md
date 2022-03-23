# .NET Core API Built Using Dapper

## Project Overview

This API is built using four layers
- REST API Interface (Controllers)
- Business Logic Layer
- Data Access Layer
- Database

This project takes advantage of using Swagger UI for easy testing. Although it can be done by hitting end-points on postman as well.

## Technologies Used

- ASP .NET Core
- Microsoft SQL Server
- Dapper
- Swagger UI
- Postman
- Visual Studio 2022

## How to run / use

In order to run this project, just simply build the solution file. After that you should navigate over to RestAPI/appsettings.json and change the connection string to your local db. You can find the connection string by first connecting the microsoft sql server or any db to visual studio and getting the connection string from there. Once you have your db connected, ensure you have the proper table columns (see below). You can always modify this code to fix the database schemas you are working with.

Database columns
- ID
- DeveloperName
- DeveloperEmail
- Department


 
