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
    
    public IActionResult Index() // main page
    {
        return View();
    }

    [HttpGet] // for entering tasks
    public IActionResult AddTask()
    {
        // view bag for categories
        ViewBag.Categories = _tasklistContext.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View("AddTask", new Task());
    }
    
    [HttpPost] // sending tasks
    public IActionResult AddTask(Task response) // save changes to database
    {
        if (ModelState.IsValid)
        {
            _tasklistContext.Tasks.Add(response); // add record to database
            _tasklistContext.SaveChanges();
            
            return View("Confirmation", response); 
        }
        else
        {
            ViewBag.Categories = _tasklistContext.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            
            return View(response);
        }
    }
    
    // displaying tasks
    // Display tasks grouped in quadrants
    public IActionResult ViewTasks()
    {
        var tasks = _tasklistContext.Tasks
            .Where(t => t.Complete == false || t.Complete == null) // Show only incomplete tasks
            .ToList();
        
        if (tasks == null)
        {
            tasks = new List<Task>();
        }

        return View(tasks);
    }

    
    [HttpGet] // edit tasks (get)
    public IActionResult Edit(int id) // pull the task for the task that we're editing
    {
        var recordToEdit = _tasklistContext.Tasks
            .SingleOrDefault(x => x.TaskId == id);

        if (recordToEdit == null)
        {
            return NotFound();
        }

        
        ViewBag.Categories = _tasklistContext.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

        return View("AddTask", recordToEdit);
    }

    [HttpPost] // edit tasks (post)
    public IActionResult Edit(Task updatedInfo) // save edited task
    {
        _tasklistContext.Tasks.Update(updatedInfo);
        _tasklistContext.SaveChanges();
        
        ViewBag.Categories = _tasklistContext.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();  
        
        return RedirectToAction("ViewTasks");
    }

    [HttpGet] // delete tasks (get)
    public IActionResult Delete(int id)
    {
        var task = _tasklistContext.Tasks.SingleOrDefault(x => x.TaskId == id);

        if (task != null)
        {
            _tasklistContext.Tasks.Remove(task);
            _tasklistContext.SaveChanges();
        }

        return RedirectToAction("ViewTasks");
    }


    [HttpPost] // delete tasks (post)
    public IActionResult Delete(Task task) // save changes to database
    {
        _tasklistContext.Tasks.Remove(task);
        _tasklistContext.SaveChanges();
        
        return RedirectToAction("ViewTasks");
    }
}