using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.ViewComponents.ServiceComponent
{
    public class ServiceComponent:ViewComponent
    {
        private IUnitOfWork _temp;
        public ServiceComponent(IUnitOfWork temp)
        {
            _temp = temp;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("MyServiceView", await _temp.serviceUW.GetEntitiesAsync()));
        }
    }
}
