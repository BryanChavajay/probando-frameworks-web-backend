import { Router } from "express";
import { getAll, getById, create, update } from "../controllers/user.js";

export const createUsersRouter = (security) => {
  const usersRouter = Router();

  usersRouter.use(security);

  usersRouter.get("/", getAll);
  usersRouter.get("/:id", getById);
  usersRouter.post("/", create);
  usersRouter.patch("/:id", update);

  return usersRouter;
};
