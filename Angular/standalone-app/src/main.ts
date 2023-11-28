import { bootstrapApplication } from "@angular/platform-browser";
import { AppComponent } from "./app/app.component";
import { importProvidersFrom } from "@angular/core";
import { CommonModule } from "@angular/common";
import { provideRouter } from "@angular/router";

bootstrapApplication(AppComponent,{
  providers: [
    provideRouter([
      {
        path: "login",
        loadComponent: ()=> import("./app/login/login.component")
      },
      {
        path: "",
        loadComponent: ()=> import("./app/layouts/layouts.component"),
        children: [
          {
            path: "",
            loadComponent: ()=> import("./app/home/home.component").then(c=> c.HomeComponent)
          },
          {
            path: "about",
            loadComponent: ()=> import("./app/about/about.component")
          },
          {
            path: "contact",
            loadComponent: ()=> import("./app/contact/contact.component")
          }
        ]
      }
    ]),
    importProvidersFrom(
      CommonModule
    )
  ]
})