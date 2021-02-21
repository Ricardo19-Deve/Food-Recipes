using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;


namespace SiteReceitas.AcessoRestrito
{
    public partial class Inserir_Receitas : System.Web.UI.Page
    {
        bool flag;

        Receita novaReceita;


        protected void Page_Load(object sender, EventArgs e)
        {


            MembershipUser mUser = Membership.GetUser(User.Identity.Name);


            if (!Page.IsPostBack)
            {
                novaReceita = new Receita();

                ddUnidade.DataSource = Unidades.ListaTodos();
                ddUnidade.DataTextField = Unidade.Campos.Nome;
                ddUnidade.DataValueField = Unidade.Campos.ID;
                ddUnidade.DataBind();

                ddIngrediente.DataSource = Ingredientes.ListaTodos();
                ddIngrediente.DataTextField = Ingrediente.Campos.Nome;
                ddIngrediente.DataValueField = Ingrediente.Campos.ID;
                ddIngrediente.DataBind();

                ddCategoria.DataSource = Categorias.ListaTodos();
                ddCategoria.DataTextField = Categoria.Campos.Nome;
                ddCategoria.DataValueField = Categoria.Campos.ID;
                ddCategoria.DataBind();

                ddDificuldade.DataSource = Dificuldades.ListaTodos();
                ddDificuldade.DataTextField = Dificuldade.Campos.Nome;
                ddDificuldade.DataValueField = Dificuldade.Campos.ID;
                ddDificuldade.DataBind();



                Session["Receita"] = novaReceita;


                flag = true;
            }

        }

        private void btnAdicionarReceita_Click(object sender, EventArgs e)
        {
        }

        protected void btnAdicionarReceita_Click1(object sender, EventArgs e)
        {
            if (txtReceita.Text != string.Empty)
            {
                Receita novaReceita = (Receita)Session["Receita"];

                MembershipUser mUser = Membership.GetUser(User.Identity.Name);
                novaReceita.IdUser = mUser.ProviderUserKey.ToString();
                novaReceita.Nome = txtReceita.Text;
                novaReceita.Categoria = new Categoria(int.Parse((ddCategoria.SelectedValue)));
                novaReceita.Dificuldade = new Dificuldade(int.Parse(ddDificuldade.SelectedValue));
                novaReceita.Confeccao = txtConfeccao.Text;
                novaReceita.Duracao =DateTime.ParseExact( txtDuracao.Text,"HH:mm",null);

                if (novaReceita.Inserir())
                {
                    Response.Write("<script>alert ('Inserida receita com sucesso!'); </script>");

                }
                else
                    Response.Write("<script>alert ('Houve um erro!'); </script>");
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtQuantidade.Text != string.Empty)
            {



                Receita novaReceita = (Receita)Session["Receita"];

                LinhaIngrediente novalinha = new LinhaIngrediente();

                novalinha.IdReceita = novaReceita.Id;
                novalinha.Quantidade = double.Parse(txtQuantidade.Text);
                novalinha.Unidade = new Unidade(int.Parse(ddUnidade.SelectedValue));
                novalinha.Ingrediente = new Ingrediente(int.Parse((ddIngrediente.SelectedValue)));


                novaReceita.LinhasIngrediente.Add((novalinha));

                lblListaIngredientes.Text += novalinha.Quantidade + " " + novalinha.Unidade.Nome + " de " + novalinha.Ingrediente.Nome + "<br/>";




            }
        }

    }
}