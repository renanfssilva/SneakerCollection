# SneakerCollection
How to run the project:
1. Clone the repository
1. Run `docker pull mcr.microsoft.com/mssql/server:2022-latest`					
1. Run `docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password123" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest`
1. Create a `secrets.json` with the following content:
```json
{
  "JwtSettings:Secret": "this is my custom Secret key for authentication",
  "ConnectionStrings:DefaultConnection": "Server=localhost;Database=SneakerCollection;User Id=SA;Password=Password123;TrustServerCertificate=true"
}
```
1. Run `dotnet ef database update --project .\src\SneakerCollection.API`					
1. Build the solution `dotnet build`
1. Run `dotnet run --project .\src\SneakerCollection.API`														
1. Open `http://localhost:5067/swagger/index.html` in your browser`
1. Use the swagger UI to test the API
1. Run `dotnet test` to run the tests