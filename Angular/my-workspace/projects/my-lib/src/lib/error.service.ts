import { Injectable } from '@angular/core';
import { SwalService } from './swal.service';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable()
export class ErrorService {

  constructor(private swal: SwalService) { }

  errorHandler(err: HttpErrorResponse){
    if(err.status === 500){
      this.swal.callToast(err.error.Message,"","error");
    }else if(err.status === 403){
      this.swal.callToast(err.error[0].errorMessage,"","error");
    }else if(err.status === 415){
      this.swal.callToast("İstek yaptığın metot tipi yanlış!", "","error");
    }else if(err.status === 404){
      this.swal.callToast("Api adresi bulunamadı!", "","error");
    }
  }
}
