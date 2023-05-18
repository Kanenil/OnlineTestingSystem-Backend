import {Component, Input} from '@angular/core';
import {ThemesService} from "../../../services/themes.service";

@Component({
  selector: 'app-theme-switcher',
  templateUrl: './theme-switcher.component.html',
  styleUrls: ['./theme-switcher.component.scss']
})
export class ThemeSwitcherComponent {

  @Input() themesService: ThemesService;
}