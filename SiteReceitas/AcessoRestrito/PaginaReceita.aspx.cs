using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data.SqlClient;
using System.Web.Security;
using DAL;

namespace SiteReceitas.AcessoRestrito
{
    public partial class PaginaReceita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdicionarReceita_Click1(object sender, EventArgs e)
        {

            MembershipUser mUser = Membership.GetUser(User.Identity.Name);



            lstReceitasFavoritas.DataSource = ReceitasFavoritas.MostraFavoritos(mUser.ProviderUserKey.ToString());
            lstReceitasFavoritas.DataValueField = Receita.Campos.ID;
            lstReceitasFavoritas.DataTextField = Receita.Campos.Nome;

            lstReceitasFavoritas.DataBind();
        }

        protected void lstReceitasFavoritas_Click(object sender, BulletedListEventArgs e)
        {
            Response.Redirect(@"~\ApresentaReceita.aspx?idReceita=" + lstReceitasFavoritas.Items[e.Index].Value);
            
        }
    }
}
