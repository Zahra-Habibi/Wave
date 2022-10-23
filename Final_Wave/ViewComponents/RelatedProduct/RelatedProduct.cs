using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.ViewComponents.RelatedProduct
{
    public class RelatedProduct :ViewComponent
    {
        private readonly IUnitOfWork _context;
        public RelatedProduct(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return await Task.FromResult((IViewComponentResult)View("RelatedProduct", await _context.productUW.GetEntitiesAsync(x => x.CategoryId == id)));
        }
    }
}
