import {IAksje} from "./aksje";

export interface IOrdre {
    id: number,
    aksje: IAksje,
    type: string;
    antall: number,
    pris: number,
}