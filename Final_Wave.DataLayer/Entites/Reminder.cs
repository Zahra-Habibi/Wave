using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Entites
{
    public class Reminder
    {
        [Key]
        public int ReminderID { get; set; }
        public string ReminderTitle { get; set; }
        public string ReminderContent { get; set; }
        public DateTime ReminderCreateDate { get; set; }
        public DateTime ReminderDate { get; set; }
        public bool IsRead { get; set; }
        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUser Users { get; set; }
    }
}

