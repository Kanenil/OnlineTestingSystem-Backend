import {Component} from '@angular/core';
import {AuthService} from "../../services/auth.service";
import {ThemesService} from "../../services/themes.service";
import {ModalService} from "../../services/modal.service";
import {LoginModalComponent} from "../modals/login-modal/login-modal.component";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  constructor(
    public authService: AuthService,
    public themesService: ThemesService,
    private modalService: ModalService
  ) {}

  showLoginModal() {
    this.modalService.show(LoginModalComponent);
  }
}
