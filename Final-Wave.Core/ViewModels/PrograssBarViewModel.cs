using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Final_Wave.Core.ViewModels.NotationViewModel;

namespace Final_Wave.Core.ViewModels
{
    public class PrograssBarViewModel
    {
        public int PrograssId { get; set; }
        [Display(Name ="Requierment")]
        public int Requirement { get; set; }

        [Display(Name = "Design")]
        public int Design { get; set; }

        [Display(Name = "Coding")]
        public int Codind { get; set; }

        [Display(Name = "Testing")]
        public int Testing { get; set; }

        [Display(Name = "Maintenace")]
        public int Maintenance { get; set; }


        public string UserID_Reciever { get; set; }
        public NotationCreatorInfo CreatorInfo { get; set; }

        public DateTime OrderTime { get; set; } = DateTime.UtcNow;
    }
}
