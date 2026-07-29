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
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy published output
COPY --from=build /app .

# Expose port (Render sets $PORT automatically)
EXPOSE 8080

# Disable IPv6 so Npgsql uses IPv4 only
RUN echo 'precedence ::ffff:0:0/96  100' >> /etc/gai.conf

# Start the app
ENTRYPOINT ["dotnet", "FiveAsideTournaments.dll"]
