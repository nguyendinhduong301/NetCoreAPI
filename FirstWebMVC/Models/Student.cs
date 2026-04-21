using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;
namespace FirstWebMVC.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Mã sinh viên không được để trống")]
        [StringLength(20, ErrorMessage = "Mã sinh viên tối đa 20 ký tự")]
        public string StudentCode { get; set; } = "default!";

        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(50, ErrorMessage = "Tên tối đa 50 ký tự")]
        public string FullName { get; set; } = "default!";
        [Range(1, 100, ErrorMessage = "Tuổi từ 1 đến 100")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = "default";
        public string? FacultyId { get; set; } = default!;
        [ForeignKey("FacultyId")]
        public virtual Faculty? Faculty { get; set; } = default!;
        
    }
}
