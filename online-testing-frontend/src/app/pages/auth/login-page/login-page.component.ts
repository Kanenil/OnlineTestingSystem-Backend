import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {AuthService} from "../../../services/auth.service";
import {Router} from "@angular/router";
import {NotificationService} from "../../../services/notification.service";
import {SocialAuthService} from "@abacritt/angularx-social-login";

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html'
})
export class LoginPageComponent implements OnInit {

  constructor(
    private authService: AuthService,
    private router: Router,
    private socialService: SocialAuthService
  ) {}

  ngOnInit() {
    this.socialService.authState.subscribe((user)=>{
      if(user) {
        this.authService.googleLogin(user.idToken).subscribe(()=>{

        })
      }
    })
  }

  isTriedSubmit = false;

  form = new FormGroup({
    email: new FormControl<string>('', [
      Validators.required,
      Validators.email
    ]),
    password: new FormControl<string>('', [
      Validators.required,
      Validators.minLength(6)
    ])
  })

  submit() {
    if(this.form.status == 'VALID') {
      this.authService.login(this.form.controls.email.value as string, this.form.controls.password.value as string).subscribe(()=>{
        this.router.navigateByUrl('/')
      })
    } else {
      this.isTriedSubmit = true;
    }
  }
}
