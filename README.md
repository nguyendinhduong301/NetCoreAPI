Cấu trúc thư mục của dự án .NET MVC :
1. Tên project (MVCMOVIE)
- Là thư mục gốc của toàn bộ ứng dụng
Chứa tất cả mã nguồn, cấu hình và tài nguyên của dự án
2. Controllers
- Thư mục chứa các Controller
- Chức năng:
+ Nhận yêu cầu (request) từ View hoặc trình duyệt
+ Xử lý nghiệp vụ
+ Trả kết quả về View
- Ví dụ:
HomeController.cs
MovieController.cs
=> Controller đóng vai trò trung gian giữa Model và View
3. Models
- Chứa các lớp đại diện cho CSDL của ứng dụng
- Chức năng:
+ Định nghĩa cấu trúc dữ liệu
+ Mapping với bảng trong Database
+ Kiểm tra dữ liệu (validation)
- Ví dụ:
Movie.cs
User.cs
=> Model phản ánh logic và dữ liệu của hệ thống
4. Views
- Thư mục chứa các thành phần hiển thị giao diện người dùng
- Chức năng:
+ Hiển thị dữ liệu ra giao diện
+ Viết bằng Razor (.cshtml)
- Cấu trúc thường gặp:
Views
├── Home
│   └── Index.cshtml
├── Shared
│   └── _Layout.cshtml
=> Mỗi Controller thường có một thư mục View tương ứng
5. wwwroot
- Thư mục chứa các file tĩnh của dự án
- Bao gồm:
+ HTML
+ CSS
+ JavaScript
+ Hình ảnh
- Ví dụ:
wwwroot
├── css
├── js
├── images
=> Các file trong wwwroot có thể truy cập trực tiếp từ trình duyệt
6. bin & obj
- Thư mục hệ thống (tự động sinh)
bin: chứa file đã build (.dll, .exe)
obj: chứa file trung gian khi biên dịch
=> Không chỉnh sửa trực tiếp
7. Properties
Chứa các cấu hình liên quan đến môi trường chạy
Ví dụ: launchSettings.json
8. appsettings.json
- File chứa cấu hình dự án
- Dùng để:
Khai báo chuỗi kết nối CSDL
Cấu hình môi trường
- Ví dụ:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=..."
  }
}
9. Program.cs
- File khởi động ứng dụng
Chức năng:
Cấu hình routing
Khai báo middleware
Chạy web server
=> Đây là trái tim của ứng dụng ASP.NET Core
10. MVCApp.csproj & MVCApp.sln
.csproj: file cấu hình project
.sln: file quản lý solution
=> Luồng hoạt động MVC (tóm tắt) : User → View → Controller → Model → Controller → View → User
-------------------------------------------------------------------------------------------------------------
Tìm hiểu về định tuyến (Route) trong .Net MVC
1. Khái niệm định tuyến (Routing)
Định tuyến (Routing) trong .NET MVC là cơ chế:
Ánh xạ URL người dùng truy cập
Đến Controller và Action tương ứng trong ứng dụng
- Nhờ Routing, ứng dụng biết:
Khi người dùng gõ URL này → chạy controller nào → action nào
2. Vai trò của Routing trong mô hình MVC
Routing giúp:
Tách URL khỏi cấu trúc vật lý của thư mục
Tạo URL ngắn gọn, thân thiện với người dùng và SEO
Điều hướng đúng luồng xử lý của ứng dụng
=> Routing là cầu nối giữa View (trình duyệt) và Controller
- Cơ chế hoạt động của Routing
Luồng xử lý: Người dùng → URL → Routing → Controller → Action → View
Ví dụ: https://localhost:5001/Home/Index
=> Routing sẽ hiểu:
Controller: HomeController
Action: Index()
4. Định tuyến mặc định (Default Route)
- Cấu hình trong Program.cs (ASP.NET Core MVC)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
5. Routing có tham số
Ví dụ URL:
/Product/Detail/5
Controller:
public IActionResult Detail(int id)
{
    return View();
}
=> id = 5 được truyền vào Action
6. Attribute Routing (Định tuyến bằng Attribute)
- Khai báo trực tiếp trên Controller hoặc Action
Ví dụ:
[Route("san-pham")]
public class ProductController : Controller
{
    [Route("chi-tiet/{id}")]
    public IActionResult Detail(int id)
    {
        return View();
    }
}
URL:
/san-pham/chi-tiet/10
=> Dễ đọc – thân thiện SEO
8. Một số lưu ý khi dùng Routing
Tên Controller không cần chữ “Controller” trong URL
Routing không phân biệt hoa – thường
Route được kiểm tra từ trên xuống dưới
Route cụ thể nên đặt trước route tổng quát
---------------------------------------------------------------------------------------------------
TÌM HIỂU VỀ NAMESPACE TRONG C#
1. Khái niệm namespace
- Namespace trong C# là một không gian tên, dùng để:
Tổ chức các class, interface, struct, enum…
Tránh trùng tên giữa các thành phần trong chương trình
Giúp code rõ ràng, dễ quản lý và mở rộng
=> Có thể hiểu namespace giống như thư mục trong hệ thống file.
2. Vai trò của namespace
Namespace giúp:
- Phân chia chương trình theo từng chức năng
Tránh xung đột tên class
Dễ bảo trì và phát triển dự án lớn
Tăng tính chuyên nghiệp trong lập trình
=> Đặc biệt quan trọng trong các dự án .NET MVC, Web API, WinForms, WPF
3. Cú pháp khai báo namespace
namespace MyApplication
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World");
        }
    }
}
=> MyApplication là namespace bao bọc class Program
4. Namespace lồng nhau (Nested Namespace)
namespace MyApplication.Models
{
    public class Product
    {
        public string Name { get; set; }
    }
}
=> Thường dùng trong MVC:
ProjectName.Models
ProjectName.Controllers
ProjectName.Views
5. Sử dụng namespace với using
- Khai báo ở đầu file
using System;
using MyApplication.Models;
=> Giúp sử dụng class không cần ghi đầy đủ namespace
- Không dùng using
MyApplication.Models.Product p = new MyApplication.Models.Product();
=> Viết dài hơn, ít dùng trong thực tế
6. Alias namespace (Đặt bí danh)
using Model = MyApplication.Models;
Model.Product p = new Model.Product();
=> Dùng khi:
Có nhiều class trùng tên
Namespace dài
7. Namespace và thư viện .NET
- Một số namespace phổ biến:
Namespace	Chức năng
System	Các lớp cơ bản
System.IO	Xử lý file
System.Linq	Truy vấn dữ liệu
System.Collections.Generic	Danh sách, Dictionary
Microsoft.AspNetCore.Mvc	MVC, Controller
8. Namespace trong .NET MVC
- Ví dụ:

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

