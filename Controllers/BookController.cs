using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baitap.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        // GET: Book
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML & CSS3 The complete Manual - Author Name Book 1");
            books.Add("HTML & CSS3 Responsive web Design cookbook - Author Name Book 2");
            books.Add("Professional APS.NET MVC5 - Author Name Book 3");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Models.Book>();
            books.Add(new Models.Book(1, "Đắc nhân tâm", "Dale Carnegie", "/Content/Image/book1.jpg"));
            books.Add(new Models.Book(2, "Ứng xử với Trung Quốc", "Henry M Paulson", "/Content/Image/book2.jpg"));
            books.Add(new Models.Book(3, "Bàn tay ánh sáng", "Barbara Brennan", "/Content/Image/book3.jpg"));
            return View(books);
        }

        public ActionResult EditBook(int id)
        {
            var books = new List<Models.Book>();
            books.Add(new Models.Book(1, "Đắc nhân tâm", "Dale Carnegie", "/Content/Image/book1.jpg"));
            books.Add(new Models.Book(2, "Ứng xử với Trung Quốc", "Henry M Paulson", "/Content/Image/book2.jpg"));
            books.Add(new Models.Book(3, "Bàn tay ánh sáng", "Barbara Brennan", "/Content/Image/book3.jpg"));
            Models.Book book = new Models.Book();
            foreach (Models.Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int? id, string Title, string Author, string Image_cover)
        {
            var books = new List<Models.Book>();
            books.Add(new Models.Book(1, "Đắc nhân tâm", "Dale Carnegie", "/Content/Image/book1.jpg"));
            books.Add(new Models.Book(2, "Ứng xử với Trung Quốc", "Henry M Paulson", "/Content/Image/book2.jpg"));
            books.Add(new Models.Book(3, "Bàn tay ánh sáng", "Barbara Brennan", "/Content/Image/book3.jpg"));
            if (id == null)
            {
                return HttpNotFound();
            }
            foreach (Models.Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Image_cover = Image_cover;
                    break;
                }
            }
            return View("ListBookModel", books);
        }

        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult ContactCreate([Bind(Include = "Id,Title,Author,Image_cover")] Models.Book book)
        {
            var books = new List<Models.Book>();
            books.Add(new Models.Book(1, "Đắc nhân tâm", "Dale Carnegie", "/Content/Images/book1.jpg"));
            books.Add(new Models.Book(2, "Ứng xử với Trung Quốc", "Henry M Paulson", "/Content/Images/book2.jpg"));
            books.Add(new Models.Book(3, "Bàn tay ánh sáng", "Barbara Brennan", "/Content/Images/book3.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (RetryLimitExceededException /*dex*/)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel", books);
        }

    }
}
