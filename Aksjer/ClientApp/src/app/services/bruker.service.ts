import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import {IAksje} from "../models/aksje";
import {Observable, throwError} from "rxjs";
import {Injectable} from "@angular/core";
import {catchError} from "rxjs/operators";
import {IOrdre} from "../models/ordre";
import {IBruker} from "../models/bruker";

@Injectable({
    providedIn: 'root'
})
export class BrukerService {

    constructor(private http: HttpClient) { }

    private url: string = "api/Bruker/"

    hentBruker() : Observable<IBruker>{

        return this.http.get<IBruker>(this.url)
        // .pipe(catchError(this.feilhaandtering));
    }

    /*
    private feilhaandtering(error: HttpErrorResponse){
        return throwError( () => error);
    }
    
     */
}
