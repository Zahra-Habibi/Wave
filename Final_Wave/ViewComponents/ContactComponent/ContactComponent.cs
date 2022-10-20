using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.ViewComponents.ContactComponent
{
    public class ContactComponent :ViewComponent
    {
        private IUnitOfWork _temp;
        public ContactComponent(IUnitOfWork temp)
        {
            _temp = temp;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("MyContacttView", await _temp.conductUW.GetEntitiesAsync()));
        }
    }
}
