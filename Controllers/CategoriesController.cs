using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPizza.Models;

namespace WebPizza.Controllers
{
    public class CategoriesController : Controller
    {
        private ProductsRepository repository = new ProductsRepository();
        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult Menu(string category)
        {
            IEnumerable<string> genres = repository.List()
                .Select(prod => prod.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(genres);
        }
    }
}