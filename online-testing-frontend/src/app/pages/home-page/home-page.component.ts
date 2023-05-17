import { Component } from '@angular/core';
import {CoursesService} from "../../services/courses.service";

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent {

  isLoading = false

  constructor(public coursesService: CoursesService) {
    this.isLoading = true
    coursesService.getAll().subscribe(()=>{
      this.isLoading = false
    })
  }

}
