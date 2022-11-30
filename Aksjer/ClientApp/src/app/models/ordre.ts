import {IAksje} from "./aksje";

export interface IOrdre {
    id: number,
    dato: string,
    tid: string,
    aksje: IAksje,
    kjopEllerSalg: boolean;
    antallAksjerKjoptEllerSolgt: number,
    kjopeEllerSalgsprisPerAksje: number,
    totalKjopeEllerSalgspris: number,
    ordreTilknyttetBruker: string
}
