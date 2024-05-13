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

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task AddCategoryAsync(Category category)
        {
            if (!_categoryRepository.GetAll().Any(x => x.Name == category.Name))
               await _categoryRepository.AddAsync(category);
               await _categoryRepository.CommitAsync();
        }

        public void DeleteCategoryAsync(int id)
        {
            Category existCategory = _categoryRepository.Get(x => x.Id == id);
            if (existCategory == null) throw new NullReferenceException("duzgun id daxil et");
            _categoryRepository.Delete(existCategory);
            _categoryRepository.Commit();
        }

        public List<Category> GetAllCategoryAsync(Func<Category, bool>? func = null)
        {
            return _categoryRepository.GetAll(func);
        }

        public Category GetCategoryAsync(Func<Category, bool>? func = null)
        {
            return _categoryRepository.Get(func);
        }

        public void UpdateCategoryAsync(int id, Category newCategory)
        {
            Category existsCategory = _categoryRepository.Get(x =>x.Id == id);
            if (existsCategory == null) throw new NullReferenceException($"{id} is not exists");

            if (!_categoryRepository.GetAll().Any(x => x.Name == newCategory.Name))
            {
                existsCategory.Name = newCategory.Name;
                _categoryRepository.Commit();
            }
        }
    }
}
