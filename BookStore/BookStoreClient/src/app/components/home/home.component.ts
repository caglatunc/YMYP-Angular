import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { RequestModel } from '../../models/request.model';
import { BookModel } from '../../models/book.model';
import { SwallService } from '../../services/swall.service';
import { TranslateService } from '@ngx-translate/core';
import { ShoppingCartService } from '../../services/shopping-cart.service';
import { AddShoppingCartModel } from 'src/app/models/add-shopping-cart.model';
import { AuthService } from 'src/app/services/auth.service';
import { ErrorService } from 'src/app/services/error.service';
import { PopupService } from 'src/app/services/popup.service';





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
  loaderDatas = [1, 2, 3, 4, 5, 6];
  isLoading: boolean = true;

  constructor(
    private http: HttpClient,
    private shopping: ShoppingCartService,//HttpClient Api isteklerini yaptığımız servis
    private swal: SwallService,
    private translate: TranslateService,
    private auth: AuthService,
    private error: ErrorService,
    private popup: PopupService
  ) {
    //Seçilen kategoriyi hafızada saklıyoruz.
    if (localStorage.getItem("request")) {
      const requestString: any = localStorage.getItem("request");
      const requestObj = JSON.parse(requestString);
      this.request = requestObj;
    }
    this.getCategories();
  }



  addShoppingCart(book: BookModel) {
    if (localStorage.getItem("response")) {
      const data: AddShoppingCartModel = new AddShoppingCartModel();
      data.bookId = book.id;
      data.price = book.price;
      data.quantity = 1;
      data.userId = this.auth.userId;
      this.http.post("https://localhost:7078/api/ShoppingCarts/Add", data).subscribe({
        next: (res: any) => {
          this.shopping.getAllShoppingCarts();
          this.translate.get("addBookInShoppingCartIsSuccessful").subscribe(res => {
            this.swal.callToast(res);        
          });
        },
        error: (err: HttpErrorResponse) => {
          this.error.errorHandler(err);
        }

      });
    } else {
      if (book.quantity < 1) {
        this.translate.get("bookQuantityIsNotEnough").subscribe(res => {
          this.swal.callToast(res, "error");
        });
      } else {
        const checkBookIsAlreadyExists=this.shopping.shoppingCarts.filter(p=> p.id == book.id)[0];
        if(checkBookIsAlreadyExists !== undefined){
          this.shopping.shoppingCarts.filter(p=> p.id == book.id)[0].quantity += 1;
        }else{
          const newBook = {...book};
          newBook.quantity = 1;
          this.shopping.shoppingCarts.push(newBook);
        }
       
        this.shopping.calcTotal();
        localStorage.setItem("shoppingCarts", JSON.stringify(this.shopping.shoppingCarts))
        this.translate.get("addBookInShoppingCartIsSuccessful").subscribe(res => {
          this.swal.callToast(res);
        });
      }
    }
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
    this.isLoading = true;
    this.http
      .post<BookModel[]>(`https://localhost:7078/api/Books/GetAll/`, this.request)
      .subscribe({
        next: (res: any) => {
          this.books = res;
          this.isLoading = false;
          localStorage.setItem("request", JSON.stringify(this.request));
        },
        error: (err: HttpErrorResponse) => {
          this.error.errorHandler(err);
        }
      })
  }

  getCategories() {
    this.isLoading = true;
    this.http.get("https://localhost:7078/api/Categories/GetAll") //client api isteği
      .subscribe({
        next: (res: any) => {
          this.categories = res;
          this.getAll();
          this.isLoading = false;
          this.popup.showDriverPopup();
        },
        error: (err: HttpErrorResponse) => {
          this.error.errorHandler(err);
        }
      });
  }

}
