using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Entites
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime When { get; set; }

        public string UserID { get; set; }

        public virtual ApplicationUser Sender { get; set; }
    }
}
