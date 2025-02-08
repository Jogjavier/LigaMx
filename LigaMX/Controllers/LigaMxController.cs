using LigaMX.Models;
using LigaMX.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LigaMX.Controllers
{
    public class LigaMxController : Controller
    {
        private readonly PartidoRepository _repository;

        public LigaMxController()
        {
            _repository = new PartidoRepository();
        }

        public IActionResult Index()
        {
            var partidos = _repository.GetAllPartidos();
            return View(partidos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
       
        public IActionResult Create(LigaMx partido)
        {
            if (ModelState.IsValid)
            {
                _repository.AddPartido(partido);
                return RedirectToAction(nameof(Index));
            }
            return View(partido);
        }

        [HttpDelete]
        public IActionResult Delete(string partido)
        {
            bool success = _repository.DeletePartido(partido);
            return Json(new { success = success, message = success ? "Partido eliminado correctamente" : "Partido no encontrado" });
        }
    }
    // GET: LigaMxController


    
}
