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
using System.Collections.Generic;
namespace juleweb.portal.master
{
    public partial class masterWeb : System.Web.UI.MasterPage
    {
      
         
        protected void Page_Load(object sender, EventArgs e)
        {
            //imgLogo.ImageUrl = "../../images/logoUDP.gif";
 

           
            vacios();

        }

        
        private void vacios()
        {
            //if ((txtbusqueda.Text == "") | (txtbusqueda.Text == "<Buscar>"))
            //{
            //    txtbusqueda.Text = "<Buscar>";
            //    txtbusqueda.Attributes.Add("onClick", "doClear(this)");
            //}
            //else
            //    txtbusqueda.Attributes.Remove("onClick");
        }

      

        protected void lnbNormal_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["tamanio"] = null;

            Response.Redirect(Request.Path  );
        }

        protected void lnbMed_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["tamanio"] = "med";
            Response.Redirect(Request.Path  );
        }

        protected void lnbGrande_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["tamanio"] = "xl";
            Response.Redirect(Request.Path  );
        }

        protected void lnbContraste_Click(object sender, EventArgs e)
        {
            string tam= "";
            if (HttpContext.Current.Session["tamanio"] != null)
                tam = sf.cadena(HttpContext.Current.Session["tamanio"]);

            if (HttpContext.Current.Session["version"] == "texto" | HttpContext.Current.Session["version"] == null)
            {
                //Page.Theme = "contraste" + idport + tam;
                HttpContext.Current.Session["version"] = null;
                HttpContext.Current.Session["version"] = "contraste";
                Response.Redirect(Request.Path  );
              //  Response.Redirect(Request.Path + "?idportal=" + idport);
            }
            else
            {
                HttpContext.Current.Session["version"] = null;
              //  Page.Theme = "normal" + idport + tam;
                Response.Redirect(Request.Path  );
                //Response.Redirect(Request.Path + "?idportal=" + idport);
            }
        }

        protected void lnbTexto_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["version"] == "contraste" | HttpContext.Current.Session["version"] == null)
            {
                HttpContext.Current.Session["version"] = null;
                HttpContext.Current.Session["version"] = "texto";
                Response.Redirect(Request.Path  + "&vr=texto");
            }
            else
            {
                HttpContext.Current.Session["version"] = null;
                Response.Redirect(Request.Path  );
            }
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            string cc = "../buscar_dir/main_buscar.aspx?busqueda=" + txtbusqueda.Text ;
            Response.Redirect(cc);
        }

        protected void imgLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../portada/portada.aspx");

        }

    }
}
