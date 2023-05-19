import { AfterViewInit, Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { SocialAuthService } from '@abacritt/angularx-social-login';
import { LocalStorageService } from '../../services/local-storage.service';
import jwt_decode from 'jwt-decode';

@Component({
  selector: 'app-google-finish-page',
  templateUrl: './google-finish-page.component.html'
})
export class GoogleFinishPageComponent implements AfterViewInit {
  constructor(
    private authService: AuthService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {}

  googleUser: any;
  googleToken: any;

  form = new FormGroup({
    firstName: new FormControl<string>('', [Validators.required]),
    lastName: new FormControl<string>('', [Validators.required])
  });

  ngAfterViewInit(): void {
    this.activatedRoute.queryParams.subscribe(params => {
      this.googleUser = jwt_decode(params.token);
      this.googleToken = params.token as string;

      //Добавити валідацію на params і на кінець життя токена з редіректом на головну

      setTimeout(() => {
        this.form.setValue({
          firstName: this.googleUser.given_name || '',
          lastName: this.googleUser.family_name || ''
        })
      });
    });
  }

  getFirstName(): string {
    return this.form.get('firstName')?.value as string;
  }

  getLastName(): string {
    return this.form.get('lastName')?.value as string;
  }

  submit() {
    if (this.form.status == 'VALID') {
      this.authService.googleRegistration({
        firstName: this.getFirstName(),
        lastName: this.getLastName(),
        image: this.googleUser.picture,
        token: this.googleToken
      }).subscribe(()=>{
        this.router.navigateByUrl('/');
      })
    } else {
      throw new Error('You not fill all fields! Fill empty fields.');
    }
  }
}
