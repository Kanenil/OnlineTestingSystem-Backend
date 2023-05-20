import {Component} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {UsersService} from "../../services/users.service";
import {IUser} from "../../models/users/User";
import {AuthService} from "../../services/auth.service";
import {Title} from "@angular/platform-browser";

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html'
})
export class UserPageComponent {
  user: IUser | null
  backgroundImage: string = "/assets/default-backgrounds/default-background-1.jpg";

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private usersService: UsersService,
    public authService: AuthService,
    private titleService:Title
  ) {
    this.route.paramMap.subscribe(params => {
      let ran = Math.round((Math.random() * 100) % 2) + 1;
      this.backgroundImage = `/assets/default-backgrounds/default-background-${ran}.jpg`;

      const slug = params.get('slug');
      if (slug) {
        this.usersService.getBySlug(slug).subscribe(user => {
          this.user = user;
          titleService.setTitle(`Smart Test - ${this.user.firstName} ${this.user.lastName}`)
        })
      } else {
        this.router.navigate(['/not-found']);
      }
    });
  }

}
