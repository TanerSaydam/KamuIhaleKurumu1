import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {

  constructor(
    private router: Router
  ){

  }
  gotoPage(event:any){
    const route = event.target.dataset["route"];
    this.router.navigateByUrl(route);

    const el:any = document.getElementById("question");
    el.style.display="none";
  }
}
