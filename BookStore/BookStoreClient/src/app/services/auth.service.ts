import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  token: string = "";
  userId:number =0;
  userName:string ="";


  constructor() { }

  //Kullanıcı girişi yapıp yapmadığını kontrol eden metod.Karlşılığında boolean değer döndürüyor.
  isAuthentication(){
const responseString = localStorage.getItem("token");//Token bilgisini localstorage'dan alıyoruz.
if(responseString ){
  const responseJson = JSON.parse(responseString);//Token bilgisini json'a çeviriyoruz.
  this.token = responseJson.token;
  this.userId= responseJson.userId;
  this.userName= responseJson.userName;
  return true;
}
return false;
  }
}
