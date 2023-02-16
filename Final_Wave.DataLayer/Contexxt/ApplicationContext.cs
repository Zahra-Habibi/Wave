using Final_Wave.DataLayer.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Contexxt
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Slider> sliders { get; set; }
        public DbSet<About> abouts { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<Social> socials { get; set; }
        public  DbSet<Team> teams { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ContactUs> contactus { get; set; }
        public DbSet<Skills> skills { get; set; }

        public DbSet<Order> orders { get; set; }
        public DbSet<Job> job { get; set; }
        public  DbSet<ProductGallery> productGalleries { get; set; }
        public DbSet<AdministrativeForm> administrativeForms { get; set; }
     
        public DbSet<Latter> letters { get; set; }
        public DbSet<Information> information { get; set; }
        public DbSet<Reminder> reminder { get; set; }
        public DbSet<ChatRoom> chatRooms { get; set; }
        public DbSet<ProductPrice> ProductPrice { get; set; }
        public DbSet<PrograssBar> prograssBars { get; set; }
        public DbSet<Notation> Notation_tbl { get; set; }
        public DbSet<ChatMessage> chatmessage { get; set; }
   








        //ModelBuilder
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<Message>()
        //        .HasOne<ApplicationUser>(a => a.Sender)
        //        .WithMany(d => d.Messages)
        //        .HasForeignKey(d => d.UserID);


        //}


    }
}
