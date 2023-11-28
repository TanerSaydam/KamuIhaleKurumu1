import { HttpClient } from '@angular/common/http';
import { Component, OnInit} from '@angular/core';
import { TodoModel } from './todo.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(
    private http: HttpClient
  ){
    
  }

  ngOnInit(): void {
   // this.getAll();
  }

  //@ViewChild("nameEl") nameEl: ElementRef<HTMLInputElement> | undefined;
  isUpdateFormActive: boolean = false;
  updateName: string = "";
  updateIndex: number = 0;
  
  todos: TodoModel[] = [];


  getAll(){
    this.http.get("https://jsonplaceholder.typicode.com/todos").subscribe((res:any)=> {
      this.todos = res;
    })
  }

  setName(event:any){
    const data =  {
      "userId": 1,
      "id": 1,
      "title": event.name,
      "completed": true
    };
    this.todos.push(data);    
  }

  removeByIndex(index: number){
    this.todos.splice(index,1);
  }

  get(index: number){
    this.updateIndex = index;
    this.updateName = this.todos[index].title;
    this.isUpdateFormActive = true;
  }

  update(){
    this.todos[this.updateIndex].title = this.updateName;
    this.cancel();
  }

  cancel(){
    this.isUpdateFormActive = false;
  }

 
}
