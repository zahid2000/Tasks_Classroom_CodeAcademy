using Microsoft.AspNetCore.SignalR;

namespace SignalRApi.Hubs
{
    public class ChatHub:Hub
    {
        public async Task SendMessageAsync(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",message);
            
        }
    }
}
