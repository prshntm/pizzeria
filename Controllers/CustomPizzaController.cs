using WebPizza.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPizza.Abstract;

namespace WebPizza.Controllers
{
    public class CustomPizzaController : Controller
    {
        IngredientsRepository repository = new IngredientsRepository();
        // GET: CustomPizza
        public ActionResult Index()
        {
            return View();
        }
        public PizzaConstructor GetPizzaConstructor()
        {
            PizzaConstructor pizzaConstructor = (PizzaConstructor)Session["PizzaConstructor"];
            if (pizzaConstructor == null)
            {
                pizzaConstructor = new PizzaConstructor();
                Session["PizzaConstructor"] = pizzaConstructor;
            }
            return pizzaConstructor;
        }
        private static byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }
        private static Bitmap MurgeImg(Bitmap baseImage, Bitmap overlay)
        {
            var finalImage = new Bitmap(overlay.Width, overlay.Height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(finalImage);
            graphics.CompositingMode = CompositingMode.SourceOver;
            graphics.DrawImage(baseImage, 0, 0);
            graphics.DrawImage(overlay, 0, 0);

            return finalImage;
        }
        public ActionResult Images()
        {
            string path = @"C:\Users\Tamara\source\repos\WebPizza\Content\";
            var bitmap = MurgeImg((Bitmap)Image.FromFile(path + "osnova.png"), (Bitmap)Image.FromFile(path + "osnova.png"));
            PizzaConstructor ne = GetPizzaConstructor();

            if (ne.Lines.Count() >= 1)
            {
                foreach (var item in ne.Lines)
                {

                    if (item.Ingredients.IngredientName == "Pepperoni")
                    {
                        bitmap = MurgeImg(bitmap, (Bitmap)Image.FromFile(path + "pepperoni.png"));
                    }
                    else if (item.Ingredients.IngredientName == "Ham")
                    {
                        bitmap = MurgeImg(bitmap, (Bitmap)Image.FromFile(path + "ham.png"));
                    }
                    else if (item.Ingredients.IngredientName == "Chicken")
                    {
                        bitmap = MurgeImg(bitmap, (Bitmap)Image.FromFile(path + "chicken.png"));
                    }
                    else if (item.Ingredients.IngredientName == "Shrimps")
                    {
                        bitmap = MurgeImg(bitmap, (Bitmap)Image.FromFile(path + "shrimps.png"));
                    }
                    else if (item.Ingredients.IngredientName == "Mussels")
                    {
                        bitmap = MurgeImg(bitmap, (Bitmap)Image.FromFile(path + "mussels.png"));
                    }
                    else if (item.Ingredients.IngredientName == "Fish")
                    {
                        bitmap = MurgeImg(bitmap, (Bitmap)Image.FromFile(path + "fish.png"));
                    }
                    else if (item.Ingredients.IngredientName == "Mozzarella")
                    {
                        bitmap = MurgeImg(bitmap, (Bitmap)Image.FromFile(path + "mozzarella.png"));
                    }
                    else if (item.Ingredients.IngredientName == "Parmigiano")
                    {
                        bitmap = MurgeImg(bitmap, (Bitmap)Image.FromFile(path + "parmezan.png"));
                    }
                    else if (item.Ingredients.IngredientName == "Sulguni")
                    {
                        bitmap = MurgeImg(bitmap, (Bitmap)Image.FromFile(path + "suluguni.png"));
                    }
                    else if (item.Ingredients.IngredientName == "Pineapple")
                    {
                        bitmap = MurgeImg(bitmap, (Bitmap)Image.FromFile(path + "pineapple.png"));
                    }
                    else if (item.Ingredients.IngredientName == "Avocado")
                    {
                        bitmap = MurgeImg(bitmap, (Bitmap)Image.FromFile(path + "avocado.png"));
                    }
                    else if (item.Ingredients.IngredientName == "Banana")
                    {
                        bitmap = MurgeImg(bitmap, (Bitmap)Image.FromFile(path + "banana.png"));
                    }
                    else if (item.Ingredients.IngredientName == "Chili")
                    {
                        bitmap = MurgeImg(bitmap, (Bitmap)Image.FromFile(path + "chili.png"));
                    }
                    else if (item.Ingredients.IngredientName == "Jalapeno")
                    {
                        bitmap = MurgeImg(bitmap, (Bitmap)Image.FromFile(path + "jalapeno.png"));
                    }
                    else if (item.Ingredients.IngredientName == "Bell pepper")
                    {
                        bitmap = MurgeImg(bitmap, (Bitmap)Image.FromFile(path + "pepper.png"));
                    }
                    else if (item.Ingredients.IngredientName == "Eggplant")
                    {
                        bitmap = MurgeImg(bitmap, (Bitmap)Image.FromFile(path + "eggplant.png"));
                    }
                    else if (item.Ingredients.IngredientName == "Tomato")
                    {
                        bitmap = MurgeImg(bitmap, (Bitmap)Image.FromFile(path + "tomato.png"));
                    }
                    else if (item.Ingredients.IngredientName == "Artichoke")
                    {
                        bitmap = MurgeImg(bitmap, (Bitmap)Image.FromFile(path + "artichokes.png"));
                    }
                    else if (item.Ingredients.IngredientName == "Mushroom")
                    {
                        bitmap = MurgeImg(bitmap, (Bitmap)Image.FromFile(path + "mushrooms.png"));
                    }
                    else if (item.Ingredients.IngredientName == "Tomato Sauce")
                    {
                        bitmap = MurgeImg(bitmap, (Bitmap)Image.FromFile(path + "sauce.png"));
                    }
                    
                }
            }
            var bitmapBytes = BitmapToBytes(bitmap);
            return File(bitmapBytes, "image/jpeg");
        }
        
        public ViewResult PizzaConstructorView(string returnUrl)
        {
            return View(new PizzaConstructorIndexViewModel
            {
                PizzaConstructor = GetPizzaConstructor(),
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCart(int ingId, string returnUrl)
        {
            Ingredients ingredient = repository.List()
                .FirstOrDefault(b => b.IngredientID == ingId);

            if (ingredient != null)
            {
                GetPizzaConstructor().AddItem(ingredient, 1);
            }
            ViewBag.Img = "ADD";
            return RedirectToAction("PizzaConstructor", "Ingredients");
        }

        public RedirectToRouteResult RemoveFromCart(int ingId, string returnUrl)
        {
            Ingredients ingredient = repository.List()
                .FirstOrDefault(b => b.IngredientID == ingId);

            if (ingredient != null)
            {
                GetPizzaConstructor().RemoveLine(ingredient);
            }

            return RedirectToAction("PizzaConstructor", "Ingredients");
        }

        public PartialViewResult Summary(PizzaConstructor make)
        {
            return PartialView(make);
        }
    }
}