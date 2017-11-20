using Montadora.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Montadora.Repository
{
    public class MontadorRepository
    {
        public IList<Montador> SelecionarTodas()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Montadores";


            SqlDataReader dr = Conexao.ExecutarSelect(comando);

            IList<Montador> montadores = new List<Montador>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Montador objMontador = new Montador();

                    objMontador.Id = Convert.ToInt32(dr["montadorID"]);
                    objMontador.Nome = (string)dr["nome"];
                    objMontador.Cpf = (string)dr["cpf"];
                    objMontador.Salario = Convert.ToDecimal(dr["salario"]);

                    montadores.Add(objMontador);
                }
            }
            else
            {
                montadores = null;
            }
            return montadores;
        }
        public Montador BuscarPorID(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Montadores Where montadorID=@id";

            comando.Parameters.AddWithValue("@id", id);

            Conexao con = new Conexao();
            SqlDataReader dr = Conexao.ExecutarSelect(comando);

            Montador objMontador = new Montador();
            if (dr.HasRows)
            {
                dr.Read();
                objMontador.Id = Convert.ToInt32(dr["montadorID"]);
                objMontador.Nome = (string)dr["nome"];
                objMontador.Cpf = (string)dr["cpf"];
                objMontador.Salario = Convert.ToDecimal(dr["salario"]);
            }
            else
            {
                objMontador = null;
            }
            return objMontador;
        }
        public void Deletar(Montador objMontador)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE Montadores WHERE montadorID=@id ";

            comando.Parameters.AddWithValue("@id", objMontador.Id);

            Conexao.ExecutarCrud(comando);
        }
        public void Salvar(Montador objMontador)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO Montadores (nome, cpf, salario) VALUES (@nome, @cpf, @salario);" +
                "SELECT CAST(scope_identity() as int);";

            comando.Parameters.AddWithValue("@nome", objMontador.Nome);
            comando.Parameters.AddWithValue("@cpf", objMontador.Cpf);
            comando.Parameters.AddWithValue("@salario", objMontador.Salario);

            Conexao.ExecutarCrud(comando);
        }
        public void Alterar(Montador objMontador)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = " UPDATE Montadores SET nome=@nome, cpf=@cpf, salario=@salario WHERE montadorID=@id";

            comando.Parameters.AddWithValue("@nome", objMontador.Nome);
            comando.Parameters.AddWithValue("@cpf", objMontador.Cpf);
            comando.Parameters.AddWithValue("@salario", objMontador.Salario);
            comando.Parameters.AddWithValue("@id", objMontador.Id);

            Conexao.ExecutarCrud(comando);
        }
        public IList<Montador> BuscarPorNome(string nomeBusca)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Montadores Where nome LIKE @nome ";

            comando.Parameters.AddWithValue("@nome", "%" + nomeBusca + "%");

            Conexao con = new Conexao();
            SqlDataReader dr = Conexao.ExecutarSelect(comando);

            IList<Montador> listaDeMontadores = new List<Montador>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Montador objMontador = new Montador();
                    objMontador.Id = Convert.ToInt32(dr["montadorID"]);
                    objMontador.Nome = (string)dr["nome"];
                    objMontador.Cpf = (string)dr["cpf"];
                    objMontador.Salario = Convert.ToDecimal(dr["salario"]);                
                    listaDeMontadores.Add(objMontador);
                }
            }
            else
            {
                listaDeMontadores = null;
            }
            return listaDeMontadores;
        }
    }
}