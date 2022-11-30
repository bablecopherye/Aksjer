import { Component, OnInit} from "@angular/core";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { Ordre } from "../../models/ordre";
import {FormGroup, FormBuilder} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {OrdreService} from "../../services/ordre.service";

@Component({
    selector: 'handle-modal',
    templateUrl: './handle-modal.component.html',
    styleUrls: ['./handle-modal.component.css']
})
export class HandleModalComponent {

    // kjopeskjema: FormGroup;

    constructor(
        private modalService: NgbModal,
        private _http: HttpClient,
        // private fb: FormBuilder,
        // private ordreService: OrdreService
    ) {}
    

    open(dialogboksen) {
        this.modalService.open(dialogboksen, {centered: true});
    }

}
/*
    vedSubmit() {
        this.registrerKjop();
    }

    registrerKjop() {
        const registrertKjop = new Ordre;
        
        registrertKjop.aksje = this.kjopeskjema.value.aksjenavn;
        registrertKjop.type = this.kjopeskjema.value.type;
        registrertKjop.antall = this.kjopeskjema.value.antall;
        registrertKjop.pris = this.kjopeskjema.value.prisperaksje;

        this.ordreService.OpprettNyOrdre(registrertKjop);
    };
    
}
*/