import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { BookModel, Money } from 'src/app/models/book.model';
import { OrderStatusEnum } from 'src/app/models/order-status-enum';
import { OrderModel } from 'src/app/models/order.model';
import { AuthService } from 'src/app/services/auth.service';
import { ErrorService } from 'src/app/services/error.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent {
orders:OrderModel[]=[];
language:string = "en";

constructor(
  private http: HttpClient,
  private auth: AuthService,
  private err: ErrorService,
  private translate: TranslateService
){
  if(localStorage.getItem("language")){
    this.language = localStorage.getItem("language") as string;
  }
    
  this.getAll();

}

getAll(){
 this.auth.isAuthentication();
 this.http.get("https://localhost:7078/api/Orders/" + this.auth.userId).subscribe({
  next:(res:any)=> {
this.orders = res;
  },
  error: (err: HttpErrorResponse)=>{
    this.err.errorHandler(err);
  }
 })
}
checkOrderIsRejected(order: OrderModel){
  for(let o of order.orderStatuses){
   if(o.status == OrderStatusEnum.Rejected){
      return true;
   } 
  }
  return false;
}
checkOrderIsReturned(order: OrderModel){
  for(let o of order.orderStatuses){
   if(o.status == OrderStatusEnum.Returned){
      return true;
   } 
  }
  return false;
}

}




