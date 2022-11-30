import {IAksje} from "./aksje";

export interface IAksjebeholdning {
    id: number,
    aksje: IAksje,
    antall: number,
    kostpris: number,
}