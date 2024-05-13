using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Business.Services.Abstract;
using MVC_CRUD.Core.Models;

namespace MVC_CRUD.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCategoryAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _categoryService.AddCategoryAsync(category);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var existsCategory = _categoryService.GetCategoryAsync(x => x.Id == id);

            if (existsCategory == null) throw new NullReferenceException("bele id movcud deyil");
            return View(existsCategory);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var existsCategory = _categoryService.GetCategoryAsync(x => x.Id == id);

            if (existsCategory == null) throw new NullReferenceException("bele id movcud deyil");
            return View(existsCategory);
        }

        [HttpPost]
        public IActionResult Update(Category newCategory)
        {
            _categoryService.UpdateCategoryAsync(newCategory.Id, newCategory);
            return RedirectToAction("Index");
        }
    }
}
