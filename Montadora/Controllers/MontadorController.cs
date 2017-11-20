using Montadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Montadora.Controllers
{
    public class MontadorController : Controller
    {
        [HttpGet]
        public ActionResult Listar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Listar(string nomeBusca)
        {
            IList<Montador> listaDeMontadores = new Montador().GetByName(nomeBusca);
            return PartialView("_ListarMontador", listaDeMontadores);
        }
        [HttpGet]
        public ActionResult Novo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Novo(Montador m)
        {
            if (ModelState.IsValid)
            {
                m.Save();
                return RedirectToAction("Listar");
            }
            else
            {
                return View(m);
            }
        }
        [HttpGet]
        public ActionResult Deletar(int id)
        {
            Montador objMontador = new Montador().FindById(id);
            return View(objMontador);
        }
        [HttpPost]
        public ActionResult Deletar(Montador objMontador)
        {
            objMontador.Delete(objMontador);
            return RedirectToAction("Listar");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            Montador objMontador = new Montador().FindById(id);
            return View(objMontador);
        }
        [HttpPost]
        public ActionResult Editar(Montador objMontador)
        {
            objMontador.Save();
            return RedirectToAction("Listar");
        }
    }
}