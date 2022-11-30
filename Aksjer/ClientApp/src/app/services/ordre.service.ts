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

    private url_hent: string = "api/Ordre/HentAlleOrdre"
    private url_ny: string = "api/Ordre/HentAlleOrdre"

    /*
    OpprettNyOrdre(innOrdre, brukersSaldo) : Observable<IOrdre>{

        return this.http.post<IOrdre>(this.url_ny, )
            .pipe(catchError(this.feilhaandtering));
    }
    
     */

    HentAlleOrdre() : Observable<IOrdre[]>{

        return this.http.get<IOrdre[]>(this.url_hent)
            .pipe(catchError(this.feilhaandtering));
    }
    
    private feilhaandtering(error: HttpErrorResponse){
        return throwError( () => error);
    }
}
