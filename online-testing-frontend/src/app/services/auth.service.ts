import { Injectable } from '@angular/core';
import {IAuthResponse, IFinishGoogleRegistration, IRegisterUser, IUser} from "../models/auth";
import {catchError, EMPTY, NEVER, Observable, retry, tap, throwError} from "rxjs";
import {HttpClient, HttpContext, HttpContextToken, HttpErrorResponse} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {LocalStorageService} from "./local-storage.service";
import jwt_decode from 'jwt-decode';
import {ErrorService} from "./error.service";
import {GlobalConstants} from "../GlobalConstants";
import {NotificationService} from "./notification.service";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  user: IUser | null = null

  constructor(
    private http: HttpClient,
    private localStore: LocalStorageService,
    private notificationService: NotificationService) {
    const token = localStore.getData('token');
    if(token) {
      this.user = this.decodeToken(token)
    }
  }

  login(email: string, password: string, isModal = false):Observable<IAuthResponse> {
    return this.http.post<IAuthResponse>(`${environment.apiUrl}${GlobalConstants.routes.login}`, {email,password})
      .pipe(
        tap(resp=>this.saveUser(resp)),
        retry(1),
        catchError((err)=>{

          if(err.status === 404 || err.error.ErrorMessage.includes('Credentials for ')) {
            this.notificationService.showError('The email or password is incorrect!', isModal);
            return NEVER
          }

          return throwError(()=>err.message)
        })
      );
  }

  register(model: IRegisterUser):Observable<IAuthResponse> {
    return this.http.post<IAuthResponse>(`${environment.apiUrl}${GlobalConstants.routes.register}`, model)
      .pipe(
        tap(resp=>this.saveUser(resp)),
        retry(1),
        catchError((err)=>{

          if(err.error.ErrorMessage.includes('already exists.')) {
            this.notificationService.showError('This email is registered!');
            return NEVER
          }

          return throwError(()=>err)
        })
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
