using Microsoft.AspNetCore.Mvc;
using Lecture3Demo.Models;
using Lecture3Demo.ViewModels;

namespace Lecture3Demo.Controllers;

public class StudentController : Controller
{
    // TASK 4: ViewModel - combines Student + Address + Title + Header
    public IActionResult Details()
    {
        Student student = new Student()
        {
            StudentId = 4,
            Name = "Diana Prince",
            Branch = "Computer Science",
            Section = "A",
            Gender = "Female",
        };

        Address address = new Address()
        {
            Street = "123 Main Street",
            City = "Wellington",
            Country = "New Zealand",
        };

        StudentDetailsViewModel viewModel = new StudentDetailsViewModel()
        {
            Student = student,
            Address = address,
            Title = "Student Details",
            Header = "Student Full Profile (ViewModel)",
        };

        return View(viewModel);
    }
}
