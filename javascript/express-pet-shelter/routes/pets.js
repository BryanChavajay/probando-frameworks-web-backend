import { Router } from "express";
import { getAll, getById, create, update } from "../controllers/pet.js";

export const createPetsRouter = (security) => {
  const petsRouter = Router();

  petsRouter.use(security);

  petsRouter.get("/", getAll);
  petsRouter.get("/:id", getById);
  petsRouter.post("/", create);
  petsRouter.patch("/:id", update);

  return petsRouter;
};
