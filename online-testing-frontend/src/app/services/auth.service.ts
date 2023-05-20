import {Injectable} from '@angular/core';
import {BehaviorSubject, catchError, NEVER, Observable, retry, Subject, tap, throwError} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {LocalStorageService} from "./local-storage.service";
import jwt_decode from 'jwt-decode';
import {GlobalConstants} from "../GlobalConstants";
import {NotificationService} from "./notification.service";
import {UsersService} from "./users.service";
import {ITokenUser} from "../models/auth/TokenUser";
import {IUser} from "../models/users/User";
import {IAuthResponse} from "../models/auth/AuthResponse";
import {IRegisterUser} from "../models/auth/RegisterUser";
import {IFinishGoogleRegistration} from "../models/auth/FinishGoogleRegistration";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  user$=new BehaviorSubject<IUser | null>(null);
  //user = this.user$.asObservable()

  constructor(
    private http: HttpClient,
    private localStore: LocalStorageService,
    private notificationService: NotificationService,
    private usersService : UsersService
  ) {
    const token = this.localStore.getData('token');
    if(token) {
      const decodeToken = this.decodeToken(token)
      if(decodeToken) {
        this.usersService.getBySlug(decodeToken.slug).subscribe(user=>{
          this.user$.next(user);
        })
      }
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
    this.user$.next(null);
    //this.user = null;
  }

  private saveUser(response: IAuthResponse):IAuthResponse {
    localStorage.setItem('token', response.token);
    const decodeToken = this.decodeToken(response.token);
    if(decodeToken) {
      this.usersService.getBySlug(decodeToken.slug).subscribe(user=>{
        this.user$.next(user);
      })
    }
    return response;
  }

  private decodeToken(token: string): ITokenUser | null {
    try {
      return jwt_decode<ITokenUser>(token);
    } catch(Error) {
      return null;
    }
  }
}
