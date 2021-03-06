import { SaveStudent } from './../models/student';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { environment } from '../../environments/environment';

@Injectable()
export class StudentService {
  private baseUrl: string = environment.baseUrl;
  constructor(private http: Http) { }

  create(student) {
    return this.http.post(this.baseUrl +'/student', student)
      .map(res => res.json());
  }
  getStudents() {
    return this.http.get(this.baseUrl +'/student' )
      .map(res => res.json());
  }

  update(student: SaveStudent) {
    return this.http.put(this.baseUrl +'/student/' + student.id, student)
      .map(res => res.json());
  }

  delete(id) {
    return this.http.delete(this.baseUrl +'/student/' + id)
      .map(res => res.json());
  }
}
