import {
  getAdopterById,
  getAdopter,
  createAdopter,
  updateAdopter,
} from "../models/adopter.js";
import { validateAdopter, validatePartialAdopter } from "../schemas/adopter.js";

export async function getAll(req, res) {
  try {
    const adopters = await getAdopter();
    res.status(200).json({
      status: 200,
      message: "Petición completada",
      data: adopters,
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
    const adopter = await getAdopterById({ id });

    if (adopter == null) {
      return res.status(404).json({
        status: 404,
        message: "No se encontró el recurso",
        data: {},
      });
    }

    res.status(200).json({
      status: 200,
      message: "Petición completada",
      data: adopter,
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
    const result = validateAdopter(req.body);

    if (!result.success) {
      // 422 Unprocessable Entity
      return res.status(400).json({
        status: 400,
        message: JSON.parse(result.error.message),
        data: {},
      });
    }

    const newAdopter = await createAdopter(result.data);

    res.status(201).json({
      status: 201,
      message: "Adoptador registrado",
      data: newAdopter,
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
    const adopter = await getAdopterById({ id });

    if (adopter == null) {
      return res.status(404).json({
        status: 404,
        message: "No se encontró el recurso",
        data: {},
      });
    }

    const result = validatePartialAdopter(req.body);

    if (!result.success) {
      // 422 Unprocessable Entity
      return res.status(400).json({
        status: 400,
        message: JSON.parse(result.error.message),
        data: {},
      });
    }

    const updated = await updateAdopter(result.data, id);

    if (updated > 0) {
      const adopterUpdated = await getAdopterById({ id });

      return res.status(200).json({
        status: 200,
        message: "Adoptador actualizado con exito",
        data: adopterUpdated,
      });
    }

    res.status(400).json({
      status: 400,
      message:
        "No se pudo actualizar al adoptador, revice los campos que envio",
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
