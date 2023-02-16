using Final_Wave.DataLayer.Contexxt;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Repository.Services
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {

            private readonly ApplicationContext _context;
            public UnitOfWork(ApplicationContext context)
            {
                _context = context;
            }
         private GenericCLass<Slider> _slider;
        private GenericCLass<About> _about;
        private GenericCLass<Service> _service;
        private GenericCLass<Social> _social;
        private GenericCLass<Team> _team;
        private GenericCLass<Category> _category;
        private GenericCLass<Product> _product;
        private GenericCLass<ContactUs> _contact;
        private GenericCLass<Order> _order;
        private GenericCLass<ProductGallery> _gallery;
        private GenericCLass<Skills> _skill;
        private GenericCLass<Job> _job;
        private GenericCLass<ApplicationUser> _user;
        private GenericCLass<Latter> _letters;
        private GenericCLass<AdministrativeForm> _administrative;
        private GenericCLass<Reminder> _Reminder;
        private GenericCLass<Message> _Message;
        private GenericCLass<PrograssBar> _prograss;
        private GenericCLass<Notation> _notation;
        private GenericCLass<ChatMessage> _chatmUW;


        //notation
        public GenericCLass<ChatMessage> ChatMessageUW
        {
            get
            {
                if (_chatmUW == null)
                {
                    _chatmUW = new GenericCLass<ChatMessage>(_context);
                }
                return _chatmUW;
            }
        } 

        //notation
        public GenericCLass<Notation> NotationUW
        {
            get
            {
                if (_notation == null)
                {
                    _notation = new GenericCLass<Notation>(_context);
                }
                return _notation;
            }
        }

        //prograss
        public GenericCLass<PrograssBar> PrograssUW
        {
            get
            {
                if (_prograss == null)
                {
                    _prograss = new GenericCLass<PrograssBar>(_context);
                }
                return _prograss;
            }
        }

        //message
        public GenericCLass<Message> MessageUW
        {
            get
            {
                if (_Message == null)
                {
                    _Message = new GenericCLass<Message>(_context);
                }
                return _Message;
            }
        }


        //AdministrativeFormUW
        public GenericCLass<Reminder> ReminderUW
        {
            get
            {
                if (_Reminder == null)
                {
                    _Reminder = new GenericCLass<Reminder>(_context);
                }
                return _Reminder;
            }
        }

        //AdministrativeFormUW
        public GenericCLass<AdministrativeForm> AdministrativeFormUW
        {
            get
            {
                if (_administrative == null)
                {
                    _administrative = new GenericCLass<AdministrativeForm>(_context);
                }
                return _administrative;
            }
        }

        //latter
        public GenericCLass<Latter> LetterUW
        {
            get
            {
                if (_letters == null)
                {
                    _letters = new GenericCLass<Latter>(_context);
                }
                return _letters;
            }
        }

        //user
        public GenericCLass<ApplicationUser> UserUW
        {
            get
            {
                if (_user == null)
                {
                    _user = new GenericCLass<ApplicationUser>(_context);
                }
                return _user;
            }
        }

        //job
        public GenericCLass<Job>JobUW
        {
            get
            {
                if (_job == null)
                {
                    _job = new GenericCLass<Job>(_context);
                }
                return _job;
            }
        }

        //skill
        public GenericCLass<Skills> skillUW
        {
            get
            {
                if (_skill == null)
                {
                    _skill = new GenericCLass<Skills>(_context);
                }
                return _skill;
            }
        }

        //gallery
        public GenericCLass<ProductGallery> galleryUW
        {
            get
            {
                if (_gallery == null)
                {
                    _gallery = new GenericCLass<ProductGallery>(_context);
                }
                return _gallery;
            }
        }

        //order
        public GenericCLass<Order> orderUW
        {
            get
            {
                if (_order == null)
                {
                    _order = new GenericCLass<Order>(_context);
                }
                return _order;
            }
        }


        //contact
        public GenericCLass<ContactUs> conductUW
        {
            get
            {
                if (_contact == null)
                {
                    _contact = new GenericCLass<ContactUs>(_context);
                }
                return _contact;
            }
        }


        //product
        public GenericCLass<Product> productUW
        {
            get
            {
                if (_product == null)
                {
                    _product = new GenericCLass<Product>(_context);
                }
                return _product;
            }
        }

        //category
        public GenericCLass<Category> categoryUW
        {
            get
            {
                if (_category == null)
                {
                    _category = new GenericCLass<Category>(_context);
                }
                return _category;
            }
        }

        //team
        public GenericCLass<Team> teamUW
        {
            get
            {
                if (_team == null)
                {
                    _team = new GenericCLass<Team>(_context);
                }
                return _team;
            }
        }


        //Social
        public GenericCLass<Social> socialUW
        {
            get
            {
                if (_social == null)
                {
                    _social = new GenericCLass<Social>(_context);
                }
                return _social;
            }
        }

        //Service
        public GenericCLass<Service> serviceUW
        {
            get
            {
                if (_service == null)
                {
                    _service = new GenericCLass<Service>(_context);
                }
                return _service;
            }
        }


        //slider
        public GenericCLass<Slider> sliderUW
        {
            get
            {
                if (_slider == null)
                {
                    _slider = new GenericCLass<Slider>(_context);
                }
                return _slider;
            }
        }

        //about
        public GenericCLass<About> AboutUW
        {
            get
            {
                if (_about == null)
                {
                    _about = new GenericCLass<About>(_context);
                }
                return _about;
            }
        }


        public async Task saveAsync()
            {
                await _context.SaveChangesAsync();
            }
 

            public void Dispose()
            {
                _context.Dispose();
            }
        
    }
}
