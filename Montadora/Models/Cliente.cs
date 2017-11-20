using Montadora.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Montadora.Models
{
    public class Cliente : Pessoa
    {
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        [Display(Name = "Número")]
        public string Numero { get; set; }
        [Display(Name ="Orgão Expedidor")]
        public string OrgaoExpedidor { get; set; }
        [Display(Name = "RG")]
        public string Rg { get; set; }
        [Display(Name ="Cidade")]
        public Cidade ObjCidade { get; set; }
        public EnumSexo Sexo { get; set; }

        public IList<Cliente> GetAll()
        {
            return new ClienteRepository().SelecionarTodas();
        }
        public void Save()
        {
            ClienteRepository clienteRep = new ClienteRepository();
            if (Id == 0)
            {
                clienteRep.Salvar(this);
            }
            else
            {
                clienteRep.Alterar(this);
            }
        }
        public Cliente FindById(int id)
        {
            return new ClienteRepository().BuscarPorID(id);
        }
        public void Deletar(Cliente c)
        {
            ClienteRepository objClienteRep = new ClienteRepository();
            objClienteRep.Deletar(c);
        }

        public IList<Cliente> FindByName(string nome)
        {
            return new ClienteRepository().BuscaPorNome(nome);
        }
    }
}