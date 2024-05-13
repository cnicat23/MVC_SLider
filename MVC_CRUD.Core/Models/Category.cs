using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_CRUD.Core.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        List<Product> products { get; set;}
    }
}
