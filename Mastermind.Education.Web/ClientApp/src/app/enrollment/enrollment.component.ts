import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { ActivatedRoute, Router } from '@angular/router';

import { SaveEnrollment, Enrollment } from './../models/enrollment';

import { EnrollmentService } from './../services/enrollment.service';
import { ToastyService } from "ng2-toasty";


@Component({
  selector: 'app-enrollment-component',
  templateUrl: './enrollment.component.html'
})
export class EnrollmentComponent implements OnInit {
  grade: any[];
  course: any[];
  enrollment: SaveEnrollment = {
    id: 0,
    courseId: 0,
    studentId: 0,
    noOfDays: 30,
    grade: 'A'

  };

  public enrollments: Enrollment[];

  //constructor(
  //  private route: ActivatedRoute,
  //  private router: Router,
  //  private enrollmentService: EnrollmentService,
  //  private toastyService: ToastyService,
  //  http: HttpClient,
  //  @Inject('BASE_URL') baseUrl: string
  //) {
  //  http.get<Enrollment[]>('http://localhost:58789/api/enrollment/').subscribe(result => {
  //    this.enrollments = result;
  //  }, error => console.error(error));
  //}
  constructor(private enrollmentService: EnrollmentService) { }
  ngOnInit() {
    this.enrollmentService.getEnrollments().subscribe(enrollments => {
      this.enrollments = enrollments;
      console.log(this.enrollments);
    });
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
  //submit() {
  //  if (this.enrollment.id) {
  //    this.enrollmentService.update(this.enrollment)
  //      .subscribe(x => {
  //        this.toastyService.success({
  //          title: 'Success',
  //          msg: 'The Enrollment was sucessfully updated.',
  //          theme: 'bootstrap',
  //          showClose: true,
  //          timeout: 5000
  //        });
  //      });
  //  }
  //  else {
  //    this.enrollmentService.create(this.enrollment)
  //      .subscribe(x => console.log(x));

  //  }
  //}

  //delete() {
  //  if (confirm("Are you sure?")) {
  //    this.enrollmentService.delete(this.enrollment.id)
  //      .subscribe(x => {
  //        this.router.navigate(['/home']);
  //      });
  //  }
  //}
}


