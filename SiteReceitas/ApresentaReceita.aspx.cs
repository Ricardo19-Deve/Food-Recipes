using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace SiteReceitas
{
    public partial class teste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Receita novaReceita = new Receita(int.Parse(Request.QueryString["idReceita"]));

           
            txtNomeReceita.Text = novaReceita.Nome;
            txtDuracao.Text = novaReceita.Duracao.ToString();
            TxtConfeccao.Text = novaReceita.Confeccao;
            txtCategoria.Text = novaReceita.Categoria.Nome;
            txtDificuldade.Text = novaReceita.Dificuldade.Nome;


            foreach  (LinhaIngrediente item in novaReceita.LinhasIngrediente)
            {
                lblLinhaIngrediente.Text += item.Quantidade + " " + item.Unidade.Nome + " " + item.Ingrediente.Nome + "<br>";
            }
        }
    }
}