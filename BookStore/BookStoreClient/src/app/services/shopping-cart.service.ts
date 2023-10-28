import { Injectable } from '@angular/core';
import { SwallService } from './swall.service';
import { TranslateService } from '@ngx-translate/core';
import { forkJoin } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { PaymentModel } from '../models/payment.model';
import { NgxSpinnerService } from 'ngx-spinner';


@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {

  shoppingCarts: any[] = [];
  prices: { value: number, currency: string }[] = [];
  count: number = 0;
  total: number = 0;

  constructor(
    private swal: SwallService,
    private translate: TranslateService,
    private http: HttpClient,
    private spinner: NgxSpinnerService
  ) {
    this.checkLocalStoreForShoppingCarts();
  }

  checkLocalStoreForShoppingCarts() {
    if (localStorage.getItem("shoppingCarts")) {
      const cards: string | null = localStorage.getItem("shoppingCarts")
      if (cards !== null) {
        this.shoppingCarts = JSON.parse(cards);


      }
    }
    this.calcTotal();
  }

  calcTotal() {
    this.count = this.shoppingCarts.length;
    this.total = 0;

    const sumMap = new Map<string, number>();

    this.prices = [];
    for (let s of this.shoppingCarts) {
      this.prices.push({ ...s.price });
    }

    for (const item of this.prices) {
      const currentSum = sumMap.get(item.currency) || 0;
      sumMap.set(item.currency, currentSum + item.value);
    }

    this.prices = [];
    for (const [currency, sum] of sumMap) {
      this.prices.push({ value: sum, currency: currency });
      console.log(this.prices);
    }
  }

  removeByIndex(index: number) {

    forkJoin({
      doYouWantToDelete: this.translate.get("remove.doYouWantToDelete"),
      cancelBtn: this.translate.get("remove.cancelBtn"),
      confirmBtn: this.translate.get("remove.confirmBtn"),
      successMessage: this.translate.get("remove.successMessage")
    }).subscribe(res => {
      this.swal.callSwal(res.doYouWantToDelete, res.cancelBtn, res.confirmBtn, res.successMessage, () => {
        this.shoppingCarts.splice(index, 1);
        localStorage.setItem("shoppingCarts", JSON.stringify(this.shoppingCarts));//localstorage güncelleme
        this.count = this.shoppingCarts.length;//count'u güncelleme
        this.calcTotal();
      });
    })
  }

  payment(data: PaymentModel, callBack: (res: any) => void) {
    this.spinner.show();
    this.http.post("https://localhost:7078/api/ShoppingCarts/Payment", data)
      .subscribe({
        next: (res: any) => {
          callBack(res);
          this.spinner.hide();
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);
          this.spinner.hide();
        }
      })
  }
}

