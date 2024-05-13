using MVC_CRUD.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_CRUD.Core.RepositoryAbstract
{
    public interface IProductRepository : IGenericRepository<Product> { }
}
