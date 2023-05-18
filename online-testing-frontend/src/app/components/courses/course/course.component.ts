import {AfterViewInit, Component, Input} from '@angular/core';
import {ICourse} from "../../../models/course";
import {AuthService} from "../../../services/auth.service";

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent {
  @Input() course : ICourse;


  constructor(public authService: AuthService) {
  }

}
