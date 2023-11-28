import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'listPipe',
  standalone: true
})
export class HomePipe implements PipeTransform {

  transform(value: any[], search: string) {
    if(search === "") return value;

    return value.filter(
      p=> 
      p.name.toLowerCase().includes(search.toLowerCase()) || 
      p.lastName.toLowerCase().includes(search.toLowerCase()));
  }

}
