using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Montadora.Models
{
    public abstract class Pessoa
    {
        public int Id { get; set; }
        [Display(Name="CPF")]
        public string Cpf { get; set; }
        public string Nome { get; set; }
    }
}