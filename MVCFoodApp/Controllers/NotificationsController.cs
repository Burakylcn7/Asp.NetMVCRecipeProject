using MVCFoodApp.Models;
using System.Linq;
using System.Web.Mvc;

namespace MVCFoodApp.Controllers
{
    public class NotificationsController : Controller
    {
        FoodAppEntities _foodContext = new FoodAppEntities();
        // GET: Notifications
        public ActionResult Index()
        {
            return View(_foodContext.Notifications.ToList());
        }
        public ActionResult NotificationAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NotificationAdd(Notification p)
        {
            _foodContext.Notifications.Add(p);
            _foodContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult NotificationDelete(int id)
        {
            var Notificationdeleteinfo = _foodContext.Notifications.Where(x => x.NotificationID == id).FirstOrDefault();
            _foodContext.Notifications.Remove(Notificationdeleteinfo);
            _foodContext.SaveChanges();
            return RedirectToAction("Index", "Notifications");
        }

    }
}