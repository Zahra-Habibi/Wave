using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Entites
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {
            Messages =new HashSet<Message>();
        }
        public bool IsActive { get; set; }
        public byte IsAdmin { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
        public List<Order> orders { get; set; }

        public virtual ICollection<Message> Messages { get; set; }  
    
    }
}
