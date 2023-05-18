import {Component, Input} from '@angular/core';
import {AuthService} from "../../../services/auth.service";

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.scss']
})
export class NotificationComponent {

  @Input() authService: AuthService;
}
