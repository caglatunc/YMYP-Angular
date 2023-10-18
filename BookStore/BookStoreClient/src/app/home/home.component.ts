import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { RequestModel } from '../models/request.model';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  books: any[]=[];
  categories: any = [];
  pageNumbers: number[] =[];
  request: RequestModel= new RequestModel();
  searchCategory: string = "";
 
  constructor( private http: HttpClient) //HttpClient Api isteklerini yaptığımız servis
  {
    //this.getAll();
    this.getCategories();
  }

  changeCategory(categoryId: number | null = null){
   
     this.request.categoryId = categoryId;
     //this.getAll();
  }
  getAll(){
   
    this.http
    .post<any>(`https://localhost:7078/api/Books/GetAll/`, this.request)
    .subscribe(res=> {
      this.books = res;
      
    })
  }

  getCategories(){
    this.http.get("https://localhost:7078/api/Categories/GetAll") //client api isteği
    .subscribe(res=> this.categories = res);
  }


  setPageNumber(){
    this.pageNumbers = [];
    for(let i=0; i<this.response.totalPageCount; i++){
      this.pageNumbers.push(i +1)
    }
  }
}
