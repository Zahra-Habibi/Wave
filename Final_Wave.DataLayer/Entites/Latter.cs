using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Entites
{
    public class Latter
    {
        [Key]
        public int LetterId { get; set; }
        public string LaterContent { get; set; }
        public string LetterSubject { get; set; }
        public byte ClassificationStatus { get; set; }
        public byte AttachmentLetter { get; set; }
        public byte ReplyStatus { get; set; }
        public string AttachmentFile { get; set; }
        public DateTime? ReplyDate { get; set; }
        public string UserId { get; set; }
        public DateTime  CreatLetterDate { get; set; }
        //relationship
        [ForeignKey("UserId")]
        public virtual ApplicationUser Users { get; set; }

    }
}
