import { z } from "zod";

const AdoptionSchema = z.object({
  petId: z
    .number({
      invalid_type_error: "El codigo de la mascota debe ser mayor a 0",
      required_error: "El codigo de la mascota es requerido",
    })
    .int()
    .positive()
    .min(1),
  adopterId: z
    .number({
      invalid_type_error: "El codigo del adoptador debe ser mayor a 0",
      required_error: "El codigo del adoptador es requerido",
    })
    .int()
    .positive()
    .min(1),
  adoptionDate: z
    .string({
      invalid_type_error:
        "El dato que envio no es una fecha, con el formato YYYY-MM-DD",
      required_error: "La fecha es obligatoria",
    })
    .regex(
      /^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$/,
      "El dato que envio no es una fecha, con el formato YYYY-MM-DD"
    ),
  userId: z
    .number({
      invalid_type_error: "El codigo del usuario debe ser mayor a 0",
      required_error: "El codigo del usuario es requerido",
    })
    .int()
    .positive()
    .min(1),
  observations: z.string().max(256),
});

export function validateAdoption(input) {
  return AdoptionSchema.safeParse(input);
}

export function validatePartialAdoption(input) {
  return AdoptionSchema.partial().safeParse(input);
}
