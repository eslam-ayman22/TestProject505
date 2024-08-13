using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project1.Data;
using Project1.Models;
using Project1.Repository.IRepository;

namespace Project1.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;

        public ProductController(IProductRepository productRepository , ICategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }

       
        public IActionResult Mobile()
        {

            //var result = context.products.include("Category").Where(e => e.CategoryId == 2 );
            var result = productRepository.Get(e => e.CategoryId == 2, "Category");
            return View(result);
        }

        public IActionResult Detals(int Id)
        {
            var result = productRepository.Get(e => e.ProductId == Id).FirstOrDefault();
            return View(result);
        }

        public IActionResult create()
        {
            Product product = new Product();
            ViewData["listofcategory"] = categoryRepository.GetAll().Select(e => new
            SelectListItem(e.Name, e.CategoryId.ToString()));
            return View(product);
        }

        [HttpPost]
        public IActionResult create(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.create(product);
                productRepository.commit();
                return RedirectToAction("createnew");
            }

            ViewData["listofcategory"] = productRepository.GetAll();
            return View(product);
        }

        public IActionResult Edit(int id)
        {


            ViewData["listofcategory"] = categoryRepository.GetAll();
            var result = productRepository.Get(e => e.ProductId == id).FirstOrDefault();
            return View(result);

        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            productRepository.Edit(product);
            productRepository.commit();

            return RedirectToAction("createnew");
        }

        public IActionResult Delete (int id)
        {
            var result = productRepository.Get(e => e.ProductId == id).FirstOrDefault();

            if(result != null)
            {
                productRepository.delete(result);
                productRepository.commit();
                return RedirectToAction("Mobile");
            }
            else
            {
                return RedirectToAction("NotFind", "Home");
            }
        }





    }
}
