import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-teacher-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './teacher-login.component.html',
  styleUrls: ['./teacher-login.component.css']
})
export class TeacherLoginComponent {
  userName: string = "";

  constructor(
    private router: Router,
    private http: HttpClient
    )
    {}

    signIn(form: NgForm){
      if(form.valid){
        this.router.navigateByUrl("/teacher");
        return;


        this.http.post("", {userName: this.userName}).subscribe({
          next: (res: any)=> {

          },
          error: (err: HttpErrorResponse) => {

          }
        });
      }
    }

}
