using Microsoft.AspNetCore.SignalR;

// must be imported by Models.ReportHub
namespace SimpleAsyncDemo.Models
{
    public class ReportHub : Hub
    {
        public async Task SendMessage(string source, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", source, message);
        }
    }
}