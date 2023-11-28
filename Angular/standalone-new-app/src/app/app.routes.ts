import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
    {
        path: "home/:year/:version/:value",
        component: HomeComponent
    },
    {
        path: "home/:year",
        component: HomeComponent
    },
    {
        path: "home",
        component: HomeComponent
    }
];
