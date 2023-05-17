import {Component, OnInit} from '@angular/core';
import {ThemesService} from "./services/themes.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  constructor(public themesService : ThemesService) {
  }

  ngOnInit() {
    this.themesService.initTheme()
  }
}