=> Tách biệt:
Controllers
Models
Services
Repositories

---------------------------------------------------------------------------------------------
TÌM HIỂU VỀ CONTROLLER VÀ VIEW TRONG .NET MVC
1. Tổng quan mô hình MVC
- MVC là viết tắt của:
Model: Dữ liệu & nghiệp vụ
View: Giao diện người dùng
Controller: Xử lý yêu cầu và điều phối
=> Trong đó:
Controller và View là hai thành phần tương tác trực tiếp với người dùng.
2. Controller trong .NET MVC
2.1. Khái niệm Controller
- Controller là thành phần:
Nhận yêu cầu (request) từ trình duyệt
Xử lý logic
Gọi Model để lấy dữ liệu
Trả kết quả về View
=> Controller đóng vai trò trung tâm điều khiển của ứng dụng MVC.
2.2. Vị trí của Controller
Controllers
├── HomeController.cs
├── ProductController.cs


Mỗi Controller là một class
Tên kết thúc bằng Controller
2.3. Cấu trúc một Controller
using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}


- Giải thích:

HomeController: tên Controller

Index(): Action

View(): trả về giao diện

2.4. Action trong Controller
- Là các phương thức public
Mỗi Action tương ứng một URL
=> Ví dụ:
/Home/Index
=> Gọi Index() trong HomeController

2.5. Truyền dữ liệu từ Controller sang View
Cách 1: Dùng Model
return View(product);
Cách 2: Dùng ViewBag
ViewBag.Title = "Trang chủ";
Cách 3: Dùng ViewData
ViewData["Title"] = "Trang chủ";
3. View trong .NET MVC
3.1. Khái niệm View
- View là thành phần:
Hiển thị dữ liệu ra giao diện
Tương tác trực tiếp với người dùng
Được viết bằng Razor (.cshtml)
=> View không xử lý logic nghiệp vụ
3.2. Vị trí của View
Views
├── Home
│   └── Index.cshtml
├── Shared
│   └── _Layout.cshtml

=> Mỗi Controller có thư mục View tương ứng.

3.3. Cấu trúc View (Razor)
@{
    ViewData["Title"] = "Trang chủ";
}

<h1>@ViewData["Title"]</h1>
<p>Xin chào ASP.NET MVC</p>


@: ký hiệu Razor

Có thể viết C# trực tiếp trong HTML

3.4. View mạnh kiểu (Strongly Typed View)
@model Product

<h2>@Model.Name</h2>
<p>Giá: @Model.Price</p>


=> View nhận dữ liệu từ Controller thông qua Model

3.5. Layout và View dùng chung
_Layout.cshtml: giao diện chung (header, footer)
_ViewStart.cshtml: cấu hình layout mặc định
=> Giúp:
Tái sử dụng giao diện
Dễ bảo trì
4. Mối quan hệ giữa Controller và View
Luồng hoạt động:
Người dùng
   ↓
Controller (Action)
   ↓
Model (nếu có)
   ↓
Controller
   ↓
View
   ↓
Người dùng

=> Controller không hiển thị, View không xử lý logic






































