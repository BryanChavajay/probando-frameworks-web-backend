import { DataTypes } from "sequelize";
import { sequelize } from "../../db/db.js";

export const Breed = sequelize.define("razas", {
  idBreed: {
    type: DataTypes.INTEGER,
    field: "codigoraza",
  },
  breed: {
    type: DataTypes.STRING,
    field: "raza",
  },
});
