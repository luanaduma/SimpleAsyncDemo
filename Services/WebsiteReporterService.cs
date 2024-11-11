using Microsoft.AspNetCore.SignalR;
using SimpleAsyncDemo.Models;

public class WebsiteReporterService
{
    private readonly IHubContext<ReportHub> _hubContext;

    public WebsiteReporterService(IHubContext<ReportHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public string ReportWebsiteInfo(WebsiteDataModel data)
    {
        return $"{data.Url} downloaded: {data.Data.Length} characters long.";
    }

    public async Task<string> ReportWebsiteInfoAsync(WebsiteDataModel data, string caller)
    {
        var message = $"{data.Url} downloaded: {data.Data.Length} characters long.";
        await _hubContext.Clients.All.SendAsync("ReceiveMessage", caller, message);
        return message;
    }
}
