using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryController(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Category> categories= _dbContext.Categories.ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display ordeer cant be same");
            }
            if (ModelState.IsValid)
            {

                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                TempData["sucess"] = "Category added Successfully.";
                return RedirectToAction("Index");
            }
            
           
                return View();
           
           
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _dbContext.Categories.Where(x=>x.Id== id).FirstOrDefault();
            if (category==null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display ordeer cant be same");
            }
            if (ModelState.IsValid)
            {
                //var data=_dbContext.Categories.Where(y => y.Id == category.Id).FirstOrDefault();
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
                TempData["sucess"] = "Category Edited Successfully.";
                return RedirectToAction("Index");
            }


            return View();


        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _dbContext.Categories.Where(x => x.Id == id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletPost(int? id)
        {
            
            if (id!=0 && id!=null)
            {
                var data=_dbContext.Categories.Where(y => y.Id == id).FirstOrDefault();
                _dbContext.Categories.Remove(data);
                _dbContext.SaveChanges();
                TempData["sucess"] = "Category Deleted Successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                NotFound();
            }


            return View();


        }
    }
}
