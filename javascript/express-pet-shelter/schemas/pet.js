import { z } from "zod";

const PetSchema = z.object({
  name: z
    .string({
      invalid_type_error:
        "El nombre debe ser una cadena de caracteres menor o igual a 128 caracteres",
      required_error: "El nombre es obligatorio",
    })
    .max(128),
  birthday: z
    .string({
      invalid_type_error:
        "El dato que envio no es una fecha, con el formato YYYY-MM-DD",
      required_error: "La fecha es obligatoria",
    })
    .regex(
      /^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$/,
      "El dato que envio no es una fecha, con el formato YYYY-MM-DD"
    ),
  typePet: z
    .number({
      invalid_type_error: "El codigo del tipo de mascota debe ser mayor a 1",
    })
    .int()
    .positive()
    .min(1),
  typeBreed: z
    .number({
      invalid_type_error:
        "El codigo de la raza de la mascota debe ser mayor a 1",
    })
    .int()
    .positive()
    .min(1),
  dateAdmission: z
    .string({
      invalid_type_error:
        "El dato que envio no es una fecha, con el formato YYYY-MM-DD",
      required_error: "La fecha es obligatoria",
    })
    .regex(
      /^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$/,
      "El dato que envio no es una fecha, con el formato YYYY-MM-DD"
    ),
  observations: z
    .string({
      invalid_type_error:
        "Las observaciones deben ser menores o iguales a 256 caracteres",
    })
    .max(256)
    .nullable(),
});

export function validatePet(input) {
  return PetSchema.safeParse(input);
}

export function validatePartialPet(input) {
  return PetSchema.partial().safeParse(input);
}
