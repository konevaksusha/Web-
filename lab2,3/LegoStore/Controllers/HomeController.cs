using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LegoStore.Models;

namespace LegoStore.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        BoxContext db = new BoxContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Box
            IEnumerable<Box> Boxes = db.Boxes;
            // передаем все объекты в динамическое свойство Bo в ViewBag
            ViewBag.Boxes = Boxes;
            // возвращаем представление
            return View();
        }
        public ActionResult kit(int Id)
        {
            Box myBox = db.Boxes.Find(Id);
            ViewBag.ThisBox = myBox;
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BoxId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            // добавляем информацию о покупке в базу данных
            db.Purchases.Add(purchase);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо," + purchase.Person + ", за покупку!";
        }

        public ActionResult Basket(int Value = 0)
        {
            // получаем из бд все объекты Box
            IEnumerable<Basket> BasBox = db.Baskets;
            List<Box> Boxes = new List<Box>();
            foreach (var Bas in BasBox)
            {
                foreach(var Box in db.Boxes)
                {
                    if (Bas.BoxId == Box.Id)
                    {
                        Boxes.Add(Box);
                        Value += Box.Price;
                        
                    }
                }
            }
            // передаем все объекты в динамическое свойство Bo в ViewBag
            ViewBag.Value = Value;
            ViewBag.ThisBasket = Boxes;
            // возвращаем представление
            return View();
        }
        public ActionResult AddBasket(int Id)
        {
            Basket basket = new Basket();
            basket.BoxId = Id;
            db.Baskets.Add(basket);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

       
        public ActionResult BoxSearch(string name)
        {
            var allboxes = db.Boxes.Where(a => a.Series.Contains(name)).ToList();
            if (allboxes.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(allboxes);
        }


    }


}