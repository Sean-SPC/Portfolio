using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.ShowLoader = true;
        string[] sonicLoaders = [
            "sonic-spindash",
            "sonic-jog",
            "sonic-run"
        ];

        Random rnd = new Random();
        int index = rnd.Next(3);
        ViewBag.Loader = sonicLoaders[index];

        string folderPath = @"C:\Users\Seanc\OneDrive\Documents\VS_Code_Workspace\Portfolio\wwwroot\src\backgrounds";
        string[] files = Directory.GetFiles(folderPath, "*.mp4");

        if (files.Length == 0)
        {
            Console.WriteLine("No files found.");
            return View();
        }
        
        string backgroundVideo = Path.GetFileName(files[rnd.Next(files.Length)]);
        ViewBag.BackgroundVideo = backgroundVideo;
        Console.WriteLine(backgroundVideo);

        ViewBag.ShowLoader = false;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
