import { SaveStudent } from './../models/student';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class StudentService {

  constructor(private http: Http) { }

  //getFeatures() {
  //  return this.http.get('/api/features')
  //    .map(res => res.json());
  //}

  //getMakes() {
  //  return this.http.get('/api/makes')
  //    .map(res => res.json());
  //}

  create(student) {
    return this.http.post('/api/student/', student)
      .map(res => res.json());
  }

  getVehicle(id) {
    return this.http.get('/api/student/' + id)
      .map(res => res.json());
  }

  update(student: SaveStudent) {
    return this.http.put('/api/student/' + student.id, student)
      .map(res => res.json());
  }

  delete(id) {
    return this.http.delete('/api/student/' + id)
      .map(res => res.json());
  }
}
