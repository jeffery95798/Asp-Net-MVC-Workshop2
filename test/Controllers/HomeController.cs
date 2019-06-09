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
            ViewBag.i = bookService.getsql();
            return View();
        }
        [HttpPost]
        public JsonResult DeleteBookById(string id)
        {
            bookService.DeleteBookById(id);
            return this.Json(true);
        }
        [HttpPost]
        public JsonResult InsertBook(string id)
        {
            string[] s = id.Split('|');
            bookService.InsertBook(s[0], s[1], s[2], s[3], s[4], s[5]);
            return this.Json(true);
        }
        public JsonResult Update(string id)
        {
            string[] s = id.Split('|');
            bookService.UpdateBook(s[0], s[1], s[2], s[3], s[4], s[5], s[6], s[7], s[8]);
            return this.Json(true);
        }

    }
}