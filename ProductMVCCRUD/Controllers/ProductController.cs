using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductMVCCRUD.Models;


namespace ProductMVCCRUD.Controllers
{

    public class ProductController : Controller
    {

        IConfiguration configuration;
        ProductCRUD procrud;
        CategoryCRUD catcrud;

        private Microsoft.AspNetCore.Hosting.IHostingEnvironment env;

        public ProductController(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            this.configuration = configuration;
            procrud = new ProductCRUD(this.configuration);
            catcrud = new CategoryCRUD(this.configuration);
            this.env = env;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View(procrud.GetAllProducts());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {

            return View(procrud.GetProductById(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            

            ViewBag.Categories = catcrud.GetAllCategories();
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product pro, IFormFile file)
        {
            try
            {
                using (var fs = new FileStream(env.WebRootPath + "\\images\\" + file.FileName, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fs);
                }
                pro.Imageurl = "~/images/" + file.FileName;
                var result = procrud.AddProduct(pro);
                if (result >= 1)
                    return RedirectToAction(nameof(Index));
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
