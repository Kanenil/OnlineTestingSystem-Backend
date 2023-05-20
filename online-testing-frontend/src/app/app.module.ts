import {ErrorHandler, NgModule} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginPageComponent } from './pages/auth/login-page/login-page.component';
import { RegisterPageComponent } from './pages/auth/register-page/register-page.component';
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
import { GoogleFinishPageComponent } from './pages/auth/google-finish-page/google-finish-page.component';
import {GlobalErrorHandler} from "./global-error-handler";
import { NotificationComponent } from './components/notifications/notification/notification.component';
import { PasswordGroupComponent } from './components/forms/password-group/password-group.component';
import { ModalNotificationComponent } from './components/notifications/modal-notification/modal-notification.component';
import { UserPageComponent } from './pages/profile/user-page/user-page.component';
import { UserCourseListComponent } from './components/courses/user-course-list/user-course-list.component';
import { MaxLenghtDotsPipe } from './pipes/max-lenght-dots.pipe';
import { UserCourseComponent } from './components/courses/user-course/user-course.component';
import { CoursesPageComponent } from './pages/courses/courses-page/courses-page.component';
import { CoursePageComponent } from './pages/courses/course-page/course-page.component';

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
    PasswordGroupComponent,
    ModalNotificationComponent,
    UserPageComponent,
    UserCourseListComponent,
    MaxLenghtDotsPipe,
    UserCourseComponent,
    CoursesPageComponent,
    CoursePageComponent,
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
