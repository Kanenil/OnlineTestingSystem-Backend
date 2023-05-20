import {Component} from '@angular/core';
import {AuthService} from "../../services/auth.service";
import {ThemesService} from "../../services/themes.service";
import {ModalService} from "../../services/modal.service";
import {LoginModalComponent} from "../modals/login-modal/login-modal.component";
import {ActivatedRoute, Router} from "@angular/router";
import {IUser} from "../../models/users/User";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent {

  loginedUser: IUser | null = null;

  constructor(
    public authService: AuthService,
    public themesService: ThemesService,
    private modalService: ModalService,
    private router: Router
  ) {
    this.authService.user$.subscribe(user=>{
      this.loginedUser = user;
    })
  }

  showLoginModal() {
    if(this.router.url !== '/login')
      this.modalService.show(LoginModalComponent);
  }

}
