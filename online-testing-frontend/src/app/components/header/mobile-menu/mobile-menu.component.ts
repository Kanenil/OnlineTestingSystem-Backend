import {Component, EventEmitter, Input, Output} from '@angular/core';
import {IUser} from "../../../models/users/User";

@Component({
  selector: 'app-mobile-menu',
  templateUrl: './mobile-menu.component.html'
})
export class MobileMenuComponent {
  isOpen = false;

  togglePopup() {
    this.isOpen = !this.isOpen;
  }

  @Input() loginedUser: IUser | null;
  @Output() logout:EventEmitter<void> = new EventEmitter()
}
