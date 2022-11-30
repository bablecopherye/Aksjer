import { Component, OnInit} from "@angular/core";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";

@Component({
    selector: 'handle-modal',
    templateUrl: './handle-modal.component.html',
    styleUrls: ['./handle-modal.component.css']
})
export class HandleModalComponent {

    constructor(
        private modalService: NgbModal
    ) {}

    open(dialogboksen) {
        this.modalService.open(dialogboksen, { centered: true});
    }
}

var aktuellAksje = new Aksjer();
var brukerNySaldo = new Brukere();
var nyAksjeIBeholdningen = new Aksjebeholdninger();
var eksisterendeAksjeIBeholdningen = new Aksjebeholdninger();
var brukersAksjer = new Aksjebeholdning();
var funnetAksje = await _db.Aksjebeholdninger.FindAsync(aktuellAksje);

// Sjekker om det skal selges
if (innOrdre.Type == "Salg")
{
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

    brukerNySaldo.Saldo = brukersSaldo+nyOrdreRad.Pris;

    eksisterendeAksjeIBeholdningen.Kostpris -= nyOrdreRad.Pris;
    eksisterendeAksjeIBeholdningen.AntallAksjerEid -= nyOrdreRad.Antall;

    // Ny ordrerad legges til, brukers saldo oppdateres, antall aksjer i markedet oppdateres,
    // samt kostpris og antall akskjer eid i brukers aksjebeholdning
    _db.Ordrer.Add(nyOrdreRad);
    _db.Brukere.Update(brukerNySaldo);
    _db.Aksjer.Update(aktuellAksje);
    _db.Aksjebeholdninger.Update(eksisterendeAksjeIBeholdningen);



}

// Hvis det ikke selges, så skal det kjøpes
else
{
    // Sjekker om bruker har nok penger på kontoen sin til å gjennomføre kjøpet
    if (brukersSaldo < nyOrdreRad.Pris)
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

    brukerNySaldo.Saldo = brukersSaldo-nyOrdreRad.Pris;


    // Ny ordrerad legges til, brukers saldo oppdateres og antall aksjer i markedet oppdateres
    _db.Ordrer.Add(nyOrdreRad);
    _db.Brukere.Update(brukerNySaldo);
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