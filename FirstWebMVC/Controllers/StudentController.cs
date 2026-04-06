using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Data;
using FirstWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWebMVC.Controllers
{
    public class StudentController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<IActionResult> Index()
        {
               var students = _context.Students.ToList();

            return View(students);
        }
    public IActionResult Create()
        {
            return View();
        }
    [HttpPost]
        public async Task<IActionResult> Create(Student std)
        {if (ModelState.IsValid)
        {
            _context.Students.Add(std);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(std);
        }
        public async Task<IActionResult> Edit(int id)
{
    var student = await _context.Students.FindAsync(id);
    if (student == null)
    {
    return View("NotFound");
    }
            return View(student);
}
    [HttpPost]
        public async Task<IActionResult> Edit(Student std)
        {
            _context.Students.Update(std);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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