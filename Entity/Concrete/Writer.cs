using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        [StringLength(50)]
        public string WriterName { get; set; }
        [StringLength(50)]
        public string WriterSurname { get; set; }
        [StringLength(500)]
        public string WriterImage { get; set; }
        [StringLength(500)]
        public string WriterEmail { get; set; }
        [StringLength(200)]
        public string WriterPassword { get; set; }

        [StringLength (2000)]
        public string WriterAbout { get; set; }

        [StringLength(250)]
        public string WriterTitle {  get; set; }
        public bool WriterStatus { get; set; }


        //Content ile ilişki ----- yani her writer 

        public ICollection<Heading> heading { get; set; }
        public ICollection<Content> content { get; set; }
    }
}
