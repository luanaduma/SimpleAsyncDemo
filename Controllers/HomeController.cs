using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleAsyncDemo.Models;

namespace SimpleAsyncDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly WebsiteDownloaderService _downloaderService;
    private readonly WebsiteReporterService _reporterService;

    public HomeController(
        ILogger<HomeController> logger,
        WebsiteDownloaderService downloaderService,
        WebsiteReporterService reporterService)
    {
        _logger = logger;
        _downloaderService = downloaderService;
        _reporterService = reporterService;
    }

    public IActionResult Index() => View();

    public IActionResult Privacy() => View();
    public IActionResult About() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private List<string> PrepareData() => new()
    {
        "https://www.yahoo.com/",
        "https://www.microsoft.com/",
        "https://www.facebook.com/"
    };

    [HttpPost]
    public JsonResult RunSync()
    {
        var watch = Stopwatch.StartNew();
        var output = RunDownloadSync();
        watch.Stop();

        return Json(new
        {
            elapsedTime = watch.ElapsedMilliseconds,
            method = "RunSync",
            output
        });
    }

    private string RunDownloadSync()
    {
        var data = PrepareData();
        return string.Join("<br/>", data.Select(item =>
        {
            var website = _downloaderService.DownloadWebsite(item);
            return _reporterService.ReportWebsiteInfo(website);
        }));
    }

    [HttpPost]
    public async Task<JsonResult> RunFunc()
    {
        var watch = Stopwatch.StartNew();
        await RunDownloadAsync();
        watch.Stop();

        return Json(new
        {
            elapsedTime = watch.ElapsedMilliseconds,
            method = "Run Async"
        });
    }

    private async Task RunDownloadAsync()
    {
        var data = PrepareData();
        foreach (var item in data)
        {
            var website = await _downloaderService.DownloadWebsiteAsync(item);
            await _reporterService.ReportWebsiteInfoAsync(website, "Async");
        }
    }

    [HttpPost]
    public async Task<JsonResult> RunParallel()
    {
        try
        {
            var watch = Stopwatch.StartNew();
            await RunDownloadParallelAsync();
            watch.Stop();

            return Json(new
            {
                elapsedTime = watch.ElapsedMilliseconds,
                method = "RunParallel"
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in RunParallel");
            return Json(new
            {
                error = true,
                message = "An error occurred while running parallel tasks."
            });
        }
    }

    private async Task RunDownloadParallelAsync()
    {
        var data = PrepareData();
        var downloadTasks = data.Select(async item =>
        {
            var website = await _downloaderService.DownloadWebsiteAsync(item);
            await _reporterService.ReportWebsiteInfoAsync(website, "Parallel");
        });

        await Task.WhenAll(downloadTasks);
    }
}
