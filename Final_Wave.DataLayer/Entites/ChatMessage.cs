using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Entites
{
    public class ChatMessage
    {

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text{ get; set; }
        public DateTime CreatTime { get; set; }
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
