export class BookModel{
    id:number=0;
    title:string ="";
    author: string ="";
    summary: string ="";
    coverImgUrl: string ="";
    price:Money = new Money();
    quantity: number = 0;
    isActive: boolean = true;
    isDleted: boolean = false;
    isbn: string = "";
    createAt: string ="";
}

export class Money{
    value: number =0;
    currency: string ="₺";
}