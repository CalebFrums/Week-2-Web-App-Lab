using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using ActionResultInASPNETCoreMVC.Models;

namespace ActionResultInASPNETCoreMVC.Controllers;

public class HomeController : Controller
{
    // TASK 1: ViewResult - Returns a strongly typed view with a Product model
    public ViewResult Index()
    {
        Product product = new Product()
        {
            Id = 1,
            Name = "Test",
        };
        return View(product);
    }

    // TASK 2: PartialViewResult - Returns a partial view with a Product model
    public PartialViewResult ProductPartial()
    {
        Product product = new Product()
        {
            Id = 2,
            Name = "Partial View",
        };
        return PartialView("_ProductDetailsPartialView", product);
    }

    // TASK 3: FileResult (FileContentResult) - Returns a PDF file for download
    public FileResult DownloadFile()
    {
        string filePath = Directory.GetCurrentDirectory() + "\\wwwroot\\PDFFiles\\" + "Sample.pdf";
        var fileBytes = System.IO.File.ReadAllBytes(filePath);
        var fileResult = File(fileBytes, "application/pdf");
        fileResult.FileDownloadName = "MySampleFile.pdf";
        fileResult.LastModified = new DateTimeOffset(System.IO.File.GetLastWriteTimeUtc(filePath));
        fileResult.EntityTag = new EntityTagHeaderValue("\"fileVersion1\"");
        fileResult.EnableRangeProcessing = true;
        return fileResult;
    }

    // TASK 4: RedirectResult - Redirects to an external URL
    public RedirectResult GoToMoodle()
    {
        return Redirect("https://moodle.whitireiaweltec.ac.nz/");
    }

    // TASK 5: StatusResult - Returns a 404 Not Found status code
    public IActionResult NotFoundExample()
    {
        return NotFound();
    }

    // TASK 5: StatusResult - Returns a 403 Forbidden status code
    public IActionResult CustomStatusCodeExample()
    {
        return StatusCode(403);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
