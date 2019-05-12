import { SaveEnrollment } from './../models/enrollment';

import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { environment } from '../../environments/environment';

@Injectable()
export class EnrollmentService {
  private baseUrl: string = environment.baseUrl;

  constructor(private http: Http) { }

  getGrades() {
    return this.http.get(this.baseUrl +'/grade')
      .map(res => res.json());
  }

  getCourses() {
    return this.http.get(this.baseUrl +'/course')
      .map(res => res.json());
  }
  
  getEnrollments() {
    return this.http.get(this.baseUrl+'/enrollment')
      .map(res => res.json());
  }

  create(enrollment) {
    return this.http.post(this.baseUrl +'/enrollment/', enrollment)
      .map(res => res.json());
  }

  getEnrollment(id) {
    return this.http.get(this.baseUrl +'/enrollment/' + id)
      .map(res => res.json());
  }

  update(enrollment: SaveEnrollment) {
    return this.http.put(this.baseUrl +'/enrollment/' + enrollment.id, enrollment)
      .map(res => res.json());
  }

  delete(id) {
    return this.http.delete(this.baseUrl +'/enrollment/' + id)
      .map(res => res.json());
  }
}
