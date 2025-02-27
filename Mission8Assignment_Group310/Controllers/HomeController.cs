using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Mission8Assignment_Group310.Models;
using Task = Mission8Assignment_Group310.Models.Task;

namespace Mission8Assignment_Group310.Controllers;

public class HomeController : Controller
{
    private TasklistContext _tasklistContext;
    public HomeController(TasklistContext temp)
    {
        _tasklistContext = temp;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Tasklist()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Tasklist(Task response)
    {
        _tasklistContext.Tasks.Add(response);
        return View();
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
