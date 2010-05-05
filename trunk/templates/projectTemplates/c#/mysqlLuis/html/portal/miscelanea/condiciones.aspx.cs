using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace juleweb.portal.miscelanea
{
    public partial class condiciones : System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Page.Theme = "normal";
            if ((Page.Session["tamanio"] != null))
            {
                Page.Theme = "normal" + Page.Session["tamanio"];
            }
            if (Page.Session["version"] != null)
            {
                if (Page.Session["tamanio"] == null)
                    Page.Theme = Page.Session["version"].ToString();
                else
                    Page.Theme = Page.Session["version"].ToString() + Page.Session["tamanio"].ToString();
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
