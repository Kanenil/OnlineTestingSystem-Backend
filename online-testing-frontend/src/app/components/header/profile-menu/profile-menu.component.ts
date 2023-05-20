import {Component, EventEmitter, HostListener, Input, OnDestroy, OnInit, Output} from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import {IUser} from "../../../models/users/User";

@Component({
  selector: 'app-profile-menu',
  templateUrl: './profile-menu.component.html'
})
export class ProfileMenuComponent {
  isOpen = false;

  togglePopup() {
    this.isOpen = !this.isOpen;
  }

  @HostListener('document:click', ['$event'])
  onDocumentClick(event: MouseEvent) {
    const element = event.target as HTMLElement;
    const isClickedInsideMenu = element.closest('#profile-menu');
    const isMenuButtonClose = element.closest('#user-menu-button');
    if (!isClickedInsideMenu && this.isOpen && !isMenuButtonClose) {
      this.isOpen = false;
    }
  }

  @Input() loginedUser : IUser;
  @Output() logout:EventEmitter<void> = new EventEmitter()
}
