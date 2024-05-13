using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Business.Services.Abstract;
using MVC_CRUD.Core.Models;

namespace MVC_CRUD.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;
        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        public IActionResult Index()
        {
            var features = _featureService.GetAllFeatureAsync();
            return View(features);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Feature feature)
        {
            _featureService.AddFeatureAsync(feature);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var existsFeature = _featureService.GetFeatureAsync(x => x.Id == id);

            if (existsFeature == null) throw new NullReferenceException("bele id movcud deyil");
            return View(existsFeature);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            _featureService.DeleteFeatureAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id) 
        {
			var existsFeature = _featureService.GetFeatureAsync(x => x.Id == id);

			if (existsFeature == null) throw new NullReferenceException("bele id movcud deyil");
			return View(existsFeature);
        }

        [HttpPost]
        public IActionResult Update(Feature newFeature)
        {
            _featureService.UpdateFeatureAsync(newFeature.Id, newFeature);
            return RedirectToAction("Index");
        }
    }
}
