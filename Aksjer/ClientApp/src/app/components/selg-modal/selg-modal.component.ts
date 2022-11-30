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
