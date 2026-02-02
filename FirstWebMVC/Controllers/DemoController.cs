using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace FirstWebMVC.Controllers
{
    public class DemoController : Controller
    { 
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Demo()
        {
            return View();
        }
        [HttpPost]
public IActionResult Index(string FullName, string Address)
{
    string strOutput = "Xin chào " + FullName + " đến từ " + Address;
    ViewBag.Message = strOutput;

    return View();
}

        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "Hello Nguyễn Đình Dương 2221050741";
        }
    }
}
