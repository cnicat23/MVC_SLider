using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Business.Services.Abstract;
using MVC_CRUD.Core.ViewsModel;
using System.Diagnostics;

namespace MVC_CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly ISliderService _sliderService;

        public HomeController(IFeatureService featureService, ISliderService sliderService)
        {
            _featureService = featureService;
            _sliderService = sliderService;
		}
		public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                features = _featureService.GetAllFeatureAsync(),
                sliders = _sliderService.GetAllSliderAsync()
            };
            return View(homeVM);
        }

        public IActionResult HomeTwo()
        {
            return View();
        }
    }
}
