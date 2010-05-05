<#-- 
 
 crea una clase para c# para la tabla  ${table}...
 Author : Luis Molina...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="listado_${table}">
<#assign extensionFile="aspx.cs">
<#assign languageGenerated="c#">
<#assign description="c#">
<#assign targetDirectory="main_${table}">
<#assign appliesToAllTables="true">
<#-- END variables used internally by the generator... -->
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

namespace ${project}.portal.main_${table}
{
    public partial class listado_${table} : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request["idportal"] != null)
            {
                int idportal;
                idportal = sf.entero(Request["idportal"]);
                if (portales.exists(idportal))
                {
                    Page.Theme = "normal" + idportal.ToString();
                    if ((Page.Session["tamanio"] != null))
                    {
                        Page.Theme = "normal" + idportal.ToString() + Page.Session["tamanio"];
                    }
                    if (Page.Session["version"] != null)
                    {
                        if (sf.cadena(Page.Session["version"]) == "texto")
                        {
                            if (Page.Session["tamanio"] == null)
                                Page.Theme = Page.Session["version"].ToString();
                            else
                                Page.Theme = Page.Session["version"].ToString() + Page.Session["tamanio"].ToString();

                        }
                        else
                        {
                            if (Page.Session["tamanio"] == null)
                                Page.Theme = Page.Session["version"].ToString() + idportal.ToString();
                            else
                                Page.Theme = Page.Session["version"].ToString() + idportal.ToString() + Page.Session["tamanio"].ToString();
                        }
                    }

                }
                else
                    Response.Redirect("../indice/indice.aspx");
            }
            else
                Response.Redirect("../indice/indice.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {

       
       
       
                List<${table}> list${table} = new List<${table}>();
                list${table} = ${table}.getList();
                //portales portalx = new portales();
                ////Esto nos dice si el portal es federacion o ${table} provincial, si es 0 es que no es federacion
                ////y si es algun numero, es el id de la autonomia, que no servira para ver las ${table} en la provincia
                //portalx = portales.getportales(idportal);
                //if (sf.entero(portalx.idfederacion) != 0)
                //{
                //    int federacionAutonomia = portalx.idfederacion;
                //    list${table} = ${table}.getListByAutonomia(federacionAutonomia);
                //}
                //else
                //    list${table} = ${table}.getListByProvincia(portalx.idprovincia, true);



                Repeater1.DataSource = list${table};
                Repeater1.DataBind();
                //hplInicio.NavigateUrl = "../portada/portada.aspx?idportal=" ;

           
        }
    }
}
