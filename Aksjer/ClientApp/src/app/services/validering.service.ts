import {Injectable} from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class ValideringService {

    constructor() { }

    public feilBrukernavn: string;
    public feilPassord: string;

    validerBrukernavn(brukernavn) {
        const regexp = /^[a-zA-ZæøåÆØÅ. \-]{2,20}$/;
        const ok = regexp.test(brukernavn);
        if (!ok) {
            this.feilBrukernavn = "Brukernavnet må bestå av 2 til 20 tegn!"
            return false;
        } else {
            this.feilBrukernavn = ""
            return true
        }
    }

    validerPassord(passord) {
        const regexp = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$/;
        const ok = regexp.test(passord);
        if (!ok) {
            this.feilPassord = "Passordet må bestå minumum 6 tegn, minst en bokstav og et tall!";
            return false;
        } else {
            this.feilPassord = "";
            return true
        }
    }

}