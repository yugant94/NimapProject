using NimapProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NimapProject.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private readonly ICategoryService _categoryService;

        // Constructor injection
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            int totalCategories;
            var categories = _categoryService.GetCategories(page, pageSize, out totalCategories);
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCategories / pageSize);
            ViewBag.CurrentPage = page;

            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!_categoryService.AddCategory(category))
            {
                ModelState.AddModelError("", "Category already exists.");
                return View(category);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var category = db.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult Delete(int id)
        {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}