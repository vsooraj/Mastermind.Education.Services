import { Component, Inject, OnInit} from '@angular/core';
import { Router } from '@angular/router';

import { CourseService } from '../services/course.service';
import { Course, SaveCourse } from '../models/course';


@Component({
  selector: 'app-course-component',
  templateUrl: './course.component.html'
})
export class CourseComponent implements OnInit{
  public courses: Course[];

  course: SaveCourse = {
    id:null,
    name: null,
    noOfDays: 0
  };

  constructor(
    private courseService: CourseService,
    private router: Router
  ) { }

  ngOnInit() {
    this.fetchData();
  }

  fetchData() {
    this.courseService.getCourses().subscribe(courses => {
      this.courses = courses;
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
          this.fetchData();
          this.router.navigate(['/course']);
        });
      this.fetchData();
    }
    else {
      this.courseService.create(this.course).subscribe(courses => {
        this.courses = courses;       
        this.fetchData();
        this.router.navigate(['/course']);
      });
      
    }  
  }
  deleteRow(index: number) {
    this.course.id = index;
   
     if (confirm("Are you sure?")) {
        this.courseService.delete(this.course.id)
          .subscribe(courses => {           
            this.router.navigate(['/course']);
          });
      
     }
  }

  //delete() {
  //  if (confirm("Are you sure?")) {
  //    this.vehicleService.delete(this.vehicle.id)
  //      .subscribe(x => {
  //        this.router.navigate(['/home']);
  //      });
  //  }
  //}
}


