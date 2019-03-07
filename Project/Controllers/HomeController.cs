using Domain.Interface;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private IDbContext _dbContext;

        
        public HomeController()
        {
            _dbContext = DatabaseConnection.GetConnection();
        }
        public ActionResult Index()
        {



            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}