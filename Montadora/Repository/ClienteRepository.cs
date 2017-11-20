using Montadora.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Montadora.Repository
{
    public class ClienteRepository
    {
        public IList<Cliente> SelecionarTodas()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT c.clienteID, c.nome 'nome', c.cpf, c.endereco, c.dtNascimento, c.sexo, c.rg, c.orgaoExpedidor, c.numero, ci.cidadeId, ci.nome 'nome'" +
                "FROM Clientes c LEFT JOIN Cidades ci on c.clienteID = ci.cidadeId";


            SqlDataReader dr = Conexao.ExecutarSelect(comando);

            IList<Cliente> clientes = new List<Cliente>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cliente objCliente = new Cliente();

                    objCliente.Id = Convert.ToInt32(dr["clienteID"]);
                    objCliente.Nome = (string)dr["nome"];
                    objCliente.Cpf = (string)dr["cpf"];
                    objCliente.DataNascimento = Convert.ToDateTime(dr["dtNascimento"]);
                    objCliente.Endereco = (string)dr["endereco"];
                    objCliente.Numero = (string)dr["numero"];
                    objCliente.OrgaoExpedidor = (string)dr["orgaoExpedidor"];
                    objCliente.Rg = (string)dr["rg"];
                    objCliente.Sexo = (EnumSexo)dr["sexo"];
                    clientes.Add(objCliente);
                }
            }
            else
            {
                clientes = null;
            }
            return clientes;
        }
        public Cliente BuscarPorID(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT c.cidadeId, c.nome, c.clienteID, c.cpf, c.dtNascimento, c.endereco, c.numero, c.orgaoExpedidor, c.rg, c.sexo, ci.nome FROM Clientes c LEFT JOIN Cidades ci ON c.cidadeId = ci.cidadeId WHERE clienteID = @id";

            comando.Parameters.AddWithValue("@id", id);

            Conexao con = new Conexao();
            SqlDataReader dr = Conexao.ExecutarSelect(comando);

            Cliente objCliente = new Cliente();
            Cidade objCidade = new Cidade();
            if (dr.HasRows)
            {
                dr.Read();
                objCliente.Id = Convert.ToInt32(dr["clienteID"]);
                objCliente.Nome = (string)dr["nome"];
                objCliente.Cpf = (string)dr["cpf"];
                objCliente.DataNascimento = Convert.ToDateTime(dr["dtNascimento"]);
                objCliente.Endereco = (string)dr["endereco"];
                objCliente.Numero = (string)dr["numero"];
                objCliente.OrgaoExpedidor = Convert.ToString(dr["orgaoExpedidor"]);
                objCliente.Rg = (string)dr["rg"];
                objCliente.Sexo = (EnumSexo)dr["sexo"];
                objCliente.ObjCidade = Cidade.FindById(Convert.ToInt32(dr["cidadeId"]));
            }
            else
            {
                objCliente = null;
            }
            return objCliente;
        }
        public void Deletar(Cliente objCliente)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE Clientes WHERE clienteID=@id ";

            comando.Parameters.AddWithValue("@id", objCliente.Id);

            Conexao.ExecutarCrud(comando);
        }
        public void Salvar(Cliente objCliente)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO Clientes (nome, cpf, endereco, dtNascimento, sexo, rg, orgaoExpedidor, numero, cidadeId) VALUES (@nome, @cpf, @endereco, @dtNascimento, @sexo, @rg, @orgaoExpedidor, @numero, @cidadeId);" +
                "SELECT CAST(scope_identity() as int);";

            comando.Parameters.AddWithValue("@nome", objCliente.Nome);
            comando.Parameters.AddWithValue("@cpf", objCliente.Cpf);
            comando.Parameters.AddWithValue("@endereco", objCliente.Endereco);
            comando.Parameters.AddWithValue("@dtNascimento", objCliente.DataNascimento);
            comando.Parameters.AddWithValue("@sexo", objCliente.Sexo);
            comando.Parameters.AddWithValue("@rg", objCliente.Rg);
            comando.Parameters.AddWithValue("@orgaoExpedidor", objCliente.OrgaoExpedidor);
            comando.Parameters.AddWithValue("@numero", objCliente.Numero);
            comando.Parameters.AddWithValue("@cidadeId", objCliente.ObjCidade.CidadeId);

            Conexao.ExecutarCrud(comando);
        }
        public void Alterar(Cliente objCliente)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = " UPDATE Clientes SET nome=@nome, cpf=@cpf, endereco=@endereco, dtNascimento=@dtNascimento, sexo=@sexo, rg=@rg, orgaoExpedidor=@orgaoExpedidor, numero=@numero, cidadeId=@cidadeId WHERE clienteID=@id";

            comando.Parameters.AddWithValue("@nome", objCliente.Nome);
            comando.Parameters.AddWithValue("@cpf", objCliente.Cpf);
            comando.Parameters.AddWithValue("@endereco", objCliente.Endereco);
            comando.Parameters.AddWithValue("@dtNascimento", objCliente.DataNascimento);
            comando.Parameters.AddWithValue("@sexo", objCliente.Sexo);
            comando.Parameters.AddWithValue("@rg", objCliente.Rg);
            comando.Parameters.AddWithValue("@orgaoExpedidor", objCliente.OrgaoExpedidor);
            comando.Parameters.AddWithValue("@numero", objCliente.Numero);
            comando.Parameters.AddWithValue("@cidadeId", objCliente.ObjCidade.CidadeId);
            comando.Parameters.AddWithValue("@id", objCliente.Id);

            Conexao.ExecutarCrud(comando);
        }
        public IList<Cliente> BuscaPorNome(string nome)
        {
            IList<Cliente> listaDeClientes = new List<Cliente>();

            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT c.cidadeId, c.nome, c.clienteID, c.cpf, c.dtNascimento, c.endereco, c.numero, c.orgaoExpedidor, c.rg, c.sexo, ci.nome FROM Clientes c LEFT JOIN Cidades ci ON c.cidadeId = ci.cidadeId Where c.nome LIKE @nome";

            comando.Parameters.AddWithValue("@nome", "%" + nome + "%");

            SqlDataReader dr = Conexao.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cliente objCliente = new Cliente();
                    objCliente.Id = Convert.ToInt32(dr["clienteID"]);
                    objCliente.Nome = (string)dr["nome"];
                    objCliente.Cpf = (string)dr["cpf"];
                    objCliente.DataNascimento = Convert.ToDateTime(dr["dtNascimento"]);
                    objCliente.Endereco = (string)dr["endereco"];
                    objCliente.Numero = (string)dr["numero"];
                    objCliente.OrgaoExpedidor = (string)dr["orgaoExpedidor"];
                    objCliente.Rg = (string)dr["rg"];
                    objCliente.Sexo = (EnumSexo)dr["sexo"];
                    objCliente.ObjCidade = Cidade.FindById(Convert.ToInt32(dr["cidadeId"]));
                    listaDeClientes.Add(objCliente);
                }
            }
            else
            {
                listaDeClientes = null;
            }
            return listaDeClientes;
        }
    }
}