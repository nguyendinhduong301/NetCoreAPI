using FirstWebMVC.Models;
using System.ComponentModel.DataAnnotations;
public class Order
{
    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    // FK
    public int CustomerId { get; set; }

    public Customer? Customer { get; set; }

    public List<OrderDetail>? OrderDetails { get; set; }
}