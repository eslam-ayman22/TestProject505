using Microsoft.AspNetCore.Mvc;
using Project1.Data;
using Project1.Models;

namespace Project1.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Mobile()
        {
            
            var result = context.products.Where(e => e.CategoryId == 2 );
            return View(result);
        }

        public IActionResult Detals(int Id)
        {
            var result = context.products.Find(Id);
            return View(result);
        }

        public IActionResult createnew()
        {
           
            ViewData["listofcategory"] = context.categorys.ToList();
            return View();
        }

        public IActionResult savenew(Product product)
        {
            context.products.Add(product);
            context.SaveChanges();
            return RedirectToAction("createnew");
        }

        public IActionResult Edit(int id)
        {
          

            ViewData["listofcategory"] = context.categorys.ToList();
            var result = context.products.Find(id);
            return View(result);
            
        }

        public IActionResult saveEdit(Product product)
        {
            context.products.Update(product);
            context.SaveChanges();
            return RedirectToAction("createnew");
        }

        public IActionResult Delete (int id)
        {
            var result = context.products.Find(id);

            if(result != null)
            {
                context.products.Remove(result);
                context.SaveChanges();
                return RedirectToAction("Mobile");
            }
            else
            {
                return RedirectToAction("NotFind", "Home");
            }
        }





    }
}
