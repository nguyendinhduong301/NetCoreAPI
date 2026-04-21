using FirstWebMVC.Models;
using System.ComponentModel.DataAnnotations;
public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên sản phẩm không được trống")]
    public string? Name { get; set; }

    [Range(1, 1000000)]
    public decimal Price { get; set; }

    public List<OrderDetail>? OrderDetails { get; set; }
}