import { NgModule } from '@angular/core';
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
import {AuthService} from "./services/auth.service";
import { ErrorComponent } from './components/error/error.component';
import { InputGroupComponent } from './components/forms/input-group/input-group.component';
import { ProfileMenuComponent } from './components/header/profile-menu/profile-menu.component';
import { CoursesListComponent } from './components/courses/courses-list/courses-list.component';
import { CourseComponent } from './components/courses/course/course.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    RegisterPageComponent,
    HomePageComponent,
    NotFoundPageComponent,
    HeaderComponent,
    ErrorComponent,
    InputGroupComponent,
    ProfileMenuComponent,
    CoursesListComponent,
    CourseComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
