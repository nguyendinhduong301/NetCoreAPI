using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Data;
using FirstWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstWebMVC.Controllers
{
    public class StudentController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<IActionResult> Index()
        {
                return View(await _context.Students.ToListAsync());
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
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
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