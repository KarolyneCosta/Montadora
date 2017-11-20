using Montadora.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Montadora.Repository
{
    public class PecaRepository
    {
        public void Salvar(Peca p)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO Pecas (fornecedorID, dtFabricacao, numSerie, descricao, valor) VALUES (@fornecedorID, @dtFabricacao, @numSerie, @descricao, @valor);" +
                "SELECT CAST(scope_identity() as int);";

            comando.Parameters.AddWithValue("@fornecedorID", p.ObjFornecedor.Id);
            comando.Parameters.AddWithValue("@dtFabricacao", p.DataFabricacao);
            comando.Parameters.AddWithValue("@numSerie", p.NumeroDeSerie);
            comando.Parameters.AddWithValue("@descricao", p.Descricao);
            comando.Parameters.AddWithValue("@valor", p.Valor);
            Conexao.ExecutarCrud(comando);
        }

        public IList<Peca> BuscaPorNome(string descricao)
        {
            IList<Peca> listaDePecas = new List<Peca>();

            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT p.pecaID, p.fornecedorID, p.dtFabricacao, p.numSerie, p.descricao, p.valor FROM Pecas p LEFT JOIN Fornecedores f ON p.fornecedorID = f.fornecedorID Where p.descricao LIKE @descricao";

            comando.Parameters.AddWithValue("@descricao", "%" + descricao + "%");

            SqlDataReader dr = Conexao.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Peca objPeca = new Peca();
                    objPeca.PecaId = Convert.ToInt32(dr["pecaID"]);
                    objPeca.Descricao = (string)dr["descricao"];
                    objPeca.NumeroDeSerie = (string)dr["numSerie"];
                    objPeca.DataFabricacao = Convert.ToDateTime(dr["dtFabricacao"]);
                    objPeca.Valor = Convert.ToDecimal(dr["valor"]);
                    objPeca.ObjFornecedor = new Fornecedor().FindById(Convert.ToInt32(dr["fornecedorID"]));
                    listaDePecas.Add(objPeca);
                }
            }
            else
            {
                listaDePecas = null;
            }
            return listaDePecas;
        }

        public Peca BuscarPorID(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT p.pecaID, p.fornecedorID, p.dtFabricacao, p.numSerie, p.descricao, p.valor FROM Pecas p LEFT JOIN Fornecedores f ON p.fornecedorID = f.fornecedorID WHERE pecaID = @id";

            comando.Parameters.AddWithValue("@id", id);

            Conexao con = new Conexao();
            SqlDataReader dr = Conexao.ExecutarSelect(comando);

            Peca objPeca = new Peca();
            if (dr.HasRows)
            {
                dr.Read();
                objPeca.PecaId = Convert.ToInt32(dr["pecaID"]);
                objPeca.Descricao = (string)dr["descricao"];
                objPeca.NumeroDeSerie = (string)dr["numSerie"];
                objPeca.DataFabricacao = Convert.ToDateTime(dr["dtFabricacao"]);
                objPeca.Valor = Convert.ToDecimal(dr["valor"]);
                objPeca.ObjFornecedor = new Fornecedor().FindById(Convert.ToInt32(dr["fornecedorID"]));
            }
            else
            {
                objPeca = null;
            }
            return objPeca;
        }

        public void Deletar(Peca objPeca)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE Pecas WHERE pecaID=@id ";

            comando.Parameters.AddWithValue("@id", objPeca.PecaId);
            Conexao.ExecutarCrud(comando);
        }

        public void Alterar(Peca p)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = " UPDATE Pecas SET fornecedorID = @fornecedorID, dtFabricacao =  @dtFabricacao, numSerie = @numSerie, descricao = @descricao, valor = @valor WHERE pecaID=@id";

            comando.Parameters.AddWithValue("@fornecedorID", p.ObjFornecedor.Id);
            comando.Parameters.AddWithValue("@dtFabricacao", p.DataFabricacao);
            comando.Parameters.AddWithValue("@numSerie", p.NumeroDeSerie);
            comando.Parameters.AddWithValue("@descricao", p.Descricao);
            comando.Parameters.AddWithValue("@valor", p.Valor);
            comando.Parameters.AddWithValue("@id", p.PecaId);
            Conexao.ExecutarCrud(comando);
        }


    }
}