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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Acción POST para procesar la creación del nuevo partido
        [HttpPost]
        public IActionResult Create(LigaMx nuevoPartido)
        {
            if (ModelState.IsValid)
            {
                partidos.Add(nuevoPartido);
                return RedirectToAction(nameof(Index));
            }

            return View(nuevoPartido);
        }
        [HttpGet]
        public IActionResult Edit(string partido)
        {
            var partidoAEditar = partidos.FirstOrDefault(p => p.Partido == partido);
            if (partidoAEditar == null)
            {
                return NotFound(); 
            }

            return View(partidoAEditar);
        }
        [HttpPost]
        public IActionResult Edit(string partido, LigaMx partidoEditado)
        {
            if (ModelState.IsValid)
            {
                
                var partidoOriginal = partidos.FirstOrDefault(p => p.Partido == partido);
                if (partidoOriginal == null)
                {
                    return NotFound();
                }

                
                partidoOriginal.Partido = partidoEditado.Partido;
                partidoOriginal.Equipo1 = partidoEditado.Equipo1;
                partidoOriginal.Equipo2 = partidoEditado.Equipo2;
                partidoOriginal.Resultado = partidoEditado.Resultado;
                partidoOriginal.Estadio = partidoEditado.Estadio;

                return RedirectToAction(nameof(Index)); 
            }

            return View(partidoEditado); 
        }
    }
    // GET: LigaMxController


    
}
