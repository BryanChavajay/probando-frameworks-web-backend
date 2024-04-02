import { Sequelize } from "sequelize";

export const sequelize = new Sequelize(
  "refugioMascotas", //Nombre de la DB
  "postgres", //Nombre del usuario
  "SQL#1234", //Contraseña de la DB
  {
    host: "localhost", //Host
    port: 5432, //Puerto
    dialect: "postgres",
  }
);
