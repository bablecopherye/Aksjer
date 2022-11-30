import {Aksje} from "./aksje";

export class Ordre {
    id: number;
    aksje: Aksje;
    type: string;
    antall: number;
    pris: number;
}