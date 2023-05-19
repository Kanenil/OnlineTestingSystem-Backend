import {Injectable} from '@angular/core';
import {HttpErrorResponse} from "@angular/common/http";
import {BackendErrors} from "../enums/backend-errors";
import {Router} from "@angular/router";
import {ModalService} from "./modal.service";

@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  constructor(
    private router: Router,
    private modalService: ModalService
  ) {}

  getClientErrorMessage(error: Error): string {
    return error.message ?
      error.message :
      error.toString();
  }

  getServerErrorMessage(error: HttpErrorResponse): string {

    console.log(error)

    if(!navigator.onLine)
      return 'No Internet Connection'

    switch (error.error.ErrorMessage) {
      case BackendErrors.GOOGLE_REGISTER: {
        this.modalService.close();

        const token = localStorage.getItem('googleToken');
        this.router.navigate(['google','finish'], {queryParams: {token}})
        localStorage.removeItem('googleToken')

        return ''
      }
      default: return error.message
    }
  }

}
