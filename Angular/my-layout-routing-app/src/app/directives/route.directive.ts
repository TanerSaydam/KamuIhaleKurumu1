import { Directive, HostListener, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Directive({
  selector: '[route]'
})
export class RouteDirective {

  @Input() route: string = "";
  constructor(
    private router: Router,
    private activated:ActivatedRoute
  ) { 
   console.log(this.activated.snapshot.routeConfig?.children)
   }

  @HostListener("click") click(){
    const el:any = document.getElementById("question");
    el.style.display="block";

    const btnEl = document.getElementById("evetBtn");
    btnEl?.setAttribute("data-route",this.route);
    
    // const result = confirm("Sayfa geçisi yapmak üzeresin, onaylıyor musun?")
    // if(result)
    //   this.router.navigateByUrl(this.route);
  }

}
