FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["*.sln", "./"]

COPY ["Bibliotrack.API/Bibliotrack.API.csproj", "Bibliotrack.API/"]
COPY ["Bibliotrack.Application/Bibliotrack.Application.csproj", "Bibliotrack.Application/"]
COPY ["Bibliotrack.Domain/Bibliotrack.Domain.csproj", "Bibliotrack.Domain/"]
COPY ["Bibliotrack.Infrastructure/Bibliotrack.Infrastructure.csproj", "Bibliotrack.Infrastructure/"]

RUN dotnet restore

COPY . .

WORKDIR "/src/Bibliotrack.API"
RUN dotnet publish "Bibliotrack.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Bibliotrack.API.dll"]
