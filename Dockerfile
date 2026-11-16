# Etapa 1: Compilación y publicación con el SDK de .NET 10
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "lab2tarea-Ariass.sln"
RUN dotnet publish "lab2tarea-Ariass.sln" -c Release -o /app/publish

# Etapa 2: Ejecución ligera en producción
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "lab2tarea-Ariass.dll"]
