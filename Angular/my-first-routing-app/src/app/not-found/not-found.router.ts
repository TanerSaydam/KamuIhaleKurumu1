import { Route } from "@angular/router";
import { NotFoundComponent } from "./not-found.component";

export const notFount: Route = {
    path: "**",
    component: NotFoundComponent
}