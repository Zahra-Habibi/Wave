using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.ViewComponents.SliderComponent
{
    public class SliderComponent:ViewComponent
    {
        private IUnitOfWork _temp;
        public SliderComponent(IUnitOfWork temp)
        {
            _temp = temp;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("MySliderView", await _temp.sliderUW.GetEntitiesAsync()));
        }
    }
}
