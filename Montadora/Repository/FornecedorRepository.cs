using Montadora.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Montadora.Repository
{
    public class FornecedorRepository
    {        
        public Fornecedor BuscarPorID(int id)
        {
            Fornecedor objFornecedor = new Fornecedor();


            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Fornecedores Where fornecedorID=@id";

            comando.Parameters.AddWithValue("@id", id);

            SqlDataReader dr = Conexao.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                dr.Read();
                objFornecedor.Id = Convert.ToInt32(dr["fornecedorID"]);
                objFornecedor.Nome = (string)dr["nome"];
                objFornecedor.Cpf = (string)dr["cpf"];
                objFornecedor.Endereco = (string)dr["endereco"];
            }
            else
            {
                objFornecedor = null;
            }
            return objFornecedor;
        }

        public IList<Fornecedor> BuscarTodos()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Fornecedores";

            SqlDataReader dr = Conexao.ExecutarSelect(comando);
            IList<Fornecedor> listaForn = new List<Fornecedor>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Fornecedor fornecedores = new Fornecedor();
                    fornecedores.Id = Convert.ToInt32(dr["fornecedorId"]);
                    fornecedores.Nome = (string)dr["nome"];
                    fornecedores.Cpf = (string)dr["cpf"];
                    fornecedores.Endereco = (string)dr["endereco"];
                    listaForn.Add(fornecedores);
                }
                return listaForn;
            }
            else
            {
                return listaForn = null;
            }
        }

        public void Deletar(Fornecedor objFornecedor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE Fornecedores WHERE fornecedorID=@id";

            comando.Parameters.AddWithValue("@id", objFornecedor.Id);

            Conexao.ExecutarCrud(comando);
        }
        public void Salvar(Fornecedor objFornecedor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO Fornecedores (nome, cpf, endereco) VALUES (@nome, @cpf, @endereco);" +
                "SELECT CAST(scope_identity() as int);";

            comando.Parameters.AddWithValue("@nome", objFornecedor.Nome);
            comando.Parameters.AddWithValue("@cpf", objFornecedor.Cpf);
            comando.Parameters.AddWithValue("@endereco", objFornecedor.Endereco);

            Conexao.ExecutarCrud(comando);
        }
        public void Alterar(Fornecedor objFornecedor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = " UPDATE Fornecedores SET nome=@nome, cpf=@cpf, endereco=@endereco WHERE fornecedorID=@id";

            comando.Parameters.AddWithValue("@nome", objFornecedor.Nome);
            comando.Parameters.AddWithValue("@cpf", objFornecedor.Cpf);
            comando.Parameters.AddWithValue("@endereco", objFornecedor.Endereco);
            comando.Parameters.AddWithValue("@id", objFornecedor.Id);
            Conexao.ExecutarCrud(comando);
        }
        public IList<Fornecedor> BuscarPorNome(string nomeBusca)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Fornecedores Where nome LIKE @nome ";

            comando.Parameters.AddWithValue("@nome", "%" + nomeBusca + "%");

            Conexao con = new Conexao();
            SqlDataReader dr = Conexao.ExecutarSelect(comando);


            IList<Fornecedor> listaDeFornecedores = new List<Fornecedor>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Fornecedor objFornecedor = new Fornecedor();
                    
                    objFornecedor.Id = Convert.ToInt32(dr["fornecedorID"]);
                    objFornecedor.Nome = (string)dr["nome"];
                    objFornecedor.Cpf = (string)dr["cpf"];
                    objFornecedor.Endereco = (string)dr["endereco"];

                    listaDeFornecedores.Add(objFornecedor);
                }
            }
            else
            {
                listaDeFornecedores = null;
            }
            return listaDeFornecedores;
        }
    }
}