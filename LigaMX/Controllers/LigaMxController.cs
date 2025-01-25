using LigaMX.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LigaMX.Controllers
{
    public class LigaMxController : Controller
    {
        private static List<LigaMx> partidos = new List<LigaMx>
            {
                new LigaMx { Partido = "America vs Chivas", Equipo1 = "América", Equipo2 = "Chivas", Resultado = "2-1", Estadio = "Estadio Azteca"},
                new LigaMx { Partido = "Tigres vs Pumas", Equipo1 = "Tigres", Equipo2 = "Pumas", Resultado = "1-1",Estadio = "Estadio Universitario" },
                new LigaMx { Partido = "Monterrey vs Santos", Equipo1 = "Monterrey", Equipo2 = "Santos", Resultado = "3-2",Estadio = "Estadio BBVA" }
            };
        public IActionResult Index()
        {
            

            return View(partidos);
        }
        public IActionResult Create()
        {
            LigaMx Model = new LigaMx();
            return View(Model);
        }
        [HttpPost]
       
        public IActionResult Create(LigaMx partido)
        {
            if (ModelState.IsValid)
            {
                partidos.Add(partido);
                return RedirectToAction(nameof(Index));
            }
                return View(partido);
        }
    }
    // GET: LigaMxController


    
}
