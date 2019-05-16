import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { ActivatedRoute, Router } from '@angular/router';
import { SaveEnrollment, Enrollment } from './../models/enrollment';
import { EnrollmentService } from './../services/enrollment.service';
import { Student } from '../models/student';
import { Course, Grade } from '../models/course';
import { Pipe, PipeTransform } from '@angular/core';



@Component({
  selector: 'app-enrollment-component',
  templateUrl: './enrollment.component.html'
})
export class EnrollmentComponent implements OnInit, PipeTransform {
  transform(items: any[], searchText: string): any[] {

    if (!items) {
      return [];
    }
    if (!searchText) {
      return items;
    }
    searchText = searchText.toLowerCase();

    return items.filter(it => {
      return it.toLowerCase().includes(searchText);
    });
  }


  grades: any[] = [
    { id: "A"},
    { id: "B"},
    { id: "C"}
  ];

  courses: Course[];
  searchCourses: Course[];   
  students: Student[];

  enrollment: SaveEnrollment = {
    id: null,
    courseId: 0,
    studentId: 0,
    noOfDays: 0,
    grade: 'A'

  };

  private setEnrollment(v: Enrollment) {
    this.enrollment.id = v.id;
    this.enrollment.courseId = v.courseId;
    this.enrollment.studentId = v.studentId;
    this.enrollment.noOfDays = v.noOfDays;
    this.enrollment.grade = v.grade;

    this.isNewRecord = false;
  } 

  public enrollments: Enrollment[];
  public cacheEnrollments: Enrollment[];

  isNewRecord: boolean=true;
  statusMessage: string;

  constructor(private enrollmentService: EnrollmentService,
    private router: Router) { }
  ngOnInit() {
    this.fetchData();
  }

  onSubmit() {
    if (this.enrollment.id) {
      this.enrollmentService.update(this.enrollment)
        .subscribe(x => {
          this.fetchData();
          this.router.navigate(['/enrollment']);
        });
    }
    else {
      this.enrollmentService.create(this.enrollment)
        .subscribe(x => {         
          this.fetchData();
          this.router.navigate(['/enrollment']);
        });
    }
    
  }


  deleteRow(index: number) {
    this.enrollment.id = index;

    if (confirm("Are you sure?")) {
      this.enrollmentService.delete(this.enrollment.id)
        .subscribe(x => {
          this.router.navigate(['/enrollment']);
          this.fetchData();
        });
      
    }
  }
  fetchData() {
    this.enrollmentService.getEnrollments().subscribe(data => {
      this.enrollments = data.enrollments;
      this.courses = data.courses;
      this.students = data.students;
      this.searchCourses = data.courses;
      console.log(this.courses);
      this.router.navigate(['/enrollment']);
    });
  }

  public onChange(args: any): void {

    this.enrollment.noOfDays = this.courses[this.courses.findIndex(x => x.id==args.target.value)].noOfDays;   
    
  }

  filterEnrollments(filterVal: any) {
    if (filterVal == "0")
      this.enrollments = this.cacheEnrollments;
    else
      this.enrollments = this.cacheEnrollments.filter((item) => item.courseId == filterVal);
  }
 

}


