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

    if (!navigator.onLine)
      return 'No Internet Connection'

    if (error.error.ErrorMessage.includes(BackendErrors.GOOGLE_REGISTER)) {
      this.modalService.close();

      const token = localStorage.getItem('googleToken');
      this.router.navigate(['google', 'finish'], {queryParams: {token}})
      localStorage.removeItem('googleToken')

      return ''
    } else if (error.error.ErrorMessage.includes(BackendErrors.USER_WITH_SLUG_NOT_FOUND)) {
      this.router.navigate([".."])

      return ''
    } else {
      return error.message
    }

  }
}
