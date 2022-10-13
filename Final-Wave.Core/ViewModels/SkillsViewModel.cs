using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class SkillsViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="SkillName")]
        [Required(ErrorMessage ="Please enter the skill name.")]
        public string SkillName { get; set; }

        [Display(Name = "SkillDescription")]
        public string Description { get; set; }
        [Display(Name = "Skill level")]
        public int level { get; set; }

    }
}
