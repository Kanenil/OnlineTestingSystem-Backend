import {Component} from '@angular/core';
import {AuthService} from "../../services/auth.service";
import {Router} from "@angular/router";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {IRegisterUser} from "../../models/auth";

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html'
})
export class RegisterPageComponent {

  isTriedSubmit = false;

  form = new FormGroup({
    firstName: new FormControl<string>('', [
      Validators.required,
    ]),
    lastName: new FormControl<string>('', [
      Validators.required,
    ]),
    email: new FormControl<string>('', [
      Validators.required,
      Validators.email
    ]),
    password: new FormControl<string>('', [
      Validators.required,
      Validators.minLength(6)
    ]),
    confirm: new FormControl<string>('', [
      Validators.required,
      Validators.minLength(6)
    ])
  })

  constructor(private authService: AuthService, private router: Router) {
    if (authService.user) router.navigateByUrl('')

    this.form.controls.confirm.addValidators(()=>{
      if (this.form.controls.password.value !== this.form.controls.confirm.value)
        return {match: 'Passwords are different'};
      return null;
    })

  }

  submit() {
    if (this.form.status == 'VALID') {
      const data : IRegisterUser = {
        firstName: this.form.controls.firstName.value as string,
        lastName: this.form.controls.lastName.value as string,
        password: this.form.controls.password.value as string,
        confirmPassword: this.form.controls.confirm.value as string,
        userName: this.form.controls.email.value as string,
        email: this.form.controls.email.value as string,
      }
      this.authService.register(data).subscribe(resp => {
        this.router.navigateByUrl('/')
      })
    } else {
      this.isTriedSubmit = true;
    }
  }


}
