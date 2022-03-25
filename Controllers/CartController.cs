using Microsoft.AspNet.Identity;
using WebPizza.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPizza.Abstract;

namespace WebPizza.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        OrdersContext context = new OrdersContext();
        ProductsRepository repo = new ProductsRepository();
        CustomPizzaRepository pizzaRepo = new CustomPizzaRepository();
        /*public CartController(IRepository prodRepo)
        { 
            repo = prodRepo;
        }*/
        public Cart GetCart() //сохранение и извлечение объектов Cart
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult CartEmpty()
        {
            return View();
        }

        [Authorize]
        public ActionResult Orders()
        {
            var orders = context.Order.Include(o => o.Product);
            return View(orders.ToList());
        }

        public ViewResult CartView(/*Cart cart,*/ string returnUrl)
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id");
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCart(Cart cart, int prodId, string returnUrl)
        {
            Products prods = repo.List()
                .FirstOrDefault(b => b.ProductID == prodId);
            if (prods != null)
            {
                //cart.AddItem(prods, 1);
                GetCart().AddItem(prods, 1);
            }
            return RedirectToAction("List", "Products", new { page = returnUrl });
        }
        [HttpPost]
        public int PizzaCost(int cost)
        {
            return cost;
        }
        public RedirectToRouteResult AddPizzaToCart(CustomPizza customPizza, int cost, string returnUrl, Products products, PizzaConstructor pizzaConstructor)
        {
            products = repo.List()
                .FirstOrDefault(c => c.ProductID == 1035);
            customPizza.ProductID = products.ProductID;
            customPizza.PizzaName = "Пицца по уникальному рецепту";
            products.ProductName = customPizza.PizzaName;
            customPizza.ProductPrice = cost;
            products.ProductPrice = (int)customPizza.ProductPrice;
            if (customPizza != null)
            {
                GetCart().AddPizzaItem(customPizza, products, 1);
            }
            return RedirectToAction("PizzaConstructor", "Ingredients", new { page = returnUrl});
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int prodId, string returnUrl)
        {
            Products prods = repo.List()
                .FirstOrDefault(b => b.ProductID == prodId);
            if (prods != null)
            {
                //cart.RemoveLine(prods, 1);
                GetCart().RemoveLine(prods);
            }
            return RedirectToAction("CartView", new { returnUrl });
        }
        public RedirectToRouteResult RemovePizzaFromCart(/*Cart cart,*/ int pizzaId, string returnUrl, Products products)
        {
            CustomPizza customPizza = pizzaRepo.List()
                .FirstOrDefault(b => b.PizzaID == pizzaId);
            if (customPizza != null)
            {
                GetCart().RemovePizzaLine(customPizza, products);
            }
            return RedirectToAction("CartView", new { returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public void ChangeStatus(int order_id, string order_status)
        {
            foreach (var ord in context.Order)
            {
                if (ord.OrderID == order_id)
                    ord.OrderStatus = order_status;
            }
            db.SaveChanges();
            
        }
        public RedirectToRouteResult AddToOrder(Orders order, string user, Products products, Cart cart)
        {
            
                foreach (var line in cart.Lines)
                {
                    order.ProductID = line.Products.ProductID;
                    order.UserID = User.Identity.GetUserId();
                    order.OrderStatus = "В обработке";
                    order.OrderDateTime = DateTime.Now.ToString();
                //order.QuantityPrice = line.Quantity * line.Products.ProductPrice;
                order.Quantity = line.Quantity;
                    order.Product = line.Products;
                    context.Order.Add(order);
                    context.SaveChanges();
                }
            //}

            return RedirectToAction("Success", "Cart");
        }

        public RedirectToRouteResult AddPizzaToOrder(Orders order, string user, Products products, Cart cart, CustomPizza pizza, PizzaConstructor pizzaConstructor)
        {
            
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Ваша корзина пуста!");
                return RedirectToAction("CartEmpty", "Cart");
            }
            else
            {
                
                order.UserID = User.Identity.GetUserId();
                order.OrderStatus = "В обработке";
                context.Order.Add(order);
                context.SaveChanges();
                foreach (var line in cart.Lines)
                {
                    order.ProductID = line.CustomPizza.PizzaID;
                    order.UserID = User.Identity.GetUserId();
                    order.OrderStatus = "В обработке";
                    order.QuantityPrice = (double)pizzaConstructor.ComputeTotalValue();
                    /*products.ProductPrice = line.Products.ProductPrice;
                    Products.Products = line.Products;*/
                    context.CustomPizza.Add(pizza);
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Success", "Cart");
        }
    }
}