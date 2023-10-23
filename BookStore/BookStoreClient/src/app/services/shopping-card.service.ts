import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCardService {

  shoppingCards: any[] = [];
  count: number = 0;
  constructor() { 
    if(localStorage.getItem("shoppingCards")){
      const cards: string | null = localStorage.getItem("shoppingCards")
      if(cards !== null){
        this.shoppingCards = JSON.parse(cards);
        this.count = this.shoppingCards.length;
      }
    }
  }
}
