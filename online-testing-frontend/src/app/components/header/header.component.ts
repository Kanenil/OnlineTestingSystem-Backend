import {Component} from '@angular/core';
import {AuthService} from "../../services/auth.service";
import {ThemesService} from "../../services/themes.service";
import {ModalService} from "../../services/modal.service";
import {LoginModalComponent} from "../modals/login-modal/login-modal.component";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent {
  constructor(
    public authService: AuthService,
    public themesService: ThemesService,
    private modalService: ModalService,
    private router: Router
  ) {}

  showLoginModal() {
    if(this.router.url !== '/login')
      this.modalService.show(LoginModalComponent);
  }
}
