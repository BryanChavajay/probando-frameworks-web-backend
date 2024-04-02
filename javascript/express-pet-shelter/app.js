import express, { json } from "express";
import { verifyToken } from "./middlewares/auth.js";
import { corsMiddleware } from "./middlewares/cors.js";
import { createAdoptersRouter } from "./routes/adopters.js";
import { createAdoptionsRouter } from "./routes/adoptions.js";
import { createPetsRouter } from "./routes/pets.js";
import { createUsersRouter } from "./routes/users.js";
import { createAuthRouter } from "./routes/auth.js";

const app = express();

app.use(json());
app.use(corsMiddleware());
app.disable("x-powered-by");

app.get("/", (req, res) => {
  res.send("Hello world!");
});
app.use("/adopters", createAdoptersRouter(verifyToken));
app.use("/adoptions", createAdoptionsRouter(verifyToken));
app.use("/pets", createPetsRouter(verifyToken));
app.use("/users", createUsersRouter(verifyToken));
app.use("/auth", createAuthRouter());

const PORT = process.env.PORT ?? 1234;

app.listen(PORT, () => {
  console.log(`server listening on port http://localhost:${PORT}`);
});
