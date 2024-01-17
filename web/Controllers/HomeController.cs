using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using web.Data;
using web.Models;

namespace web.Controllers;

public class HomeController : Controller
{
        private readonly ILogger<HomeController> _logger;
        private readonly SvetKnjigContext _context;

        public HomeController(ILogger<HomeController> logger, SvetKnjigContext context)
        {
            _logger = logger;
            _context = context;
        }

    public IActionResult Index()
    {

        var avtorji = _context.Avtorji.ToList(); 
        var knjige = _context.Knjige.ToList();   

        var viewModel = new Knjiga_avtor
        {
            Avtorji = avtorji,
            Knjige = knjige
        };

        return View(viewModel);

    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
