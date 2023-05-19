import { Component } from '@angular/core';
import {NotificationService} from "../../services/notification.service";
import {ModalService} from "../../services/modal.service";

@Component({
  selector: 'app-global-notification',
  templateUrl: './notification.component.html'
})
export class NotificationComponent {
  constructor(
    public notificationService: NotificationService
  ) {}

}
