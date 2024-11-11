using System.Net;
using Microsoft.Extensions.Logging;
using SimpleAsyncDemo.Models;

public class WebsiteDownloaderService
{
    private readonly ILogger<WebsiteDownloaderService> _logger;

    public WebsiteDownloaderService(ILogger<WebsiteDownloaderService> logger)
    {
        _logger = logger;
    }

    public WebsiteDataModel DownloadWebsite(string url)
    {
        try
        {
            using var client = new WebClient();
            var data = client.DownloadString(url);
            return new WebsiteDataModel { Url = url, Data = data };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error downloading {url}");
            return new WebsiteDataModel { Url = url, Data = $"Error: {ex.Message}" };
        }
    }

    public async Task<WebsiteDataModel> DownloadWebsiteAsync(string url)
    {
        try
        {
            using var client = new WebClient();
            var data = await client.DownloadStringTaskAsync(url);
            return new WebsiteDataModel { Url = url, Data = data };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error downloading {url}");
            return new WebsiteDataModel { Url = url, Data = $"Error: {ex.Message}" };
        }
    }
}
