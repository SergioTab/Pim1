using Microsoft.AspNetCore.Mvc;
using Pim1.Models;
using Pim1.Repositorio;

namespace Pim1.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRepositorio _usuariorepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuariorepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuariorepositorio.BuscarTodos();

            return View(usuarios);
        }
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuariorepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar usuário! :( - detalhes:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
