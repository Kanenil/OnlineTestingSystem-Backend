import { Component } from '@angular/core';
import {BehaviorSubject} from "rxjs";
import {ICourse} from "../../../models/courses/Course";
import {CoursesService} from "../../../services/courses.service";
import {AuthService} from "../../../services/auth.service";

@Component({
  selector: 'app-courses-page',
  templateUrl: './courses-page.component.html'
})
export class CoursesPageComponent {
  isLoading = false
  courses$  = new BehaviorSubject<ICourse[]>([]);

  constructor(
    private coursesService: CoursesService,
    public authService: AuthService
  ) {
    this.isLoading = true
    coursesService.getAll().subscribe(courses=>{
      this.courses$.next(courses);
      this.isLoading = false;
    })
  }
}
