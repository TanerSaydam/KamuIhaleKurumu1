import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  template: `
  <h1>{{count()}}</h1>
  <h2>{{name}}</h2>
  <button (click)="increment()">+</button>
  <button (click)="decrement()">-</button>
  `
})
export class AppComponent {
  count = signal(0);
  name: string = "Taner Saydam"

  increment(){
    this.count.update((res)=> res +1); // eski değerini alıp günceller
    this.count.set(0); //sıfırdan değer atar
  }

  decrement(){
    this.count.update((res)=> res-1);
  }
}
