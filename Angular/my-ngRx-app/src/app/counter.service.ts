import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CounterService {

  newCount: number = 0;
  constructor() { }

  increment(num: number){
    this.newCount += +num;
  }

  decrement(num: number){
    this.newCount -= +num;
  }
}
