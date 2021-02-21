using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using DAL;

namespace SiteReceitas
{
    public partial class PaginaPesquisa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                ddReceita.DataSource = Receitas.ListaTodos();
                ddReceita.DataTextField = Receita.Campos.Nome;
                ddReceita.DataValueField = Receita.Campos.ID;
                ddReceita.DataBind();


                ddCategoria.DataSource = Categorias.ListaTodos();
                ddCategoria.DataTextField = Categoria.Campos.Nome;
                ddCategoria.DataValueField = Categoria.Campos.ID;
                ddCategoria.DataBind();

                ddDificuldade.DataSource = Dificuldades.ListaTodos();
                ddDificuldade.DataTextField = Dificuldade.Campos.Nome;
                ddDificuldade.DataValueField = Dificuldade.Campos.ID;
                ddDificuldade.DataBind();

            }

        }

        protected void btnAdicionarReceita_Click1(object sender, EventArgs e)
        {
            
            lstReceitas.DataSource = ReceitasPesquisa.MostraPesquisaNome(int.Parse(ddReceita.SelectedValue));
            lstReceitas.DataValueField = Receita.Campos.ID;
            lstReceitas.DataTextField = Receita.Campos.Nome;

            lstReceitas.DataBind();
        }

        protected void btnAdicionarReceita_Click2(object sender, EventArgs e)
        {
            
            lstReceitas.DataSource = ReceitasPesquisa.MostraPesquisaCategoria(int.Parse(ddCategoria.SelectedValue));
            lstReceitas.DataValueField = Receita.Campos.ID;
            lstReceitas.DataTextField = Receita.Campos.Nome;

            lstReceitas.DataBind();
        }

        protected void btnAdicionarReceita_Click3(object sender, EventArgs e)
        {
            
            lstReceitas.DataSource = ReceitasPesquisa.MostraPesquisaDificuldade(int.Parse(ddDificuldade.SelectedValue));
            lstReceitas.DataValueField = Receita.Campos.ID;
            lstReceitas.DataTextField = Receita.Campos.Nome;

            lstReceitas.DataBind(); 
        }

        protected void lstReceitasPesquisa_Click(object sender, BulletedListEventArgs e)
        {
            Response.Redirect(@"~\ApresentaReceita.aspx?idReceita=" + lstReceitas.Items[e.Index].Value);
        }
    }
}