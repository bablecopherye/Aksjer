import {Injectable} from "@angular/core";


@Injectable({
    providedIn: 'root'
})
export class HandleService {

    visHandleAksjerVindu = false;
    
    constructor() { }

}








///////////////////////////


/*
import { Injectable } from '@angular/core';

import { ModalDirective } from 'ng-uikit-pro-standard';

import { NgbModal, ModalDismissReasons } from "@ng-bootstrap/ng-bootstrap";

@Injectable({

    providedIn:'root'

})

export class HandleService {

    yourModal:ModalDirective;

    constructor() { }

    setModal(modal:ModalDirective) {

        this.yourModal=modal;

    }

    visHandleModal() {

        this.yourModal.show();

    }

}
*/