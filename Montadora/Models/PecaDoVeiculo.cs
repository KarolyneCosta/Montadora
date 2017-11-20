using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Montadora.Models
{
    public class PecaDoVeiculo
    {
        public int PecaDoVeiculoID { get; set; }
        public decimal Desconto { get; set; }
        public int Quantidade { get; set; }
        public Veiculo ObjVeiculo { get; set; }
        public PecaDoVeiculo(Veiculo veiculo)
        {
            ObjVeiculo = veiculo;
        }
    }
}