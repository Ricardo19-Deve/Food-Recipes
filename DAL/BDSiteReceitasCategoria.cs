using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Categoria
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

        public Categoria()
        { }

        //método da classe Receita
        public Categoria(int CategoriaID)
        {
            SqlConnection mySQLConnection = new SqlConnection();
            mySQLConnection.ConnectionString = Properties.Settings.Default.sqlCnStr2;

            SqlCommand cmdCategoria = new SqlCommand();
            cmdCategoria.Connection = mySQLConnection;
            cmdCategoria.CommandText = "ApresentarUmaCategoriaPorID";
            cmdCategoria.CommandType = System.Data.CommandType.StoredProcedure;
            cmdCategoria.Parameters.AddWithValue("@CategoriaID", CategoriaID);

            mySQLConnection.Open();

            //    //o C# executa o comando à BD
            SqlDataReader drApresentacaoPorCategoria = cmdCategoria.ExecuteReader();

            drApresentacaoPorCategoria.Read();

            _id = CategoriaID;
            _nome = drApresentacaoPorCategoria[1].ToString();

            mySQLConnection.Close();

        }

        public bool Inserir()
        {
            try
            {
                SqlConnection mySQLConnection = new SqlConnection();
                mySQLConnection.ConnectionString = Properties.Settings.Default.sqlCnStr2;

                SqlCommand cmdInserirCategoria = new SqlCommand();
                cmdInserirCategoria.Connection = mySQLConnection;
                cmdInserirCategoria.CommandText = "InsereCategorias";
                cmdInserirCategoria.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInserirCategoria.Parameters.AddWithValue("@Categoria", _nome);

                mySQLConnection.Open();
                cmdInserirCategoria.ExecuteNonQuery();
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

                SqlCommand cmdApagarCategoria = new SqlCommand();
                cmdApagarCategoria.Connection = mySQLConnection;
                cmdApagarCategoria.CommandText = "ApagaCategoria";
                cmdApagarCategoria.CommandType = System.Data.CommandType.StoredProcedure;
                cmdApagarCategoria.Parameters.AddWithValue("@CategoriaID", _id);

                mySQLConnection.Open();
                cmdApagarCategoria.ExecuteNonQuery();
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

                SqlCommand cmdAtualizaCategoria = new SqlCommand();
                cmdAtualizaCategoria.Connection = mySQLConnection;
                cmdAtualizaCategoria.CommandText = "AlteraCategoria";
                cmdAtualizaCategoria.CommandType = System.Data.CommandType.StoredProcedure;
                cmdAtualizaCategoria.Parameters.AddWithValue("@CategoriaID", _id);
                cmdAtualizaCategoria.Parameters.AddWithValue("@NovaCategoria", _nome);

                mySQLConnection.Open();
                cmdAtualizaCategoria.ExecuteNonQuery();
                mySQLConnection.Close();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    public static class Categorias
    {
        public static List<Categoria> ListaTodos()
        {
            SqlConnection mySqlCon = new SqlConnection(Properties.Settings.Default.sqlCnStr2);

            SqlCommand cmdListaTodasAsCategorias = new SqlCommand();
            cmdListaTodasAsCategorias.Connection = mySqlCon;
            cmdListaTodasAsCategorias.CommandText = "ListaTodasAsCategorias";
            cmdListaTodasAsCategorias.CommandType = System.Data.CommandType.StoredProcedure;

            List<Categoria> listaCategorias = new List<Categoria>();

            mySqlCon.Open();

            SqlDataReader drListaCategorias = cmdListaTodasAsCategorias.ExecuteReader();

            while (drListaCategorias.Read())
            {
                Categoria novaCategoria = new Categoria();

                novaCategoria.ID = drListaCategorias.GetInt32(0);
                novaCategoria.Nome = drListaCategorias[1].ToString();

                listaCategorias.Add(novaCategoria);
            }

            mySqlCon.Close();

            return listaCategorias;

        }
    }


}
