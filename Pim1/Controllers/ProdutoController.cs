using Microsoft.AspNetCore.Mvc;
using Pim1.Models;
using Pim1.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pim1.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtorepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtorepositorio = produtoRepositorio;
        }
        public IActionResult Index()
        {
            List<ProdutoModel> produtos = _produtorepositorio.BuscarTodos();

            return View(produtos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int Id)
        {
            ProdutoModel produto = _produtorepositorio.ListarPorId(Id);
            return View(produto);
        }

        public IActionResult ApagarConfirmacao(int Id)
        {
            ProdutoModel produto = _produtorepositorio.ListarPorId(Id);
            return View(produto);
        }

        public IActionResult Apagar(int Id)
        {
            try
            {
                bool apagado = _produtorepositorio.Apagar(Id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Produto deletado com sucesso";
                }
                else
                {
                    TempData["MensagemSucesso"] = "Não foi possível deletar o produto :( ";
                }

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível apagar o produto! :( - detalhes:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ProdutoModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtorepositorio.Adicionar(produto);
                    TempData["MensagemSucesso"] = "Produto cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(produto);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar produto! :( - detalhes:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ProdutoModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtorepositorio.Atualizar(produto);
                    TempData["MensagemSucesso"] = "Produto alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", produto);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Erro ao alterar produto! :( - detalhes:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
