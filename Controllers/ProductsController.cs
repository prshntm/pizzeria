using WebPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPizza.Models;

namespace WebPizza.Controllers
{
    public class ProductsController : Controller
    {
        private ProductsRepository repository = new ProductsRepository();
        private int pageSize = 4;
        protected int CurrentPage
        {
            get {
                int page;
                return int.TryParse(Request.QueryString["page"], out page) ? page : 1;
            }
        }
        /*public IEnumerable<Products> GetProducts()
        {
            return repository.Product
            .OrderBy(p => p.ProductID)
            .Skip((CurrentPage - 1) * pageSize)
            .Take(pageSize);
        }*/

        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Product = repository.List()
                .Where(c => category == null || c.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
                        repository.List().Count() :
                        repository.List().Where(c => c.Category == category).Count()
                },
                CurrentCategory = category
            };
            
            return View(model);
        }
        public ViewResult PizzaList(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Product = repository.List()
             .Where(c => c.Category == "Пицца")
            .OrderBy(p => p.ProductID)
            .Skip((page - 1) * pageSize)
            .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
                        repository.List().Count() :
                        repository.List().Where(c => c.Category == "Пицца").Count()
                },
                CurrentCategory = category
            };



            return View(model);
        }


    }
}