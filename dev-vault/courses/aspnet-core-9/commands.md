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

# Add MediatR (example package)
dotnet add package MediatR.Contracts

# Open the solution in VS Code
code .
