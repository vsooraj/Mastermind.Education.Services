export interface Enrollment {
  id: number;
  name: string;
  courseId: number,
  course: string,
  noOfDays: number,
  studentId: number,
  student: string,
  grade: string

}


export interface SaveEnrollment {
  id: number;
  courseId: number,
  noOfDays: number,
  studentId: number,
  grade: string

}
