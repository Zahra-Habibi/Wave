using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.ViewComponents.ShowserviceComponent
{
    public class ShowserviceComponent:ViewComponent
    {
        private IUnitOfWork _temp;
        public ShowserviceComponent(IUnitOfWork temp)
        {
            _temp = temp;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("MyAllServiceView", await _temp.serviceUW.GetEntitiesAsync()));
        }
    }
}
