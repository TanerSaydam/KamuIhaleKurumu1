import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutsComponent } from './layouts.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    LayoutsComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: "",
        component: LayoutsComponent,
        children:[
          {
            path: "",
            loadChildren: ()=> import("../home/home.module").then(m=> m.HomeModule)
          },
          {
            path: "about",
            loadChildren: ()=> import("../about/about.module")
          },
          {
            path: "contact",
            loadChildren: ()=> import("../contact/contact.module")
          }
        ]
      }
    ])
  ]
})
export default class LayoutsModule { }
