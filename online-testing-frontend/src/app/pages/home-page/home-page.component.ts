import { Component } from '@angular/core';
import {CoursesService} from "../../services/courses.service";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html'
})
export class HomePageComponent {
  isLoading = false

  constructor(public coursesService: CoursesService, private http: HttpClient) {
    if(!coursesService.courses.length) {
      this.isLoading = true
      coursesService.getAll().subscribe(()=>{
        this.isLoading = false
      })
    }
  }
}
