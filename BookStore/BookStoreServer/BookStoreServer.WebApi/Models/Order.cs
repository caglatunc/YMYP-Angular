using BookStoreServer.WebApi.Models.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreServer.WebApi.Models;

public sealed class Order
{
   
    public int id { get; set; }
    public string OrderNumber { get; set; }//16 hane ve unique olmalı

    [ForeignKey("Book")]
    public int BookId { get; set; }
    public Book Book { get; set; } 
    public Money Price { get; set; }
    public DateTime CreatedAt { get; set; }//Siparişin oluşturulma tarihi
    public DateTime PaymentDate { get; set; }//Siparişin ödeme tarihi
    public string PaymentType { get; set; }//Ödemeyi hangi kanalla yaptığımızı tutuyoruz
    public string PaymentNumber { get; set; }//Ödeme numarası


    public static string GetNewOrderNumber()
    {
        //Burayı değştireceğiz.
        return Guid.NewGuid().ToString();
    }
}
