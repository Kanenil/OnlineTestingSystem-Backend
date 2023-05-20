import {Component, Input, OnChanges, SimpleChanges} from '@angular/core';
import {ICourse} from "../../../models/courses/Course";
import {IUser} from "../../../models/users/User";
import {IRole} from "../../../models/Role";

@Component({
  selector: 'app-user-course',
  templateUrl: './user-course.component.html'
})
export class UserCourseComponent {
  @Input() course: {
    role: IRole,
    course: ICourse
  };
  @Input() user: IUser;
}
