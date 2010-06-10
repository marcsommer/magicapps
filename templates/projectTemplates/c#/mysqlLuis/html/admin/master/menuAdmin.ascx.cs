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

namespace juleweb.admin.master
{
    public partial class menuAdmin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idportal = sf.entero(HttpContext.Current.Session["admin"]);
            if (idportal != 0)
            {
                if (idportal == 1)
                    PanelFede.Visible = true;
                else
                {
                    if (idportal == 2)
                        PanelAsociacionNoAsoc.Visible = true;
                    if (idportal == 3)
                        PanelFADEX.Visible = true;
                    if (idportal == 4)
                        PanelAsociacionNoAsoc.Visible = true;
                    if (idportal == 5)
                        PanelAsociacionNoAsoc.Visible = true;
                    if (idportal == 6)
                        PanelAsociacion.Visible = true;
                    if (idportal == 7)
                        PanelMadrid.Visible = true;
                    if (idportal == 8)
                        PanelAsociacion.Visible = true;
                    if (idportal == 9)
                        PanelAsociacionNoAsoc.Visible = true;
                    if (idportal == 10)
                        PanelAsociacion.Visible = true;
                    if (idportal == 11)
                        PanelAsociacion.Visible = true;
                    if (idportal == 12)
                        PanelAsociacionNoAsoc.Visible = true;
                    if (idportal == 13)
                        PanelAsociacionNoAsoc.Visible = true;
                    if (idportal == 14)
                        PanelAsociacion.Visible = true;
                    if (idportal == 15)
                        PanelAsociacion.Visible = true;
                    if (idportal == 16)
                        PanelAsociacion.Visible = true;
                    if (idportal == 17)
                        PanelAsociacion.Visible = true;
                    if (idportal == 18)
                        PanelAsociacionNoAsoc.Visible = true;
                    if (idportal == 19)
                        PanelAsociacionNoAsoc.Visible = true;
                }

            }
        }
    }
}