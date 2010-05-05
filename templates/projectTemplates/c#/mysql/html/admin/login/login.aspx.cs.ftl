<#-- 
 
 crea una clase para un listado_...aspx para la tabla  ${table}...
 Author : Luis Molina...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="login">
<#assign extensionFile="aspx.cs">
<#assign languageGenerated="c#">
<#assign description="description">
<#assign targetDirectory="">
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

namespace ${project}.admin.login
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
	   }
        private void vacios()
        {
 

 
        }
        protected void btnEntrar_Click(object sender, EventArgs e)
        {

			// autologin
            // txtlogix.Text = "xx";
            // txtpasx.Text = "xx";
			
			// we clean the data...
			txtlogix.Text = sf.SafeMeta(txtlogix.Text);
            txtpasx.Text = sf.SafeMeta(txtpasx.Text);
			
           if (txtlogix.Text != null && !txtlogix.Text.Equals("") && txtpasx.Text != null && !txtpasx.Text.Equals(""))
           {
           
				// // fill with your logic
               //List<admins> listadmins = new List<admins>();
               //listadmins = admins.getList();
               //foreach (admins adminx in listadmins)
               //{

               //    if (adminx.usuario == sf.cadena(txtlogix.Text) & adminx.clave == sf.cadena(txtpasx.Text))
               //    {
               //        HttpContext.Current.Session["${project}"] = "0";
               //        //Response.Redirect("../noticias_dir/listado_noticias.aspx");
               //        Response.Redirect("../cuestionarios_dir/listado_cuestionarios.aspx");
               //    }

               //}
            }

          
        }
    }
}
