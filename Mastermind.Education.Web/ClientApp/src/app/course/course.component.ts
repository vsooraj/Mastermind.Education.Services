import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-course-component',
  templateUrl: './course.component.html'
})
export class CourseComponent {
  public courses: Course[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Course[]>('http://localhost:58789/api/course/').subscribe(result => {
      this.courses = result;
    }, error => console.error(error));
  }
}

interface Course {
  id: number;
  name: string;
  noOfDays: number;

}

