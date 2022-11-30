import { Component, OnInit} from "@angular/core";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";

@Component({
    selector: 'selg-modal',
    templateUrl: './selg-modal.component.html',
    styleUrls: ['./selg-modal.component.css']
})
export class SelgModalComponent {

    constructor(
        private modalService: NgbModal
    ) {}

    open(dialogboksen) {
        this.modalService.open(dialogboksen, { centered: true});
    }
}





/*


// Sjekker om aksjen som selges finnes i beholdningen til bruker
if (funnetAksje == null)
{
    _log.LogInformation("Aksjen kan ikke selges ettersom den ikke eksisterer i brukers beholdning");
    return false;
}

// Sjekker om bruker har nok aksjer til å selge
if (brukersAksjer.AntallAksjerEid < nyOrdreRad.Antall)
{
    _log.LogInformation("Det er ikke nok aksjer i beholdningen til å gjennomføre salget");
    return false;
}

eksisterendeAksjeIBeholdningen.Kostpris -= nyOrdreRad.Pris;
eksisterendeAksjeIBeholdningen.AntallAksjerEid -= nyOrdreRad.Antall;

// Ny ordrerad legges til, brukers saldo oppdateres, antall aksjer i markedet oppdateres,
// samt kostpris og antall akskjer eid i brukers aksjebeholdning
_db.Ordrer.Add(nyOrdreRad);
_db.Aksjer.Update(aktuellAksje);
_db.Aksjebeholdninger.Update(eksisterendeAksjeIBeholdningen);

*/
