using HomeWorkRouting.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HomeWorkRouting.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveData(string value, DateTime expirationDate)
        {
            CookieOptions options = new CookieOptions
            {
                Expires = expirationDate
            };

            Response.Cookies.Append("MyData", value, options);

            return RedirectToAction("CheckData");
        }

        public IActionResult CheckData()
        {
            string data = Request.Cookies["MyData"];

            return View(data);
        }
    }
}