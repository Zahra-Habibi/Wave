using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Entites
{
    public class Message
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the title")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter your message")]
        [Display(Name = "Message")]
        public string Text { get; set; }

        [Display(Name = "CreateDate")]
        public DateTime CreatMessage { get; set; }

        public string userId_sender { get; set; }
        public string userId_reciever { get; set; }

        [ForeignKey("userId_reciever")]
        public virtual ApplicationUser Sender { get; set; }
    }
}
