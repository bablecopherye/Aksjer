import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import {Aksje} from "../models/aksje";
import {Observable, throwError} from "rxjs";
import {Injectable} from "@angular/core";
import {catchError} from "rxjs/operators";

@Injectable({
    providedIn: 'root'
})
export class AksjeService {

    constructor(private http: HttpClient) { }

    private urlTilAksjeKlasse: string = "api/Aksje/"

    hentAlleAksjer() : Observable<Aksje[]>{

        return this.http.get<Aksje[]>(this.urlTilAksjeKlasse)
           .pipe(catchError(this.feilhaandtering));
    }
    
    private feilhaandtering(error: HttpErrorResponse){
        return throwError( () => error);
    }
}
