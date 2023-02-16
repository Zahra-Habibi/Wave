using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Final_Wave.Core.ViewModels.NotationViewModel;

namespace Final_Wave.Core.ViewModels
{
    public class MessageViewModel
    {
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
    }

}
