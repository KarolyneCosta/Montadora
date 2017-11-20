using Montadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Montadora.Controllers
{
    public class FornecedorController : Controller
    {
        [HttpGet]
        public ActionResult Listar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Listar(string nomeBusca)
        {
            IList<Fornecedor> fornecedores = new Fornecedor().FindByName(nomeBusca);
            return PartialView("_ListarFornecedor", fornecedores);
        }
        [HttpPost]
        public ActionResult ListarFornecedoresPorPeca(string nome)
        {
            IList<Fornecedor> fornecedores = new Fornecedor().FindByName(nome);
            return PartialView("_ListarFornecedorPorPeca", fornecedores);
        }
        [HttpGet]
        public ActionResult Novo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Novo(Fornecedor f)
        {
            if (ModelState.IsValid)
            {
                f.Save();
                return RedirectToAction("Listar");
            }
            else
            {
                return View(f);
            }
        }
        [HttpGet]
        public ActionResult Deletar(int id)
        {
            Fornecedor objFornecedor = new Fornecedor().FindById(id);
            return View(objFornecedor);
        }
        [HttpPost]
        public ActionResult Deletar(Fornecedor objFornecedor)
        {
            objFornecedor.Delete(objFornecedor);
            return RedirectToAction("Listar");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            Fornecedor objFornecedor = new Fornecedor().FindById(id);
            return View(objFornecedor);
        }
        [HttpPost]
        public ActionResult Editar(Fornecedor objFornecedor)
        {
            objFornecedor.Save();
            return RedirectToAction("Listar");
        }
    }
}