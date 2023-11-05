import { Component } from '@angular/core';
import { driver } from "driver.js";
import { interval } from 'rxjs';

@Component({
  selector: 'app-layouts',
  templateUrl: './layouts.component.html',
  styleUrls: ['./layouts.component.css']
})
export class LayoutsComponent {
  isPopupShow: boolean = false;
  processBar: number = 0;
  interval: any;

  constructor() {
    setTimeout(() => {
      this.changePopupShow();
      this.interval = setInterval(() => {
        console.log(this.processBar);
          this.processBar += 2;
      }, 100)
    }, 2000);

    setTimeout(() => {
      clearInterval(this.interval);
      if (this.isPopupShow) {
        this.changePopupShow();
      }
    }, 8000);
  }

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
    this.changePopupShow();
  }

  changePopupShow() {
    this.isPopupShow = !this.isPopupShow;
  }
}
