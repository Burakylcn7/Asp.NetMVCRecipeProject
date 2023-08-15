using MVCFoodApp.Models;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;

namespace MVCFoodApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        FoodAppEntities _foodContext = new FoodAppEntities();
        public ActionResult Index()
        {
            return View(_foodContext.Foods.ToList());
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult FoodList()
        {
            return View(_foodContext.Foods.ToList());
        }

        public ActionResult FoodAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FoodAdd(Food p)
        {
            _foodContext.Foods.Add(p);
            _foodContext.SaveChanges();
            return RedirectToAction("FoodList", "Home");
        }

        public ActionResult FoodUpdate(int id)
        {
            var foodupdateinfo = _foodContext.Foods.Where(x => x.FoodID == id).FirstOrDefault();
            return View(foodupdateinfo);
        }

        [HttpPost]
        public ActionResult FoodUpdate(int id, Food p)
        {
            _foodContext.Foods.AddOrUpdate(p);
            _foodContext.SaveChanges();
            return RedirectToAction("FoodList", "Home");
        }

        public ActionResult FoodDelete(int id)
        {
            var fooddeleteinfo = _foodContext.Foods.Where(x => x.FoodID == id).FirstOrDefault();
            return View(fooddeleteinfo);
        }

        [HttpPost]
        public ActionResult FoodDelete(int id, Food p)
        {
            var fooddeleteinfo = _foodContext.Foods.Where(x => x.FoodID == id).FirstOrDefault();
            _foodContext.Foods.Remove(fooddeleteinfo);
            _foodContext.SaveChanges();
            return RedirectToAction("FoodList", "Home");
        }
    }
}