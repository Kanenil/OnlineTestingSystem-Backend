import {Component, Input} from '@angular/core';
import {AuthService} from "../../../services/auth.service";

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html'
})
export class NotificationComponent {

  @Input() authService: AuthService;
}
