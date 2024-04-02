import { getUserByEmailOrUser } from "../models/user.js";
import { validateAuth } from "../schemas/auth.js";
import bcrypt from "bcrypt";
import jwt from "jsonwebtoken";

export async function getUSer(req, res) {
  try {
    const SECRET = "ContraseñaSuperSeguraNoSeCompartaConNadie1234";
    const result = validateAuth(req.body);

    const user = await getUserByEmailOrUser(result.data.username);

    if (!user) {
      return res.status(401).json({
        status: 401,
        message: "Usuario o contraseña incorrectos",
        data: {},
      });
    }

    const checkPassword = bcrypt.compareSync(
      result.data.password,
      user.dataValues.password
    );

    if (!checkPassword) {
      return res.status(401).json({
        status: 401,
        message: "Usuario o contraseña incorrectos",
        data: {},
      });
    }

    const payload = {
      username: user.dataValues.user,
      id: user.dataValues.userId,
    };

    const token = jwt.sign(payload, SECRET, { expiresIn: "8h" });

    res.status(200).json({
      status: 200,
      message: "Petición completada",
      data: {
        token: token,
        type: "Bearer",
      },
    });
  } catch (error) {
    console.log(error);
    res.status(500).json({
      status: 500,
      message: "Error interno del servidor, revise su petición o intente luego",
      data: {},
    });
  }
}
