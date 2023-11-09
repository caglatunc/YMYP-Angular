import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { TranslateService, TranslateModule } from '@ngx-translate/core';
import { AuthService } from 'src/app/services/auth.service';
import { ShoppingCartService } from 'src/app/services/shopping-cart.service';
import { FormsModule } from '@angular/forms';
import { NgIf, NgClass } from '@angular/common';


@Component({
    selector: 'app-navbar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.css'],
    standalone: true,
    imports: [RouterLink, NgIf, FormsModule, NgClass, TranslateModule]
})
export class NavbarComponent {
  language: string = "";

  constructor(
    private translate: TranslateService,
    public shopping: ShoppingCartService,
    public auth: AuthService,
    private router: Router
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

  logout(){
    localStorage.removeItem("response");
    this.shopping.getAllShoppingCarts();
    this.router.navigateByUrl("/login");  
  }
}
