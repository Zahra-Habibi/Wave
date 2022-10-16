using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.ViewComponents.TeamComponent
{
    public class TeamComponent:ViewComponent
    {
        private IUnitOfWork _temp;
        public TeamComponent(IUnitOfWork temp)
        {
            _temp = temp;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("MyTeamView", await _temp.teamUW.GetEntitiesAsync()));
        }
    }
}
