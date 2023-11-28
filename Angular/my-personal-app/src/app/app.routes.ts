import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: "",
        loadComponent: ()=> import("./ui/components/layouts/layouts.component"),
        children: [
            {
                path: "",
                loadComponent: ()=> import("./ui/components/home/home.component")
            }
        ]
    },
    {
        path: "login",
        loadComponent:()=> import("./ui/components/login/login.component")
    }
];
