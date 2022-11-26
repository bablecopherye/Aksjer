import { Component } from '@angular/core';

@Component({
    selector: 'nav-meny',
    templateUrl: './nav-meny.component.html',
    styleUrls: ['./nav-meny.component.css']
})
export class NavMenyComponent {
    isExpanded = false;

    collapse() {
        this.isExpanded = false;
    }

    toggle() {
        this.isExpanded = !this.isExpanded;
    }
}
