using Microsoft.AspNetCore.SignalR;

namespace Final_Wave.Hubs
{
    public class UserHub :Hub
    {
        public string username { get; set; }
    }
}
