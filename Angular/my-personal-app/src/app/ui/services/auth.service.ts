import { Injectable } from '@angular/core';
import { api } from 'src/app/common/constants/api';
import { HttpService } from 'src/app/common/services/http.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private http: HttpService
  ) { }

  apiRequest(methodName: MethodName, data:any,callBack: (res:any)=> void){
    this.http.post(`${api}/Auth/${methodName}`,data,res=> callBack(res))
  }
}

export type MethodName = "Login"
