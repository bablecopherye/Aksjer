import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";

import { AppComponent } from './app.component';
import {HjemComponent} from "./components/hjem/hjem.component";
import {AksjeService} from "./services/aksje.service";
import {HandleModalComponent} from "./components/handle-modal/handle-modal.component";
import {NavMenyComponent} from "./components/nav-meny/nav-meny.component";
import {OrdrelisteComponent} from "./components/ordreliste/ordreliste.component";
import {AksjebeholdningComponent} from "./components/aksjebeholdning/aksjebeholdning.component";
import {BunnlinjeComponent} from "./components/bunnlinje/bunnlinje.component";
import {ProfilComponent} from "./components/profil/profil.component";
import {LoggInnModalComponent} from "./components/logg-inn-modal/logg-inn-modal.component";

@NgModule({
  declarations: [
    AppComponent,
    HjemComponent,
    HandleModalComponent,
    NavMenyComponent,
    OrdrelisteComponent,
    AksjebeholdningComponent,
    BunnlinjeComponent,
    ProfilComponent,
    LoggInnModalComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    RouterModule.forRoot([
      { path: '', component: HjemComponent, pathMatch: 'full' },
      { path: 'aksjebeholdning', component: AksjebeholdningComponent },
      { path: 'ordreliste', component: OrdrelisteComponent },
      { path: 'profil', component: ProfilComponent },
    ])
  ],
  providers: [AksjeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
