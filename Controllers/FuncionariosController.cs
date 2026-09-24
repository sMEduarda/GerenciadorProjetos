using GerenciadorProjetos.Models;
using GerenciadorProjetos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorProjetos.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly IFuncionarioRepository _repository;

        public FuncionariosController(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        // GET: Funcionarios
        public IActionResult Index()
        {
            var funcionarios = _repository.GetAll();

            return View(funcionarios);
        }

        // GET: Funcionarios/Details/5
        public IActionResult Details(int id)
        {
            var funcionario = _repository.GetById(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(funcionario);

                return RedirectToAction(nameof(Index));
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public IActionResult Edit(int id)
        {
            var funcionario = _repository.GetById(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repository.Update(funcionario);

                return RedirectToAction(nameof(Index));
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public IActionResult Delete(int id)
        {
            var funcionario = _repository.GetById(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}