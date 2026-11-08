import type { CarroGlobal } from '../types/carro.types';

export const obtenerCarrosGlobalesAsync = (): Promise<CarroGlobal[]> => {
    return new Promise((resolve) => {
        setTimeout(() => {
            const datosCatalogo: CarroGlobal[] = [
                { id: 1, nombre: 'Porsche 911 GT3 RS' },
                { id: 2, nombre: 'Toyota GR86' },
                { id: 3, nombre: 'Ferrari 296 GT3' },
                { id: 4, nombre: 'Chevorolet Corvette C6' },
                { id: 5, nombre: 'Ford Mustang GT3' },
                { id: 6, nombre: 'Toyota GR Yaris Rally1' },
            ]
            resolve(datosCatalogo)
        }, 1000)
    })
}