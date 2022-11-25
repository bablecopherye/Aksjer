export interface IOrdre {
    id: number,
    dato: string,
    tid: string,
    aksjenavn: string, //hentes fra Aksje-klassen
    ticker: string, //hentes fra Aksje-klassen
    kjopEllerSalg: boolean;
    antallAksjerKjoptEllerSolgt: number,
    kjopeEllerSalgsprisPerAksje: number,
    totalKjopeEllerSalgspris: number,
    boers: string //hentes fra Aksje-klassen
    ordreTilknyttetBruker: string
}
