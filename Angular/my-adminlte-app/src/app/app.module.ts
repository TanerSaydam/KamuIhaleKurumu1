import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutsComponent } from './ui/components/layouts/layouts.component';
import { PreloaderComponent } from './ui/components/layouts/preloader/preloader.component';
import { NavbarComponent } from './ui/components/layouts/navbar/navbar.component';
import { MainSidebarComponent } from './ui/components/layouts/main-sidebar/main-sidebar.component';
import { FooterComponent } from './ui/components/layouts/footer/footer.component';
import { RightSidebarComponent } from './ui/components/layouts/right-sidebar/right-sidebar.component';
import { HomeComponent } from './ui/components/home/home.component';
import { AboutComponent } from './ui/components/about/about.component';
import { BlankComponent } from './common/components/blank/blank.component';
import { CardComponent } from './common/components/card/card.component';
import { HttpClientModule } from '@angular/common/http'
import { FormsModule } from '@angular/forms';
import { TodoPipe } from './ui/pipes/todo.pipe';
import { Todo2Pipe } from './ui/pipes/todo2.pipe';
import { TrCurrencyPipe } from './ui/pipes/tr-currency.pipe';
@NgModule({
  declarations: [
    AppComponent,
    LayoutsComponent,
    PreloaderComponent,
    NavbarComponent,
    MainSidebarComponent,
    FooterComponent,
    RightSidebarComponent,
    HomeComponent,
    AboutComponent,
    BlankComponent,
    CardComponent,
    TodoPipe,
    Todo2Pipe,
    TrCurrencyPipe,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
