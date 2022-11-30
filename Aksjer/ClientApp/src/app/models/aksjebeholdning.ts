import {Aksje} from "./aksje";

export interface Aksjebeholdning {
    id: number,
    aksje: Aksje,
    antall: number,
    kostpris: number,
}