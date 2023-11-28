import { Component } from '@angular/core';
import { BreadCrumbModel } from 'src/app/common/models/bread-crumb.model';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent {
  breadCrumbs: BreadCrumbModel[] = [
    {
      path: "/about",
      title: "About",
      class: "active"
    }
  ]
}
