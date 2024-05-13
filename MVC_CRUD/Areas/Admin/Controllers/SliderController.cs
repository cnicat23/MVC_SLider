using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Business.Services.Abstract;
using MVC_CRUD.Core.Models;

namespace MVC_CRUD.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SliderController : Controller
	{
		private readonly ISliderService _sliderService;

		public SliderController(ISliderService sliderService)
		{
			_sliderService = sliderService;
		}

		public IActionResult Index()
		{
			var sliders = _sliderService.GetAllSliderAsync();
            return View(sliders);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Slider slider)
		{
			await _sliderService.AddSliderAsync(slider);
			return RedirectToAction("Index");
		}
	}
}
