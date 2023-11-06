using BookStoreServer.WebApi.Context;
using BookStoreServer.WebApi.Models.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreServer.WebApi.Models;

public sealed class Order
{

    public int Id { get; set; }
    public string OrderNumber { get; set; }//16 hane ve unique olmalı

    [ForeignKey("Book")]
    public int BookId { get; set; }
    public Book Book { get; set; }
    public int Quantity { get; set; }//Siparişteki kitap sayısı
    public int? UserId { get; set; }  
    public Money Price { get; set; }
    public DateTime CreatedAt { get; set; }//Siparişin oluşturulma tarihi
    public DateTime PaymentDate { get; set; }//Siparişin ödeme tarihi
    public string PaymentType { get; set; }//Ödemeyi hangi kanalla yaptığımızı tutuyoruz
    public string PaymentNumber { get; set; }//Ödeme numarası
    public string Comment { get; set; }
    public short? Raiting { get; set; }


    public static string GetNewOrderNumber()
    {
        string initialLetter = "CTS";
        string year = DateTime.Now.Year.ToString();
        string newOrderNumber = initialLetter + year;

        AppDbContext context = new();
        var lastOrder = context.Orders.OrderByDescending(o => o.Id).FirstOrDefault();
        string currentOrderNumber = lastOrder?.OrderNumber;

        if (currentOrderNumber != null)
        {
            string currentYear = currentOrderNumber.Substring(3, 4);
            int startIndex = (currentYear == year) ? 7 : 0;
            GenerateUniqueOrderNumber(context, ref newOrderNumber, currentOrderNumber.Substring(startIndex));
        }
        else
        {
            newOrderNumber += "000000001";
        }

        return newOrderNumber;
    }

    private static void GenerateUniqueOrderNumber(AppDbContext context, ref string newOrderNumber, string currentOrderNumStr)
    {
        int currentOrderNumberInt = int.TryParse(currentOrderNumStr, out var num) ? num : 0;
        bool isOrderNumberUnique = false;

        while (!isOrderNumberUnique)
        {
            currentOrderNumberInt++;
            newOrderNumber += currentOrderNumberInt.ToString("D9");
            string checkOrderNumber = newOrderNumber;
            var order = context.Orders.FirstOrDefault(o => o.OrderNumber == checkOrderNumber);
            if (order == null)
            {
                isOrderNumberUnique = true;
            }
        }
    }
}


