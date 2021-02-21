using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SiteReceitas.AcessoRestrito
{
    public partial class AreaPessoal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAlterarEmail_Click1(object sender, EventArgs e)
        {
            MembershipUser user = Membership.GetUser();
            user.Email = txtEmail.Text;
            Membership.UpdateUser(user);

           
        }
    }
}