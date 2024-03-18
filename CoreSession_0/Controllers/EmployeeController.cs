using CoreSession_0.Models.ContextClasses;
using CoreSession_0.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreSession_0.Controllers
{
    // Bir Emplooyeer ismi ve soyisimi girip SignIn Action'ina post yapsın.. Eğer o isimde ve soy isimde bir Employee varsa bu employee nesnensi session'a eklensin ve onu 3.Action'a yönlendirerek Sesion bilgisinddeki ismi ve soyismi yazdırsın eğer Employee yoksa ViewBag.Message'da böyle bir çalışan yoktur diye mesaj çıkartıp SignIn sayfasında kalmasını sağlayın.
    public class EmployeeController : Controller
    {
        NorthwindContext _db;

        public EmployeeController(NorthwindContext db)
        {
            _db = db;
        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(Employee item)
        {
            Employee e = _db.Employees.FirstOrDefault(x => x.FirstName == item.FirstName && x.LastName==item.LastName);
            if (e == null) 
            {
                ViewBag.Message = "Çalışan Bulunamadı";
                return View();
            }
            HttpContext.Session.SetObject("cagri", e);
            return RedirectToAction("GetSessionData");
        }

        public IActionResult GetSessionData()
        {
            return View();
        }
    }
}
