using Montadora.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Montadora.Models
{
    public class Cidade
    {
        public int CidadeId { get; set; }
        [Display(Name ="Cidade")]
        public string Nome { get; set; }
        public EnumEstado Estado { get; set; }

        public IList<Cidade> GetAll()
        {
            return new CidadeRepository().SelecionarTodas();
        }
        public IList<Cidade> BuscarCidade(EnumEstado estado)
        {
            return new CidadeRepository().BuscarCidade(estado);
        }
        public void Save()
        {            
            CidadeRepository cidadeRep = new CidadeRepository();
            if (CidadeId == 0)
            {
                cidadeRep.Salvar(this);
            }
            else
            {
                cidadeRep.Alterar(this);
            }
        }   
        public static Cidade FindById(int id)
        {
            return new CidadeRepository().BuscarPorID(id);
        }
        public void Deletar(Cidade c)
        {
            new CidadeRepository().Deletar(c);
        }
    }
}