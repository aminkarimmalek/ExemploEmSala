using ExercicioCrudWinForms.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicioCrudWinForms.Model
{
    public class ProdutosDAO : IProdutosDAO
    {
        private Iconnection conexao;
        public ProdutosDAO()
        {
            conexao = new Connection();
        }
        public void InserirRegistro(string descricao)
        {
            string query = @"INSERT INTO PRODUTOS (DESCRICAO,DATA_INSERCAO) VALUES (@descricao,GETDATE())";
            var conn = conexao.Conexao();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@descricao", descricao);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public List<Produtos> BuscaProdutos()
        {
            var lista = new List<Produtos>();
            string query = @"SELECT * FROM PROTUDOS ORDER BY DESCRICAO";
            var conn = conexao.Conexao();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Produtos P = new Produtos();
                P.Id = Convert.ToInt32(reader["ID"]);
                P.Descricao = reader["RESCRICAO"].ToString();
                P.Data_Insercao = Convert.ToDateTime(reader["DATA_INSERCAO"]);
                if (P.Data_Remocao < new DateTime(1900, 01, 01))
                {
                    P.Data_Remocao = new DateTime(1900, 01, 01);
                }
                else
                {
                    P.Data_Remocao = Convert.ToDateTime(reader["DATA_REMOCAO"]);
                }

                lista.Add(p);
            }
            conn.Close();

            return lista;
        }

        public void DeletaRegistro(int id)
        {
            string query = @"DELETE FROM PRODUTOS WHERE ID = " + id;
            var conn = conexao.Conexao();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }
        public void AtualizaRegistro(int id,string descricao)
        {
            string query = @"APDETE PRODUTOS SET DESCRICAO = @descricao  WHERE ID =" + id;
            var conn = conexao.Conexao();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@descricao", descricao);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }

}
