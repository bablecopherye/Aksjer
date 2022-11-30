import {IAksje} from "./aksje";

export interface IAksjebeholdning {
    aksje: IAksje,
    antallAksjerIBeholdning: number,
    kostprisPerAksje: number,
    kostpris: number,
    naaverdi: number,
    avkastningIKr: number,
    avkastningIProsent: number,
}