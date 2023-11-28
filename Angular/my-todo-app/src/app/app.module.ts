import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';

import {HttpClientModule} from '@angular/common/http'
import { AppListComponent } from './app-list/app-list.component';
import { AppAddComponent } from './app-add/app-add.component';

@NgModule({
  declarations: [
    AppComponent,
    AppListComponent,
    AppAddComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
