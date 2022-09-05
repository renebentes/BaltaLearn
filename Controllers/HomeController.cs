using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BaltaLearn.Models;
using BaltaLearn.Data;
using Microsoft.EntityFrameworkCore;

namespace BaltaLearn.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index([FromServices] ApplicationDbContext context)
    {
        var courses = await context.Courses
            .AsNoTracking()
            .OrderByDescending(course => course.Id)
            .Skip(0)
            .Take(4)
            .ToListAsync();
        return View(courses);
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
