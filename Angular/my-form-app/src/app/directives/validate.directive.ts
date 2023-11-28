import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[validate]'
})
export class ValidateDirective {

  constructor(
    private el: ElementRef<HTMLInputElement>
  ) { 
  }

  checkValidation(){
    if(this.el.nativeElement.validity.valid) 
    this.el.nativeElement.className = "form-control is-valid"
    else 
    this.el.nativeElement.className = "form-control is-invalid"
  }

  @HostListener("keyup") keyup(){
    this.checkValidation();
  }
}
