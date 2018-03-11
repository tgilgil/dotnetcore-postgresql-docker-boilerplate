![alt text](https://github.com/tgilgil/dotnetcore-postgres-docker-boilerplate/blob/master/tech.png ".NET Core + Docker + Postgres")

# dotnetcore-postgresql-docker-boilerplate
💠 .NET Core project built on top of Docker with Entity Framework (with PostgreSQL instead of MSSQL) boilerplate. Ready to launch. 

# Migrations

Create a new migration
`dotnet ef migrations add add-ev-stat`

Update to latest migration
`dotnet ef migrations update`

# Things left to do
- Heroku setup for out of the box deployment
- CI setup?
- Unit tests
- Basic seeding
- Clean up db access
