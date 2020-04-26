using System.Web.Mvc;

namespace HtmlToPdf.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}