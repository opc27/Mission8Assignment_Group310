using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission8Assignment_Group310.Models;

namespace Mission8Assignment_Group310.Controllers;

public class HomeController : Controller
{
    private EnterTasksContext _context;
    
    public HomeController(EnterTasksContext temp) // constructor
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
        // view bag for categories
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
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
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            
            return View(response);
        }
        
    }
    
    // displaying tasks
    public IActionResult ViewTasks()
    {
        return View();
    }
    
    [HttpGet] // edit tasks (get)
    public IActionResult Edit(int id) // pull the movie for the movie that we're editing
    {
        var recordToEdit = _context.Tasks
            .Single(x => x.TaskId == id);
        
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();  
        
        return View("AddTask", recordToEdit);
    }

    [HttpPost] // edit tasks (post)
    public IActionResult Edit(Task updatedInfo) // save edited movie
    {
        _context.Movies.Update(updatedInfo);
        _context.SaveChanges();
        
        return RedirectToAction("ViewTasks");
    }

    [HttpGet] // delete tasks (get)
    public IActionResult Delete(int id) // delete movie
    {
        var recordToDelete = _context.Tasks
            .Single(x => x.TaskId == id);

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