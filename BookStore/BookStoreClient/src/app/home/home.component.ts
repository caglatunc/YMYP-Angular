import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { RequestModel } from '../models/request.model';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  response: any;
  categories: any = [];
  pageNumbers: number[] = [];
  request: RequestModel= new RequestModel();
 
  constructor( private http: HttpClient) //HttpClient Api isteklerini yaptığımız servis
  {
    this.getAll();
    this.getCategories();
  }

  changeCategory(categoryId: number | null = null){
    console.log('Kategori değişti');
     this.request.categoryId = categoryId;
     this.getAll(1);
  }
  getAll(pageNumber = 1){
    this.request.pageNumber = pageNumber;
    this.http
    .post(`https://localhost:7078/api/Books/GetAll/`, this.request)
    .subscribe(res=> {
      this.response = res;
      this.setPageNumber();
    })
  }

  getCategories(){
    this.http.get("https://localhost:7078/api/Categories/GetAll") //api isteği
    .subscribe(res=> this.categories = res);
  }


  setPageNumber(){
    this.pageNumbers = [];
    for(let i=0; i<this.response.totalPageCount; i++){
      this.pageNumbers.push(i +1)
    }
  }
}
