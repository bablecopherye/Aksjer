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