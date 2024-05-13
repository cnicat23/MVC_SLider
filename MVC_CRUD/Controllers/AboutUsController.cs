using Microsoft.AspNetCore.Mvc;

namespace MVC_CRUD.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
