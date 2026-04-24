using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }
        [StringLength(5000)]
        public string ContentValue { get; set; }
        public DateTime Date { get; set; }


        public bool Status { get; set; }
        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }

        //Heading ile ilişki ----- yani her content bir heading var ama  çok content aynı heading olabilir
        public int HeadingID { get; set; }
        public virtual Heading Heading {  get; set; }
    }
}
