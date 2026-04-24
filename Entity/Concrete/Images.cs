using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Images
    {
        [Key]
        public int ImageID { get; set; }
        [StringLength(500)]
        public string ImageName { get; set; }
        [StringLength(1000)]
        public string ImageUrl { get; set; }
    }
}
