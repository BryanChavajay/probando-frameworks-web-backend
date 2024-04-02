import { DataTypes } from "sequelize";
import { sequelize } from "../../db/db.js";

export const User = sequelize.define(
  "usuarios",
  {
    userId: {
      type: DataTypes.INTEGER,
      primaryKey: true,
      autoIncrement: true,
      field: "codigousuario",
    },
    firstName: {
      type: DataTypes.STRING,
      field: "primernombre",
      allowNull: true,
    },
    secondName: {
      type: DataTypes.STRING,
      field: "segundonombre",
      allowNull: true,
    },
    othersNames: {
      type: DataTypes.STRING,
      field: "otrosnombres",
      allowNull: true,
    },
    firstLastname: {
      type: DataTypes.STRING,
      field: "primerapellido",
    },
    secondLastName: {
      type: DataTypes.STRING,
      field: "segundoapellido",
      allowNull: true,
    },
    user: {
      type: DataTypes.STRING,
      field: "usuario",
    },
    email: {
      type: DataTypes.STRING,
      field: "correoelectronico",
    },
    password: {
      type: DataTypes.STRING,
      field: "contrasenia",
    },
  },
  {
    timestamps: false,
  }
);
