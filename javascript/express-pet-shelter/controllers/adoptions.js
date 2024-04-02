import {
  getAdoptionById,
  getAdoptions,
  createAdoption,
} from "../models/adoption.js";
import { validateAdoption } from "../schemas/adoption.js";

export async function getAll(req, res) {
  try {
    const adoptions = await getAdoptions();
    res.status(200).json({
      status: 200,
      message: "Petición completada",
      data: adoptions,
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
    const adoption = await getAdoptionById({ id });

    if (adoption == null) {
      return res.status(404).json({
        status: 404,
        message: "No se encontró el recurso",
        data: {},
      });
    }

    res.status(200).json({
      status: 200,
      message: "Petición completada",
      data: adoption,
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
    const result = validateAdoption(req.body);

    if (!result.success) {
      // 422 Unprocessable Entity
      return res.status(400).json({
        status: 400,
        message: JSON.parse(result.error.message),
        data: {},
      });
    }

    const newAdoption = await createAdoption(result.data);

    res.status(201).json({
      status: 201,
      message: "Adopcion registrada",
      data: newAdoption,
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
