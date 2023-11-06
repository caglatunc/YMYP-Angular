import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class PopupService {
  processBar: number = 0;
  interval: any;
  isPopupShow: boolean = false;
  notShowThisPopup: boolean = false;

  constructor() { 
    if(localStorage.getItem("notShowDiscoverPopupAgain")){
      this.notShowThisPopup = true ; 
    }
  }
  
  showDriverPopup(){
    if(!this.notShowThisPopup){
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
          if(!this.isPopupShow) clearInterval(this.interval);//Eğer popup kapatılmışsa intervali durduruyoruz.

          
        }
      }, 8000);
    }
  }
  changePopupShow() {
    this.isPopupShow = !this.isPopupShow;
  }

  notShowAgain(){
    localStorage.setItem("notShowDiscoverPopupAgain", "true");
    this.notShowThisPopup = true;
  }

}
