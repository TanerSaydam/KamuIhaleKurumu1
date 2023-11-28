import { Component } from '@angular/core';
import { Menus } from '../router/route';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent {
  menus= Menus;

  constructor(
    private auth: AuthService
  ){
      for(let m of this.menus){
        m.isAuthorize = this.auth.checkAuthorize(m.authorizeName);
      }
  }
}
  