# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything
COPY . .

# Restore dependencies
RUN dotnet restore

# Publish the app
RUN dotnet publish -c Release -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0-bullseye-slim AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080

# Copy published output
COPY --from=build /app .

# Expose port (Render sets $PORT automatically)
EXPOSE 8080

# Start the app
ENTRYPOINT ["dotnet", "FiveAsideTournaments.dll"]
