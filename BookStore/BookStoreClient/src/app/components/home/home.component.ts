import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { RequestModel } from '../../models/request.model';
import { BookModel } from '../../models/book.model';
import { SwallService } from '../../services/swall.service';
import { TranslateService } from '@ngx-translate/core';
import { ShoppingCartService } from '../../services/shopping-cart.service';



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
    private shopping: ShoppingCartService,//HttpClient Api isteklerini yaptığımız servis
    private swal: SwallService,
    private translate : TranslateService
    ) {
    this.getCategories();
  }

  addShoppingCart(book: BookModel) {
    this.shopping.shoppingCarts.push(book);
    localStorage.setItem("shoppingCarts", JSON.stringify(this.shopping.shoppingCarts))
    this.shopping.count++;
    this.translate.get("addBookInShoppingCartIsSuccessful").subscribe(res=> {
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
