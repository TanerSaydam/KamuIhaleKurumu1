import { NgModule, inject } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ValidateDirective } from './directives/validate.directive';
import { FormValidateDirective } from './directives/form-validate.directive';
import { AuthService } from './services/auth.service';
import { HttpClientModule } from '@angular/common/http'
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { ErrorModule } from 'angular-error-service';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    ValidateDirective,
    FormValidateDirective
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ErrorModule,
    SweetAlert2Module,
    RouterModule.forRoot([
      {
        path: "",
        component: HomeComponent,
        canActivate: 
            [()=> inject(AuthService).checkAuth()]
      },
      {
        path: "login",
        component: LoginComponent
      }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
