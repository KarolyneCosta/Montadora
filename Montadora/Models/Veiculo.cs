using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Montadora.Models
{
    public class Veiculo
    {
        public int VeiculoId { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public Usuario ObjUsuario { get; set; }
        public Cliente ObjCliente { get; set; }
        public Montador ObjMontador { get; set; }
        public IList<PecaDoVeiculo> ObjPecaDoVeiculo { get; set; }
    }
}