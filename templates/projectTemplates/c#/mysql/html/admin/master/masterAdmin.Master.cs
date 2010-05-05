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

namespace admin.masterAdmin
{
    public partial class masterAdmin : System.Web.UI.MasterPage
    {
        private static int idport;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargar();
                seguridad();
            }
        }
        private void seguridad()
        {

            if (HttpContext.Current.Session["admin${project}"] != null)
            {

            }
            else
            {
                //Response.Redirect("../login/login.aspx");
            }
        }



        #region["comun"]
        private void cargar()
        {
            if (HttpContext.Current.Session["versionadmin"] == "contraste")
            {
                btnContraste.Text = "Versi�n standard";
                btnTexto.Text = "Versi�n texto";
            }
            if (HttpContext.Current.Session["versionadmin"] == "texto")
            {
                btnContraste.Text = "Versi�n alto contraste";
                btnTexto.Text = "Versi�n standard";
            }
        }
        protected void btnNormal_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["tamanio"] = null;
            Response.Redirect(HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"]);
        }


        protected void btnMediano_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["tamanio"] = "med";
            Response.Redirect(HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"]);
        }

        protected void btnGrande_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["tamanio"] = "xl";
            Response.Redirect(HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"]);

        }
        protected void btnTexto_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["versionadmin"] == "contraste" | HttpContext.Current.Session["versionadmin"] == null)
            {
                HttpContext.Current.Session["versionadmin"] = "texto";
                Response.Redirect(HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"]);
            }
            else
            {
                HttpContext.Current.Session["versionadmin"] = null;
                Response.Redirect(HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"]);
            }
        }

        protected void btnContraste_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["versionadmin"] == "texto" | HttpContext.Current.Session["versionadmin"] == null)
            {
                HttpContext.Current.Session["versionadmin"] = "admcontraste";
                Response.Redirect(HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"]);
            }
            else
            {
                HttpContext.Current.Session["versionadmin"] = null;
                Response.Redirect(HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"]);
            }

        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["admin"] = null;

            Response.Redirect("../../portal/portada/portada.aspx");
        }

        protected void btnAccesibilidad_Click(object sender, EventArgs e)
        {
            Response.Redirect("../miscelanea/accesibilidad.aspx");
        }
        #endregion
    }
}
