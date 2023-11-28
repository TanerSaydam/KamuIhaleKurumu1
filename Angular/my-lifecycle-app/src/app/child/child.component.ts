import { Component, DoCheck, Input, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.css']
})
export class ChildComponent implements OnChanges {

@Input() names: string[] = [];
@Input() name: string = "";

ngOnChanges(changes: SimpleChanges): void {
  //input ile veri değiştinde yakalar //Not: Arraylerde çalışmıyor!
  //console.log(changes)
}

}
