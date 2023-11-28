import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'trCurrency'
})
export class TrCurrencyPipe implements PipeTransform {

  transform(value: string | null, ...args: unknown[]) {
    console.log(value);
   let newvalue = value?.toString().replaceAll(",","%");
   newvalue = newvalue?.replaceAll(".",",");
   newvalue = newvalue?.replaceAll("%",".");
    return newvalue;
  }

}
