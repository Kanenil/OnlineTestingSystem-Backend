import {Injectable} from '@angular/core';
import {HttpClient, HttpErrorResponse} from "@angular/common/http";
import {catchError, delay, Observable, retry, tap, throwError} from "rxjs";
import {ICourse} from "../models/courses/Course";
import {environment} from "../../environments/environment";
import {LocalStorageService} from "./local-storage.service";
import {ErrorService} from "./error.service";
import {GlobalConstants} from "../GlobalConstants";

@Injectable({
  providedIn: 'root'
})
export class CoursesService {
  constructor(private http: HttpClient) {
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

  getBySlug(slug: string) {
    return this.http.get<ICourse>(`${environment.apiUrl}${GlobalConstants.routes.coursesBySlug}/${slug}`)
      .pipe(
        retry(2)
      );
  }

}
