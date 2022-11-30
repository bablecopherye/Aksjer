import { Component, OnInit} from "@angular/core";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { Ordre } from "../../models/ordre";
import {FormGroup, FormControl, Validators, FormBuilders, FormBuilder} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {OrdreService} from "../../services/ordre.service";

@Component({
    selector: 'handle-modal',
    templateUrl: './handle-modal.component.html',
    styleUrls: ['./handle-modal.component.css']
})
export class HandleModalComponent {

    kjopeskjema: FormGroup;

    constructor(
        private modalService: NgbModal,
        private _http: HttpClient, 
        private fb: FormBuilder,
        private ordreService: OrdreService
    ) {}

    ngOnInit() {
        this.hentAksje();
    }


    open(dialogboksen) {
        this.modalService.open(dialogboksen, { centered: true});
    }

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


// Hvis det ikke selges, så skal det kjøpes
else
{

    {
        _log.LogInformation("Bruker har ikke nok penger på konten sin");
        return false;
    }


    // Den nye ordreraden får inn data
    nyOrdreRad.Id = innOrdre.Id;
    nyOrdreRad.Aksje = innOrdre.Aksje;
    nyOrdreRad.Type = innOrdre.Type;
    nyOrdreRad.Antall = innOrdre.Antall;
    nyOrdreRad.Pris = innOrdre.Pris;




    // Ny ordrerad legges til, brukers saldo oppdateres og antall aksjer i markedet oppdateres
    _db.Ordrer.Add(nyOrdreRad);
    _db.Aksjer.Update(aktuellAksje);

    // Hvis aksjen ikke finnes i beholdningen fra før, så legges den til
    if (funnetAksje == null)
    {
        _db.Aksjebeholdninger.Add(nyAksjeIBeholdningen);
    }

    eksisterendeAksjeIBeholdningen.Kostpris += nyOrdreRad.Pris;
    eksisterendeAksjeIBeholdningen.AntallAksjerEid += nyOrdreRad.Antall;

    _db.Aksjebeholdninger.Update(eksisterendeAksjeIBeholdningen);

}

await _db.SaveChangesAsync();
return true;