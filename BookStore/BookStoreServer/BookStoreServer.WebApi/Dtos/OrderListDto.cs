using BookStoreServer.WebApi.Models;
using BookStoreServer.WebApi.Models.ValueObjects;


namespace BookStoreServer.WebApi.Dtos;

public sealed record OrderListDto
{
    public int Id { get; set; }
    public string OrderNumber { get; set; }
    public Book Book { get; set; }
    public int Quantity { get; set; }//Siparişteki kitap sayısı
    public Money Price { get; set; }
    public DateTime CreatedAt { get; set; }//Siparişin oluşturulma tarihi
    public DateTime PaymentDate { get; set; }//Siparişin ödeme tarihi
    public string PaymentType { get; set; }//Ödemeyi hangi kanalla yaptığımızı tutuyoruz
    public string PaymentNumber { get; set; }//Ödeme numarası
    public  List<OrderStatus> OrderStatuses { get; set; }
    public string Comment { get; set; }
    public short? Raiting { get; set; }

};
