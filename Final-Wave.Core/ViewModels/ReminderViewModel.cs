using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Final_Wave.Core.ViewModels
{
    public class ReminderViewModel
    {
        public int ReminderID { get; set; }
        [Display(Name = "Reminder Title : ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your reminder title!")]
        public string ReminderTitle { get; set; }
        [Display(Name = "Reminder Content : ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your reminder content!")]
        public string ReminderContent { get; set; }
        public DateTime ReminderCreateDate { get; set; }
        [Display(Name = "Reminder date : ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your reminder date!")]
        [DataType(DataType.Date)]
        public DateTime ReminderDate { get; set; }
        [Display(Name = "IsRead : ")]
        public bool IsRead { get; set; }
        public string UserID { get; set; }
    }
}
