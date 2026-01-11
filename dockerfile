# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the Solution file
COPY "Tawla.360.sln" .

# Copy project files
COPY ["Tawla.360.API/Tawla.360.API.csproj", "Tawla.360.API/"]
COPY ["Tawla.360.Application/Tawla.360.Application.csproj", "Tawla.360.Application/"]
COPY ["Tawla.360.Domain/Tawla.360.Domain.csproj", "Tawla.360.Domain/"]
COPY ["Tawla.360.Infrastructure/Tawla.360.Infrastructure.csproj", "Tawla.360.Infrastructure/"]
COPY ["Tawla.360.Persistence/Tawla.360.Persistence.csproj", "Tawla.360.Persistence/"]
COPY ["Tawla.360.Shared/Tawla.360.Shared.csproj", "Tawla.360.Shared/"]
COPY ["Tawla.360.Logging/Tawla.360.Logging.csproj", "Tawla.360.Logging/"]

# --- NETWORK DEBUGGING START ---
# 1. Print DNS settings (checks if your daemon.json fix worked)
RUN cat /etc/resolv.conf

# 2. Check connection to NuGet (Better than ping for .NET)
# If this fails, the build stops here with a clear error.
RUN curl -I https://api.nuget.org/v3/index.json

# 3. (Optional) If you really want 'ping', you must install it first:
# RUN apt-get update && apt-get install -y iputils-ping && ping -c 3 8.8.8.8
# --- NETWORK DEBUGGING END ---

# Restore dependencies
RUN dotnet restore "Tawla.360.Logging/Tawla.360.Logging.csproj"
RUN dotnet restore "Tawla.360.Shared/Tawla.360.Shared.csproj"
RUN dotnet restore "Tawla.360.Domain/Tawla.360.Domain.csproj"
RUN dotnet restore "Tawla.360.Application/Tawla.360.Application.csproj"
RUN dotnet restore "Tawla.360.Persistence/Tawla.360.Persistence.csproj"
RUN dotnet restore "Tawla.360.Infrastructure/Tawla.360.Infrastructure.csproj"
RUN dotnet restore "Tawla.360.API/Tawla.360.API.csproj"

# Copy the remaining source code
COPY . .

# Build the application
WORKDIR "/src/Tawla.360.API"
RUN dotnet build "Tawla.360.API.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "Tawla.360.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
USER app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tawla.360.API.dll"]