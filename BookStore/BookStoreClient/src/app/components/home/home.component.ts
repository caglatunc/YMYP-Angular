import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RequestModel } from '../../models/request.model';
import { BookModel } from '../../models/book.model';
import { SwallService } from '../../services/swall.service';
import { TranslateService, TranslateModule } from '@ngx-translate/core';
import { ShoppingCartService } from '../../services/shopping-cart.service';
import { AddShoppingCartModel } from 'src/app/models/add-shopping-cart.model';
import { AuthService } from 'src/app/services/auth.service';
import { ErrorService } from 'src/app/services/error.service';
import { PopupService } from 'src/app/services/popup.service';
import { CategoryPipe } from '../../pipes/category.pipe';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { IconControlDirective } from '../../directives/icon-control.directive';
import { FormsModule } from '@angular/forms';
import { NgIf, NgFor, NgClass, CurrencyPipe } from '@angular/common';
import { BestsellerModel } from 'src/app/models/bestseller.model';
import { OrderModel } from 'src/app/models/order.model';
import { RouterLink } from '@angular/router';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css'],
    standalone: true,
    imports: [NgIf, FormsModule, NgFor, IconControlDirective, NgClass, InfiniteScrollModule, CurrencyPipe, TranslateModule, CategoryPipe, RouterLink]
})
export class HomeComponent implements OnInit {
  books: BookModel[] = [];
  categories: any = [];
  pageNumbers: number[] = [];
  request: RequestModel = new RequestModel();
  searchCategory: string = "";
  newData: any[] = [];
  loaderDatas = [1, 2, 3, 4, 5, 6];
  isLoading: boolean = true;
  bestsellers: BookModel[] = [];
  newBooks: BookModel[] = [];
  lastComments: OrderModel[] = [];

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
    
  }
  ngOnInit(): void {
    this.getCategories();
    this.getBestsellers();
    this.getNewBooks();
    this.getLastComments()
  }


  getBestsellers() {
    this.http.get<BookModel[]>('https://localhost:7078/api/Home/Bestsellers/').subscribe({
      next: (res: any) => {
        this.bestsellers = res;
      },
      error: (err: HttpErrorResponse) => {
        this.error.errorHandler(err);
      }
    });
  }

  getNewBooks() {
    this.http.get<BookModel[]>('https://localhost:7078/api/Home/GetNewBooks/').subscribe({
      next: (res: any) => {
        this.newBooks = res;
      },
      error: (err: HttpErrorResponse) => {
        this.error.errorHandler(err);
      }
    });
  }
 
  getLastComments() {
    this.http.get<BestsellerModel[]>('https://localhost:7082/api/Home/GetLastComments/').subscribe({
      next: (res: any) => {
        this.lastComments = res;
      },
      error: (err: HttpErrorResponse) => {
        this.error.errorHandler(err);
      }
    });
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

  leftSlider() {
    const workList:any = document.querySelector(".work-list");
    const slideAmount = 295;  
    workList.scrollLeft -= slideAmount * 1;
    workList.scrollLeft = Math.max(0, workList.scrollLeft);
  }

  rightSlider(){
    const workList:any = document.querySelector(".work-list");
    const slideAmount = 295; 
    const maxScroll = slideAmount * (11) -5;
    workList.scrollLeft += slideAmount * 1;
    workList.scrollLeft = Math.min(maxScroll, workList.scrollLeft);
    
  }

}
