import { Component, Input } from '@angular/core';
import { BreadCrumbModel } from '../../models/bread-crumb.model';

@Component({
  selector: 'app-blank',
  templateUrl: './blank.component.html',
  styleUrls: ['./blank.component.css']
})
export class BlankComponent {
  @Input() pageTitle: string = "";
  @Input() breadCrumbs: BreadCrumbModel[] = [];
}
