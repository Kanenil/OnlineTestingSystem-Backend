import { Component } from '@angular/core';
import {NotificationService} from "../../../services/notification.service";

@Component({
  selector: 'app-global-notification',
  templateUrl: './notification.component.html'
})
export class NotificationComponent {

  message:string;
  isModal:boolean;
  isError:boolean;
  constructor(
    public notificationService: NotificationService
  ) {
    this.notificationService.message$.subscribe((value: string) => {
      this.message = value;
    });
    this.notificationService.isModal$.subscribe((value: boolean) => {
      this.isModal = value;
    });
    this.notificationService.isModal$.subscribe((value: boolean) => {
      this.isError = value;
    });
  }

}
