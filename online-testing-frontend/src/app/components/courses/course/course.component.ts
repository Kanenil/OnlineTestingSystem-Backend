import {Component, Input, OnChanges, SimpleChanges} from '@angular/core';
import {ICourse} from "../../../models/courses/Course";
import {IUser} from "../../../models/users/User";
import {IRole} from "../../../models/Role";

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html'
})
export class CourseComponent implements OnChanges {
  @Input() course: ICourse;

  owner: { role: IRole; user: IUser } ;

  ngOnChanges(changes: SimpleChanges) {
    if (changes.course.currentValue) {
      this.course = changes.course.currentValue;
      this.owner = this.course.users.filter(value=>value.role.name === "Owner")[0];
    }
  }


}
