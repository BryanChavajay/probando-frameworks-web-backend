import {
  getUsers,
  getUserById,
  createUser,
  updateUser,
} from "../models/user.js";
import { validatePartialUser, validateUser } from "../schemas/user.js";
import bcrypt from "bcrypt";

export async function getAll(req, res) {
  try {
    const users = await getUsers();
    res.status(200).json({
      status: 200,
      message: "Petición completada",
      data: users,
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

export async function getById(req, res) {
  try {
    const { id } = req.params;
    const user = await getUserById({ id });

    if (user == null) {
      return res.status(404).json({
        status: 404,
        message: "No se encontró el recurso",
        data: {},
      });
    }

    res.status(200).json({
      status: 200,
      message: "Petición completada",
      data: user,
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

export async function create(req, res) {
  try {
    const result = validateUser(req.body);

    if (!result.success) {
      return res.status(400).json({
        status: 400,
        message: JSON.parse(result.error.message),
        data: {},
      });
    }

    const hash = bcrypt.hashSync(result.data.password, 10);

    result.data.password = hash;

    const newUser = await createUser(result.data);

    res.status(201).json({
      status: 201,
      message: "Usuario registrado",
      data: newUser,
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

export async function update(req, res) {
  try {
    const { id } = req.params;
    const user = await getUserById({ id });

    if (user == null) {
      return res.status(404).json({
        status: 404,
        message: "No se encontró el recurso",
        data: {},
      });
    }

    const result = validatePartialUser(req.body);

    if (!result.success) {
      // 422 Unprocessable Entity
      return res.status(400).json({
        status: 400,
        message: JSON.parse(result.error.message),
        data: {},
      });
    }

    if (result.data.password) {
      const hash = bcrypt.hashSync(result.data.password, 10);

      result.data.password = hash;
    }

    const updated = await updateUser(result.data, id);

    if (updated > 0) {
      const petUpdated = await getUserById({ id });

      return res.status(200).json({
        status: 200,
        message: "Usuario actualizado con exito",
        data: petUpdated,
      });
    }

    res.status(400).json({
      status: 400,
      message: "No se pudo actualizar al usuario, revice los campos que envio",
      data: {},
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
