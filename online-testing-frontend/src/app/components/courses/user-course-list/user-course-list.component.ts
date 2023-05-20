import {Component, Input} from '@angular/core';
import {ICourse} from "../../../models/courses/Course";
import {IRole} from "../../../models/Role";
import {IUser} from "../../../models/users/User";

@Component({
  selector: 'app-user-course-list',
  templateUrl: './user-course-list.component.html'
})
export class UserCourseListComponent {
  @Input() courses: {
    role: IRole,
    course: ICourse
  }[];
  @Input() user: IUser;
}
