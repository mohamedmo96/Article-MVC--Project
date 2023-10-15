using Article.core;
using Article.Date;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Article.Controler
{
    [Authorize]

    public class ProductController : Controller
    {
        private readonly IDataHelper<Product> dataHelper;
        
        public ProductController(IDataHelper<Product> dataHelper)
        {
            this.dataHelper = dataHelper;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            var model = dataHelper.GetAll();
            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            
            return View(dataHelper.GetById(id));
        }
        public ActionResult Create()
        {
            return View();
        }


        // POST: ProductController/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product collection)
        {
            try
            {
              var model =dataHelper.Add(collection);
                if (model == 1)
                {
                    return RedirectToAction(nameof(Index));

                }
                else 
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = dataHelper.GetById(id);
            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product collection)
        {
            try
            {
                var model = dataHelper.Update(id ,collection);
                if (model == 1)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View();
                }
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
        public ActionResult Delete(int id, Product collection)
        {
            try
            {
                var model = dataHelper.Delete(id);
                if (model == 1)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
