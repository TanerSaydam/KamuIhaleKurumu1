import { Component } from '@angular/core';
import { LoginModel } from '../models/login.model';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { SwalService,ErrorService } from 'angular-error-service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
login: LoginModel = new LoginModel();

constructor(
  private router: Router,
  private http: HttpClient,
  private err: ErrorService,
  private swal: SwalService
  ) {
    swal.callToast("Deneme","deneme2","info");
  }

signIn(form: NgForm){ 
  if(form.valid){
    this.http.post("https://kik.ecnorow.com/api/Auth/login",form.value).subscribe({
      next: (res:any)=> {
        localStorage.setItem("response", JSON.stringify(res));
        this.router.navigate(["/"]);
        //this.swal.callToast("Giriş işlemi başarılı","","success");
      },
      error: (err: HttpErrorResponse)=> {       
        console.log(err); 
        this.err.errorHandler(err);
      }
    })
    //this.router.navigate(["/"]); //home sayfasına git. go to home 
  }  
}
}
