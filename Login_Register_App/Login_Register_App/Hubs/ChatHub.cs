using Microsoft.AspNetCore.SignalR;

namespace Login_Register_App.Hubs
{
    public class ChatHub:Hub
    {
        public async Task SendMessageAsync(string user,string message)
        {
            await Clients.All.SendAsync("usersMessage",user,message);
        }
    }
}
