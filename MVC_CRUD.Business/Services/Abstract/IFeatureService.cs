using MVC_CRUD.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_CRUD.Business.Services.Abstract
{
    public interface IFeatureService
    {
        Task AddFeatureAsync(Feature feature);
        void DeleteFeatureAsync(int id);
        void UpdateFeatureAsync(int id, Feature newFeature);
        Feature GetFeatureAsync(Func<Feature, bool>? func = null);
        List<Feature> GetAllFeatureAsync(Func<Feature, bool>? func = null);

    }
}
