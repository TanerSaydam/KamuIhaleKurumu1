import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'todo2'
})
export class Todo2Pipe implements PipeTransform {

  transform(value: any[], ...args: unknown[]) {
    console.log("Ben Todo2Pipe çalıştım");
    

    return value.filter(p=> p.completed === true);
  }
  
  
}
