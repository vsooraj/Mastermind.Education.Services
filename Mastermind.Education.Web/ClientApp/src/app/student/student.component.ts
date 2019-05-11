import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ToastyService } from "ng2-toasty";
import 'rxjs/add/Observable/forkJoin';

import { SaveStudent, Student } from './../models/student';

//import { StudentService } from './../services/student.service';
@Component({
  selector: 'app-student-component',
  templateUrl: './student.component.html'
})
export class StudentComponent {
  public students: Student[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Student[]>('http://localhost:58789/api/student/').subscribe(result => {
      this.students = result;
    }, error => console.error(error));
  }
}

