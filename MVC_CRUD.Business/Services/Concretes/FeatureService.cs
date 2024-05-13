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
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;
        public FeatureService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }
        public async Task AddFeatureAsync(Feature feature)
        {
            if (!_featureRepository.GetAll().Any(x => x.Name == feature.Name))
                await _featureRepository.AddAsync(feature);
                await _featureRepository.CommitAsync();
        }

        public void DeleteFeatureAsync(int id)
        {
            var existsFeature = _featureRepository.Get(x => x.Id == id);
            if (existsFeature == null) throw new NullReferenceException("duzgun id daxil et");
            _featureRepository.Delete(existsFeature);
            _featureRepository.Commit();
        }

        public List<Feature> GetAllFeatureAsync(Func<Feature, bool>? func = null)
        {
            return _featureRepository.GetAll(func);
        }

        public Feature GetFeatureAsync(Func<Feature, bool>? func = null)
        {
            return _featureRepository.Get(func);
        }

        public void UpdateFeatureAsync(int id, Feature newFeature)
        {
            var existsFeature = _featureRepository.Get(x=> x.Id == id);
            if(existsFeature == null) throw new NullReferenceException($"duzgun id daxil et");
            if (!_featureRepository.GetAll().Any(x => x.Name == newFeature.Name))
            {
                existsFeature.Icon = newFeature.Icon;
                existsFeature.Name = newFeature.Name;
                existsFeature.Description = newFeature.Description;
                _featureRepository.Commit();
            }
        }
    }
}
