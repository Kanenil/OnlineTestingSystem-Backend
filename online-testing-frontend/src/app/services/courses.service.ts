import {Injectable} from '@angular/core';
import {HttpClient, HttpErrorResponse} from "@angular/common/http";
import {catchError, delay, Observable, retry, tap, throwError} from "rxjs";
import {ICourse} from "../models/course";
import {environment} from "../../environments/environment";
import {LocalStorageService} from "./local-storage.service";
import {ErrorService} from "./error.service";
import {GlobalConstants} from "../GlobalConstants";

@Injectable({
  providedIn: 'root'
})
export class CoursesService {
  constructor(private http: HttpClient, private localStore: LocalStorageService, private errorService: ErrorService) {
  }

  courses: ICourse[] = []

  getAll(): Observable<ICourse[]> {
    return this.http.get<ICourse[]>(`${environment.apiUrl}${GlobalConstants.routes.courses}`)
      .pipe(
        tap(resp => {
          this.courses = resp;
          return resp;
        }),
        retry(2)
      );
  }

}
