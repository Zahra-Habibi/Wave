using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Entites
{
    public class AdministrativeForm
    {
        [Key]
        public int AdministrativeFormID { get; set; }
        public bool AdministrativeFormType { get; set; }
        public string AdministrativeFormTitle { get; set; }
        public string AdministrativeFormContent { get; set; }
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser Users { get; set; }
    }
}
