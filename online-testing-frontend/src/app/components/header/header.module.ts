import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ThemeSwitcherComponent} from "./theme-switcher/theme-switcher.component";
import {ProfileMenuComponent} from "./profile-menu/profile-menu.component";
import {NotificationComponent} from "./notification/notification.component";
import {MobileMenuComponent} from "./mobile-menu/mobile-menu.component";
import {RouterModule} from "@angular/router";

@NgModule({
  declarations: [
    ThemeSwitcherComponent,
    ProfileMenuComponent,
    NotificationComponent,
    MobileMenuComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    ThemeSwitcherComponent,
    ProfileMenuComponent,
    NotificationComponent,
    MobileMenuComponent
  ]
})
export class HeaderModule {
}
