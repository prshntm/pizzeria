using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPizza.Abstract;
using WebPizza.Models;

namespace WebPizza.Controllers
{
    public class IngredientsController : Controller
    {
        
        IngredientsRepository repository = new IngredientsRepository();
        // GET: Ingredients
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PizzaConstructor(PizzaConstructor constructor, string returnUrl)
        {
            IngredientsListViewModel viewModel = new IngredientsListViewModel()
            {
                Ingredients = repository.List()
            };
            return View(viewModel);
        }
        
    }
}