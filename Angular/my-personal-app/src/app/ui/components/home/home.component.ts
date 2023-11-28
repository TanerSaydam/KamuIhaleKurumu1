import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeService } from '../../services/home.service';
import { FormsModule } from '@angular/forms';
import { HomePipe } from '../../pipes/home.pipe';
import { ColorDirective } from '../../directives/color.directive';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, FormsModule,HomePipe, ColorDirective],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export default class HomeComponent {
  list: any = [];
  search: string = "";

constructor(
  private home: HomeService
){}

getApiRequest(){
  this.home.apiGetRequest("GetAll",res=> {
    console.log(res);
    this.list = res;
  });
}
}
