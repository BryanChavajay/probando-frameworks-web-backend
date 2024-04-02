import { Router } from "express";
import { getUSer } from "../controllers/auth.js";

export const createAuthRouter = () => {
  const authRouter = Router();

  authRouter.post("/", getUSer);

  return authRouter;
};
