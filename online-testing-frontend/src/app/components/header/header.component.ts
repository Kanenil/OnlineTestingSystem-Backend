import {Component} from '@angular/core';
import {AuthService} from "../../services/auth.service";
import {ThemesService} from "../../services/themes.service";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  isOpenedMobileMenu = false;



  constructor(public authService: AuthService, public themesService: ThemesService) {

  }


}
