import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ShoppingCartService } from '../../services/shopping-cart.service';
import { PaymentModel } from 'src/app/models/payment.model';
import { Cities, Countries } from 'src/app/constants/address';
import { Months, Years } from 'src/app/constants/expireDates';
import { SwallService } from 'src/app/services/swall.service';


@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent {
  [key: string]: any;
  language: string = "en";
  selectedTab: number = 1; // 1: shopping cart, 2: payment, 3: order completed
  request: PaymentModel = new PaymentModel();
  countries = Countries;
  cities = Cities;
  months = Months;
  years = Years;
  isSameAddress: boolean = false;
  cardNumber1: string = "5890";
  cardNumber2: string = "0400";
  cardNumber3: string = "0000";
  cardNumber4: string = "0016";
  expireMonthAndYear: string = "2025-07";
 selectedCurrencyForPayment: string = "₺"; //Ödeme işlemi için seçilen para birimi.

  constructor(
    public shopping: ShoppingCartService,
    private translate: TranslateService,
    private swal: SwallService
  ) {

    if (localStorage.getItem("language")) {
      this.language = localStorage.getItem("language") as string;
    }

    this.request.books = this.shopping.shoppingCarts; //Kitapların listesi alındı. 
  }

  changeTab(tabNumber: number) {
    this.selectedTab = tabNumber;
  }

  setSelectedPaymentCurrency(currency: string) {
 this.selectedCurrencyForPayment = currency;
 const newBooks = this.shopping.shoppingCarts.filter(p=> p.price.currency === this.selectedCurrencyForPayment);
 this.request.books = newBooks;
  }
  payment() { 
    this.request.paymentCard.expireMonth = this.expireMonthAndYear.substring(5);
    this.request.paymentCard.expireYear = this.expireMonthAndYear.substring(0,4);
   this.request.paymentCard.cardNumber = this.cardNumber1 + this.cardNumber2 + this.cardNumber3 + this.cardNumber4;
   this.request.buyer.registrationAddress = this.request.shippingAddress.description;
   this.request.buyer.city = this.request.shippingAddress.city;
   this.request.buyer.country = this.request.shippingAddress.country;
    this.shopping.payment(this.request, (res)=> {
      const btn = document.getElementById("paymentModalCloseBtn");
      btn?.click();// ödeme işlemi tamamlandıktan sonra modal kapatıldı.
      const remainShoppingCarts = this.shopping.shoppingCarts.filter(p=> p.price.currency !== this.selectedCurrencyForPayment);
      localStorage.setItem("shoppingCarts", JSON.stringify(remainShoppingCarts));
      this.shopping.checkLocalStoreForShoppingCarts();
      this.translate.get("paymentIsSuccessful").subscribe(translate =>{
        this.swal.callToast(translate,"success");
      })
      
    })
  }

  changeIsSameAddress() {
    if (this.isSameAddress) {
      this.request.billingAddress = this.request.shippingAddress;
    }
  }

  gotoNextInputIf4Length(inputCount: string = "", value: string = "") {

   this[`cardNumber${inputCount}`] = value.replace(/[^0-9]/g, ""); //inputa sadece sayı girilmesi sağlandı.
   value = value.replace(/[^0-9]/g, "");
   
   if (value.length === 4) {
      if (inputCount === "4") {
          const el: any = document.getElementById("expireMonthAndYear") //input elementi seçildi.
         el?.focus();
       } else {
          const id: string = `cardNumber${+inputCount + 1}`;
          const el: any = document.getElementById(id) //input elementi seçildi. 
        el.focus();
        }
      }
}
setExpireMonthAndYear(){

 // Sadece sayıları kabul ediyoruz
 this.expireMonthAndYear = this.expireMonthAndYear.replace(/[^0-9]/g, "");

 // Eğer stringin uzunluğu 2'den büyükse, 2. ve 3. karakter arasına "/" ekliyoruz
 if (this.expireMonthAndYear.length > 2) {
   this.expireMonthAndYear = this.expireMonthAndYear.substring(0, 2) + "/" + this.expireMonthAndYear.substring(2);
 }

 // Ayın 01 ile 12 arasında olup olmadığını kontrol ediyoruz
 if (this.expireMonthAndYear.length >= 2) {
   const month = parseInt(this.expireMonthAndYear.substring(0, 2));
   if (month === 0) {
     this.expireMonthAndYear = "01" + this.expireMonthAndYear.substring(2);
   } else if (month > 12) {
     this.expireMonthAndYear = "12" + this.expireMonthAndYear.substring(2);
   }
 }

 if(this.expireMonthAndYear.length > 4){
   const el = document.getElementById("cvc");
   el?.focus();
 }




}
}

