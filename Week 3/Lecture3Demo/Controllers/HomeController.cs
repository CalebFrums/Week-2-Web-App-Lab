using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Lecture3Demo.Models;

namespace Lecture3Demo.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    // TASK 1: ViewData
    public IActionResult DetailsViewData()
    {
        ViewData["Title"] = "Student Details Page";
        ViewData["Header"] = "Welcome to Student Details (ViewData)";
        ViewData["Student"] = new Student()
        {
            StudentId = 1,
            Name = "John Smith",
            Branch = "Computer Science",
            Section = "A",
            Gender = "Male",
        };
        return View("Details");
    }

    // TASK 2: ViewBag
    public IActionResult DetailsViewBag()
    {
        ViewBag.Title = "Student Details Page";
        ViewBag.Header = "Welcome to Student Details (ViewBag)";
        ViewBag.Student = new Student()
        {
            StudentId = 2,
            Name = "Jane Doe",
            Branch = "Information Technology",
            Section = "B",
            Gender = "Female",
        };
        return View("DetailsViewBag");
    }

    // TASK 3: Strongly Typed View
    public IActionResult DetailsTyped()
    {
        Student student = new Student()
        {
            StudentId = 3,
            Name = "Alice Brown",
            Branch = "Software Engineering",
            Section = "C",
            Gender = "Female",
        };
        return View("DetailsTyped", student);
    }

    // TASK 5: TempData
    public IActionResult TempDataIndex()
    {
        TempData["Name"] = "Bob Wilson";
        TempData["Role"] = "Administrator";
        TempData.Keep();
        return View("TempDataIndex");
    }

    public IActionResult TempDataPrivacy()
    {
        TempData.Keep();
        return View("TempDataPrivacy");
    }

    public IActionResult TempDataAbout()
    {
        return View("TempDataAbout");
    }

    // TASK 5c: TempData with complex object (serialized to JSON)
    public IActionResult TempDataComplex()
    {
        Student student = new Student()
        {
            StudentId = 5,
            Name = "Charlie Davis",
            Branch = "Data Science",
            Section = "D",
            Gender = "Male",
        };
        TempData["StudentJson"] = JsonSerializer.Serialize(student);
        return View("TempDataComplex");
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
