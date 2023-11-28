import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-teacher-students',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './teacher-students.component.html',
  styleUrls: ['./teacher-students.component.css']
})
export class TeacherStudentsComponent {
  students: any[] = [];


  constructor(
    private http: HttpClient
  ){
    this.getAll();
  }

  getAll(){
    this.http.get("").subscribe((res:any)=> {
      this.students = res;
    })
  }

  save(form: NgForm){
    if(form.valid){
      this.students.push(form.value);
      return;

      this.http.post("", form.value).subscribe(res=> {
        const el = document.getElementById("addStudentModalCloseBtn");
        el?.click();
        this.getAll();
      })
    }
  }
}
