import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'todo'
})
export class TodoPipe implements PipeTransform {

  transform(value: any[], search: string) {
    console.log("Ben Todo1Pipe çalıştım");
    
    
    if(search === "") return value;


    return value.filter(
      p=> 
      p.title.toLowerCase().includes(search.toLowerCase()));
  }

}
