using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{

    public class HomeController : Controller
    {
        Models.BookService bookService = new Models.BookService();

        public ActionResult Index()
        {
            ViewBag.SearchResult = bookService.GetBookByCondtioin();
            return View();
        }
        
    }
}