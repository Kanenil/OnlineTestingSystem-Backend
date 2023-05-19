import {Component, Input} from '@angular/core';
import {FormControl} from "@angular/forms";

@Component({
  selector: 'app-password-group',
  templateUrl: './password-group.component.html'
})
export class PasswordGroupComponent {
  @Input() field: FormControl;
  @Input() name: string;
  @Input() triedSubmit: boolean;
}
