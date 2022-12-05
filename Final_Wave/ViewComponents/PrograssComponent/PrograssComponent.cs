using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.ViewComponents.PrograssComponent
{
    public class PrograssComponent:ViewComponent
    {
        private readonly IUnitOfWork _context;
        public PrograssComponent(IUnitOfWork context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return await Task.FromResult((IViewComponentResult)View("OrderPrograss", await _context.PrograssUW.GetEntitiesAsync(x => x.orderid == id)));
        }
    }
}
