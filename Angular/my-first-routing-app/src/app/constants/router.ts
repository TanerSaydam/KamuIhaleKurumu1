import { Routes } from "@angular/router";
import { aboutRoute } from "../about/aout.router";
import { homeRoute } from "../home/home.router";
import { blogRoute } from "../new-blog/new-blog.router";
import { notFount } from "../not-found/not-found.router";
import { contactRoute } from "../contact/contact.router";

export const routes: Routes = [
    homeRoute,
    aboutRoute,
    blogRoute,
    contactRoute,
    notFount,
]

