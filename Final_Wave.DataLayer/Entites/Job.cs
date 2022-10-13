using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Entites
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string JobName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public string? Resume { get; set; }
        public bool IsDelete { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
  


    }
}
