// Modules:
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
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
import {BrukerComponent} from "./components/bruker/bruker.component";
import {BrukerEndreInfoModalComponent} from "./components/bruker-endre-info-modal/bruker-endre-info-modal.component";
import {DiagramComponent} from "./components/diagram/diagram.component";
import {SelgModalComponent} from "./components/selg-modal/selg-modal.component";
import {LoggInnComponent} from "./components/logg-inn/logg-inn.component";

// Services:
import {AksjeService} from "./services/aksje.service";
import {HandleService} from "./services/handle.service";
import {OrdreService} from "./services/ordre.service";
import {BrukerService} from "./services/bruker.service";

@NgModule({
  declarations: [
    AppComponent,
    HjemComponent,
    HandleModalComponent,
    NavMenyComponent,
    OrdrelisteComponent,
    AksjebeholdningComponent,
    BunnlinjeComponent,
    BrukerComponent,
    LoggInnComponent,
    BrukerEndreInfoModalComponent,
    DiagramComponent,
    SelgModalComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    NgApexchartsModule,
    RouterModule.forRoot([
      { path: '', component: HjemComponent, pathMatch: 'full' },
      { path: 'aksjebeholdning', component: AksjebeholdningComponent },
      { path: 'ordreliste', component: OrdrelisteComponent },
      { path: 'bruker', component: BrukerComponent },
    ])
  ],
  providers: [AksjeService, HandleService, OrdreService, BrukerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
