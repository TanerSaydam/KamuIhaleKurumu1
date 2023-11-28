import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { routes } from '../constants/router';



@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes,{
      
    })
  ],
  exports: [
    RouterModule
  ]
})
export class MyRoutingModule { }
