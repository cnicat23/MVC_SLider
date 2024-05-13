using MVC_CRUD.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_CRUD.Business.Services.Abstract
{
    public interface ICategoryService 
    {
        Task AddCategoryAsync(Category category);
        void DeleteCategoryAsync(int id);
        void UpdateCategoryAsync(int id, Category newCategory);
        Category GetCategoryAsync(Func<Category, bool>? func = null);
        List<Category> GetAllCategoryAsync(Func<Category, bool>? func = null);

    }
}
