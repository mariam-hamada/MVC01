using Microsoft.AspNetCore.Mvc;
using MVC01.Models;
using System.Diagnostics;

namespace MVC01.Controllers
{
    public class ProductController : Controller
    {
        // GET-> BaseURL / Product/TestAction
        //public string TestAction()
        //{
        //    return "tested successfully";
        //}

        //will give error if we have the same action name in the same controller even if the action verbs [HTTPGet] or [HTTPPost] are different
        //public String TestAction()
        //{
        //    return "tested successfully";
        //}

        //Will not give error if we have the same action name in the same controller if have different Parameters
        //public String TestAction(int x)
        //{
        //    return "tested successfully";
        //}

        //public ContentResult Index()
        //{
        //    ContentResult result = new ContentResult()
        //    {
        //        Content = "<h1>Hello From Index</h1>",
        //        StatusCode = 1000,
        //        ContentType ="text/plain"
        //    };

        //    return result;
        //}//print the content in the browser as plain  :<h1>Hello From Index</h1>

        //public ContentResult Index1()
        //{
        //    ContentResult result = new ContentResult()
        //    {
        //        Content = "<h1>Hello From Index1</h1>",
        //        StatusCode = 1000,
        //        ContentType = "text/html"
        //    };

        //    return result;
        //}//Print the content in the browser as html :Hello From Index1 in a bold heading form 

        //instead of doing all of these i can use the built in form HelperMethods to return the content in the browser as plain or html
        //public ViewResult Index()
        //{ 
        //    return View();
        //}
        //Will throw an exception if the view is not found in the Views/Product/Index.cshtml or Views/Shared/Index.cshtml but it goes to the action name but doesnt found the view so it will throw an exception

        public ViewResult Index()
        {
            return View();
        }

        //public JsonResult GetProducts()
        //{
        //    var products = new List<Product>()
        //    {
        //        new Product{Id=1,Name="Product 1"},
        //        new Product{Id=2,Name="Product 2"},
        //        new Product{Id=3,Name="Product 3"}
        //    };
        //    return Json(products);
        //}

        public IActionResult GetProductsById(int id)
        {
            if (id < 0)
                return BadRequest();
            else if (id == 0)
                return RedirectToAction(nameof(Index));
            else if (id > 100)
                return NotFound();
            else
                return Json(new { Id = id, Name = "Laptop" });
            //if i dont send the id it will take the default =0
        }

        public IActionResult RedirectToLink()
        {
            return Redirect("https://routeeg.com/");
        }

        public IActionResult FileAction()
        {
            var fileBytes = System.IO.File.ReadAllBytes("wwwroot/files/AAA");
            return File(fileBytes, "appliction/pdf");
        }
    }
}
