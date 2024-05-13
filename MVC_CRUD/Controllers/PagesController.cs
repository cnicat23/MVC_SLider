using Microsoft.AspNetCore.Mvc;

namespace MVC_CRUD.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
