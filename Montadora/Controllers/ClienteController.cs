using Montadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Montadora.Controllers
{
    public class ClienteController : Controller
    {       
        [HttpGet]
        public ActionResult Listar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Listar(string nome)
        {
            IList<Cliente> clientes = new Cliente().FindByName(nome);
            return PartialView("_ListarClientes", clientes);
        }
        [HttpGet]
        public ActionResult Novo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Novo(Cliente objCliente)
        {
                objCliente.Save();
                return RedirectToAction("Listar");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            Cliente objCliente = new Cliente().FindById(id);
            return View(objCliente);
        }
        [HttpPost]
        public ActionResult Editar(Cliente objCliente)
        {
            objCliente.Save();
            return RedirectToAction("Listar");
        }
        public ActionResult Deletar(int id)
        {
            Cliente objCliente = new Cliente().FindById(id);
            return View(objCliente);
        }
        [HttpPost]
        public ActionResult Deletar(Cliente objCliente)
        {
            objCliente.Deletar(objCliente);
            return RedirectToAction("Listar");
        }
    }
}