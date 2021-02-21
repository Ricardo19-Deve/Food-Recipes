using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{


    public static class ReceitasFavoritas
    {

        public static List<Receita> MostraFavoritos(string IdUser)
        {

            SqlConnection mySqlCon = new SqlConnection(Properties.Settings.Default.sqlCnStr2);

            SqlCommand cmdListaReceitasFavoritas = new SqlCommand();
            cmdListaReceitasFavoritas.Connection = mySqlCon;
            cmdListaReceitasFavoritas.CommandText = "MostraReceitaFavoritasV2";
            cmdListaReceitasFavoritas.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter
                   ("@UserId", IdUser);
            cmdListaReceitasFavoritas.Parameters.Add(param);

            List<Receita> receitasFavoritas = new List<Receita>();

            mySqlCon.Open();

            SqlDataReader drListaReceitas = cmdListaReceitasFavoritas.ExecuteReader();

            while (drListaReceitas.Read())
            {
                Receita novaReceita = new Receita();

                novaReceita.Id = drListaReceitas.GetInt32(0);
                novaReceita.Nome = drListaReceitas[1].ToString();
              

                receitasFavoritas.Add(novaReceita);
            }

            mySqlCon.Close();

            return receitasFavoritas;
        }
    }

}
