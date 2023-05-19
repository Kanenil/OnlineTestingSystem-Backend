import { Component, HostListener, Input } from '@angular/core';
import { AuthService } from '../../../services/auth.service';

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




  @Input() authService: AuthService;
}
