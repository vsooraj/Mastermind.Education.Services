import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { ActivatedRoute, Router } from '@angular/router';

import { SaveEnrollment, Enrollment } from './../models/enrollment';

import { EnrollmentService } from './../services/enrollment.service';
import { Student } from '../models/student';
import { Course, Grade } from '../models/course';



@Component({
  selector: 'app-enrollment-component',
  templateUrl: './enrollment.component.html'
})
export class EnrollmentComponent implements OnInit {

  grades: Grade[] = [
    { id: "A"},
    { id: "B"},
    { id: "C"}
  ];

  courses: Course[] = [
    { id: 1, name: "C#", noOfDays:30},
    { id: 2, name: "Angualr", noOfDays:60},
    { id: 3, name: ".NET Core", noOfDays:90}
  ];
  
   
  students: Student[] = [
    { id: 1, name: "Jon Doe" },
    { id: 2, name: "Jane Doe" },
    { id: 3, name: "Willy Doe" }
  ];
  noOfDays: any[] = [
    { id: 30, title: " 30" },
    { id: 60, title: " 60" },
    { id: 90, title: " 90" }
  ];


  enrollment: SaveEnrollment = {
    id: null,
    courseId: 0,
    studentId: 0,
    noOfDays: 30,
    grade: 'A'

  };

  public enrollments: Enrollment[];

  constructor(private enrollmentService: EnrollmentService) { }
  ngOnInit() {
    this.fetchData();
    //this.grades = this.enrollmentService.getGrades();
    //this.courses = this.enrollmentService.getCourses();
  }
  //ngOnInit() {
  //  var sources = [
  //    this.enrollmentService.getGrades(),
  //    this.enrollmentService.getCourses(),
  //    this.enrollmentService.getEnrollments(),
  //  ];

  //  if (this.enrollment.id)
  //    sources.push(this.enrollmentService.getEnrollment(this.enrollment.id));    
  //}
  onSubmit() {
    if (this.enrollment.id) {
      this.enrollmentService.update(this.enrollment)
        .subscribe(x => {
          x => console.log(x);
          //this.toastyService.success({
          //  title: 'Success',
          //  msg: 'The Enrollment was sucessfully updated.',
          //  theme: 'bootstrap',
          //  showClose: true,
          //  timeout: 5000
          //});
        });
    }
    else {
      this.enrollmentService.create(this.enrollment)
        .subscribe(x => console.log(x));

    }
  }

  //delete() {
  //  if (confirm("Are you sure?")) {
  //    this.enrollmentService.delete(this.enrollment.id)
  //      .subscribe(x => {
  //        console.log(this.enrollments);
  //        //this.router.navigate(['/home']);
  //      });
  //    this.fetchData();
  //  }
  //}

  deleteRow(index: number) {
    this.enrollment.id = index;

    if (confirm("Are you sure?")) {
      this.enrollmentService.delete(this.enrollment.id)
        .subscribe(x => {
          console.log(this.enrollments);
          //this.router.navigate(['/home']);
        });
      this.fetchData();
    }
  }
  fetchData() {
    this.enrollmentService.getEnrollments().subscribe(enrollments => {
      this.enrollments = enrollments;
      console.log(this.enrollments);
    });
  }
}


