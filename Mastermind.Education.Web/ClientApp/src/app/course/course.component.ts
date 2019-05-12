import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { CourseService } from '../services/course.service';
import { Course, SaveCourse } from '../models/course';


@Component({
  selector: 'app-course-component',
  templateUrl: './course.component.html'
})
export class CourseComponent {
  public courses: Course[];

  course: SaveCourse = {
    id:null,
    name: null,
    noOfDays: 0
  };

  constructor(private courseService: CourseService) { }

  ngOnInit() {
    this.fetchData();
  }

  fetchData() {
    this.courseService.getCourses().subscribe(courses => {
      this.courses = courses;
      console.log(this.courses);
    });
  }

  onSubmit() {
    if (this.course.id) {
      this.courseService.update(this.course)
        .subscribe(x => {
          console.log(this.courses);
          //this.toastyService.success({
          //  title: 'Success',
          //  msg: 'The Course was sucessfully updated.',
          //  theme: 'bootstrap',
          //  showClose: true,
          //  timeout: 5000
          //});
        });
      this.fetchData();
    }
    else {
      this.courseService.create(this.course).subscribe(courses => {
        this.courses = courses;
        console.log(this.courses);
      });
      this.fetchData();
    }  
  }
  deleteRow(index: number) {
    this.course.id = index;
   
    if (confirm("Are you sure?")) {
      this.courseService.delete(this.course.id)
        .subscribe(x => {
          console.log(this.courses);
          //this.router.navigate(['/home']);
        });
      this.fetchData();
    }
  }
}


