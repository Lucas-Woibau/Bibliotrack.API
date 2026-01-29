FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Bibliotrack.API/Bibliotrack.API/Bibliotrack.API.csproj", "Bibliotrack.API/Bibliotrack.API/"]

RUN dotnet restore "Bibliotrack.API/Bibliotrack.API/Bibliotrack.API.csproj"

COPY . .

WORKDIR "/src/Bibliotrack.API/Bibliotrack.API"
RUN dotnet build "Bibliotrack.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Bibliotrack.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bibliotrack.API.dll"]
