import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { CounterService } from '../counter.service';

@Component({
  selector: 'app-count-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './count-list.component.html',
  styleUrls: ['./count-list.component.css']
})
export class CountListComponent {
  count: number = 0;
  count$: Observable<number> | undefined;

  constructor(
    private store: Store<{count: number, num: number}>,
    public _counter: CounterService
  ){
    this.store.select("num").subscribe(res=> this.count = res);
    this.count$ = this.store.select("num")
  }
}
