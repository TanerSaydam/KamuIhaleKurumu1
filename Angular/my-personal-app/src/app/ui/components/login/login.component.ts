import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export default class LoginComponent {
  email: string = "";
  password: string = "";

  constructor(
    private auth: AuthService,
    private router: Router
  ){}

  signIn(){
    const data = {
      userNameOrEmail: this.email,
      password: this.password
    };
    this.auth.apiRequest("Login",data,res=> {
      localStorage.setItem("response", JSON.stringify(res));
      // this.router.navigateByUrl("/");
      document.location.href = "/";
    })
    
  }
}
