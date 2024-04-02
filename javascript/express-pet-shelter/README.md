# Documentación del Proyecto Express Pet Shelter con PostgreSQL

## Tecnologías Utilizadas

- Node 20.9.0
- Pnpm 8.15.5
- PostgreSQL 16

## Configuración y Ejecución del Proyecto

1.  Clona el repositorio

2.  Navega a la carpeta del proyecto:

    ```bash
    cd express-pet-shelter
    ```

3.  Instala las dependencias

    ```bash
    pnpm install
    ```

4.  Configuración de la cadena de conexión a la base de datos
    Para configurar la cadena de conexión debes dirigirte a la carpeta db

    ```bash
    cd db
    ```

    En el archivo **db.js** encontrarás la constante **sequelize**, aca debes de colocar las credenciales para acceder a la DB.

    ```JavaScript
    export const sequelize = new Sequelize(
        "NombreDB", 
        "Usuario",
        "Contraseña",
        {
            host: "host",
            port: 1234,
            dialect: "postgres", //Esto no lo cambies, a no se que uses otra DB
        }
    );
    ```

5.  Ejecuta el servidor con el siguiente comando:

    ```bash
    pnpm run dev
    ```

6.  Una vez iniciado el servidor, puedes empezar a realizar peticiones a: [http://localhost:1234/](http://localhost:1234/)

7. ¿Que peticiones puedo hacer?
    En el archivo **api.http** encontrarás todas las peticiones posibles para interactuar con la API. Así como los ejemplos de como mandar los datos.

## Notas Importantes

- Antes de iniciar el servidor, asegúrate de ejecutar los scripts de base de datos que se encuentran en la carpeta `db`.
- Los scripts de la base de datos crean un usuario por defecto con el correo `johndoe@gmail.com` y la contraseña `Admin1234`.
- Si utilizas VS Code, puedes utilizar la extensións **REST Client** y por medio del archivo **api.http** puedes comenzar a interactuar con la API.
- Si deseas cambiar el puerto por defecto (1234) debes cambiar el valor de la constante **PORT** en el archivo **app.js**
