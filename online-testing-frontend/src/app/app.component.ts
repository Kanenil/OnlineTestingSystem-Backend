import {Component, OnInit} from '@angular/core';
import {ThemesService} from "./services/themes.service";
import {ModalService} from "./services/modal.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  constructor(
    public themesService : ThemesService,
    public modalService: ModalService
  ) {
  }

  ngOnInit() {
    this.themesService.initTheme()
  }
}
