import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import {Aksje} from "../models/aksje";
import {Observable, throwError} from "rxjs";
import {Injectable} from "@angular/core";
import {catchError} from "rxjs/operators";
import {Aksjebeholdning} from "../models/aksjebeholdning";

@Injectable({
    providedIn: 'root'
})
export class AksjeService {

    constructor(private http: HttpClient) { }

    private url: string = "api/Aksje/"
    private url_beholdning: string = "api/Aksjebeholdning/"

    hentAlleAksjer() : Observable<Aksje[]>{

        return this.http.get<Aksje[]>(this.url)
           .pipe(catchError(this.feilhaandtering));
    }

    hentEnAksje() : Observable<Aksje>{

        return this.http.get<Aksje>(this.url+"hentenaksje")
            .pipe(catchError(this.feilhaandtering));
    }

    hentHeleAksjebeholdningen() : Observable<Aksjebeholdning[]>{

        return this.http.get<Aksjebeholdning[]>(this.url_beholdning)
            .pipe(catchError(this.feilhaandtering));
    }
    
    private feilhaandtering(error: HttpErrorResponse){
        return throwError( () => error);
    }
}
