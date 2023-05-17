import { Injectable } from '@angular/core';
import {IAuthResponse, IRegisterUser, IUser} from "../models/auth";
import {catchError, Observable, retry, tap, throwError} from "rxjs";
import {HttpClient, HttpErrorResponse} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {LocalStorageService} from "./local-storage.service";
import jwt_decode from 'jwt-decode';
import {ErrorService} from "./error.service";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  user: IUser | null = null

  constructor(private http: HttpClient, private localStore: LocalStorageService, private errorService: ErrorService) {
    const token = localStore.getData('token');
    if(token) {
      this.user = this.decodeToken(token)
    }
  }

  login(email: string, password: string):Observable<IAuthResponse> {
    return this.http.post<IAuthResponse>(`${environment.apiUrl}/account/login`, {email,password})
      .pipe(
        tap(resp=>{
          console.log(resp)
          localStorage.setItem('token', resp.token);
          this.user = this.decodeToken(resp.token);
          return resp;
        }),
        retry(2),
        catchError(this.errorHandler.bind(this))
      );
  }

  register(model: IRegisterUser):Observable<IAuthResponse> {
    return this.http.post<IAuthResponse>(`${environment.apiUrl}/account/register`, model)
      .pipe(
        tap(resp=>{
          console.log(resp)
          localStorage.setItem('token', resp.token);
          this.user = this.decodeToken(resp.token);
          return resp;
        }),
        retry(2),
        catchError(this.errorHandler.bind(this))
      );
  }

  logout() {
    localStorage.removeItem('token');
    this.user = null;
  }

  private errorHandler(error: HttpErrorResponse) {
    this.errorService.handle(error.message)
    return throwError(()=>error.message)
  }

  private decodeToken(token: string): IUser | null {
    try {
      return jwt_decode<IUser>(token);
    } catch(Error) {
      return null;
    }
  }
}
