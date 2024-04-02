import { DataTypes } from "sequelize";
import { sequelize } from "../../db/db.js";
import { TypePet } from "./typePet.js";
import { Breed } from "./breed.js";

export const Pet = sequelize.define(
  "mascotas",
  {
    petId: {
      type: DataTypes.INTEGER,
      primaryKey: true,
      autoIncrement: true,
      field: "codigomascota",
    },
    name: {
      type: DataTypes.STRING,
      field: "nombre",
    },
    birthday: {
      type: DataTypes.DATEONLY,
      field: "fechanacimiento",
    },
    typePet: {
      type: DataTypes.INTEGER,
      field: "codigotipomascota",
    },
    typeBreed: {
      type: DataTypes.INTEGER,
      field: "codigoraza",
    },
    dateAdmission: {
      type: DataTypes.DATEONLY,
      field: "fechaingreso",
    },
    observations: {
      type: DataTypes.STRING,
      field: "observaciones",
    },
  },
  {
    timestamps: false,
  }
);

Pet.belongsTo(TypePet, {
  foreignKey: "typePet",
  targetKey: "idTypePet",
});

TypePet.hasMany(Pet, {
  foreignKey: "typePet",
  sourceKey: "idTypePet",
});

Pet.belongsTo(Breed, {
  foreignKey: "typeBreed",
  targetKey: "idBreed",
});

Breed.hasMany(Pet, {
  foreignKey: "typeBreed",
  sourceKey: "idBreed",
});
