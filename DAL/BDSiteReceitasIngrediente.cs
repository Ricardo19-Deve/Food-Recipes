using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class Ingrediente
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

        public Ingrediente()
        { }

        //método da classe Receita
        public Ingrediente(int IngredienteID)
        {
            SqlConnection mySQLConnection = new SqlConnection();
            mySQLConnection.ConnectionString = Properties.Settings.Default.sqlCnStr2;

            SqlCommand cmdIngrediente = new SqlCommand();
            cmdIngrediente.Connection = mySQLConnection;
            cmdIngrediente.CommandText = "ApresentarUmIngredientePorID";
            cmdIngrediente.CommandType = System.Data.CommandType.StoredProcedure;
            cmdIngrediente.Parameters.AddWithValue("@IngredienteID", IngredienteID);

            mySQLConnection.Open();

            //    //o C# executa o comando à BD
            SqlDataReader drApresentacaoPorIngrediente = cmdIngrediente.ExecuteReader();

            drApresentacaoPorIngrediente.Read();

            _id = IngredienteID;
            _nome = drApresentacaoPorIngrediente[1].ToString();

            mySQLConnection.Close();

        }

        public bool Inserir()
        {
            try
            {
                SqlConnection mySQLConnection = new SqlConnection();
                mySQLConnection.ConnectionString = Properties.Settings.Default.sqlCnStr2;

                SqlCommand cmdInserirIngrediente = new SqlCommand();
                cmdInserirIngrediente.Connection = mySQLConnection;
                cmdInserirIngrediente.CommandText = "InsereIngredientes";
                cmdInserirIngrediente.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInserirIngrediente.Parameters.AddWithValue("@Ingrediente", _nome);

                mySQLConnection.Open();
                cmdInserirIngrediente.ExecuteNonQuery();
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

                SqlCommand cmdApagarIngrediente = new SqlCommand();
                cmdApagarIngrediente.Connection = mySQLConnection;
                cmdApagarIngrediente.CommandText = "ApagaIngrediente";
                cmdApagarIngrediente.CommandType = System.Data.CommandType.StoredProcedure;
                cmdApagarIngrediente.Parameters.AddWithValue("@IngredienteID", _id);

                mySQLConnection.Open();
                cmdApagarIngrediente.ExecuteNonQuery();
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

                SqlCommand cmdAtualizaIngrediente = new SqlCommand();
                cmdAtualizaIngrediente.Connection = mySQLConnection;
                cmdAtualizaIngrediente.CommandText = "AlteraIngrediente";
                cmdAtualizaIngrediente.CommandType = System.Data.CommandType.StoredProcedure;
                cmdAtualizaIngrediente.Parameters.AddWithValue("@IngredienteID", _id);
                cmdAtualizaIngrediente.Parameters.AddWithValue("@NovoIngrediente", _nome);

                mySQLConnection.Open();
                cmdAtualizaIngrediente.ExecuteNonQuery();
                mySQLConnection.Close();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    public static class Ingredientes
    {
        public static List<Ingrediente> ListaTodos()
        {
            SqlConnection mySqlCon = new SqlConnection(Properties.Settings.Default.sqlCnStr2);

            SqlCommand cmdListaTodosOsIngredientes = new SqlCommand();
            cmdListaTodosOsIngredientes.Connection = mySqlCon;
            cmdListaTodosOsIngredientes.CommandText = "ListaTodosOsIngredientes";
            cmdListaTodosOsIngredientes.CommandType = System.Data.CommandType.StoredProcedure;

            List<Ingrediente> listaIngredientes = new List<Ingrediente>();

            mySqlCon.Open();

            SqlDataReader drListaIngredientes = cmdListaTodosOsIngredientes.ExecuteReader();

            while (drListaIngredientes.Read())
            {
                Ingrediente novoIngrediente = new Ingrediente();

                novoIngrediente.ID = drListaIngredientes.GetInt32(0);
                novoIngrediente.Nome = drListaIngredientes[1].ToString();

                listaIngredientes.Add(novoIngrediente);
            }

            mySqlCon.Close();

            return listaIngredientes;

        }
    }
}
