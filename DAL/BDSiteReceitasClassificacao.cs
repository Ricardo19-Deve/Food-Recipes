using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class Classificacao
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

        public Classificacao()
        { }

        //método da classe Receita
        public Classificacao(int ClassificacaoID)
        {
            SqlConnection mySQLConnection = new SqlConnection();
            mySQLConnection.ConnectionString = Properties.Settings.Default.sqlCnStr2;

            SqlCommand cmdClassificacao = new SqlCommand();
            cmdClassificacao.Connection = mySQLConnection;
            cmdClassificacao.CommandText = "ApresentarUmaClassificacaoPorID";
            cmdClassificacao.CommandType = System.Data.CommandType.StoredProcedure;
            cmdClassificacao.Parameters.AddWithValue("@ClassificacaoID", ClassificacaoID);

            mySQLConnection.Open();

            //    //o C# executa o comando à BD
            SqlDataReader drApresentacaoPorClassificacao = cmdClassificacao.ExecuteReader();

            drApresentacaoPorClassificacao.Read();

            _id = ClassificacaoID;
            _nome = drApresentacaoPorClassificacao[1].ToString();

            mySQLConnection.Close();

        }

        public bool Inserir()
        {
            try
            {
                SqlConnection mySQLConnection = new SqlConnection();
                mySQLConnection.ConnectionString = Properties.Settings.Default.sqlCnStr2;

                SqlCommand cmdInserirClassificacao = new SqlCommand();
                cmdInserirClassificacao.Connection = mySQLConnection;
                cmdInserirClassificacao.CommandText = "InsereClassificacao";
                cmdInserirClassificacao.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInserirClassificacao.Parameters.AddWithValue("@Classificacao", _nome);

                mySQLConnection.Open();
                cmdInserirClassificacao.ExecuteNonQuery();
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

                SqlCommand cmdApagarClassificacao = new SqlCommand();
                cmdApagarClassificacao.Connection = mySQLConnection;
                cmdApagarClassificacao.CommandText = "ApagaClassificacao";
                cmdApagarClassificacao.CommandType = System.Data.CommandType.StoredProcedure;
                cmdApagarClassificacao.Parameters.AddWithValue("@ClassificacaoID", _id);

                mySQLConnection.Open();
                cmdApagarClassificacao.ExecuteNonQuery();
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

                SqlCommand cmdAtualizaClassificacao = new SqlCommand();
                cmdAtualizaClassificacao.Connection = mySQLConnection;
                cmdAtualizaClassificacao.CommandText = "AlteraClassificacao";
                cmdAtualizaClassificacao.CommandType = System.Data.CommandType.StoredProcedure;
                cmdAtualizaClassificacao.Parameters.AddWithValue("@ClassificacaoID", _id);
                cmdAtualizaClassificacao.Parameters.AddWithValue("@NovaClassificacao", _nome);

                mySQLConnection.Open();
                cmdAtualizaClassificacao.ExecuteNonQuery();
                mySQLConnection.Close();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    public static class Classificacoes
    {
        public static List<Classificacao> ListaTodos()
        {
            SqlConnection mySqlCon = new SqlConnection(Properties.Settings.Default.sqlCnStr2);

            SqlCommand cmdListaTodasAsClassificacoes = new SqlCommand();
            cmdListaTodasAsClassificacoes.Connection = mySqlCon;
            cmdListaTodasAsClassificacoes.CommandText = "ListaTodasAsClassificacoes";
            cmdListaTodasAsClassificacoes.CommandType = System.Data.CommandType.StoredProcedure;

            List<Classificacao> listaClassificacoes = new List<Classificacao>();

            mySqlCon.Open();

            SqlDataReader drListaClassificacoes = cmdListaTodasAsClassificacoes.ExecuteReader();

            while (drListaClassificacoes.Read())
            {
                Classificacao novaClassificacao = new Classificacao();

                novaClassificacao.ID = drListaClassificacoes.GetInt32(0);
                novaClassificacao.Nome = drListaClassificacoes[1].ToString();

                listaClassificacoes.Add(novaClassificacao);
            }

            mySqlCon.Close();

            return listaClassificacoes;

        }
    }
}
