import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
  <h1>App Component</h1>
  <ul>
    <li>
      <a routerLink="/" routerLinkActive="active" [routerLinkActiveOptions]="{exact:true}">Home</a>
    </li>
    <li>
      <a routerLink="/about" routerLinkActive="active">About</a>
    </li>
    <li>
      <a routerLink="/blog" routerLinkActive="active">Blog</a>
    </li>
    <li>
      <a routerLink="/contact" routerLinkActive="active">Contact</a>
    </li>
  </ul>
  <router-outlet></router-outlet>
  `
})
export class AppComponent {
  title = 'my-first-routing-app';
}
