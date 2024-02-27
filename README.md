# Sneaker Collection API

## Overview
This project is a simple web application that serves as a CRUD (Create, Read, Update, Delete) API for managing sneakers in a collection. The application is developed using .NET C# and SQL Server, adhering to Clean Architecture principles and DDD methodologies.

## User Story
As a sneaker enthusiast and collection owner, I want to manage my sneakers collection efficiently. I need a system where I can add new sneakers, update existing ones, remove sneakers that I don't have anymore, and retrieve information about all the sneakers in my collection. Additionally, I need a secure way to manage user authentication for accessing the system.

## How to Run

To run the application locally using Docker, follow these steps:

1. Clone the repository to your local machine:
```bash
git clone https://github.com/renanfssilva/SneakerCollection.git
cd SneakerCollection
```
2. Get the docker image for the database:
```bash
docker pull mcr.microsoft.com/mssql/server:2022-latest
```					
3. Start the docker container
```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password123" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```
4. Create a `secrets.json` with the following content:
```json
{
  "JwtSettings:Secret": "this is my custom Secret key for authentication",
  "ConnectionStrings:DefaultConnection": "Server=localhost;Database=SneakerCollection;User Id=SA;Password=Password123;TrustServerCertificate=true"
}
```
5. Run the migrations:
```bash
dotnet ef database update --project .\src\SneakerCollection.API
```
6. Build the solution:
```bash
dotnet build
```
7. Run the solution:
```bash
dotnet run --project .\src\SneakerCollection.API
```
8. Open the [Swagger UI](http://localhost:5067/swagger/index.html) in your browser.
9. Use the Swagger UI to test the API.
10. Run the command below to run the tests:
```bash
dotnet test
```
