import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[yellowColor]'
})
export class MyFirstDirective {

  constructor(
    private el: ElementRef<HTMLLIElement>
  ) {}

  @HostListener("mouseenter") mouseenter(){
    this.el.nativeElement.style.backgroundColor = "yellow"
  }

  @HostListener("mouseleave") mouseleave(){
    this.el.nativeElement.style.backgroundColor = "white"
  }

}
