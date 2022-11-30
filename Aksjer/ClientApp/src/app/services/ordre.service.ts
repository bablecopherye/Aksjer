import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import {Observable, throwError} from "rxjs";
import {Injectable} from "@angular/core";
import {catchError} from "rxjs/operators";
import {Ordre} from "../models/ordre";

@Injectable({
    providedIn: 'root'
})
export class OrdreService {

    constructor(private http: HttpClient) { }

    private url: string = "api/Ordre/"
    
    OpprettNyOrdre(registrertKjop) : Observable<Ordre>{

        return this.http.post<Ordre>(this.url, registrertKjop)
            .pipe(catchError(this.feilhaandtering));
    }

    HentAlleOrdre() : Observable<Ordre[]>{

        return this.http.get<Ordre[]>(this.url)
            .pipe(catchError(this.feilhaandtering));
    }
    
    private feilhaandtering(error: HttpErrorResponse){
        return throwError( () => error);
    }
}
