
using System.ComponentModel.DataAnnotations;


namespace Final_Wave.DataLayer.Entites
{
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime SentDate { get; set; } = DateTime.UtcNow;
    }
}
