using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Entites
{
    public class Notation
    {
        [Key]
        public int NotationID { get; set; }
        public string NotationTitle { get; set; }
        public string NotationContent { get; set; }
        public DateTime NotationDate { get; set; }
        public string UserID_Creator { get; set; }
        public string UserID_Reciever { get; set; }
        public bool IsAccept { get; set; }
        //
        [ForeignKey("UserID_Creator")]
        public virtual ApplicationUser User_Creator { get; set; }

        [ForeignKey("UserID_Reciever")]
        public virtual ApplicationUser User_Reciever { get; set; }
    }
}
