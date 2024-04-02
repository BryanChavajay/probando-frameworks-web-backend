import { z } from "zod";

const UserSchema = z.object({
  firstName: z
    .string({
      invalid_type_error:
        "El nombre debe ser una cadena de caracteres y menor o igual a 50 caracteres",
      required_error: "Este campo es requerido",
    })
    .max(20),
  secondName: z
    .string({
      invalid_type_error:
        "El segundo nombre debe ser una cadena de caracteres y menor o igual a 50 caracteres",
    })
    .max()
    .nullable(),
  othersNames: z
    .string({
      invalid_type_error:
        "El tercer nombre debe ser una cadena de caracteres y menor o igual a 50 caracteres",
    })
    .max(50)
    .nullable(),
  firstLastname: z
    .string({
      invalid_type_error:
        "El primer apellido debe ser una cadena de caracteres y menor o igual a 50 caracteres",
      required_error: "El apellido es requerido",
    })
    .max(50),
  secondLastName: z
    .string({
      invalid_type_error:
        "El tercer nombre debe ser una cadena de caracteres y menor o igual a 50 caracteres",
    })
    .max(50)
    .nullable(),
  user: z.string({
    invalid_type_error:
      "El usuario debe ser una cadena de caracteres sin espacios, menor o igual a 50 caracteres",
    required_error: "El usuario es obligatorio",
  }),
  email: z
    .string({
      invalid_type_error:
        "Debe de proporcionar un correo valido menor o igual a 128 caracteres",
    })
    .email(),
  password: z.string().max(256),
});

export function validateUser(input) {
  return UserSchema.safeParse(input);
}

export function validatePartialUser(input) {
  return UserSchema.partial().safeParse(input);
}
