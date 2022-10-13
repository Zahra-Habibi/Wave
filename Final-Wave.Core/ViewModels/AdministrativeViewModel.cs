using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class AdministrativeViewModel
    {
        public int AdministrativeFormID { get; set; }


        [Display(Name = "AdministrativeFormType")]
        public bool AdministrativeFormType { get; set; }


        [Display(Name = "AdministrativeFormTitle")]
        public string AdministrativeFormTitle { get; set; }


        [Display(Name = "AdministrativeFormContent")]
        public string AdministrativeFormContent { get; set; }


        public string UserID { get; set; }
    }
}
