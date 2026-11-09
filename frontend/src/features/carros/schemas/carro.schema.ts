// frontend/src/features/carros/schemas/carro.schema.ts
import { z } from 'zod'

// Artefacto Declarativo de Validación Sintáctica (Espejo de FluentValidation en .NET)
export const crearCarroGlobalSchema = z.object({
    nombre: z
        .string()
        .trim() // Sanitiza espacios en blanco al inicio y al final
        .min(1, 'El nombre del carro no puede estar vacío.')
        .min(3, 'El carro debe tener al menos 3 caracteres.')
        .max(100, 'El nombre no puede superar los 100 caracteres permitidos en PostgreSQL.')
        .regex(
            /^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9\s.,()-]+$/,
            'El carro contiene caracteres especiales no permitidos.'
        ),
})

export type CrearCarroGlobalSchemaType = z.infer<typeof crearCarroGlobalSchema>
