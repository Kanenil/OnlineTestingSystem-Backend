import { Component, Input } from '@angular/core';
import {FormControl} from "@angular/forms";

@Component({
  selector: 'app-input-group',
  templateUrl: './input-group.component.html'
})
export class InputGroupComponent {
  @Input() field: FormControl;
  @Input() name: string;
  @Input() title: string;
  @Input() type: string;
}
