using QuanLyBanSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBanSach.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        private List<Book> listBooks;
        public BooksController()
        {
            listBooks = new List<Book>();
            listBooks.Add(new Book()
            {
                Id = 1,
                Title = "sach 1",
                Author= "tac gia sach 1",
                Price = 30000,
                PublicYear = 2018,
                Cover = "Content/Image/1.jpg"
            }) ;
            listBooks.Add(new Book()
            {
                Id = 2,
                Title = "sach 2",
                Author = "tac gia sach 2",
                Price = 305000,
                PublicYear = 2018,
                Cover = "Content/Image/2.jpg"
            });
            listBooks.Add(new Book()
            {
                Id = 3,
                Title = "sach 3",
                Author = "tac gia sach 3",
                Price = 3000045,
                PublicYear = 2018,
                Cover = "Content/Image/3.jpg"
            });
        }
        public ActionResult ListBooks()
        {
            ViewBag.TitlePageName = "book view page";
            return View(listBooks);
        }
        public ActionResult Detail(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book =listBooks.Find(s=>s.Id==id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = listBooks.Find(s => s.Id == id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var editBook = listBooks.Find(b => b.Id == book.Id);
                    editBook.Title = book.Title;
                    editBook.Author = book.Author;
                    editBook.Cover = book.Cover;
                    editBook.Price = book.Price;
                    editBook.PublicYear = book.PublicYear;
                    return View("ListBooks", listBooks);
                }catch(Exception ex)
                {
                    return HttpNotFound();
                }
            }
            else
            {
                ModelState.AddModelError("", "input Model not valid!@");
                return View(book);
            }
        }
    }
}