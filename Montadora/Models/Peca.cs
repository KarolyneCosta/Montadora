using Montadora.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Montadora.Models
{
    public class Peca
    {
        public int PecaId { get; set; }
        [Display(Name = "Data de Fabricação")]
        public DateTime DataFabricacao { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Número de Série")]
        public string NumeroDeSerie { get; set; }
        public decimal Valor { get; set; }
        public Fornecedor ObjFornecedor { get; set; }

        public void Save()
        {
            PecaRepository objPeca = new PecaRepository();
            if (PecaId == 0)
            {
                objPeca.Salvar(this);
            }
            else
            {
                objPeca.Alterar(this);
            }
        }

        public IList<Peca> FindByName(string descricao)
        {
            return new PecaRepository().BuscaPorNome(descricao);
        }

        public Peca FindById(int id)
        {
            return new PecaRepository().BuscarPorID(id);
        }

        public void Deletar(Peca c)
        {
            new PecaRepository().Deletar(c);
        }

    }
}