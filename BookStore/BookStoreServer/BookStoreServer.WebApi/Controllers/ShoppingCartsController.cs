using BookStoreServer.WebApi.Context;
using BookStoreServer.WebApi.Dtos;
using BookStoreServer.WebApi.Enums;
using BookStoreServer.WebApi.Models;
using BookStoreServer.WebApi.Models.ValueObjects;
using BookStoreServer.WebApi.Services;
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
    public async Task<IActionResult> Payment(PaymentDto requestDto)
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
        Iyzipay.Options options = new Iyzipay.Options();
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

            AppDbContext context = new();

           OrderStatus orderStatus = new()
           {
               OrderNumber = orderNumber,
               Status = OrderStatusEnum.AwaitingApproval,
              StatusDate = DateTime.Now
           };

            context.OrderStatuses.Add(orderStatus);    
            context.Orders.AddRange(orders);
            context.SaveChanges();

            string response = await MailService.SendEmailAsync(requestDto.Buyer.Email, "Siparişiniz Alındı", $@"
                <h1>Siparişiniz Alındı</h1>
                <p>Sipariş numaranız: {orderNumber}</p>
                <p>Ödeme numaranız: {payment.PaymentId}</p>
                <p>Ödeme tutarınız: {payment.PaidPrice}</p>
                <p>Ödeme tarihiniz: {DateTime.Now}</p>
                <p>Ödeme tipiniz: Kredi Kartı</p>
                <p>Ödeme durumunuz: Onay bekliyor</p>");

            //mail göndersin
            //smtp => mail sisteminin bir tane smtp.google.com 127.01.20.312
            //email
            //password
            //port // 587 465
            //ssl // true false
            //html


            return NoContent();
        }
        else
        {
            return BadRequest(payment.ErrorMessage);
        }

        //status: success | failure
        //ErrotMessage: Hata mesajı var.
    }
}
