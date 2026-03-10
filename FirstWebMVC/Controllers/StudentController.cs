using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
public IActionResult Index(int Id, String FullName, String Address)
{
string strOutput = "Tôi xin chào: "+"-"+ Id + "-"+ FullName + " - " + Address;

    ViewBag.infoStudent = strOutput;

    return View();
}
    }
}
