# Etapa 1: Imagen base para .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar archivos y restaurar dependencias
COPY . ./
RUN dotnet restore

# Instalar dotnet-ef globalmente
RUN dotnet tool install --global dotnet-ef

# Asegurarse de que las herramientas estén disponibles en PATH
ENV PATH="$PATH:/root/.dotnet/tools"

# Generar certificados SSL para desarrollo
RUN dotnet dev-certs https --clean \
    && dotnet dev-certs https --trust

# Construir el proyecto
RUN dotnet publish -c Release -o out

# Etapa 2: Imagen runtime para ejecutar la API
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar los certificados SSL generados
COPY --from=build-env /root/.aspnet/https /root/.aspnet/https

# Copiar los binarios construidos
COPY --from=build-env /app/out .

# Exponer puertos para HTTP y HTTPS
EXPOSE 5261
EXPOSE 5262

# Configurar el punto de entrada
ENTRYPOINT ["dotnet", "ENTITY_FRAMEWORK_EXAMPLE.dll"]
