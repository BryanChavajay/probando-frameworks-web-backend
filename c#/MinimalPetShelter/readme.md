# Documentación del Proyecto MinimalPetShelter con PostgreSQL

## ¿Qué es Minimal API?
> Es una nueva forma de programar aplicaciones web en Asp.Net Core. Una forma más sencilla, más rápida y más flexible. Y todo sin perder la robustez de Asp.Net Core o la flexibilidad de Asp.Net Core MVC. https://www.developerro.com/2023/03/22/minimal-api-net7/ 

## Tecnologías Utilizadas

- .Net 8.0
- PostgreSQL 16

## Configuración y Ejecución del Proyecto

1. Clona el repositorio:

2. Navega a la carpeta del proyecto:

    ```bash
    cd c#/MinimalPetShelter
    ```

3. Instalar dependencias: Ejecuta el siguiente comando para instalar todas las dependencias del proyecto:

    ```bash
    dotnet restore
    ```

4. Configura la cadena de conexión de la base de datos: Abre el archivo appsettings.json y asegúrate de que la cadena de conexión de la base de datos esté configurada correctamente. Reemplaza los valores de <HOST>, <PUERTO>, <NOMBRE_DB>, <USUARIO> y <CONTRASEÑA> con los valores de tu base de datos:

    ```json
    {
        "ConnectionStrings": {
            "Connection": "Server=<HOST>;Port=<PUERTO>;Database=<NOMBRE_DB>;;Username=<USUARIO>;Password=<CONTRASEÑA>"
        }
    }
    ```

5. Ejecutar el programa: Una vez que hayas configurado la cadena de conexión, puedes ejecutar el programa con el siguiente comando:

    ```bash
    dotnet run
    ```

6. Una vez iniciado el servidor, puedes acceder a la documentación interactiva en **http://localhost:5037/swagger/index.html** en esta documentación encontrarás todas las rutas disponibles, por autenticación mediante JWT las unicas rutas que podrás usar sin el token son la de autenticación y la ruta para crear usuarios. 
   
    **Nota:** El puerto podría variar de acuerdo a la configuración de tu computadora, recuerda revisar la consola para verificar el puerto.

7. Para probar cada ruta te recomiendo utilizar un cliente rest y recuerda añadir el encabezado de seguridad Authorization con el valor: **Bearer <TU_TOKEN>**

## Notas Importantes

- Antes de iniciar el servidor, asegúrate de ejecutar los scripts de base de datos que se encuentran en la carpeta `db`.
- Los scripts de base de datos crean un usuario por defecto con el correo `johndoe@gmail.com` y la contraseña `Admin1234`.
- En la documentación interactiva, se espera que ingreses un usuario debido al estándar de OAuth2. Utiliza el correo mencionado anteriormente.
