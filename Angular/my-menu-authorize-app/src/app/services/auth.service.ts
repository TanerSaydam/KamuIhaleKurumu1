import { Injectable } from '@angular/core';
import jwtDecode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  checkAuthorize(authorizeName: string): boolean{
    const responseString = localStorage.getItem("response");

    if(responseString){
      const response = JSON.parse(responseString);
      const token = response.token;
      const decode:any = jwtDecode(token);

      const rolesString = decode["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
      const role = JSON.parse(rolesString);
      console.log(role);
      return role.includes(authorizeName);      
    }

    return false;
  }
}
