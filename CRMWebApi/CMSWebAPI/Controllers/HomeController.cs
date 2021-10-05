using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CMSWebAPI.Models;

namespace CMSWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }        
    }
}
