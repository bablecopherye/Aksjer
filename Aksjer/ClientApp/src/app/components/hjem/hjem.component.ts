import { Component, OnInit} from "@angular/core";
import {Aksje} from "src/app/models/aksje";
import {AksjeService} from "../../services/aksje.service";

@Component({
    selector: 'hjem',
    templateUrl: './hjem.component.html',
    styleUrls: ['./hjem.component.css']
})
export class HjemComponent implements OnInit {
    
    constructor(
        private aksjeService: AksjeService,
    ) {}
    
    public alleAksjer: Array<Aksje> = [];
    public feilmelding: string = "";

    ngOnInit() {
        this.hentAlleAksjer();
    }

    hentAlleAksjer() {
        this.feilmelding = "Serverfeil";
        this.aksjeService.hentAlleAksjer()
            .subscribe({
                next: (data: Aksje[]) => this.alleAksjer = data,
                error: () => console.error(this.feilmelding),
                complete: () => console.info('Aksjeinfo er hentet fra server til klient')
            })
    }
}