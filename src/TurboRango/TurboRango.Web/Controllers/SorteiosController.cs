using System.Web.Mvc;
using TurboRango.Web.Models;
using System.Linq;

namespace TurboRango.Web
{
    public class SorteiosController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sorteios
        public ActionResult Index()
        {
            ViewBag.QtdRestaurantes = db.Restaurantes.Count();
            return View();
        }
    }
}
