using GerenciadorProjetos.Models;
using GerenciadorProjetos.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GerenciadorProjetos.Controllers
{
    public class TarefasController : Controller
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IProjetoRepository _projetoRepository;

        public TarefasController(
            ITarefaRepository tarefaRepository,
            IProjetoRepository projetoRepository)
        {
            _tarefaRepository = tarefaRepository;
            _projetoRepository = projetoRepository;
        }

        // GET: Tarefas
        public IActionResult Index()
        {
            var tarefas = _tarefaRepository.GetAllWithProjetos();

            return View(tarefas);
        }

        // GET: Tarefas/Details/5
        public IActionResult Details(int id)
        {
            var tarefa = _tarefaRepository.GetByIdWithProjeto(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        // GET: Tarefas/Create
        public IActionResult Create()
        {
            CarregarProjetos();

            return View();
        }

        // POST: Tarefas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _tarefaRepository.Add(tarefa);

                return RedirectToAction(nameof(Index));
            }

            CarregarProjetos(tarefa.ProjetoId);

            return View(tarefa);
        }

        // GET: Tarefas/Edit/5
        public IActionResult Edit(int id)
        {
            var tarefa = _tarefaRepository.GetById(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            CarregarProjetos(tarefa.ProjetoId);

            return View(tarefa);
        }

        // POST: Tarefas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Tarefa tarefa)
        {
            if (id != tarefa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _tarefaRepository.Update(tarefa);

                return RedirectToAction(nameof(Index));
            }

            CarregarProjetos(tarefa.ProjetoId);

            return View(tarefa);
        }

        // GET: Tarefas/Delete/5
        public IActionResult Delete(int id)
        {
            var tarefa = _tarefaRepository.GetByIdWithProjeto(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _tarefaRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private void CarregarProjetos(int? projetoSelecionado = null)
        {
            var projetos = _projetoRepository.GetAll();

            ViewBag.Projetos = new SelectList(
                projetos,
                "Id",
                "Nome",
                projetoSelecionado
            );
        }
    }
}