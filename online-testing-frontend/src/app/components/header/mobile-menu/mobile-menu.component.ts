import {Component, Input} from '@angular/core';
import {AuthService} from "../../../services/auth.service";

@Component({
  selector: 'app-mobile-menu',
  templateUrl: './mobile-menu.component.html',
  styleUrls: ['./mobile-menu.component.scss']
})
export class MobileMenuComponent {
  isOpen = false;

  togglePopup() {
    this.isOpen = !this.isOpen;
  }

  @Input() authService: AuthService;
}
