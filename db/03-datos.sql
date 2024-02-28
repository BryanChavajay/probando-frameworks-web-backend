INSERT INTO "tiposMascotas" VALUES
('PERRO'), ('GATO'), ('PEZ'), ('ROEDOR');

INSERT INTO "razas"(raza) VALUES
('Pastor alemán'),
('Husky siberiano'),
('Golden retriever'),
('Bulldog francés'),
('Chihuahua'),
('Beagle'),
('Persa'),
('Siamés'),
('Siberiano'),
('Bengalí'),
('Dorado'),
('Cirujano');

INSERT INTO mascotas(nombre, codigotipomascota, codigoraza, fechaingreso, fechanacimiento, observaciones) VALUES
('Aslan', 1, 1, '2024/2/1', '2020/5/5', 'Es muy jugueton y cariñoso con los niños'),
('Bella', 1, 2, '2023/8/16', '2022/9/10', 'Le gustan los juguetes con sonido');

-- Lo siguiente es un usuario genérico, para poder interactuar con la documentación interactiva
-- En la documentación interactiva, se pide una usuario esto se debe a OAuth
-- Sin embargo debes ingresar el correo, la contraseña es: Admin1234
INSERT INTO usuarios (
    primernombre, segundoapellido, otrosnombres, 
    primerapellido, segundoapellido, usuario, 
    correoelectronico, contrasenia
)
VALUES (
    'John', 'Doe', '',
    'Doe', '', 'johndoe',
    'johndoe@gmail.com', '$2b$12$XQvKNV5J1cE1jgJTeklS3enUQF7VTl5A75/1IKXlVjINwuCmTfmt2'
);