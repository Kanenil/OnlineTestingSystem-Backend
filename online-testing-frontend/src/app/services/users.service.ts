import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable, retry} from "rxjs";
import {IUser} from "../models/users/User";
import {environment} from "../../environments/environment";
import {GlobalConstants} from "../GlobalConstants";

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(
    private http: HttpClient
  ){}

  getBySlug(slug:string):Observable<IUser> {
    return this.http.get<IUser>(`${environment.apiUrl}${GlobalConstants.routes.usersBySlug}/${slug}`)
      .pipe(
        retry(2),
      );
  }

  getById(id:string | number):Observable<IUser> {
    return this.http.get<IUser>(`${environment.apiUrl}${GlobalConstants.routes.usersById}/${id}`)
      .pipe(
        retry(2),
      );
  }

}
