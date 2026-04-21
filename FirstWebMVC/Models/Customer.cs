using System.ComponentModel.DataAnnotations;
using FirstWebMVC.Models;
public class Customer
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên không được trống")]
    public string? Name { get; set; }

    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string? Email { get; set; }

    public List<Order>? Orders { get; set; }
}