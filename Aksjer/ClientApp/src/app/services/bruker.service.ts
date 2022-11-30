import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import {Observable, throwError} from "rxjs";
import {Injectable} from "@angular/core";
import {catchError} from "rxjs/operators";
import {IBruker} from "../models/bruker";

@Injectable({
    providedIn: 'root'
})
export class BrukerService {

    constructor(private http: HttpClient) {
    }

    private urlHent: string = "api/Bruker/"

    hentBruker(): Observable<IBruker> {

        return this.http.get<IBruker>(this.urlHent)
        // .pipe(catchError(this.feilhaandtering));
    }

    /*
    private feilhaandtering(error: HttpErrorResponse){
        return throwError( () => error);
    }
    
     */
    
}