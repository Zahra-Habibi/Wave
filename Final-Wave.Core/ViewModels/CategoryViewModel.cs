using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the Category Name !")]
        [MinLength(3, ErrorMessage = "Cant be less than 3 character.")]
        [MaxLength(100, ErrorMessage = "Cant be more than 100 character.")]
        public string CategoryName { get; set; }

        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg" })]
        public string? CategoryPhoto { get; set; }

        [Display(Name = "Alt")]
        [Required(ErrorMessage = "Please enter the image alt.")]
        public string Alt { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please enter the image title.")]
        public string Title { get; set; }
        
    }
}
