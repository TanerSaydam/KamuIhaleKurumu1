import { Injectable } from '@angular/core';
import { api } from 'src/app/common/constants/api';
import { HttpService } from 'src/app/common/services/http.service';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(
    private http: HttpService
  ) { }

  apiGetRequest(methodName: MethodName, callBack: (res:any)=> void){
    this.http.get(`${api}/Personels/${methodName}`,res=> callBack(res))
  }
}

export type MethodName = "GetAll"
