import { Component } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {AuthService} from "../../services/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html'
})
export class LoginPageComponent {

  constructor(private authService: AuthService, private router: Router) {
    if(authService.user) router.navigateByUrl('')
  }


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
      this.authService.login(this.form.controls.email.value as string, this.form.controls.password.value as string).subscribe(resp=>{
        this.router.navigateByUrl('/')
      })
    }
  }
}
