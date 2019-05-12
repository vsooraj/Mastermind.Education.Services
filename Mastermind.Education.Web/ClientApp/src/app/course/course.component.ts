import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CourseService } from '../services/course.service';
import { Course } from '../models/course';

@Component({
  selector: 'app-course-component',
  templateUrl: './course.component.html'
})
export class CourseComponent {
  public courses: Course[];

  constructor(private courseService: CourseService) { }

ngOnInit() {
  this.courseService.getCourses().subscribe(courses => {
    this.courses = courses;
    console.log(this.courses);
  });
}
}


