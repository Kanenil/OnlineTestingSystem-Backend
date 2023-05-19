import {Component, OnDestroy, OnInit} from '@angular/core';
import {AuthService} from "../../../services/auth.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ModalService} from "../../../services/modal.service";
import {SocialAuthService, SocialUser} from "@abacritt/angularx-social-login";

@Component({
  selector: 'app-login-modal',
  templateUrl: './login-modal.component.html'
})
export class LoginModalComponent implements OnInit, OnDestroy {
  constructor(
    private authService: AuthService,
    public modalService: ModalService,
    private socialService: SocialAuthService)
  {}

  isTriedSubmit = false;

  googleUser: SocialUser | null = null;

  ngOnInit() {
    this.socialService.authState.subscribe((user)=>{
      if(user) {
        this.googleUser = user;
        this.authService.googleLogin(user.idToken).subscribe(()=>{
          this.modalService.close();
        })
      }
    })
  }

  ngOnDestroy() {
    if(this.googleUser) {
      this.socialService.signOut();
      this.googleUser = null;
    }
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
      try {
        this.authService.login(this.form.controls.email.value as string, this.form.controls.password.value as string, true).subscribe(resp=>{
          this.modalService.close()
        })
      } catch (error) {
        console.log('error here', error)
      }

    } else {
      this.isTriedSubmit = true;
    }
  }
}
