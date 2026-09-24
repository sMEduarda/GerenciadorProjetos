using GerenciadorProjetos.Models;
using GerenciadorProjetos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorProjetos.Controllers
{
    public class ProjetosController : Controller
    {
        private readonly IProjetoRepository _repository;

        public ProjetosController(IProjetoRepository repository)
        {
            _repository = repository;
        }

        // GET: Projetos
        public IActionResult Index()
        {
            var projetos = _repository.GetAll();

            return View(projetos);
        }

        // GET: Projetos/Details/5
        public IActionResult Details(int id)
        {
            var projeto = _repository.GetById(id);

            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // GET: Projetos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projetos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(projeto);

                return RedirectToAction(nameof(Index));
            }

            return View(projeto);
        }

        // GET: Projetos/Edit/5
        public IActionResult Edit(int id)
        {
            var projeto = _repository.GetById(id);

            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // POST: Projetos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Projeto projeto)
        {
            if (id != projeto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repository.Update(projeto);

                return RedirectToAction(nameof(Index));
            }

            return View(projeto);
        }

        // GET: Projetos/Delete/5
        public IActionResult Delete(int id)
        {
            var projeto = _repository.GetById(id);

            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // POST: Projetos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}