import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import jwtDecode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(
    private route: Router,
    private http: HttpClient
  ) { }

  checkAuth(){
      if(!localStorage.getItem("response")){
        this.route.navigateByUrl("/login");
        return false;
      }else{
        const responseString = localStorage.getItem("response");
        if(responseString === null) {
          this.route.navigateByUrl("/login");
          return false;
        }
        const response = JSON.parse(responseString);
        if(!response?.token){
          this.route.navigateByUrl("/login");
          return false;
        }

        try {
          const decodeToken:any = jwtDecode(response.token);
          console.log(decodeToken);

          const exp = decodeToken.exp;
          const now = new Date().getTime() / 1000;

          if(now > exp){

            const refreshToken = response.refreshToken;
            const refreshTokenExp = response.refreshTokenExpires;

            if(now > refreshTokenExp){
              this.route.navigateByUrl("/login");
              return false;
            }

            this.http.post(
              "https://kik.ecnorow.com/api/auth/LoginWithRefreshToken/" + refreshToken, {})
              .subscribe({
                next: (res: any)=> {
                  localStorage.setItem("response", JSON.stringify(res));
                  this.checkAuth();
                },
                error: (err: HttpErrorResponse)=> {
                  console.log(err);
                  this.route.navigateByUrl("/login");
                  return false;
                }
              });            
          }
        } catch (error) {
          this.route.navigateByUrl("/login");
          return false;
        }     

        return true;
      };
  }

  checkAuth2() {
    const redirectToLogin = () => {
      this.route.navigateByUrl("/login");
      return false;
    };
  
    const responseString = localStorage.getItem("response");
  
    if (!responseString) return redirectToLogin();
  
    const response = JSON.parse(responseString);
    const { token, refreshToken, refreshTokenExpires } = response;
  
    if (!token) return redirectToLogin();
  
    let decodeToken: any;
  
    try {
      decodeToken = jwtDecode(token);
    } catch (error) {
      return redirectToLogin();
    }
  
    const now = new Date().getTime() / 1000;
  
    if (now > decodeToken.exp) {
      if (now > refreshTokenExpires) return redirectToLogin();
  
      this.http.post(`https://kik.ecnorow.com/api/auth/LoginWithRefreshToken/${refreshToken}`, {})
        .subscribe({
          next: (res: any) => {
            localStorage.setItem("response", JSON.stringify(res));
            this.checkAuth();
          },
          error: (err: HttpErrorResponse) => {
            console.log(err);
            return redirectToLogin();
          }
        });
      return false;
    }
  
    return true;
  }
  
}
