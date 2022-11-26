import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";

import { AppComponent } from './app.component';
import {HjemComponent} from "./components/hjem/hjem.component";
import {AksjeService} from "./services/aksje.service";
import {HandleComponent} from "./components/handle/handle.component";
import {NavMenyComponent} from "./components/nav-meny/nav-meny.component";
import {OrdrelisteComponent} from "./components/ordreliste/ordreliste.component";
import {AksjebeholdningComponent} from "./components/aksjebeholdning/aksjebeholdning.component";

@NgModule({
  declarations: [
    AppComponent,
    HjemComponent,
    HandleComponent,
    NavMenyComponent,
    OrdrelisteComponent,
    AksjebeholdningComponent
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
    ])
  ],
  providers: [AksjeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
