using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Mission8Assignment_Group310.Models;
using Task = Mission8Assignment_Group310.Models.Task;

namespace Mission8Assignment_Group310.Controllers;

public class HomeController : Controller
{

    private TasklistContext _context;
    public HomeController(TasklistContext temp)
    {
        _context = temp;
    }
    
    public IActionResult Index() // main page
    {
        return View();
    }

    [HttpGet] // for entering tasks
    public IActionResult AddTask()
    {
        return View("AddTask", new Task());
    }
    
    [HttpPost] // sending tasks
    public IActionResult AddTask(Task response) // save changes to database
    {
        if (ModelState.IsValid)
        {
            _context.Tasks.Add(response); // add record to database
            _context.SaveChanges();
            
            return View("Confirmation", response); 
        }
        else
        {
            
            return View(response);
        }
    }
    
    // displaying tasks
    public IActionResult ViewTasks()
    {
        return View();
    }
    
    [HttpGet] // edit tasks (get)
    public IActionResult Edit(int id) // pull the task for the task that we're editing
    {
        var recordToEdit = _context.Tasks
            .Single(x => x.FormId == id);
        
        return View("AddTask", recordToEdit);
    }

    [HttpPost] // edit tasks (post)
    public IActionResult Edit(Task updatedInfo) // save edited task
    {
        _context.Tasks.Update(updatedInfo);
        _context.SaveChanges();
        
        return RedirectToAction("ViewTasks");
    }

    [HttpGet] // delete tasks (get)
    public IActionResult Delete(int id) // delete task
    {
        var recordToDelete = _context.Tasks
            .Single(x => x.FormId == id);

        return View(recordToDelete);
    }

    [HttpPost] // delete tasks (post)
    public IActionResult Delete(Task task) // save changes to database
    {
        _context.Tasks.Remove(task);
        _context.SaveChanges();
        
        return RedirectToAction("ViewTasks");
    }
}