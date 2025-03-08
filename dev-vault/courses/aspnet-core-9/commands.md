# List installed .NET SDK versions
dotnet --list-sdks

# Create a global.json specifying a particular SDK version
dotnet new globaljson --sdk-version 9.0.103 --force

# Create a new solution
dotnet new sln --name CatalogoNet

# Create class library projects and a Web API project
dotnet new classlib -o src/Catalogo.Domain
dotnet new classlib -o src/Catalogo.Application
dotnet new classlib -o src/Catalogo.Infrastructure
dotnet new webapi   -o src/Catalogo.Api

# Generate a .gitignore file
dotnet new gitignore

# Add the projects to the solution
dotnet sln add src/Catalogo.Domain
dotnet sln add src/Catalogo.Application
dotnet sln add src/Catalogo.Infrastructure
dotnet sln add src/Catalogo.Api

# Build the solution
dotnet build

# Set project references (respecting the desired dependency flow)
dotnet add .\src\Catalogo.Application\ reference .\src\Catalogo.Domain\
dotnet add .\src\Catalogo.Infrastructure\ reference .\src\Catalogo.Application\
dotnet add .\src\Catalogo.Api\ reference .\src\Catalogo.Infrastructure\

# Add MediatR (example package) in Catalogo.Domain
dotnet add package MediatR.Contracts

# Open the solution in VS Code
code .

Infrastructure
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package EFCore.NamingConventions
dotnet add package Microsoft.EntityFrameworkCore.Sqlite

Catalogo.Api
dotnet add package Microsoft.EntityFrameworkCore.Design

# Migraciones
dotnet tool install --global dotnet-ef

dotnet ef migrations add InitialCatalogoProduct -p src/Catalogo.Infrastructure -s src
dotnet ef migrations add AddCodeToProduct -p src/Catalogo.Infrastructure

CQRS

C => COMMAND => INSERTAR NUEVOS DATOS
Q => QUERY => CONSULTAR DATOS
R => RESPONSABILITY
S => SEGREGATION

Depende del tipo de request que envia el cliente 

command => alteración de data.
query => consultar data.

cd src/Catalogo.Application

dotnet add package MediatR

dotnet add package FluentValidation.AspNetCore

cd src/Catalogo.Api

dotnet add package Swashbuckle.AspNetCore