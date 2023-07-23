using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace PracticaFinalFranciscoPerez.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome(string name , int  numTimes=1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            return View();
        }
    }
}
