using Montadora.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Montadora.Models
{
    public class Montador : Pessoa
    {
        [Display(Name="Salário")]
        public decimal Salario { get; set; }

        public IList<Montador> GetAll()
        {
            MontadorRepository objMontadorRep = new MontadorRepository();
            return objMontadorRep.SelecionarTodas();
        }
        public void Save()
        {
            MontadorRepository MontadorRep = new MontadorRepository();
            if (Id == 0)
            {
                MontadorRep.Salvar(this);
            }
            else
            {
                MontadorRep.Alterar(this);
            }
        }
        public IList<Montador> GetByName(string nomeBusca)
        {
            return new MontadorRepository().BuscarPorNome(nomeBusca);
        }
        public Montador FindById(int id)
        {
            MontadorRepository objMontadorRep = new MontadorRepository();
            Montador objMontador = new Montador();
            return objMontador = objMontadorRep.BuscarPorID(id);            
        }
        public void Delete(Montador m)
        {
            MontadorRepository objMontadorRep = new MontadorRepository();
            objMontadorRep.Deletar(m);
        }
        public IList<Montador> FindByName(string nomeBusca)
        {
            MontadorRepository objMontadorRep = new MontadorRepository();
            IList<Montador> listaDeMontadores = new List<Montador>();
            return listaDeMontadores = objMontadorRep.BuscarPorNome(nomeBusca);
        }
    }
}