using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingID { get; set; }
        [StringLength(500)]
        public string HeadingName{ get; set; }
        public DateTime Date {  get; set; }

        public bool Status { get; set; }

        //Content ile ilişki ----- yani her bir heading çok content olabilir
        public ICollection<Content> contents { get; set; }

        



        //Kategori ile ilişki ---- yani her heading bir category var ama her heading çok category yok
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
