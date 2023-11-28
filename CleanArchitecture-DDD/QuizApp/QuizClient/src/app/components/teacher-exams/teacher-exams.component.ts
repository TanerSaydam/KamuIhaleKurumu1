import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-teacher-exams',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './teacher-exams.component.html',
  styleUrls: ['./teacher-exams.component.css']
})
export class TeacherExamsComponent {
  exams: any[] = [];
  students: any[] = [
    {
      id: 0,
      name: "Taner"
    },
    {
      id: 1,
      name: "Mahmut"
    }
  ];
  chosenStudents: any;
  selectedExamId: number = 0;
  constructor(
    private http: HttpClient
  ){
    this.getAll();
  }

  selectExam(id: number){
    this.selectedExamId = id;
  }

  getAll(){
    this.http.get("").subscribe((res:any)=> {
      this.exams = res;
    })
  }

  getStudents(){
    this.http.get("").subscribe((res:any)=> {
      this.students = res;
    })
  }

  selectStudents(){
    this.http.post("", {examId: this.selectedExamId, chosenStudents: this.chosenStudents}).subscribe(res=> {
      const el = document.getElementById("studentsSelectionModalCloseBtn");
      el?.click();
    })
  }

  save(form: NgForm){
    if(form.valid){
      this.exams.push(form.value);
      return;

      this.http.post("", form.value).subscribe(res=> {
        const el = document.getElementById("addExamModalCloseBtn");
        el?.click();
        this.getAll();
      })
    }
  }
}
