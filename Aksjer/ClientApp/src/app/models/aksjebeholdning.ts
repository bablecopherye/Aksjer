export interface IAksjebeholdning {
    ticker: string, //hentes fra Aksje-klassen
    aksjenavn: string, //hentes fra Aksje-klassen
    antallAksjerIBeholdning: number,
    kostprisPerAksje: number,
    kostpris: number,
    naaverdi: number,
    avkastningIKr: number,
    avkastningIProsent: number,
    boers: string //hentes fra Aksje-klassen
    beholdningTilknyttetBruker
}