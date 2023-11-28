import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Store } from '@ngrx/store';
import { decrement, increment } from '../store/count2.action';
import { FormsModule } from '@angular/forms';
import { CounterService } from '../counter.service';
// import { decrement, increment } from '../store/count.actions';

@Component({
  selector: 'app-counter',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.component.css']
})
export class CounterComponent {
  num: number = 0;
  constructor(
    private store: Store,
    public _counter: CounterService
  ){}

  increment(){
    this.store.dispatch(increment({num: this.num}))
  }

  decrement(){
    this.store.dispatch(decrement({num: this.num}))
  }
}
