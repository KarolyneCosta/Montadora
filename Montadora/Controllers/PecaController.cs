using Montadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Montadora.Controllers
{
    public class PecaController : Controller
    {
        [HttpGet]
        public ActionResult Listar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Listar(string descricao)
        {
            IList<Peca> pecas = new Peca().FindByName(descricao);
            return PartialView("_ListarPecas", pecas);
        }

        [HttpGet]
        public ActionResult Novo()
        {
            ViewBag.Fornecedor = new SelectList(new Fornecedor().GetAll(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Peca p)
        {
            p.Save();
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            Peca objPeca = new Peca().FindById(id);
            ViewBag.Fornecedor = new SelectList(new Fornecedor().GetAll(), "Id", "Nome");
            return View(objPeca);
        }

        [HttpPost]
        public ActionResult Editar(Peca p)
        {
            p.Save();
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Deletar(int id)
        {
            Peca objPeca = new Peca().FindById(id);
            return View(objPeca);
        }

        [HttpPost]
        public ActionResult Deletar(Peca p)
        {
            p.Deletar(p);
            return RedirectToAction("Listar");
        }
    }
}
