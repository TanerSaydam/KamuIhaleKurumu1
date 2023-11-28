import { Component, Input } from '@angular/core';
import { RouteModel } from 'src/app/router/route';

@Component({
  selector: 'menu-item',
  templateUrl: './menu-item.component.html',
  styleUrls: ['./menu-item.component.css']
})
export class MenuItemComponent {
  @Input() menu: RouteModel = new RouteModel();
}
