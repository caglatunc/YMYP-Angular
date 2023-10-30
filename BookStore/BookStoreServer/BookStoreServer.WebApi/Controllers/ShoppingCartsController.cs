using BookStoreServer.WebApi.Context;
using BookStoreServer.WebApi.Dtos;
using BookStoreServer.WebApi.Models;
using BookStoreServer.WebApi.Models.ValueObjects;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class ShoppingCartsController : ControllerBase
{
    [HttpPost]
    public IActionResult Payment(PaymentDto requestDto)
    {
        decimal total = 0;
        decimal commission = 0;
        foreach (var book in requestDto.Books)
        {
            total += book.Price.Value;
        }
        commission = total;
        //commission = total * 1.2m/100;

        Currency currency = Currency.TRY;
        string requestCurrency = requestDto.Books[0]?.Price?.Currency;//İlk kitabın para tipini alıyoruz.

        if (!string.IsNullOrEmpty(requestCurrency)) 
        {
            switch (requestCurrency)
            {
                case "₺":
                    currency = Currency.TRY;
                    break;
                case "$":
                    currency = Currency.USD;
                    break;
                case "£":
                    currency = Currency.GBP;
                    break;
                case "€":
                    currency = Currency.EUR;
                    break;
                default:
                    throw new Exception("Para birimi bulunamadı.");
                    break;
            }
        }
        else
        {
            throw  new Exception("Sepette ürününüz yok!");
        }

        //Bağlantı bilgilerini istiyor
        Options options = new Options();
        options.ApiKey = "sandbox-4OAzqhdZcQazv1T4W46N3dgMYA8hArsm";
        options.SecretKey = "sandbox-kWVjwRAEYVhxvLvt2OmCtvG5NZzyawqH";
        options.BaseUrl = "https://sandbox-api.iyzipay.com";

        //
        CreatePaymentRequest request = new CreatePaymentRequest();
        request.Locale = Locale.TR.ToString();
        request.ConversationId = Guid.NewGuid().ToString();
        request.Price = total.ToString(); //Ödeme kısmı
        request.PaidPrice = commission.ToString(); // komiston + ödeme tutarı
        request.Currency =currency.ToString();
        request.Installment = 1;
        request.BasketId = Order.GetNewOrderNumber();//CTS202300000005 sipariş numarası
        request.PaymentChannel = PaymentChannel.WEB.ToString();
        request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

        PaymentCard paymentCard = requestDto.PaymentCard;// Parametreden kart bilgilerini alıyoruz. Bu bilgileri kulanıcıdan alacağız.
        request.PaymentCard = paymentCard;

        //Kullanıcı girişi olmadığı için karşı tarafın bu bilgileri göndermesi gerekiyor.
       
        Buyer buyer = requestDto.Buyer;
        buyer.Id = Guid.NewGuid().ToString();
        request.Buyer = buyer;

     
        request.ShippingAddress = requestDto.ShippingAddress;//Karşı tarafa göndereceğimiz request, paramtereden aldığımız requestDto.
        request.BillingAddress = requestDto.BillingAddress;

        List<BasketItem> basketItems = new List<BasketItem>(); // Sepete gönderidğim tüm ürünleri listeme eklettim. 

        foreach (var book in requestDto.Books )
        {
            BasketItem item = new BasketItem();
            item.Category1 ="Book";
            item.Category2 ="Book";
            item.Id = book.Id.ToString();
            item.Name = book.Title; 
            item. ItemType = BasketItemType.PHYSICAL.ToString();
            item.Price = book.Price.Value.ToString();
            basketItems.Add(item);  
        }
            request.BasketItems = basketItems;
                                               
        Payment payment = Iyzipay.Model.Payment.Create(request, options);

        if(payment.Status == "success")
        {
            string orderNumber = Order.GetNewOrderNumber();
            
            List<Order> orders = new();
            foreach(var book in requestDto.Books)
            {
                Order order = new Order()
                {
                    OrderNumber = orderNumber,
                    BookId = book.Id,
                    Price = new Money(book.Price.Value, book.Price.Currency),
                    PaymentDate = DateTime.Now,
                    PaymentType = "Credit Cart",
                    PaymentNumber = payment.PaymentId,
                    CreatedAt = DateTime.Now
                };
                orders.Add(order);
            }
            AppDbContext context = new AppDbContext();
            context.Orders.AddRange(orders);
            context.SaveChanges();
            return NoContent();
        }
        else
        {
            return BadRequest(payment.ErrorMessage);
        }

        //status: success | failure
        //ErrotMessage: Hata mesajı var.
        return NoContent();
    }
}
