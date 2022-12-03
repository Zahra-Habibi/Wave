
using AutoMapper;
using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using static Final_Wave.Core.ViewModels.NotationViewModel;

namespace Final_Wave.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Slider, SliderViewModel>().ReverseMap();
            CreateMap<About, AboutViewModel>().ReverseMap();
            CreateMap<Service, ServicesViewModel>().ReverseMap();
            CreateMap<Social, SocialViewModel>().ReverseMap();
            CreateMap<Team, TeamViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Order , OrderViewModel>().ReverseMap();
            CreateMap<ProductGallery, ProductGalleryViewModel>().ReverseMap();
            CreateMap<Skills, SkillsViewModel>().ReverseMap();
            CreateMap<Job, JobViewModel>().ReverseMap();
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
            CreateMap<Latter, LetterViewModel>().ReverseMap();
            CreateMap<ContactUs, ContactViewModel>().ReverseMap();
            CreateMap<Reminder, ReminderViewModel>().ReverseMap();
            CreateMap<Message, MessageViewModel>().ReverseMap();
            CreateMap<PrograssBar, PrograssBarViewModel>().ReverseMap();
            CreateMap<Notation, SentNotationListViewModel>().ReverseMap();

        }
    }
}
