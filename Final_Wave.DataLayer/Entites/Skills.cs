using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Entites
{
    public class Skills
    {
        [Key]
        public int Id { get; set; }
        public string SkillName { get; set; }
        public string Description { get; set;}
        public int level { get; set; }
        public bool IsDelete { get; set; }
       



    }
}
