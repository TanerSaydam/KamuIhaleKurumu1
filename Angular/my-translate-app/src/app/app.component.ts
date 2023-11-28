import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, RouterOutlet } from '@angular/router';
import { TranslateModule, TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterModule, TranslateModule],
  template: `
  <button (click)="swtichLanguage('en')">English</button>
  <button (click)="swtichLanguage('tr')">Turkish</button>
  <button (click)="swtichLanguage('fr')">Fransızca</button>
  <button routerLink="/home">Home</button>
  <h1>{{'hello' | translate}}</h1>
  <h1>{{'hi' | translate}}</h1>
  <select class="form-control" #langSelect
                                    name="languageCode" 
                                    required>
                                    <option >
                                        <span [class]="'fi fi-fr'"></span>
                                        FR
                                    </option>
                                </select>
  <router-outlet></router-outlet>
  `
})
export class AppComponent {
  constructor(
    private translate: TranslateService
  ){
    translate.setDefaultLang("en");
  }

  swtichLanguage(lang: string){
    this.translate.use(lang);
  }
}
