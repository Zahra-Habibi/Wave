using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class TeamViewModel
    {
        public int Id { get; set; }
        [Display(Name = ("Name"))]
        [Required(ErrorMessage = ("Please enter the name of your team member."))]
        [MinLength(3, ErrorMessage = "You can not enter less than 3 character.")]
        [MaxLength(40, ErrorMessage = ("You can not enter more than 40 character."))]
        public string Name { get; set; }
        [Display(Name = ("LastName"))]
        [Required(ErrorMessage = ("Please enter the name of your team member."))]
        [MinLength(3, ErrorMessage = "You can not enter less than 3 character.")]
        [MaxLength(60, ErrorMessage = ("You can not enter more than 60 character."))]
        public string LastName { get; set; }
        [Display(Name = ("Positionname"))]
        [MinLength(3, ErrorMessage = "You can not enter less than 3 character.")]
        [MaxLength(80, ErrorMessage = ("You can not enter more than 80 character."))]
        public string PositionName { get; set; }

        [Display(Name = ("shortdescription"))]
        public string? ShortDesc { get; set; }

        [Display(Name = ("teamphoto"))]
        public string? ImageUrl { get; set; }


        [Display(Name = "Image")]
        [Required(ErrorMessage = "Please enter the image alt.")]
        public string Alt { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Please enter the image title.")]
        public string Title { get; set; }
    }
}
