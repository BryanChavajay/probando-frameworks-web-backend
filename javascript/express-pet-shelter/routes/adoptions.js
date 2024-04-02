import { Router } from "express";
import { getAll, getById, create } from "../controllers/adoptions.js";

export const createAdoptionsRouter = (security) => {
  const adoptionsRouter = Router();

  adoptionsRouter.use(security);

  adoptionsRouter.get("/", getAll);
  adoptionsRouter.get("/:id", getById);
  adoptionsRouter.post("/", create);

  return adoptionsRouter;
};
