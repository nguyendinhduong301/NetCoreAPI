using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Models; 

namespace FirstWebMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Khai báo các bảng trong database
        public DbSet<Student> Students { get; set; }
    }
}