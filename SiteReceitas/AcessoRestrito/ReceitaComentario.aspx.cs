using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;


namespace SiteReceitas.AcessoRestrito
{
    public partial class ReceitaComentario : System.Web.UI.Page
    {
        bool flag;

        Receita novoComentario;

        protected void Page_Load(object sender, EventArgs e)
        {
            MembershipUser mUser = Membership.GetUser(User.Identity.Name);

            if (!Page.IsPostBack)
            {

                novoComentario = new Receita();

                ddReceita.DataSource = Receitas.ListaTodos();
                ddReceita.DataTextField = Receita.Campos.Nome;
                ddReceita.DataValueField = Receita.Campos.ID;
                ddReceita.DataBind();

                ddClassificação.DataSource = Classificacoes.ListaTodos();
                ddClassificação.DataTextField = Classificacao.Campos.Nome;
                ddClassificação.DataValueField = Classificacao.Campos.ID;
                ddClassificação.DataBind();


                Session["Receita"] = novoComentario;

                flag = true;
            }
        }

        protected void btnAdicionarReceita_Click1(object sender, EventArgs e)
        {
            if (txtcomentario.Text != string.Empty)
            {
                Receita novaComentario = (Receita)Session["Receita"];

                MembershipUser mUser = Membership.GetUser(User.Identity.Name);

                novaComentario.IdUser = mUser.ProviderUserKey.ToString();
                novaComentario.IdReceita =  int.Parse((ddReceita.SelectedValue));
                novaComentario.Comentario1 = txtcomentario.Text;
               

                if (novaComentario.Comentario())
                {
                    Response.Write("<script>alert ('Inserido comentário com sucesso!'); </script>");

                }
                else
                    Response.Write("<script>alert ('Houve um erro come!'); </script>");

                
            }


        }

        protected void btnAdicionarFavorito_Click1(object sender, EventArgs e)
        {
            Receita favorita = (Receita)Session["Receita"];

            MembershipUser mUser = Membership.GetUser(User.Identity.Name);

            favorita.IdUser = mUser.ProviderUserKey.ToString();
            favorita.IdReceita = int.Parse((ddReceita.SelectedValue));

            if (favorita.Favorito())
            {
                Response.Write("<script>alert ('Inserida as suas Receitas Favoritas!'); </script>");

            }
            else
                Response.Write("<script>alert ('Houve um erro come!'); </script>");

        }

        protected void btnAdicionarAvaliacao_Click1(object sender, EventArgs e)
        {
            Receita novaComentario = (Receita)Session["Receita"];

            MembershipUser mUser = Membership.GetUser(User.Identity.Name);

            novaComentario.IdUser = mUser.ProviderUserKey.ToString();
            novaComentario.IdReceita = int.Parse((ddReceita.SelectedValue));
            novaComentario.Classificacao = new Classificacao(int.Parse((ddClassificação.SelectedValue)));

            if (novaComentario.ClassificaReceita())
            {
                Response.Write("<script>alert ('Inserida Avaliacao com sucesso!'); </script>");

            }
            else
                Response.Write("<script>alert ('Houve um erro come!'); </script>");
        }
    }
}