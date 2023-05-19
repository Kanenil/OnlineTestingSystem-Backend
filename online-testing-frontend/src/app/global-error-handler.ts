import {ErrorHandler, Injectable} from "@angular/core";
import {ErrorService} from "./services/error.service";
import {HttpErrorResponse} from "@angular/common/http";
import {Subject} from "rxjs";
import {NotificationService} from "./services/notification.service";

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {

  constructor(
    private errorService: ErrorService,
    private notificationService: NotificationService
  ) { }

  handleError(error: Error | HttpErrorResponse) {
    let message;

    if (error instanceof HttpErrorResponse) {
      // Server error
      message = this.errorService.getServerErrorMessage(error);
    } else {
      // Client Error
      message = this.errorService.getClientErrorMessage(error);
    }

    this.notificationService.showError(message)
  }

}
