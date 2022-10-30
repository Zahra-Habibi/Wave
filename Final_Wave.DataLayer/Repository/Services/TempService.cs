using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Repository.Services
{
    public class TempService : ITemp
    {
        private readonly ApplicationUser _context;

        public TempService(ApplicationUser context)
        {
            _context = context;
        }
    }
}
