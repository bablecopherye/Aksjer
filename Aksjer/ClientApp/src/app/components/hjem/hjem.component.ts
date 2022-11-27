import { Component, OnInit} from "@angular/core";
import { IAksje } from "src/app/models/aksje";
import {AksjeService} from "../../services/aksje.service";
import {HandleService} from "../../services/handle.service";
// import * as moment from 'moment'

@Component({
    selector: 'hjem',
    templateUrl: './hjem.component.html',
    styleUrls: ['./hjem.component.css']
})
export class HjemComponent implements OnInit {
/*
    idag = moment();
    
    hentFormatertDatoOgTid() {
        console.log(this.idag);
    }
    
    
 */
    
    constructor(
        private aksjeService: AksjeService,
        // private handleService: HandleService
    ) {}
    
    public alleAksjer: Array<IAksje> = [];
    public feilmelding: string = "";

    ngOnInit() {
        this.hentAlleAksjer();
    }

    hentAlleAksjer() {
        this.feilmelding = "Serverfeil";
        this.aksjeService.hentAlleAksjer()
            .subscribe({
                next: (data: IAksje[]) => this.alleAksjer = data,
                error: () => console.error(this.feilmelding),
                complete: () => console.info('Aksjeinfo er hentet fra server til klient')
            })
    }
}