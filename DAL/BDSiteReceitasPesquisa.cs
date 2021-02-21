using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.SqlClient;

namespace DAL
{

    public static class ReceitasPesquisa
    {

        public static List<Receita> MostraPesquisaNome(int idReceita)
        {

            SqlConnection mySqlCon = new SqlConnection(Properties.Settings.Default.sqlCnStr2);

            SqlCommand cmdListaReceitasPesquisa = new SqlCommand();
            cmdListaReceitasPesquisa.Connection = mySqlCon;
            cmdListaReceitasPesquisa.CommandText = "PesquisaPorNomeDeReceitaV2";
            cmdListaReceitasPesquisa.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter
                    ("@NomeReceita", idReceita);
            cmdListaReceitasPesquisa.Parameters.Add(param);
         
            List<Receita> receitasPesquisa = new List<Receita>();

            mySqlCon.Open();

            SqlDataReader drListaReceitas = cmdListaReceitasPesquisa.ExecuteReader();

            while (drListaReceitas.Read())
            {
                Receita novaReceita = new Receita();

                novaReceita.Id = drListaReceitas.GetInt32(0);//não mexa... sff isto está com delay...relativamente
                novaReceita.Nome = drListaReceitas[1].ToString();


                receitasPesquisa.Add(novaReceita);
            }

            mySqlCon.Close();

            return receitasPesquisa;
        }
        public static List<Receita> MostraPesquisaCategoria(int idCategoria)
        {

            SqlConnection mySqlCon = new SqlConnection(Properties.Settings.Default.sqlCnStr2);

            SqlCommand cmdListaReceitasPesquisa = new SqlCommand();
            cmdListaReceitasPesquisa.Connection = mySqlCon;
            cmdListaReceitasPesquisa.CommandText = "PesquisaPorNomeDeReceitaV2";
            cmdListaReceitasPesquisa.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter
                    ("@Categoria", idCategoria);
            cmdListaReceitasPesquisa.Parameters.Add(param);
       
            List<Receita> receitasPesquisa = new List<Receita>();

            mySqlCon.Open();

            SqlDataReader drListaReceitas = cmdListaReceitasPesquisa.ExecuteReader();

            while (drListaReceitas.Read())
            {
                Receita novaReceita = new Receita();

                novaReceita.Id = drListaReceitas.GetInt32(0);
                novaReceita.Nome = drListaReceitas[1].ToString();


                receitasPesquisa.Add(novaReceita);
            }

            mySqlCon.Close();

            return receitasPesquisa;
        }
        public static List<Receita> MostraPesquisaDificuldade(int idDificuldade)
        {

            SqlConnection mySqlCon = new SqlConnection(Properties.Settings.Default.sqlCnStr2);

            SqlCommand cmdListaReceitasPesquisa = new SqlCommand();
            cmdListaReceitasPesquisa.Connection = mySqlCon;
            cmdListaReceitasPesquisa.CommandText = "PesquisaPorNomeDeReceitaV2";
            cmdListaReceitasPesquisa.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter
                    ("@Dificuldade", idDificuldade);
            cmdListaReceitasPesquisa.Parameters.Add(param);

            List<Receita> receitasPesquisa = new List<Receita>();

            mySqlCon.Open();

            SqlDataReader drListaReceitas = cmdListaReceitasPesquisa.ExecuteReader();

            while (drListaReceitas.Read())
            {
                Receita novaReceita = new Receita();

                novaReceita.Id = drListaReceitas.GetInt32(0);
                novaReceita.Nome = drListaReceitas[1].ToString();

                receitasPesquisa.Add(novaReceita);
            }

            mySqlCon.Close();

            return receitasPesquisa;
        }
    }
}
