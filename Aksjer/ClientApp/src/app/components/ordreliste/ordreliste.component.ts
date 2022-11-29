import { Component, OnInit} from "@angular/core";
import {OrdreService} from "../../services/ordre.service";
import {IOrdre} from "../../models/ordre";
import {IBruker} from "../../models/bruker";
import {BrukerService} from "../../services/bruker.service";

@Component({
    selector: 'ordreliste',
    templateUrl: './ordreliste.component.html',
    styleUrls: ['./ordreliste.component.css']
})
export class OrdrelisteComponent implements OnInit {

    constructor(
        private ordreService: OrdreService,
        private brukerService: BrukerService
    ) {}

    public alleOrdreTilEnBruker: Array<IOrdre> = [];
    public feilmelding: string = "";
    public bruker: IBruker;
    public brukernavn: string = this.bruker.brukernavn;

    ngOnInit() {
        this.hentBrukernavn();
        this.hentAlleOrdre();
    }

    hentBrukernavn() {
        this.feilmelding = "Serverfeil";
        this.brukerService.hentBruker()
            .subscribe({
                next: (data: IBruker) => this.bruker = data,
                error: () => console.error(this.feilmelding),
                complete: () => console.info('Bruker er hentet')
            })
    }

    hentAlleOrdre() {
        this.feilmelding = "Serverfeil";
        this.ordreService.hentAlleOrdreTilEnBruker(this.brukernavn)
            .subscribe({
                next: (data: IOrdre[]) => this.alleOrdreTilEnBruker = data,
                error: () => console.error(this.feilmelding),
                complete: () => console.info('Alle ordre til en bruker er hentet fra server til klient')
            })
    }
}