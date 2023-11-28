import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[formValidate]'
})
export class FormValidateDirective {

  constructor(
    private el: ElementRef<HTMLFormElement>
  ) { }

  
  @HostListener("keyup") keyup(){
    this.checkValidation();
  }

  @HostListener("submit") submit(){
    this.checkValidation();
  }

  checkValidation(){
    for(let el in this.el.nativeElement.elements){
      const childElement:any= this.el.nativeElement.elements[el];
      
      if(childElement.validity === undefined) continue;

      if(childElement.validity.valid){
        childElement.classList.add("is-valid");
        childElement.classList.remove("is-invalid");
      }else{
        childElement.classList.add("is-invalid");
        childElement.classList.remove("is-valid");
      }
    }
  }

}
