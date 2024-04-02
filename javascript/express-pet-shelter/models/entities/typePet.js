import { DataTypes } from "sequelize";
import { sequelize } from "../../db/db.js";

export const TypePet = sequelize.define("tiposMascotas", {
  idTypePet: {
    type: DataTypes.INTEGER,
    field: "codigotipomascota",
  },
  type: {
    type: DataTypes.STRING,
    field: "tipo",
  },
});
