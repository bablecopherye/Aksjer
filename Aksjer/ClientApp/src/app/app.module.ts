// Modules:
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { NgApexchartsModule } from "ng-apexcharts";

// Components:
import { AppComponent } from './app.component';
import {HjemComponent} from "./components/hjem/hjem.component";
import {HandleModalComponent} from "./components/handle-modal/handle-modal.component";
import {NavMenyComponent} from "./components/nav-meny/nav-meny.component";
import {OrdrelisteComponent} from "./components/ordreliste/ordreliste.component";
import {AksjebeholdningComponent} from "./components/aksjebeholdning/aksjebeholdning.component";
import {BunnlinjeComponent} from "./components/bunnlinje/bunnlinje.component";
import {DiagramComponent} from "./components/diagram/diagram.component";
import {SelgModalComponent} from "./components/selg-modal/selg-modal.component";

// Services:
import {AksjeService} from "./services/aksje.service";
import {HandleService} from "./services/handle.service";
import {OrdreService} from "./services/ordre.service";
import {ValideringService} from "./services/validering.service";

@NgModule({
  declarations: [
    AppComponent,
    HjemComponent,
    HandleModalComponent,
    NavMenyComponent,
    OrdrelisteComponent,
    AksjebeholdningComponent,
    BunnlinjeComponent,
    DiagramComponent,
    SelgModalComponent
  ],
    imports: [
        BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
        HttpClientModule,
        FormsModule,
        NgbModule,
        NgApexchartsModule,
        RouterModule.forRoot([
            {path: '', component: HjemComponent, pathMatch: 'full'},
            {path: 'aksjebeholdning', component: AksjebeholdningComponent},
            {path: 'ordreliste', component: OrdrelisteComponent},
        ]),
        ReactiveFormsModule
    ],
  providers: [AksjeService, HandleService, OrdreService, ValideringService],
  bootstrap: [AppComponent]
})
export class AppModule { }
