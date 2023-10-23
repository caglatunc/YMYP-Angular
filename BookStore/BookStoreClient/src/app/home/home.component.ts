import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { RequestModel } from '../models/request.model';
import { BookModel } from '../models/book.model';
import { ShoppingCardService } from '../services/shopping-card.service';
import { SwallService } from '../services/swall.service';
import { TranslateService } from '@ngx-translate/core';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  books: BookModel[] = [];
  categories: any = [];
  pageNumbers: number[] = [];
  request: RequestModel = new RequestModel();
  searchCategory: string = "";
  newData: any[] = [];


  constructor(
    private http: HttpClient,
    private shopping: ShoppingCardService,//HttpClient Api isteklerini yaptığımız servis
    private swal: SwallService,
    private translate : TranslateService
    ) {
    this.getCategories();
  }

  addShoppingCard(book: BookModel) {
    this.shopping.shoppingCards.push(book);
    localStorage.setItem("shoppingCards", JSON.stringify(this.shopping.shoppingCards))
    this.shopping.count++;
    this.translate.get("addBookInShoppingCardIsSuccessful").subscribe(res=> {
      this.swal.callToast(res);
    })
  }

  feedData() {
    this.request.pageSize += 10;
    this.newData = [];
    this.getAll();
  }

  changeCategory(categoryId: number | null = null) {
    this.request.categoryId = categoryId;
    this.request.pageSize = 0; //Uygulammanın başında sıfır gelmesi için yapıyoruz.Kategori değiştirdiğimde kaydı sıfırlaması gerekır.
    this.feedData();
  }

  getAll() {
    this.http
      .post<BookModel[]>(`https://localhost:7078/api/Books/GetAll/`, this.request)
      .subscribe(res => {
        this.books = res;
      })
  }

  getCategories() {
    this.http.get("https://localhost:7078/api/Categories/GetAll") //client api isteği
      .subscribe(res => {
        this.categories = res;
        this.getAll();
      });
  }

}
