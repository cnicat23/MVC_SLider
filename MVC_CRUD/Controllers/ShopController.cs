using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Business.Services.Abstract;

namespace MVC_CRUD.Controllers
{
    public class ShopController : Controller
    {
        private readonly ICategoryService _categoryService;
        public ShopController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
			var categories = _categoryService.GetAllCategoryAsync();
			return View(categories);
        }

        public IActionResult SingleProductVariable()
        {
            return View();
        }
    }
}
