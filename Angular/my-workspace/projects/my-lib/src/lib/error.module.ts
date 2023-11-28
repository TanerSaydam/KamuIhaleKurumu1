import { NgModule } from '@angular/core';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2'
import { ErrorService } from './error.service';
import { SwalService } from './swal.service';


@NgModule({
  imports: [
    SweetAlert2Module
  ],
  providers: [ErrorService, SwalService],
  exports: [
    SweetAlert2Module
  ]
})
export class ErrorModule { }
