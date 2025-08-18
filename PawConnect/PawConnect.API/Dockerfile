FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PawConnect.API/PawConnect.API.csproj", "PawConnect.API/"]
COPY ["PawConnect.Application/PawConnect.Application.csproj", "PawConnect.Application/"]
COPY ["PawConnect.Domain/PawConnect.Domain.csproj", "PawConnect.Domain/"]
COPY ["PawConnect.Infrastructure/PawConnect.Infrastructure.csproj", "PawConnect.Infrastructure/"]
RUN dotnet restore "PawConnect.API/PawConnect.API.csproj"
COPY . .
WORKDIR "/src/PawConnect.API"
RUN dotnet build "./PawConnect.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PawConnect.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PawConnect.API.dll"]
