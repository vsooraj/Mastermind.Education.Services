import { SaveCourse } from './../models/course';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { environment } from '../../environments/environment';

@Injectable()
export class CourseService {
  private baseUrl: string = environment.baseUrl;
  constructor(private http: Http) { }

  create(course) {
    return this.http.post(this.baseUrl + '/course', course)
      .map(res => res.json());
  }
  getCourses() {
    return this.http.get(this.baseUrl +'/course' )
      .map(res => res.json());
  }

  update(course: SaveCourse) {
    return this.http.put(this.baseUrl + '/course/' + course.id, course)
      .map(res => res.json());
  }

  delete(id) {
    return this.http.delete(this.baseUrl +'/course/' + id)
      .map(res => res.json());
  }
}
