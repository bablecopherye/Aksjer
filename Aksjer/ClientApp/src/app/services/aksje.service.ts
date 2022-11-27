import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import {IAksje} from "../models/aksje";
import {Observable, throwError} from "rxjs";
import {Injectable} from "@angular/core";
import {catchError} from "rxjs/operators";

@Injectable({
    providedIn: 'root'
})
export class AksjeService {

    constructor(private http: HttpClient) { }

    private urlTilAksjeKlasse: string = "api/Aksje/"

    hentAlleAksjer() : Observable<IAksje[]>{

        return this.http.get<IAksje[]>(this.urlTilAksjeKlasse)
           // .pipe(catchError(this.feilhaandtering));
    }

    /*
    private feilhaandtering(error: HttpErrorResponse){
        return throwError( () => error);
    }
    
     */
}
