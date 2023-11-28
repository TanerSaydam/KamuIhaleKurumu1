import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  todos: any = [];
  search: string = "";
  number: number = 50515615656.50;
  constructor(
    private http: HttpClient
  ) { 
    this.getAll();
  }

  getAll() {
    this.http.get("https://jsonplaceholder.typicode.com/todos")
      .subscribe(res => this.todos = res);
  }
}
