# Stage 1: Build the application using the SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy the project files and restore dependencies
COPY ./WebAlertApi/WebAlertApi.csproj ./WebAlertApi/WebAlertApi.csproj
COPY ./DomainLayer/DomainLayer.csproj ./DomainLayer/DomainLayer.csproj
COPY ./RepositoryLayer/RepositoryLayer.csproj ./RepositoryLayer/RepositoryLayer.csproj


RUN dotnet restore WebAlertApi/WebAlertApi.csproj

# Copy the source code into the container
COPY . .

WORKDIR "/src/WebAlertApi"

# Build the project
RUN dotnet build WebAlertApi.csproj -c Release -o /app/build

# Stage 2: Publish the application
FROM build AS publish

RUN dotnet publish WebAlertApi.csproj -c Release -o /app/publish

# Stage 3: Create a runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

# Copy the published files from the build stage
COPY --from=publish /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "WebAlertApi.dll"]
