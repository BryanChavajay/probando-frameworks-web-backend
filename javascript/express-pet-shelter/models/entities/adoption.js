import { DataTypes } from "sequelize";
import { sequelize } from "../../db/db.js";
import { Pet } from "./pet.js";
import { Adopter } from "./adopter.js";
import { User } from "./user.js";

export const Adoption = sequelize.define(
  "adopciones",
  {
    adoptionId: {
      type: DataTypes.INTEGER,
      primaryKey: true,
      autoIncrement: true,
      field: "codigoadopcion",
    },
    petId: {
      type: DataTypes.INTEGER,
      field: "codigomascota",
    },
    adopterId: {
      type: DataTypes.INTEGER,
      field: "codigoadoptador",
    },
    adoptionDate: {
      type: DataTypes.DATEONLY,
      field: "fechaadopcion",
    },
    userId: {
      type: DataTypes.INTEGER,
      field: "codigousuario",
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

Adoption.belongsTo(Pet, {
  foreignKey: "petId",
  targetKey: "petId",
});
Pet.hasOne(Adoption, {
  foreignKey: "petId",
  sourceKey: "petId",
});

Adoption.belongsTo(User, {
  foreignKey: "userId",
  targetKey: "userId",
});
User.hasOne(Adoption, {
  foreignKey: "userId",
  sourceKey: "userId",
});

Adoption.belongsTo(Adopter, {
  foreignKey: "adopterId",
  targetKey: "adopterId",
});
Adopter.hasOne(Adoption, {
  foreignKey: "adopterId",
  sourceKey: "adopterId",
});
