using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class LetterViewModel
    {

        public int LetterId { get; set; }

        [Required(ErrorMessage = "Please enter the letter content !")]
        [MinLength(5, ErrorMessage = "Cant be less than 5 character.")]
        [Display(Name ="LetterContent")]
        public string LaterContent { get; set; }

        [Required(ErrorMessage = "Please enter the letter content !")]
        [StringLength(maximumLength:300, MinimumLength =8,ErrorMessage ="Letter jubject should be 8-300 characters!")]
        [Display(Name = "LetterSubeject")]
        public string LetterSubject { get; set; }

        [Display(Name = "Classification")]
        public byte ClassificationStatus { get; set; }

        [Display(Name = "Attachment")]
        public byte AttachmentLetter { get; set; }

        [Display(Name = "ReplyStatus")]
        public byte ReplyStatus { get; set; }

        [Display(Name = "AttachmentFile")]
        public string AttachmentFile { get; set; }

        [Display(Name = "ReplyDate")]
        public DateTime? ReplyDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "UserId")]
        public string UserId { get; set; }

        [Display(Name = "CreatLetterDate")]
        public DateTime CreatLetterDate { get; set; } = DateTime.UtcNow;

    }
}
