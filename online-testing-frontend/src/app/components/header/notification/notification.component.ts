import {Component, Input} from '@angular/core';
import {IUser} from "../../../models/users/User";

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html'
})
export class NotificationComponent {

  @Input() loginedUser: IUser| null;
}
