import { Component } from '@angular/core';
import { driver } from "driver.js";
import { PopupService } from 'src/app/services/popup.service';
import { TranslateModule } from '@ngx-translate/core';
import { NgIf, NgStyle } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';


@Component({
    selector: 'app-layouts',
    templateUrl: './layouts.component.html',
    styleUrls: ['./layouts.component.css'],
    standalone: true,
    imports: [NavbarComponent, RouterOutlet, NgIf, NgStyle, TranslateModule]
})
export class LayoutsComponent {
  
  constructor(
    public popup: PopupService
  ) {}

 
  showDriver() {
    const driverObj = driver({
      popoverClass: "driverjs-theme",
      showProgress: true,
      steps: [
        {
          element: '#language',
          popover: {
            title: 'Language',
            description: 'Bu kısımdan dili değiştirebilirsiniz.'
          }
        },
        {
          element: '#categories',
          popover: {
            title: 'Categories',
            description: 'Bu kısımdan kategorileri seçebilirsiniz'
          }
        },
        {
          element: '#bookSearch',
          popover: {
            title: 'Book Search',
            description: 'Bu kısımdan kitap arayabilirsiniz'
          }
        },
        {
          element: '#book0',
          popover: {
            title: 'Book',
            description: 'Bu kısımdan kitap detaylarını görebilirsiniz.'
          }
        },
        {
          element: '#addShoppingCartBtn0',
          popover: {
            title: 'Add Shopping Cart',
            description: 'Bu kısımdan kitabı sepete ekleyebilirsiniz.'
          }
        }
      ]
    });
    driverObj.drive();
    this.popup.changePopupShow();
  }

  
}
