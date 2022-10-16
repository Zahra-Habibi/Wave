using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.ViewComponents.ProductComponent
{
    public class ProductComponent: ViewComponent
    {
        private IUnitOfWork _temp;
        public ProductComponent(IUnitOfWork temp)
        {
            _temp = temp;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("MyProductView", await _temp.productUW.GetEntitiesAsync()));
        }
    }

}
