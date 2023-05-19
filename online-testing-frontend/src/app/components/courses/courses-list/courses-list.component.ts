import {Component, Input} from '@angular/core';
import {ICourse} from "../../../models/course";

@Component({
  selector: 'app-courses-list',
  templateUrl: './courses-list.component.html'
})
export class CoursesListComponent {
  @Input() courses: ICourse[];
}
