using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Message
    {
        public int MessageID {  get; set; }
        [StringLength(50)]
        public string Sender { get; set; }
        [StringLength(50)]
        public string Receiver { get; set; }
        [StringLength(50)]
        public string  Subject { get; set; }
        [StringLength(5000)]
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public bool IsRead { get; set; }
        public bool IsDraft { get; set; }   // Taslak
        public bool IsSpam { get; set; }    // Spam
        public bool IsTrash { get; set; }
    }
}
