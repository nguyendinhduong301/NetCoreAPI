using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Data;
using FirstWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;

namespace FirstWebMVC.Controllers
{
    public class StudentController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;
        [HttpGet]
public IActionResult ImportExcel()
{
    return View();
}
[HttpPost]
public IActionResult ImportExcel(IFormFile file)
{
    if (file == null || file.Length == 0)
    {
        ViewBag.Message = "Vui lòng chọn file!";
        return View();
    }

    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

    using (var stream = new MemoryStream())
    {
        file.CopyTo(stream);

        using (var package = new ExcelPackage(stream))
        {
            var worksheet = package.Workbook.Worksheets[0];
            int rowCount = worksheet.Dimension.Rows;

            for (int row = 2; row <= rowCount; row++)
            {
                int age = 0;
                int.TryParse(worksheet.Cells[row, 3].Text, out age);

                var student = new Student
                {
                    StudentCode = worksheet.Cells[row, 1].Text,
                    FullName = worksheet.Cells[row, 2].Text,
                    Age = age,
                    Email = worksheet.Cells[row, 4].Text
                };

                _context.Students.Add(student);
            }

            _context.SaveChanges();
        }
    }

    ViewBag.Message = "Import thành công!";
    return View();
}
        public async Task<IActionResult> Index()
        {
                 var result = await _context.Students
                            .Select(s => new StudentVM
                            {
                                StudentCode = s.StudentCode,
                                FullName = s.FullName,
                                FacultyName = s.Faculty!.FacultyName
                            })
                            .ToListAsync();
            return View(result);
        }
    public IActionResult Create()
        {
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "FacultyId", "FacultyName");
            return View();
        }
    [HttpPost]
    [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create([Bind("StudentCode,FullName,FacultyId")] Student student)
        {if (ModelState.IsValid)
        {
            _context.Students.Add(student); //quản lí trạng thái dữ liệu
            await _context.SaveChangesAsync(); //lưu vào csdl
            return RedirectToAction(nameof(Index));
        }
        ViewData["FacultyId"] = new SelectList(_context.Faculties, "FacultyId", "FacultyName", student.FacultyId);
        return View(student);
        }
        public async Task<IActionResult> Edit(int id)
{
    var student = await _context.Students.FindAsync(id);
    if (student == null)
    {
    return View("NotFound");
    }
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "FacultyId", "FacultyName", student.FacultyId);
            return View(student);
}
    [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("Id,StudentCode,FullName,FacultyId")] Student student)
{
    if (id != student.Id)
    {
        return View("NotFound");
    }

    if (ModelState.IsValid)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "FacultyName", student.FacultyId);
    return View(student);
}
public async Task<IActionResult> Delete(int id)
{
    var student = await _context.Students.FindAsync(id);
    if (student == null)
            {
                return View("NotFound");
            }
            return View(student);
}
    [HttpPost]
        public async Task<IActionResult> Delete(Student std)
        {
            _context.Students.Remove(std);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // public IActionResult Index()
        // {
        //      return View();
        //  }

        //  [HttpPost]
        //  public IActionResult Index(int Id, string FullName, string Address)
        //  {
        //      string strOutput = "Tôi xin chào: " + "-" + Id + "-" + FullName + " - " + Address;

        //     ViewBag.infoStudent = strOutput;

        //     return View();
        //  }
    }
}