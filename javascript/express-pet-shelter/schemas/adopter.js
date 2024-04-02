import { z } from "zod";

const AdopterSchema = z.object({
  name: z
    .string({
      invalid_type_error:
        "El nombre de usuario debe ser una cadena de caracteres menor o igual a 128",
      required_error: "Este campo es obligatorio",
    })
    .max(128),
  direction: z
    .string({
      invalid_type_error:
        "La dirección debe ser una cadena de caracteres menor o igual a 256",
      required_error: "Este campo es obligatorio",
    })
    .max(256),
  phone: z
    .string({
      invalid_type_error: "El telefono solo pueden ser números y maximo 8",
    })
    .length(8),
  email: z.string().email().max(128),
});

export function validateAdopter(input) {
  return AdopterSchema.safeParse(input);
}

export function validatePartialAdopter(input) {
  return AdopterSchema.partial().safeParse(input);
}
