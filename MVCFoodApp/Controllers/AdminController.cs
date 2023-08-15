using MVCFoodApp.Models;
using System.Linq;
using System.Web.Mvc;

namespace MVCFoodApp.Controllers
{
    public class AdminController : Controller
    {
        FoodAppEntities _foodContext = new FoodAppEntities();
        // GET: Admin

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var adminuserinfo = _foodContext.Admins.FirstOrDefault(x => x.AdminMail == p.AdminMail && x.AdminPassword == p.AdminPassword);

            //var adminuser = from x in _foodContext.Admins where p.AdminMail == x.AdminMail && p.AdminPassword == x.AdminPassword select x;
            //if (adminuser.Count() > 0)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            //return RedirectToAction("Index", "Admin");

            if (adminuserinfo != null)
            {
                return RedirectToAction("FoodList", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
    }
}