namespace FirstWebMVC.Models.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }
        public string StudentCode { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string FacultyName { get; set; } = default!;
        public string Age { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}