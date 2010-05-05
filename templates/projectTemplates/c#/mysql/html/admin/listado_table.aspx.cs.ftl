<#-- 
 
 crea una clase para un listado_...aspx para la tabla  ${table}...
 Author : Luis Molina...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="listado_${table}">
<#assign extensionFile="aspx.cs">
<#assign languageGenerated="c#">
<#assign description="description">
<#assign targetDirectory="${table}_dir">
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


namespace ${project}.${table}_dir
{
    public partial class listado_${table} : System.Web.UI.Page
    {
		private static int idportal;
        protected void Page_Load(object sender, EventArgs e)
        {
            idportal = sf.entero(HttpContext.Current.Session["admin"]);
			seguridad();
            if (!Page.IsPostBack)
            {
                List<${table}> lista = new List<${table}>();
                lista = ${table}.getListByPortal(idportal);

				 
				<#list table.getRelations() as relation>
				 
				 #if ($relation.ParentTable() == "categorias"+ $relation.ChildTable())	
                List< categorias${table} > listacat = new List< categorias${table} >();
                listacat = categorias${table}.getListByPortal(idportal);
                Repeater2.DataSource = listacat;
                Repeater2.DataBind();	
				
				if (sf.entero(Request["idcat"]) != 0)
                {
                   
					lista = ${table}.getList${table}By${relation.getParentKey()}(sf.entero(Request["idcat"]));
                }
				
				#end			
				#end 	
                Repeater1.DataSource = lista;
                Repeater1.DataBind();				
            }
			 
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<${table}> lista = new List<${table}>();
            lista = ${table}.getListByBusquedaGeneral(txtBusqueda.Text);
            Repeater1.DataSource = lista;
            Repeater1.DataBind();
        }
		
		private void seguridad()
        {
           if(sf.cadena(HttpContext.Current.Session["admin"])=="")
		   {
		   //Sales..
		    //Response.Redirect("../login/login.aspx");
		   }
        }

    }
}
