# # Use the ASP.NET Core runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# WORKDIR /app
# EXPOSE 80

# # Build image
# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# WORKDIR /src
# # COPY ["api.csproj", "api/"]
# # RUN dotnet restore "api/api.csproj"
# COPY . .
# #WORKDIR "/src"
# #RUN dotnet restore "api/api.csproj"
# RUN dotnet build "api.csproj" -c Release -o /app/build

# # Publish image
# FROM build AS publish
# RUN dotnet publish "api.csproj" -c Release -o /app/publish

# # Run the application
# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "api.dll"]

# Use .NET 8 SDK to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Set the working directory
WORKDIR /app
# Copy the project files
COPY . .
# Restore and build the project
RUN dotnet restore
RUN dotnet publish -c Release -o out
# Final stage: run the application using the ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
# Expose port 80 for the application
EXPOSE 80
# Set the application to listen on IPv4 only
ENV ASPNETCORE_URLS=http://0.0.0.0:80
# Run the application
ENTRYPOINT ["dotnet", "api.dll"]