import { Component, OnInit} from "@angular/core";
import {BrukerService} from "../../services/bruker.service";
import {ValideringService} from "../../services/validering.service";
import {IBruker} from "../../models/bruker";

@Component({
    selector: 'logg-inn',
    templateUrl: './logg-inn.component.html',
    styleUrls: ['./logg-inn.component.css']
})
export class LoggInnComponent implements OnInit {
    
    public bruker: IBruker;
    
    public innBrukernavn: string;
    public feilBrukernavn: string = this.valideringService.feilBrukernavn;
    
    public innPassord: string;
    public feilPassord: string = this.valideringService.feilPassord;

    public feilmelding: string = "";
    
    constructor(
        private brukerService: BrukerService,
        private valideringService: ValideringService
    ) {}

    ngOnInit() {
    }
    
    
    loggInn() {
    let brukernavnOk = this.valideringService.validerBrukernavn(this.innBrukernavn);
    let passordOk = this.valideringService.validerPassord(this.innPassord);
        if (brukernavnOk && passordOk) {
            let bruker: IBruker = 
            {
                brukernavn: this.innBrukernavn,
                passord: this.innPassord,
            }
            
            let innlogging = this.brukerService.autentiser(bruker);
            
            

            if (innlogging = true) {
                window.location.href = 'index.html';
            }
            else {
                $("#feil").html("Feil brukernavn eller passord");
        }
    }
/*
    autentiser(brukernavn, passord) {
        this.feilmelding = "Serverfeil";
        this.brukerService.autentiser(brukernavn, passord)
            .subscribe({
                next: (data: IBruker) => this.bruker = data,
                error: () => console.error(this.feilmelding),
                complete: () => console.info('Bruker er hentet')
            })
    }
    
 */
}