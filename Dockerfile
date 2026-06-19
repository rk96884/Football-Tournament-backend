# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything and restore
COPY . .
RUN dotnet restore

# Build the app
RUN dotnet publish -c Release -o out

# Use the ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy published output
COPY --from=build /app/out .

# Expose port 10000 for Render
ENV ASPNETCORE_URLS=http://0.0.0.0:10000
EXPOSE 10000

# Run the app
ENTRYPOINT ["dotnet", "FiveAsideTournaments.dll"]