import { DataTypes } from "sequelize";
import { sequelize } from "../../db/db.js";

export const Adopter = sequelize.define(
  "adoptadores",
  {
    adopterId: {
      type: DataTypes.INTEGER,
      primaryKey: true,
      autoIncrement: true,
      field: "codigoadoptador",
    },
    name: {
      type: DataTypes.STRING,
      field: "nombre",
    },
    direction: {
      type: DataTypes.STRING,
      field: "direccion",
    },
    phone: {
      type: DataTypes.STRING,
      field: "telefono",
    },
    email: {
      type: DataTypes.STRING,
      field: "correoelectronico",
    },
  },
  {
    timestamps: false,
  }
);
