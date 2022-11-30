import { Component, OnInit} from "@angular/core";
import {OrdreService} from "../../services/ordre.service";
import { Ordre } from "../../models/ordre";

@Component({
    selector: 'ordreliste',
    templateUrl: './ordreliste.component.html',
    styleUrls: ['./ordreliste.component.css']
})
export class OrdrelisteComponent implements OnInit {

    constructor(
        private ordreService: OrdreService,
    ) {}

    public alleOrdre: Array<Ordre> = [];
    public feilmelding: string = "Klarte ikke hente ordrene";

    ngOnInit() {
        this.hentAlleOrdre();
    }

    hentAlleOrdre() {
        this.feilmelding = "Serverfeil";
        this.ordreService.HentAlleOrdre()
            .subscribe({
                next: (data: Ordre[]) => this.alleOrdre = data,
                error: () => console.error(this.feilmelding),
                complete: () => console.info('Alle ordre er hentet fra server til klient')
            })
    }
}