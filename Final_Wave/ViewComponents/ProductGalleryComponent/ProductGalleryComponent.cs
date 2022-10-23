using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.ViewComponents.GalleryComponent
{
    public class ProductGalleryComponent :ViewComponent
    {
        private readonly IUnitOfWork _context;
        public ProductGalleryComponent(IUnitOfWork context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return await Task.FromResult((IViewComponentResult)View("GalleryProduct", await _context.galleryUW.GetEntitiesAsync(x => x.ProductId == id, null, "Product")));
        }
    }
}
