using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookManager.Models;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBook()
        {
            BookManagerContext con = new BookManagerContext();
            var ListBook = con.Books.ToList();
            return View(ListBook);
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,Author,Images,Price")] Book book)
        {
            BookManagerContext context = new BookManagerContext();
            List<Book> listBook = context.Books.ToList();
            if (ModelState.IsValid)
            {
                context.Books.AddOrUpdate(book);
                context.SaveChanges();

            }
            return RedirectToAction("ListBook");
        }

        public ActionResult Edit(int? id)
        {
            BookManagerContext context = new BookManagerContext();
            List<Book> listBook = context.Books.ToList();
            Book book = context.Books.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View();
        }
        [Authorize]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Title, Description,Author, Images, Price")] Book book)
        {
            BookManagerContext context = new BookManagerContext();
            List<Book> listBook = context.Books.ToList();
            if (ModelState.IsValid)
            {
                context.Books.AddOrUpdate(book);
                context.SaveChanges();

            }
            return RedirectToAction("ListBook", listBook);
        }
        public ActionResult Delete(int? id)
        {
            BookManagerContext context = new BookManagerContext();
            List<Book> listBook = context.Books.ToList();
            Book book = context.Books.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(BookManagerContext.BadRequest);
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            BookManagerContext context = new BookManagerContext();
            List<Book> listBook = context.Books.ToList();
            Book book = context.Books.Find(id);
            context.Books.Remove(book);
            context.SaveChanges();
            return RedirectToAction("ListBook", listBook);
        }
    }
}