using Microsoft.AspNetCore.SignalR;

namespace SignalR_Backend.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("Welcome", "You are connected to the hub.");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("Goodbye", "Someone has left the hub.");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
