import {Component, Input} from '@angular/core';
import {ICourse} from "../../../models/courses/Course";

@Component({
  selector: 'app-courses-list',
  templateUrl: './courses-list.component.html'
})
export class CoursesListComponent {
  @Input() courses: ICourse[];
}
