using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class Unidade
    {
        public static class Campos
        {
            public static string Nome
            {
                get
                {
                    return "Nome";
                }
            }

            public static string ID
            {
                get
                {
                    return "ID";
                }
            }
        }

        private int _id;
        private string _nome;

        public string Nome
        {
            get
            {
                return _nome;
            }

            set
            {
                _nome = value;
            }
        }

        public int ID { get => _id; set => _id = value; }

        public Unidade()
        { }

        //método da classe Receita
        public Unidade(int UnidadeID)
        {
            SqlConnection mySQLConnection = new SqlConnection();
            mySQLConnection.ConnectionString = Properties.Settings.Default.sqlCnStr2;

            SqlCommand cmdUnidade = new SqlCommand();
            cmdUnidade.Connection = mySQLConnection;
            cmdUnidade.CommandText = "ApresentarUmaUnidadePorID";
            cmdUnidade.CommandType = System.Data.CommandType.StoredProcedure;
            cmdUnidade.Parameters.AddWithValue("@UnidadeID", UnidadeID);

            mySQLConnection.Open();

            //    //o C# executa o comando à BD
            SqlDataReader drApresentacaoPorUnidade = cmdUnidade .ExecuteReader();

            drApresentacaoPorUnidade.Read();

            _id = UnidadeID;
            _nome = drApresentacaoPorUnidade[1].ToString();

            mySQLConnection.Close();

        }

        public bool Inserir()
        {
            try
            {
                SqlConnection mySQLConnection = new SqlConnection();
                mySQLConnection.ConnectionString = Properties.Settings.Default.sqlCnStr2;

                SqlCommand cmdInserirUnidade = new SqlCommand();
                cmdInserirUnidade.Connection = mySQLConnection;
                cmdInserirUnidade.CommandText = "InsereUnidades";
                cmdInserirUnidade.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInserirUnidade.Parameters.AddWithValue("@Unidade", _nome);

                mySQLConnection.Open();
                cmdInserirUnidade.ExecuteNonQuery();
                mySQLConnection.Close();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Eliminar()
        {
            try
            {
                SqlConnection mySQLConnection = new SqlConnection();
                mySQLConnection.ConnectionString = Properties.Settings.Default.sqlCnStr2;

                SqlCommand cmdApagarUnidade = new SqlCommand();
                cmdApagarUnidade.Connection = mySQLConnection;
                cmdApagarUnidade.CommandText = "ApagaUnidade";
                cmdApagarUnidade.CommandType = System.Data.CommandType.StoredProcedure;
                cmdApagarUnidade.Parameters.AddWithValue("@UnidadeID", _id);

                mySQLConnection.Open();
                cmdApagarUnidade.ExecuteNonQuery();
                mySQLConnection.Close();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Atualizar()
        {
            try
            {
                SqlConnection mySQLConnection = new SqlConnection();
                mySQLConnection.ConnectionString = Properties.Settings.Default.sqlCnStr2;

                SqlCommand cmdAtualizaUnidade = new SqlCommand();
                cmdAtualizaUnidade.Connection = mySQLConnection;
                cmdAtualizaUnidade.CommandText = "AlteraUnidade";
                cmdAtualizaUnidade.CommandType = System.Data.CommandType.StoredProcedure;
                cmdAtualizaUnidade.Parameters.AddWithValue("@UnidadeID", _id);
                cmdAtualizaUnidade.Parameters.AddWithValue("@NovaUnidade", _nome);

                mySQLConnection.Open();
                cmdAtualizaUnidade.ExecuteNonQuery();
                mySQLConnection.Close();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    public static class Unidades
    {
        public static List<Unidade> ListaTodos()
        {
            SqlConnection mySqlCon = new SqlConnection(Properties.Settings.Default.sqlCnStr2);

            SqlCommand cmdListaTodasAsUnidades = new SqlCommand();
            cmdListaTodasAsUnidades.Connection = mySqlCon;
            cmdListaTodasAsUnidades.CommandText = "ListaTodasAsUnidades";
            cmdListaTodasAsUnidades.CommandType = System.Data.CommandType.StoredProcedure;

            List<Unidade> listaUnidades = new List<Unidade>();

            mySqlCon.Open();

            SqlDataReader drListaUnidades = cmdListaTodasAsUnidades.ExecuteReader();

            while (drListaUnidades.Read())
            {
                Unidade novaUnidade = new Unidade();

                novaUnidade.ID = drListaUnidades.GetInt32(0);
                novaUnidade.Nome = drListaUnidades[1].ToString();

                listaUnidades.Add(novaUnidade);
            }

            mySqlCon.Close();

            return listaUnidades;

        }
    }
}
