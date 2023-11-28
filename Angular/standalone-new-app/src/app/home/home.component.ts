import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  constructor(
    private activated: ActivatedRoute
  ){

    this.activated.params.subscribe(res=> {
      console.log(res);
      const year = res["year"];
      const version = res["version"];
      const value = res["value"];

      console.log("Year: " + year);
      console.log("Version: " + version);
      console.log("Value: " + value);
    });
  }

}
