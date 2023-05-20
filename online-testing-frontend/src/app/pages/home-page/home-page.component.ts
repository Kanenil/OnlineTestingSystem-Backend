import { Component } from '@angular/core';
import {CoursesService} from "../../services/courses.service";
import {ICourse} from "../../models/courses/Course";
import {BehaviorSubject} from "rxjs";

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html'
})
export class HomePageComponent {
  isLoading = false
  courses$  = new BehaviorSubject<ICourse[]>([]);

  constructor(
    private coursesService: CoursesService
  ) {
    this.isLoading = true
    coursesService.getAll().subscribe(courses=>{
      this.courses$.next(courses);
      this.isLoading = false;
    })
  }
}
