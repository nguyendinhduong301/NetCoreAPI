using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FirstWebMVC.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string StudentCode { get; set; } = "default!";

        public string FullName { get; set; } = "default!";
        public int? Age { get; set; }
    }
}