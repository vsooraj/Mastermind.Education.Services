import { Component, Inject, OnInit } from '@angular/core';
import { ToastyService } from "ng2-toasty";
import 'rxjs/add/Observable/forkJoin';

import { SaveStudent, Student } from './../models/student';
import { StudentService } from '../services/student.service';
@Component({
  selector: 'app-student-component',
  templateUrl: './student.component.html'
})
export class StudentComponent implements OnInit {
 
  public students: Student[];

  constructor(private studentService: StudentService) { }

  ngOnInit() {
    this.studentService.getStudents().subscribe(students => {
      this.students = students;
      console.log(this.students);
    });
  }
}

