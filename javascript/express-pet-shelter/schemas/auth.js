import { z } from "zod";

const AuthSchema = z.object({
  username: z
    .string({
      required_error: "Es obligatorio el correo o nombre de usuario",
      invalid_type_error: "El correo o nombre de usuario de ser un string",
    })
    .max(128),
  password: z
    .string({
      required_error: "La contraseña del usuario es obligatoria",
      invalid_type_error: "La contraseña debe ser un string",
    })
    .max(256),
});

export function validateAuth(input) {
  return AuthSchema.safeParse(input);
}
