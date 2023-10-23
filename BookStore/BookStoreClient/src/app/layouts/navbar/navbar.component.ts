import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ShoppingCardService } from 'src/app/services/shopping-card.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  language: string = "";

  constructor(
    private translate: TranslateService,
    public shopping: ShoppingCardService
  ) {
    if (localStorage.getItem("language")) {
      this.language = localStorage.getItem("language") as string;
    } 

    translate.setDefaultLang(this.language);
  }


  switchLanguage(event: any) {
    localStorage.setItem("language", event.target.value);
    this.language = event.target.value;
    this.translate.use(event.target.value);
    location.reload();
  }
}
