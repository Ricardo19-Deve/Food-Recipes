using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class Receita
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
        private List<LinhaIngrediente> _linhasIngrediente;
        private Dificuldade _dificuldade;
        private Categoria _categoria;
        private Classificacao _classificacao;
        private bool _validado;
        private string _idUser;
        private string _confeccao;
        private string _comentario1;
        private string _nomeReceita;
        private int _idReceita;
        private DateTime _duracao;



        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public List<LinhaIngrediente> LinhasIngrediente { get => _linhasIngrediente; set => _linhasIngrediente = value; }
        public Dificuldade Dificuldade { get => _dificuldade; set => _dificuldade = value; }
        public Categoria Categoria { get => _categoria; set => _categoria = value; }
        public Classificacao Classificacao { get => _classificacao; set => _classificacao = value; }
        public string IdUser { get => _idUser; set => _idUser = value; }
        public string Confeccao { get => _confeccao; set => _confeccao = value; }
        public string Comentario1 { get => _comentario1; set => _comentario1 = value; }
        public bool Validado { get => _validado; set => _validado = value; }
        public string NomeReceita { get => _nomeReceita; set => _nomeReceita = value; }
        public int IdReceita { get => _idReceita; set => _idReceita = value; }
        public DateTime Duracao { get => _duracao; set => _duracao = value; }

        public Receita()
        {
            _linhasIngrediente = new List<LinhaIngrediente>();
        }


        public Receita(int idReceita) //é o contrutor, esta criar um objeto
        {
            _idReceita = idReceita;
            _linhasIngrediente = new List<LinhaIngrediente>();

            SqlConnection mySQLConnection = new SqlConnection();
            mySQLConnection.ConnectionString = Properties.Settings.Default.sqlCnStr2;

            SqlCommand cmdReceita = new SqlCommand();
            cmdReceita.Connection = mySQLConnection;
            cmdReceita.CommandText = "MostraReceita ";
            cmdReceita.CommandType = System.Data.CommandType.StoredProcedure;
            cmdReceita.Parameters.AddWithValue("@ReceitaID", _idReceita);


            mySQLConnection.Open();
            SqlDataReader drMostraReceita = cmdReceita.ExecuteReader();
            drMostraReceita.Read();

            _nome = drMostraReceita[1].ToString();
            _confeccao = drMostraReceita[2].ToString();
            _duracao = DateTime.Parse(drMostraReceita[3].ToString());
            _categoria = new Categoria((int)drMostraReceita[4]);
            _dificuldade = new Dificuldade(drMostraReceita.GetInt32(5));

            drMostraReceita.Close();

            cmdReceita.CommandText = "LinhaReceita";
            cmdReceita.CommandType = System.Data.CommandType.StoredProcedure;
            cmdReceita.Parameters.Clear();
            cmdReceita.Parameters.AddWithValue("@ReceitaID", _idReceita);

            SqlDataReader drMostraLinhaReceita = cmdReceita.ExecuteReader();
            drMostraLinhaReceita.Read();

            do 
            {

                LinhaIngrediente linhaIngrediente = new LinhaIngrediente();
                linhaIngrediente.IdReceita = _idReceita;
                linhaIngrediente.Quantidade = double.Parse(drMostraLinhaReceita.GetString(3));
                linhaIngrediente.Ingrediente = new Ingrediente(drMostraLinhaReceita.GetInt32(1));
                linhaIngrediente.Unidade = new Unidade(drMostraLinhaReceita.GetInt32(4));

                _linhasIngrediente.Add(linhaIngrediente);

            }
            while (drMostraLinhaReceita.Read());


        }


        public bool Inserir()
        {
            bool retorno;

            using (SqlConnection mySqlCon = new SqlConnection(Properties.Settings.Default.sqlCnStr2))
            {
                mySqlCon.Open();

                SqlCommand command = mySqlCon.CreateCommand();
                SqlTransaction transaction;

                transaction = mySqlCon.BeginTransaction("Transacao");

                command.Connection = mySqlCon;
                command.Transaction = transaction;

                try
                {

                    command.CommandText = "InsereReceitas";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserId", _idUser);
                    command.Parameters.AddWithValue("@NomeReceita", _nome);
                    command.Parameters.AddWithValue("@Dificuldade", _dificuldade.ID);
                    command.Parameters.AddWithValue("@Categoria", _categoria.ID);
                    command.Parameters.AddWithValue("@Confecção", _confeccao);
                    command.Parameters.AddWithValue("@Duracao", _duracao);

                    command.ExecuteNonQuery();

                    //limpar parametroe
                    command.Parameters.Clear();

                    command.CommandText = "MostraUltimaReceitaInserida";
                    command.CommandType = System.Data.CommandType.StoredProcedure;//criar SP que devolve a ultima receita inserida                    

                    int idReceita = (int)command.ExecuteScalar(); //valor returnado pela SP



                    foreach (LinhaIngrediente linha in _linhasIngrediente)
                    {
                        //linha.Inserir(idReceita);

                        command.CommandText = "InsereIngredientesQuatindadesUnidades";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@IngredienteID", linha.Ingrediente.ID);
                        command.Parameters.AddWithValue("@Quantidade", linha.Quantidade);
                        command.Parameters.AddWithValue("@ReceitaID", idReceita);
                        command.Parameters.AddWithValue("@UnidadeID", linha.Unidade.ID);

                        command.ExecuteNonQuery();

                        command.Parameters.Clear();
                    }

                    transaction.Commit();
                    retorno = true;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    retorno = false;
                }
                finally
                {
                    mySqlCon.Close();
                }
                return retorno;
            }
        }

        public bool Eliminar()
        {
            try
            {
                SqlConnection mySQLConnection = new SqlConnection();
                mySQLConnection.ConnectionString = Properties.Settings.Default.sqlCnStr2;

                SqlCommand cmdApagarReceita = new SqlCommand();
                cmdApagarReceita.Connection = mySQLConnection;
                cmdApagarReceita.CommandText = "ApagaReceitas";
                cmdApagarReceita.CommandType = System.Data.CommandType.StoredProcedure;
                cmdApagarReceita.Parameters.AddWithValue("@IDReceita", _id);

                mySQLConnection.Open();
                cmdApagarReceita.ExecuteNonQuery();
                mySQLConnection.Close();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Comentario()
        {
            try
            {
                SqlConnection mySQLConnection = new SqlConnection();
                mySQLConnection.ConnectionString = Properties.Settings.Default.sqlCnStr2;

                SqlCommand cmdComentaReceita = new SqlCommand();
                cmdComentaReceita.Connection = mySQLConnection;
                cmdComentaReceita.CommandText = "InsereComentarios";
                cmdComentaReceita.CommandType = System.Data.CommandType.StoredProcedure;
                cmdComentaReceita.Parameters.AddWithValue("@ReceitaID", _idReceita);
                cmdComentaReceita.Parameters.AddWithValue("@UserID", _idUser);
                cmdComentaReceita.Parameters.AddWithValue("@Comentario", _comentario1);

                mySQLConnection.Open();
                cmdComentaReceita.ExecuteNonQuery();
                mySQLConnection.Close();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool ClassificaReceita()
        {
            try
            {
                SqlConnection mySQLConnection = new SqlConnection();
                mySQLConnection.ConnectionString = Properties.Settings.Default.sqlCnStr2;

                SqlCommand cmdClassificaReceita = new SqlCommand();
                cmdClassificaReceita.Connection = mySQLConnection;
                cmdClassificaReceita.CommandText = "InsereClassificacaoReceita";
                cmdClassificaReceita.CommandType = System.Data.CommandType.StoredProcedure;
                cmdClassificaReceita.Parameters.AddWithValue("@ReceitaID", _idReceita);
                cmdClassificaReceita.Parameters.AddWithValue("@UserID", _idUser);
                cmdClassificaReceita.Parameters.AddWithValue("@ClassificacaoID", _classificacao.ID);

                mySQLConnection.Open();
                cmdClassificaReceita.ExecuteNonQuery();
                mySQLConnection.Close();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Favorito()
        {
            try
            {
                SqlConnection mySQLConnection = new SqlConnection();
                mySQLConnection.ConnectionString = Properties.Settings.Default.sqlCnStr2;

                SqlCommand cmdFavorito = new SqlCommand();
                cmdFavorito.Connection = mySQLConnection;
                cmdFavorito.CommandText = "InsereFavorito";
                cmdFavorito.CommandType = System.Data.CommandType.StoredProcedure;
                cmdFavorito.Parameters.AddWithValue("@ReceitaID", _idReceita);
                cmdFavorito.Parameters.AddWithValue("@UserID", _idUser);


                mySQLConnection.Open();
                cmdFavorito.ExecuteNonQuery();
                mySQLConnection.Close();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update()
        {
            try
            {
                SqlConnection mySQLConnection = new SqlConnection();
                mySQLConnection.ConnectionString = Properties.Settings.Default.sqlCnStr2;

                SqlCommand cmdValidaReceita = new SqlCommand();
                cmdValidaReceita.Connection = mySQLConnection;
                cmdValidaReceita.CommandText = "AlteraEstadoValidacao";
                cmdValidaReceita.CommandType = System.Data.CommandType.StoredProcedure;
                cmdValidaReceita.Parameters.AddWithValue("@ReceitaID", _id);
                cmdValidaReceita.Parameters.AddWithValue("@NovoEstadoValidação", _validado);


                mySQLConnection.Open();
                cmdValidaReceita.ExecuteNonQuery();
                mySQLConnection.Close();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public DataTable Lista(int ReceitaId)
        {
            DataTable dt = new DataTable();

            DataSet ds = new DataSet();
            SqlConnection mySQLConnection = new SqlConnection();
            mySQLConnection.ConnectionString = Properties.Settings.Default.sqlCnStr2;



            SqlCommand sqlComm = new SqlCommand("ListaLinhaDeReceitaPorReceita", mySQLConnection);
            sqlComm.Parameters.AddWithValue("@ReceitaID", ReceitaId);


            sqlComm.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;

            da.Fill(ds);


            dt = ds.Tables["IngredienteReceitasUnidade"];

            return dt;

        }

    }
    public static class Receitas
    {
        public static List<Receita> ListaTodos()
        {
            SqlConnection mySqlCon = new SqlConnection(Properties.Settings.Default.sqlCnStr2);

            SqlCommand cmdListaTodasAsReceitas = new SqlCommand();
            cmdListaTodasAsReceitas.Connection = mySqlCon;
            cmdListaTodasAsReceitas.CommandText = "ListaTodasAsReceitas";
            cmdListaTodasAsReceitas.CommandType = System.Data.CommandType.StoredProcedure;

            List<Receita> listaReceitas = new List<Receita>();

            mySqlCon.Open();

            SqlDataReader drListaReceitas = cmdListaTodasAsReceitas.ExecuteReader();

            while (drListaReceitas.Read())
            {
                Receita novaReceita = new Receita();

                novaReceita.Id = drListaReceitas.GetInt32(0);
                novaReceita.Nome = drListaReceitas[1].ToString();
                novaReceita.Validado = drListaReceitas.GetBoolean(drListaReceitas.FieldCount - 1);

                listaReceitas.Add(novaReceita);
            }

            mySqlCon.Close();

            return listaReceitas;

        }

    }
    public static class TodasAsReceitas
    {
        public static List<Receita> ListaTodos()
        {
            SqlConnection mySqlCon = new SqlConnection(Properties.Settings.Default.sqlCnStr2);

            SqlCommand cmdListaTodasAsReceitas = new SqlCommand();
            cmdListaTodasAsReceitas.Connection = mySqlCon;
            cmdListaTodasAsReceitas.CommandText = "ListaTodasAsReceitasV2";
            cmdListaTodasAsReceitas.CommandType = System.Data.CommandType.StoredProcedure;

            List<Receita> listaReceitas = new List<Receita>();

            mySqlCon.Open();

            SqlDataReader drListaReceitas = cmdListaTodasAsReceitas.ExecuteReader();

            while (drListaReceitas.Read())
            {
                Receita novaReceita = new Receita();

                novaReceita.Id = drListaReceitas.GetInt32(0);
                novaReceita.Nome = drListaReceitas[1].ToString();
                novaReceita.Validado = drListaReceitas.GetBoolean(drListaReceitas.FieldCount - 1);

                listaReceitas.Add(novaReceita);
            }

            mySqlCon.Close();

            return listaReceitas;

        }

    }
}