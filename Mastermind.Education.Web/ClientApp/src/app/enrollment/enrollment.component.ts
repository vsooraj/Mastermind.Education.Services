import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-enrollment-component',
  templateUrl: './enrollment.component.html'
})
export class EnrollmentComponent {
  public enrollments: Enrollment[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Enrollment[]>('http://localhost:58789/api/enrollment/').subscribe(result => {
      this.enrollments = result;
    }, error => console.error(error));
  }
}

interface Enrollment {
  id: number;
  name: string;
  courseId: number,
  course: string,
  noOfDays: number,
  studentId: number,
  student: string,
  grade: string

}

