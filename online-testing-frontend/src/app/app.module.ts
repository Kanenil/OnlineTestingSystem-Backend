import {ErrorHandler, NgModule} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { RegisterPageComponent } from './pages/register-page/register-page.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { HeaderComponent } from './components/header/header.component';
import {HttpClientModule} from "@angular/common/http";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { InputGroupComponent } from './components/forms/input-group/input-group.component';
import { CoursesListComponent } from './components/courses/courses-list/courses-list.component';
import { CourseComponent } from './components/courses/course/course.component';
import { FooterComponent } from './components/footer/footer.component';
import { ModalComponent } from './components/modals/modal/modal.component';
import { LoginModalComponent } from './components/modals/login-modal/login-modal.component';
import {HeaderModule} from "./components/header/header.module";

import {
  SocialLoginModule,
  SocialAuthServiceConfig,
  GoogleSigninButtonModule
} from '@abacritt/angularx-social-login';
import {
  GoogleLoginProvider
} from '@abacritt/angularx-social-login';
import {environment} from "../environments/environment";
import { GoogleFinishPageComponent } from './pages/google-finish-page/google-finish-page.component';
import {GlobalErrorHandler} from "./global-error-handler";
import { NotificationComponent } from './components/notification/notification.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    RegisterPageComponent,
    HomePageComponent,
    NotFoundPageComponent,
    HeaderComponent,
    InputGroupComponent,
    CoursesListComponent,
    CourseComponent,
    FooterComponent,
    ModalComponent,
    LoginModalComponent,
    GoogleFinishPageComponent,
    NotificationComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    HeaderModule,
    SocialLoginModule,
    GoogleSigninButtonModule
  ],
  providers: [
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              environment.googleClientId,{
                oneTapEnabled: false,
              }
            )
          }
        ],
        onError: (err) => {
          console.error(err);
        }
      } as SocialAuthServiceConfig,
    },
    { provide: ErrorHandler, useClass: GlobalErrorHandler },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
