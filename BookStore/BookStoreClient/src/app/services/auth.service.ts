import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  token: string = "";
  userId: number | null = 0;
  userName: string = "";


  constructor() { }

  //Kullanıcı girişi yapıp yapmadığını kontrol eden metod.Karlşılığında boolean değer döndürüyor.
  isAuthentication() {
    const responseString = localStorage.getItem("response");//Token bilgisini localstorage'dan alıyoruz.
    if (responseString) {
      const responseJson = JSON.parse(responseString);//Token bilgisini json'a çeviriyoruz.
      this.token = responseJson.token;
      this.userId = responseJson.userId;
      this.userName = responseJson.userName;
      return true;
    } else {
      this.userId = null;
    }
    return false;
  }
}
