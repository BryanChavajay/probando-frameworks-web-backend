CREATE TABLE "usuarios"(
	codigoUsuario SERIAL PRIMARY KEY NOT NULL,
	primerNombre VARCHAR(50) NOT NULL,
	segundoNombre VARCHAR(50),
	otrosNombres VARCHAR(50),
	primerApellido VARCHAR(50) NOT NULL,
	segundoApellido VARCHAR(50),
	usuario VARCHAR(50) NOT NULL,
	correoElectronico VARCHAR(128) NOT NULL,
	contrasenia VARCHAR(256) NOT NULL
);

CREATE TABLE "adoptadores"(
	codigoAdoptador SERIAL PRIMARY KEY NOT NULL,
	nombre VARCHAR(128) NOT NULL,
	direccion VARCHAR(256) NOT NULL,
	telefono VARCHAR(8) NOT NULL,
	correoElectronico VARCHAR(128)
);

CREATE TABLE "tiposMascotas"(
	codigoTipoMascota SMALLSERIAL PRIMARY KEY NOT NULL,
	tipo VARCHAR(128) NOT NULL
);

CREATE TABLE "razas"(
	codigoRaza SMALLSERIAL PRIMARY KEY NOT NULL,
	raza VARCHAR(128) NOT NULL
);

CREATE TABLE "mascotas"(
	codigoMascota SERIAL PRIMARY KEY NOT NULL,
	nombre VARCHAR(128) NOT NULL,
	fechaNacimiento DATE,
	codigoTipoMascota INT NOT NULL,
	codigoRaza INT NOT NULL,
	fechaIngreso DATE NOT NULL,
	observaciones VARCHAR(256),
	FOREIGN KEY (codigoTipoMascota) REFERENCES "tiposMascotas"(codigoTipoMascota),
	FOREIGN KEY (codigoRaza) REFERENCES razas(codigoRaza)
);

CREATE TABLE "adopciones"(
	codigoAdopcion SERIAL PRIMARY KEY NOT NULL,
	codigoMascota INT,
	codigoAdoptador INT,
	fechaAdopcion DATE,
	codigoUsuario INT,
	observaciones VARCHAR(256),
	FOREIGN KEY (codigoMascota) REFERENCES mascotas(codigoMascota),
	FOREIGN KEY (codigoAdoptador) REFERENCES adoptadores(codigoAdoptador),
	FOREIGN KEY (codigoUsuario) REFERENCES usuarios(codigoUsuario)
);