import { Component } from '@angular/core';
import {AuthService} from "../../../services/auth.service";
import {Router} from "@angular/router";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ModalService} from "../../../services/modal.service";

@Component({
  selector: 'app-login-modal',
  templateUrl: './login-modal.component.html',
  styleUrls: ['./login-modal.component.scss']
})
export class LoginModalComponent {
  constructor(private authService: AuthService, private modalService: ModalService) {
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
        this.modalService.close()
      })
    }
  }
}
