import { AfterViewInit, Directive, ElementRef, Input } from '@angular/core';

@Directive({
  selector: '[color]'
})
export class ColorDirective implements AfterViewInit {

  @Input() color: string = "";
  @Input() font: string = ""
  constructor(
    private el: ElementRef<any>
  ) {}

  ngAfterViewInit(): void {
    console.log(this.color)
    console.log(this.font)
  return;
    if(this.color === "true"){
      this.el.nativeElement.style.backgroundColor = "yellow"
    }else{
      this.el.nativeElement.style.backgroundColor = "red"
    }
  }
  

}
