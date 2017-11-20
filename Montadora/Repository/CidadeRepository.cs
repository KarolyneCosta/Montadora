using Montadora.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Montadora.Repository
{
    public class CidadeRepository
    {
        public IList<Cidade> SelecionarTodas()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Cidades";

            SqlDataReader dr = Conexao.ExecutarSelect(comando);
 
            IList<Cidade> cidades = new List<Cidade>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cidade c = new Cidade();
                    c.CidadeId = (int)dr["cidadeId"];
                    c.Nome = (string)dr["nome"];
                    c.Estado = (EnumEstado)dr["estado"];
                    cidades.Add(c);
                }
            }
            else
            {
                cidades = null;
            }
            return cidades;
        }
        public IList<Cidade> BuscarCidade(EnumEstado estado)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * From Cidades Where estado = @estado";

            comando.Parameters.AddWithValue("@estado", estado);
            SqlDataReader dr = Conexao.ExecutarSelect(comando);

            IList<Cidade> cidades = new List<Cidade>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cidade objCidade = new Cidade();
                    objCidade.CidadeId = (int)dr["cidadeId"];
                    objCidade.Nome = (string)dr["nome"];
                    objCidade.Estado = (EnumEstado)dr["estado"];
                    cidades.Add(objCidade);
                }
            }
            else
            {
                cidades = null;
            }
            return cidades;
        }
        public Cidade BuscarPorID(int id)
        {
            Cidade objCidade = new Cidade();


            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Cidades Where cidadeId=@id";

            comando.Parameters.AddWithValue("@id", id);

            Conexao con = new Conexao();
            SqlDataReader dr = Conexao.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                dr.Read();
                objCidade.CidadeId = Convert.ToInt32(dr["cidadeId"]);
                objCidade.Nome = dr["nome"].ToString();
                objCidade.Estado = (EnumEstado)dr["estado"];
            }
            else
            {
                objCidade = null;
            }
            return objCidade;
        }
        public void Deletar(Cidade objCidade)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE Cidades WHERE cidadeId=@id ";

            comando.Parameters.AddWithValue("@id", objCidade.CidadeId);

            Conexao.ExecutarCrud(comando);
        }
        public void Salvar(Cidade objCidade)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO Cidades (nome, estado) VALUES (@nome, @estado);" +
                "SELECT CAST(scope_identity() as int);";

            comando.Parameters.AddWithValue("@nome", objCidade.Nome);
            comando.Parameters.AddWithValue("@estado", objCidade.Estado);

            Conexao.ExecutarCrud(comando);
        }
        public void Alterar(Cidade objCidade)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = " UPDATE Cidades SET nome=@nome, estado=@enumEstado WHERE cidadeId=@id";

            comando.Parameters.AddWithValue("@nome", objCidade.Nome);
            comando.Parameters.AddWithValue("@enumEstado", objCidade.Estado);
            comando.Parameters.AddWithValue("@id", objCidade.CidadeId);

            Conexao.ExecutarCrud(comando);
        }
    }
}