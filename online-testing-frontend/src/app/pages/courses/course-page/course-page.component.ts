import { Component } from '@angular/core';
import {ICourse} from "../../../models/courses/Course";
import {ActivatedRoute, Router} from "@angular/router";
import {AuthService} from "../../../services/auth.service";
import {Title} from "@angular/platform-browser";
import {CoursesService} from "../../../services/courses.service";
import {IRole} from "../../../models/Role";
import {IUser} from "../../../models/users/User";

@Component({
  selector: 'app-course-page',
  templateUrl: './course-page.component.html'
})
export class CoursePageComponent {
  course: ICourse | null;
  isLoading = false;

  isInCourse = false;
  owner: { role: IRole; user: IUser } ;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private coursesService: CoursesService,
    public authService: AuthService,
    private titleService:Title
  ) {
    this.route.paramMap.subscribe(params => {
      const slug = params.get('slug');
      if (slug) {
        this.isLoading = true;
        this.coursesService.getBySlug(slug).subscribe(course => {
          this.course = course;
          this.isLoading = false;
          this.owner = this.course.users.filter(value=>value.role.name === "Owner")[0];
          this.authService.user$.forEach(user=>{
            console.log(user)
            if(user && user.courses.length > 0) {
              this.isInCourse = !!user.courses.find(value=>value.course.id == course.id);
            } else {
              this.isInCourse = false;
            }
          })
          titleService.setTitle(`Smart Test - ${this.course?.name}`)
        })
      } else {
        this.router.navigate(['/not-found']);
      }
    })
  }
}
