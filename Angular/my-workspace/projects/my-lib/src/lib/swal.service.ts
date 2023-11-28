import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';
@Injectable()
export class SwalService {

  constructor() { }  
  
  callToast(content: string, title: string, icon: SweetAlertIcon){
    const Toast = Swal.mixin({
      toast: true,
      position: 'bottom-end',
      timer: 5000,
      timerProgressBar: true,
      showCloseButton: true,      
      showConfirmButton: false,
    })
    Toast.fire(content, title, icon);
  }
}

type SweetAlertIcon = 'success' | 'error' | 'warning' | 'info' | 'question'
