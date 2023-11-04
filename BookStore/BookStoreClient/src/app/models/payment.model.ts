import { BookModel } from "./book.model";

export class PaymentModel {
    userId: number = 0;
    books: BookModel[] = []
    buyer: BuyerModel = new BuyerModel();
    shippingAddress: AddressModel = new AddressModel();
    billingAddress: AddressModel = new AddressModel();
    paymentCard: PaymentCardModel = new PaymentCardModel();
}


export class BuyerModel {
    id: string = "";
    name: string = "Çağla";
    surname: string = "Tunç Savaş";
    identityNumber: string = "11111111111";
    email: string = "caglatuncsavas@gmail.com";
    gsmNumber: string = "5555555555";
    registrationDate: string = "";
    lastLoginDate: string = "";
    registrationAddress: string = "";
    city: string = "";
    country: string = "";
    zipCode: string = "";
    ip: string = "";
}

export class AddressModel {
    description: string = "İstanbul";
    zipCode: string = "34245";
    contactName: string = "Çağla Tunç Savaş";
    city: string = "İstanbul";
    country: string = "Türkiye";
}

export class PaymentCardModel {
    cardHolderName: string = "Çağla Tunç Savaş";
    cardNumber: string = "";
    expireYear: string = "";
    expireMonth: string = "";
    cvc: string = "544";
}