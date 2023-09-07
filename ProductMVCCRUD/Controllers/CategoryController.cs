using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMVCCRUD.Models;

namespace ProductMVCCRUD.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration configuration;
        public CategoryCRUD crud;

        public CategoryController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new CategoryCRUD(this.configuration);
        }
            
        // GET: CategoryController
        public ActionResult Index()
        {
            var model = crud.GetAllCategories();
            return View(model);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var result =crud.GetCategoryById(id);
            return View(result);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                int result = crud.AddCategory(category);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = crud.GetCategoryById(id);
            return View(result);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            try
            {
                int result = crud.UpdateCategory(category);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var result=crud.DeleteCategory(id);
            return View(result);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteCategory(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
