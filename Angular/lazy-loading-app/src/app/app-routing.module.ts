import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: "login",
    loadChildren: ()=> import("./login/login.module").then(m=> m.LoginModule)
  },
  {
    path: "",
    loadChildren: ()=> import("./layouts/layouts.module")
  }
  
  // {
  //   path: "",
  //   loadChildren: ()=> import("./layouts/layouts.module").then(m=> m.LayoutsModule),
  //   component: LayoutsComponent,
  //   children: [
  //     {
  //       path: "",
  //       loadChildren: ()=> import("./home/home.module").then(m=> m.HomeModule),
  //       component: HomeComponent
  //     }
  //   ]
  // }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
