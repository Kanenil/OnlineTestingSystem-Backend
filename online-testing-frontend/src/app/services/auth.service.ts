import { Injectable } from '@angular/core';
import {IAuthResponse, IFinishGoogleRegistration, IRegisterUser, IUser} from "../models/auth";
import {catchError, Observable, retry, tap, throwError} from "rxjs";
import {HttpClient, HttpContext, HttpContextToken, HttpErrorResponse} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {LocalStorageService} from "./local-storage.service";
import jwt_decode from 'jwt-decode';
import {ErrorService} from "./error.service";
import {GlobalConstants} from "../GlobalConstants";

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
    return this.http.post<IAuthResponse>(`${environment.apiUrl}${GlobalConstants.routes.login}`, {email,password})
      .pipe(
        tap(resp=>this.saveUser(resp)),
        retry(2)
      );
  }

  register(model: IRegisterUser):Observable<IAuthResponse> {
    return this.http.post<IAuthResponse>(`${environment.apiUrl}${GlobalConstants.routes.register}`, model)
      .pipe(
        tap(resp=>this.saveUser(resp)),
        retry(2)
      );
  }

  googleLogin(googleToken: string): Observable<IAuthResponse> {
    localStorage.setItem('googleToken', googleToken)
    return this.http.post<IAuthResponse>(`${environment.apiUrl}${GlobalConstants.routes.googleLogin}`, {googleToken})
      .pipe(
        tap(resp=>{
          localStorage.removeItem('googleToken')
          return this.saveUser(resp)
        })
      );
  }

  googleRegistration(model: IFinishGoogleRegistration): Observable<IAuthResponse> {
    return this.http.post<IAuthResponse>(`${environment.apiUrl}${GlobalConstants.routes.googleRegister}`, model)
      .pipe(
        tap(resp=> this.saveUser(resp)),
        retry(2)
      );
  }

  logout() {
    localStorage.removeItem('token');
    this.user = null;
  }

  private saveUser(response: IAuthResponse):IAuthResponse {
    localStorage.setItem('token', response.token);
    this.user = this.decodeToken(response.token);
    return response;
  }

  private decodeToken(token: string): IUser | null {
    try {
      return jwt_decode<IUser>(token);
    } catch(Error) {
      return null;
    }
  }
}
