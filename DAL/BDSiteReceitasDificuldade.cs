using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DAL
{
    public class Dificuldade
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

        public Dificuldade()
        { }

        //método da classe Receita
        public Dificuldade(int DificuldadeID)
        {
            SqlConnection mySQLConnection = new SqlConnection();
            mySQLConnection.ConnectionString = Properties.Settings.Default.sqlCnStr2;

            SqlCommand cmdDificuldade = new SqlCommand();
            cmdDificuldade.Connection = mySQLConnection;
            cmdDificuldade.CommandText = "ApresentarUmaDificuldadePorID";
            cmdDificuldade.CommandType = System.Data.CommandType.StoredProcedure;
            cmdDificuldade.Parameters.AddWithValue("@DificuldadeID", DificuldadeID);

            mySQLConnection.Open();

            //    //o C# executa o comando à BD
            SqlDataReader drApresentacaoPorDificuldade = cmdDificuldade.ExecuteReader();

            drApresentacaoPorDificuldade.Read();

            _id = DificuldadeID;
            _nome = drApresentacaoPorDificuldade[1].ToString();

            mySQLConnection.Close();

        }

        public bool Inserir()
        {
            try
            {
                SqlConnection mySQLConnection = new SqlConnection();
                mySQLConnection.ConnectionString = Properties.Settings.Default.sqlCnStr2;

                SqlCommand cmdInserirDificuldade = new SqlCommand();
                cmdInserirDificuldade.Connection = mySQLConnection;
                cmdInserirDificuldade.CommandText = "InsereDificuldade";
                cmdInserirDificuldade.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInserirDificuldade.Parameters.AddWithValue("@Dificuldade", _nome);

                mySQLConnection.Open();
                cmdInserirDificuldade.ExecuteNonQuery();
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

                SqlCommand cmdApagarDificuldade = new SqlCommand();
                cmdApagarDificuldade.Connection = mySQLConnection;
                cmdApagarDificuldade.CommandText = "ApagaDificuldade";
                cmdApagarDificuldade.CommandType = System.Data.CommandType.StoredProcedure;
                cmdApagarDificuldade.Parameters.AddWithValue("@DificuldadeID", _id);

                mySQLConnection.Open();
                cmdApagarDificuldade.ExecuteNonQuery();
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

                SqlCommand cmdAtualizaDificuldade = new SqlCommand();
                cmdAtualizaDificuldade.Connection = mySQLConnection;
                cmdAtualizaDificuldade.CommandText = "AlteraDificuldade";
                cmdAtualizaDificuldade.CommandType = System.Data.CommandType.StoredProcedure;
                cmdAtualizaDificuldade.Parameters.AddWithValue("@DificuldadeID", _id);
                cmdAtualizaDificuldade.Parameters.AddWithValue("@NovaDificuldade", _nome);

                mySQLConnection.Open();
                cmdAtualizaDificuldade.ExecuteNonQuery();
                mySQLConnection.Close();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    public static class Dificuldades
    {
        public static List<Dificuldade> ListaTodos()
        {
            SqlConnection mySqlCon = new SqlConnection(Properties.Settings.Default.sqlCnStr2);

            SqlCommand cmdListaTodasAsDificuldades = new SqlCommand();
            cmdListaTodasAsDificuldades.Connection = mySqlCon;
            cmdListaTodasAsDificuldades.CommandText = "ListaTodasAsDificuldades";
            cmdListaTodasAsDificuldades.CommandType = System.Data.CommandType.StoredProcedure;

            List<Dificuldade> listaDificuldades = new List<Dificuldade>();

            mySqlCon.Open();

            SqlDataReader drListaDificuldades = cmdListaTodasAsDificuldades.ExecuteReader();

            while (drListaDificuldades.Read())
            {
                Dificuldade novaDificuldade = new Dificuldade();

                novaDificuldade.ID = drListaDificuldades.GetInt32(0);
                novaDificuldade.Nome = drListaDificuldades[1].ToString();

                listaDificuldades.Add(novaDificuldade);
            }

            mySqlCon.Close();

            return listaDificuldades;

        }
    }
}

