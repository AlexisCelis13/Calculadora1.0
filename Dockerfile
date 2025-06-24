# Imagen base oficial de .NET para aplicaciones ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Imagen base oficial de .NET SDK para compilar la app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia los archivos del proyecto y restaura dependencias
COPY GoldenCalculator/GoldenCalculator.csproj GoldenCalculator/
RUN dotnet restore GoldenCalculator/GoldenCalculator.csproj

# Copia el resto del código y compila
COPY . .
WORKDIR /src/GoldenCalculator
RUN dotnet publish -c Release -o /app/publish

# Imagen final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "GoldenCalculator.dll"] 