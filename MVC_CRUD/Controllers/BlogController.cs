using Microsoft.AspNetCore.Mvc;

namespace MVC_CRUD.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BlogDetail()
        {
            return View();
        }

        public IActionResult BlogListView()
        {
            return View();
        }
    }
}
