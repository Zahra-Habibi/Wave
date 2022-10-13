using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        public GenericCLass<Slider> sliderUW { get; }
        public GenericCLass<About> AboutUW { get; }
        public GenericCLass<Service> serviceUW { get; }
        public GenericCLass<Social> socialUW { get; }
        public GenericCLass<Team> teamUW { get; }
        public GenericCLass<Category> categoryUW { get; }
        public GenericCLass<Product> productUW { get; }
        public GenericCLass<ContactUs> conductUW { get; }
        public GenericCLass<Order> orderUW { get; }
        public GenericCLass<ProductGallery> galleryUW { get; }
        public GenericCLass<Skills> skillUW { get; }
        public GenericCLass<Job> JobUW { get; }
        public GenericCLass<ApplicationUser> UserUW { get; }
        public GenericCLass<Latter> LetterUW { get; }
        public GenericCLass<AdministrativeForm> AdministrativeFormUW { get; }
        Task saveAsync();
        void Dispose();
    }
}
