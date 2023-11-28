import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(
    private http: HttpClient
  ) { }

  get(api: string, callBack: (res:any)=> void){
    const responseString: any = localStorage.getItem("response");
    const response:any = JSON.parse(responseString);

    this.http.get(api, {
      headers: {
        "Authorization": "Bearer " + response?.token
      }
    })
    .subscribe({
      next: (res: any)=> {
        callBack(res);
      },
      error: (err: HttpErrorResponse)=> {
        console.log(err);
      }
    })
  }  

  post(api: string, data:any, callBack: (res:any)=> void){
    this.http.post(api, data)
    .subscribe({
      next: (res: any)=> {
        callBack(res);
      },
      error: (err: HttpErrorResponse)=> {
        console.log(err);
      }
    })
  }
}
