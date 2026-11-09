export interface CarroGlobal {
    id: number;
    nombre: string;
}

export interface CrearCarroGlobalDTO {
    nombre: string;
}

export interface FluentValidationError {
    propertyName: string;
    errorMessage: string;
    attemptedValue?: unknown;
    errorCode?: string;
}