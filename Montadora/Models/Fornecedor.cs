using Montadora.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Collections;

namespace Montadora.Models
{
    public class Fornecedor : Pessoa
    {
        [Display(Name="Endereço")]
        public string Endereco { get; set; }

        public void Save()
        {
            FornecedorRepository fornecedorRep = new FornecedorRepository();
            if (Id == 0)
            {
                fornecedorRep.Salvar(this);
            }
            else
            {
                fornecedorRep.Alterar(this);
            }
        }
        public Fornecedor FindById(int id)
        {            
            return new FornecedorRepository().BuscarPorID(id);         
        }

        public IList<Fornecedor> GetAll ()
        {
            return new FornecedorRepository().BuscarTodos();
        }

        public void Delete(Fornecedor f)
        {            
            new FornecedorRepository().Deletar(f);
        }
        public IList<Fornecedor> FindByName(string nomeBusca)
        {            
            return new FornecedorRepository().BuscarPorNome(nomeBusca);
        }
    }
}