using MVC_CRUD.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_CRUD.Business.Services.Abstract
{
	public interface ISliderService
	{
		Task AddSliderAsync (Slider slider);
		void DeleteSliderAsync (int id);
		void UpdateSliderAsync (int id, Slider newSlider);
		Slider GetSliderAsync (Func<Slider, bool>? func = null);
		List<Slider> GetAllSliderAsync (Func<Slider, bool>? func = null);
	}
}
