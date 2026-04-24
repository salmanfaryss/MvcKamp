using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID {  get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public bool CategoryStatus { get; set; }



        //Heading ile ilişki ---- yani her bir kategory çok heading bulabilir
        public ICollection<Heading> heading { get; set; }
    }
}
