using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Project1.Data;
using Project1.Models;

namespace Project1.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
           var result = context.categorys.ToList();
            return View(result);
        }

        public IActionResult createnew()
        {

            return View();
        }

        public IActionResult savenew(Category category)
        {
            context.categorys.Add(category);
            context.SaveChanges();
            return RedirectToAction("createnew");
        }

        public IActionResult Edit(int id) 
        {
           var result= context.categorys.Find(id);
            return result != null ? View(result) : RedirectToAction("Notfound","Home");
        }


        [HttpPost]
        public IActionResult Edit(Category category)
        {
            context.categorys.Update(category);
            context.SaveChanges();
            return RedirectToAction("createnew");
        }

        public IActionResult Delete(int id)
        {
            var result = context.categorys.Find(id);

            if(result != null)
            {
                context.categorys.Remove(result);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
              return  RedirectToAction("Notfound", "Home");
            }
        }

       
    }
}
