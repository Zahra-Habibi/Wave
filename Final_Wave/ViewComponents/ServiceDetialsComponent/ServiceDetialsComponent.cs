using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.ViewComponents.ServiceDetialsComponent
{
    public class ServiceDetialsComponent :ViewComponent
    {
        private IUnitOfWork _temp;
        public ServiceDetialsComponent(IUnitOfWork temp)
        {
            _temp = temp;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return await Task.FromResult((IViewComponentResult)View("MyServieDetialView", await _temp.serviceUW.GetByIdAsync(id)));
        }
    }
}
