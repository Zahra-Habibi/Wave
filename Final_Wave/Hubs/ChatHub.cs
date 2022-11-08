using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Final_Wave.Hubs
{
    [Authorize]
    public class ChatHub :Hub
    {
        //total views in window
        public static int TotalViews { get; set; } = 0;
        public static int TotalUsers { get; set; } = 0;

        public override Task OnConnectedAsync()
        {
            TotalUsers++;
            Clients.All.SendAsync("updateTotalUsers", TotalUsers).GetAwaiter().GetResult();
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            TotalUsers --;
            Clients.All.SendAsync("updateTotalUsrs", TotalUsers).GetAwaiter().GetResult();
            return base.OnDisconnectedAsync(exception);
        }

        
        public async Task NewWindowLoaded()
        {
            TotalViews++;
            await Clients.All.SendAsync("updateTotalViews",TotalViews);
        }
        //public chat
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

     
    }
}
