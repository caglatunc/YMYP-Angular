import { Component } from '@angular/core';
import { ShoppingCardService } from '../services/shopping-card.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-shopping-card',
  templateUrl: './shopping-card.component.html',
  styleUrls: ['./shopping-card.component.css']
})
export class ShoppingCardComponent {
  
  language: string = "en";

  constructor(
    public shopping: ShoppingCardService,
    private translate: TranslateService
  ) {

    if (localStorage.getItem("language")) {
      this.language = localStorage.getItem("language") as string;
    } 

    translate.setDefaultLang(this.language);
  }
}