import {Aksje} from "./aksje";

export interface IAksjebeholdning {
    id: number,
    aksje: Aksje,
    antall: number,
    kostpris: number,
}