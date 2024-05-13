using MVC_CRUD.Business.Exceptions;
using MVC_CRUD.Business.Services.Abstract;
using MVC_CRUD.Core.Models;
using MVC_CRUD.Core.RepositoryAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_CRUD.Business.Services.Concretes
{
	public class SliderService : ISliderService
	{
		private readonly ISliderRepository _sliderRepository;
        public SliderService(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

		public async Task AddSliderAsync(Slider slider)
		{
			if (slider.ImageFile.ContentType != "image/png" && slider.ImageFile.ContentType != "image/jpeg")
				throw new ImageContentTypeException("fayl formati duzgun deyil");

			if (slider.ImageFile.Length > 2097152)
				throw new ImageSizeException("seklin olcusu maksimum 2mb ola biler");

			string fileName = Guid.NewGuid().ToString() + Path.GetExtension(slider.ImageFile.FileName);
			fileName = slider.ImageFile.FileName.Length > 100 ? slider.ImageFile.FileName.Substring(0, 55) : fileName + slider.ImageFile.FileName;

			string path = "C:\\Users\\Acer\\OneDrive\\İş masası\\Back-end\\MVC_CRUD\\MVC_CRUD\\wwwroot\\" + "uploads\\sliders\\" + fileName;

			using(FileStream fileStream = new FileStream(path, FileMode.Create))
			{
				slider.ImageFile.CopyTo(fileStream);
			}

			slider.ImageUrl = fileName;


			await _sliderRepository.AddAsync(slider);
			await _sliderRepository.CommitAsync();

		}

		public void DeleteSliderAsync(int id)
		{
			var existSlider = _sliderRepository.Get(x => x.Id == id);
			if (existSlider == null)
				throw new NullReferenceException("bele id movcud deyil");
			_sliderRepository.Delete(existSlider);
			_sliderRepository.Commit();
		}

		public List<Slider> GetAllSliderAsync(Func<Slider, bool>? func = null)
		{
			return _sliderRepository.GetAll(func);
		}

		public Slider GetSliderAsync(Func<Slider, bool>? func = null)
		{
			return _sliderRepository.Get(func);
		}

		public void UpdateSliderAsync(int id, Slider newSlider)
		{
			var existSlider = _sliderRepository.Get(x => x.Id == id);
			if (existSlider == null) throw new NullReferenceException("duzgun id daxil et");
			if (_sliderRepository.GetAll().Any(x => x.Title == newSlider.Title))
			{
				existSlider.LifeCycle = newSlider.LifeCycle;
				existSlider.Title = newSlider.Title;
				existSlider.Description = newSlider.Description;
				existSlider.RedirectUrl = newSlider.RedirectUrl;
				existSlider.ImageUrl = newSlider.ImageUrl;
				_sliderRepository.Commit();
			}


		}
	}
}
