using Final_Wave.DataLayer.Contexxt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Final_Wave.Hubs
{
    public class FirstChat:Hub
    {
        private readonly ApplicationContext _db;
        public FirstChat(ApplicationContext context)
        {
            _db = context;
        }

        public async Task SendMessageToAll(string user, string message)
        {
            await Clients.All.SendAsync("MessageRecieved", user, message);
        }



        public async Task SendMessageToReceiver(string sender, string receiver, string message)
        {
            var userId = _db.Users.FirstOrDefault(u => u.Email.ToLower() == receiver.ToLower()).Id;

            if (!string.IsNullOrEmpty(userId))
            {
                await Clients.User(userId).SendAsync("MessageReceived", sender, message);
            }

        }
    }
}
