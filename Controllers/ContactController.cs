using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers;

public class ContactController : Controller
{
    // 
    // GET: /Contact
    public IActionResult Index()
    {
        return View();
    }
}
