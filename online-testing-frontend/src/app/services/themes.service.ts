import {Injectable, OnInit} from '@angular/core';
import {GlobalConstants} from "../GlobalConstants";
import {BehaviorSubject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class ThemesService implements OnInit {
  isDarkEnable = false
  presentTheme$ = new BehaviorSubject<string>('');

  ngOnInit() {
    const savedTheme = localStorage.getItem(GlobalConstants.darkMode);
    if (savedTheme) {
      this.presentTheme$.next(savedTheme);
    }
  }

  changeTheme() {
    this.presentTheme$.value === ''
      ? this.presentTheme$.next('dark')
      : this.presentTheme$.next('');
    localStorage.setItem(GlobalConstants.darkMode, this.presentTheme$.value);
    this.isDarkEnable = !this.isDarkEnable;
  }
}
