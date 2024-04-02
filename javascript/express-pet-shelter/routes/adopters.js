import { Router } from "express";
import { getAll, getById, create, update } from "../controllers/adopter.js";

export const createAdoptersRouter = (security) => {
  const adoptersRouter = Router();

  adoptersRouter.use(security);

  adoptersRouter.get("/", getAll);
  adoptersRouter.get("/:id", getById);
  adoptersRouter.post("/", create);
  adoptersRouter.patch("/:id", update);

  return adoptersRouter;
};
