using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Montadora.Repository
{
    public class Conexao
    {
        private static SqlConnection Conectar()
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["ConexaoMontadora"].ConnectionString;
            SqlConnection conexao = new SqlConnection(stringConexao);
            conexao.Open();
            return conexao;
        }

        public static int ExecutarCrud(SqlCommand comando)
        {
            SqlConnection con = Conectar();
            comando.Connection = con;
            int id = Convert.ToInt32(comando.ExecuteScalar());
            con.Close();
            return id;
        }

        public static SqlDataReader ExecutarSelect(SqlCommand comando)
        {
            SqlConnection con = Conectar();
            comando.Connection = con;
            SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;         
        }
    }
}