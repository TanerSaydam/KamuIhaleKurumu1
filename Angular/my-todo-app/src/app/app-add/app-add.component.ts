import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-app-add',
  templateUrl: './app-add.component.html',
  styleUrls: ['./app-add.component.css']
})
export class AppAddComponent {
  @Output() setEvent = new EventEmitter<any>();
  name: string = "";

  setName(el: HTMLInputElement){
    this.setEvent.emit({name: this.name});
    this.name = ""
    el.focus();

  }
}
