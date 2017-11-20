using Montadora.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Montadora.Controllers
{
    public class CidadeController : Controller
    {
        [HttpGet]
        public ActionResult Listar()
        {
            return View();
        }
        public ActionResult Listar(EnumEstado estado)
        {
            IList<Cidade> cidades = new Cidade().BuscarCidade(estado);
            return PartialView("_ListarCidade", cidades);
        }
        [HttpGet]
        public ActionResult Novo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Novo(Cidade objCidade)
        {
            if (ModelState.IsValid)
            {
                objCidade.Save();
                return RedirectToAction("Listar");
            }            
                return View(objCidade);            
        }
        [HttpGet]
        public ActionResult Deletar(int id)
        {
            Cidade objCidade = Cidade.FindById(id);
            return View(objCidade);
        }
        [HttpPost]
        public ActionResult Deletar(Cidade objCidade)
        {
            objCidade.Deletar(objCidade);
            return RedirectToAction("Listar");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            Cidade objCidade = Cidade.FindById(id);
            return View(objCidade);
        }
        [HttpPost]
        public ActionResult Editar(Cidade objCidade)
        {
            objCidade.Save();
            return RedirectToAction("Listar");
        }
        [HttpPost]
        public ActionResult ListarCidadePorEstado(EnumEstado estado)
        {
            IList<Cidade> cidades = new Cidade().BuscarCidade(estado);
            return PartialView("_ListarCidadePorEstado", cidades);
        }
    }
}