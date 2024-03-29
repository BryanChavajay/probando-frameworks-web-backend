# Documentación del Proyecto FastAPI con PostgreSQL

## Tecnologías Utilizadas

- Python 3.12
- FastAPI 0.110.0
- PostgreSQL 16

## Configuración y Ejecución del Proyecto

1. Clona el repositorio:

2. Navega a la carpeta del proyecto:

    ```bash
    cd fastapi-sqlalchemy
    ```

3. Crea y activa un entorno virtual (para Windows, Linux o macOS):

    - **Windows:**
        ```bash
        python -m venv venv
        venv\Scripts\activate
        ```

    - **Linux/macOS:**
        ```bash
        python3 -m venv venv
        source venv/bin/activate
        ```

4. Instala los paquetes necesarios desde `requirements.txt`:

    ```bash
    pip install -r requirements.txt
    ```

5. Configuración de la cadena de conexión a la base de datos
   Para configurar la cadena de conexión debes dirigirte a la carpeta db
   ```bash
   cd db
   ```

   En el archivo **db.py** encontrarás la constante **SQLALCHEMY_DATABASE_URL** aca debes pegar la url de conexión con tu base de datos. Remplaza las variables **CONTRASEÑA**, **HOST**, **PUERTO** y **NOMBRE_BASE_DE_DATOS**
   ```python
   SQLALCHEMY_DATABASE_URL = (
    "postgresql://postgres:CONTRASEÑA@HOST:PUERTO/NOMBRE_BASE_DE_DATOS"
   )
   ```

6. Ejecuta el servidor con el siguiente comando:

    ```bash
    uvicorn main:app --reload --port 8081
    ```

7. Una vez iniciado el servidor, puedes acceder a la documentación interactiva en [http://localhost:8081/docs](http://localhost:8081/docs) o a la documentación adicional en [http://localhost:8081/redoc](http://localhost:8081/redoc).

## Notas Importantes

- Antes de iniciar el servidor, asegúrate de ejecutar los scripts de base de datos que se encuentran en la carpeta `db`.
- Los scripts de base de datos crean un usuario por defecto con el correo `johndoe@gmail.com` y la contraseña `Admin1234`.
- En la documentación interactiva, se espera que ingreses un usuario debido al estándar de OAuth2. Utiliza el correo mencionado anteriormente.
