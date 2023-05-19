import {Component, Input} from '@angular/core';
import {AuthService} from "../../../services/auth.service";

@Component({
  selector: 'app-mobile-menu',
  templateUrl: './mobile-menu.component.html'
})
export class MobileMenuComponent {
  isOpen = false;

  togglePopup() {
    this.isOpen = !this.isOpen;
  }

  @Input() authService: AuthService;
}
