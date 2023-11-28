import { Directive, ElementRef, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[color]',
  standalone: true
})
export class ColorDirective {

  @Input() color: string = "";
  constructor(
    private el: ElementRef<HTMLTableRowElement>
  ) { }

    @HostListener("mouseenter") mouseenter(){
      console.log(this.color)
      if(this.color === null){
        this.el.nativeElement.className = "alert alert-success"
      }else{
        this.el.nativeElement.className = "alert alert-danger"
      }
    }
}
