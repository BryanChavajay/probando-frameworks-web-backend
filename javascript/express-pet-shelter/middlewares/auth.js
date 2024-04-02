import jwt from "jsonwebtoken";

export function verifyToken(req, res, next) {
  const SECRET = "ContraseñaSuperSeguraNoSeCompartaConNadie1234";
  const header = req.header("Authorization") || "";
  const token = header.split(" ")[1];
  if (!token) {
    return res.status(401).json({ message: "No tiene acceso" });
  }
  try {
    const payload = jwt.verify(token, SECRET);
    req.username = payload.username;
    next();
  } catch (error) {
    return res.status(403).json({ message: "Token not valid" });
  }
}
