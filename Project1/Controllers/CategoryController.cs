using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Identity.Client;
using Project1.Data;
using Project1.Models;
using Project1.Repository;
using Project1.Repository.IRepository;
using System.Security.Cryptography.X509Certificates;

namespace Project1.Controllers
{
    public class CategoryController : Controller
    {
        private  readonly ICategoryRepository categoryRepository; // new CategoryRepository();

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {

            var result = categoryRepository.GetAll();
            return View(result);
        }

        public IActionResult createnew()
        {
            Category category = new Category();
            return View(category);
        }

        [HttpPost]
        public IActionResult createnew(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.create(category);
                TempData["stats"] = "Data Added Successfully";
                return RedirectToAction("Index");
            }


            return View(category);
        }

        public IActionResult Edit(int id) 
        {
            var result = categoryRepository.Get(e=>e.CategoryId==id);
            return result != null ? View(result) : RedirectToAction("Notfound","Home");
        }


        [HttpPost]
        public IActionResult Edit(Category category)
        {

                categoryRepository.Edit(category);
                TempData["stats"] = "Data Update Successfully";
                return RedirectToAction("Index");
            
     
        }

        public IActionResult Delete(int id)
        {
            var result = categoryRepository.Get(e=>e.CategoryId==id).FirstOrDefault();

            if(result != null)
            {
                categoryRepository.delete(result);
                return RedirectToAction("Index");
            }
            else
            {
              return  RedirectToAction("Notfound", "Home");
            }
        }

       
    }
}
