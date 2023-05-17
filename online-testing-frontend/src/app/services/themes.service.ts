import {Injectable, OnInit} from '@angular/core';
import {GlobalConstants} from "../GlobalConstants";
import {BehaviorSubject} from "rxjs";
import {LocalStorageService} from "./local-storage.service";

@Injectable({
  providedIn: 'root'
})
export class ThemesService {
  isDarkEnable = true

  constructor(private localStore: LocalStorageService) {
  }

  initTheme() {
    const savedTheme = this.localStore.getData(GlobalConstants.darkMode);
    this.isDarkEnable = savedTheme?true:false
  }

  changeTheme() {
    if (!this.isDarkEnable)
      this.localStore.saveData(GlobalConstants.darkMode, 'dark');
    else
      this.localStore.removeData(GlobalConstants.darkMode)
    this.isDarkEnable = !this.isDarkEnable;
  }
}
