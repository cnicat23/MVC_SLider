using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_CRUD.Core.Models
{
    public class Feature : BaseEntity
    {
        [Required]
        public string Icon { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
