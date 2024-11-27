# Cervezas Api

Api que contiene dos crud, marcas y cervezas. El proyecto fue realizado siguiendo el curso de Backend de Hector de Leon

## Stack

* dotnet core version 8.0.303
* msSQL server 2022


## Comenzando

Para comenzar debemos tener instalado dotnet y entity framework en nuestra maquina.

Tambien debemos tener una base de datos, en mi caso estoy usando msSqlServer, a contuación dejo el comando
para levantarla en una macbook pro m1.

```bash
docker run --platform linux/amd64 \ 
        -e "ACCEPT_EULA=Y" \ 
        -e "MSSQL_SA_PASSWORD=[TuContrasena]" \ 
        -p 1433:1433 \ 
        --name [NombreDelContenedor] \ 
        -d mcr.microsoft.com/mssql/server:2022-latest
```

## Configuraciones.

### Descargar y correr el proyecto.

Desde git clonamos el proyecto

```bash
git clone https://github.com/vmonsalve/entity_framework_csharp.git
```

Luego nos movemos al directorio

```bash
cd entity_framework_example_csharp
```
y restauramos el proyecto

```bash
dotnet restore
```

### launchSettings.json

Debemos modificar nuestro lounchSettings.json de la siguiente manera.

```json
{
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "http://localhost:5261;https://localhost:5262",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
```
Aquí lo importante es aplication url, esto nos permitira tener configurado una salida para http y https con diferentes puertos.

### appsettings.json

En este archivo de momento configuraremos nuestra conección a la base de datos.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings" : {
    "StoreConection" : "Server=localhost,1433;Database=tu_dba;User Id=sa;Password=tu_password;Encrypt=True;TrustServerCertificate=True;"
  }
}
```

Lo que sigue es migrar nuestra base de datos, creamos nuestra migracion inicial.

```bash
dotnet ef migrations add InitialCreate
```
y por ultimo actualizamos

```bash
dotnet ef database update
```

Ahora si ya podemos compilar nuestro proyecto en modo observador, esto nos permite que al hacer cambios en el codigo, el servicio se reinicie automaticamente.

```bash
dotnet watch run --project ENTITY_FRAMEWORK_EXAMPLE.csproj
```

## Documentacion api.

El correr la api, se abrira el siguiente. enlace con la [documentación de la api](http://localhost:5261/swagger/index.html).

## Colección con endpoints.

[Aquí](./api_beers.postman_collection.json) esta el json con la collecion que contiene endpoints.

