import { getPets, getPetById, createPet, updatePet } from "../models/pet.js";
import { validatePartialPet, validatePet } from "../schemas/pet.js";

export async function getAll(req, res) {
  try {
    const pets = await getPets();
    res.status(200).json({
      status: 200,
      message: "Petición completada",
      data: pets,
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
    const pet = await getPetById({ id });

    if (pet == null) {
      return res.status(404).json({
        status: 404,
        message: "No se encontró el recurso",
        data: {},
      });
    }

    res.status(200).json({
      status: 200,
      message: "Petición completada",
      data: pet,
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
    const result = validatePet(req.body);

    if (!result.success) {
      return res.status(400).json({
        status: 400,
        message: JSON.parse(result.error.message),
        data: {},
      });
    }

    const newPet = await createPet(result.data);

    res.status(201).json({
      status: 201,
      message: "Mascota registrada",
      data: newPet,
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
    const pet = await getPetById({ id });

    if (pet == null) {
      return res.status(404).json({
        status: 404,
        message: "No se encontró el recurso",
        data: {},
      });
    }

    const result = validatePartialPet(req.body);

    if (!result.success) {
      // 422 Unprocessable Entity
      return res.status(400).json({
        status: 400,
        message: JSON.parse(result.error.message),
        data: {},
      });
    }

    const updated = await updatePet(result.data, id);

    if (updated > 0) {
      const petUpdated = await getPetById({ id });

      return res.status(200).json({
        status: 200,
        message: "Mascota actualizada con exito",
        data: petUpdated,
      });
    }

    res.status(400).json({
      status: 400,
      message:
        "No se pudo actualizar a la mascota, revice los campos que envio",
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
