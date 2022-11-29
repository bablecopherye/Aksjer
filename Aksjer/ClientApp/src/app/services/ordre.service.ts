import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import {IAksje} from "../models/aksje";
import {Observable, throwError} from "rxjs";
import {Injectable} from "@angular/core";
import {catchError} from "rxjs/operators";
import {IOrdre} from "../models/ordre";

@Injectable({
    providedIn: 'root'
})
export class OrdreService {

    constructor(private http: HttpClient) { }

    private url: string = "api/Ordre/"

    hentAlleOrdreTilEnBruker(brukernavn) : Observable<IOrdre[]>{

        return this.http.get<IOrdre[]>(this.url)
        // .pipe(catchError(this.feilhaandtering));
    }

    /*
    private feilhaandtering(error: HttpErrorResponse){
        return throwError( () => error);
    }
    
     */
}
