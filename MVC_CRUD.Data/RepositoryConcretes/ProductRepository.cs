using MVC_CRUD.Core.Models;
using MVC_CRUD.Core.RepositoryAbstract;
using MVC_CRUD.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_CRUD.Data.RepositoryConcretes
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext) : base (appDbContext) { }
    }
}
