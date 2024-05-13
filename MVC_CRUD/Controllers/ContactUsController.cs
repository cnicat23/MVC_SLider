using Microsoft.AspNetCore.Mvc;

namespace MVC_CRUD.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
