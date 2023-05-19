import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {LoginPageComponent} from "./pages/login-page/login-page.component";
import {RegisterPageComponent} from "./pages/register-page/register-page.component";
import {HomePageComponent} from "./pages/home-page/home-page.component";
import {NotFoundPageComponent} from "./pages/not-found-page/not-found-page.component";
import {GoogleFinishPageComponent} from "./pages/google-finish-page/google-finish-page.component";

const routes: Routes = [
  {path: '', component: HomePageComponent, data: { title: 'Home' }},
  {path: 'login', component: LoginPageComponent, data: { title: 'Login' }},
  {path: 'register', component: RegisterPageComponent, data: { title: 'Register' }},
  {path: 'google/finish', component: GoogleFinishPageComponent, data: { title: 'Finish Registration' }},
  {path: '**', component: NotFoundPageComponent, data: { title: 'Not Found' }}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
