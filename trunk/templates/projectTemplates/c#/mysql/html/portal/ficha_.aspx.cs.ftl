<#-- 
 
 crea una clase para c# para la tabla  ${table}...
 Author : Luis Molina...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="ficha_${table}">
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
    public partial class ficha_${table} : System.Web.UI.Page
    {
		
		private static ${table} ${table}x = new ${table}();
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


			if (!Page.IsPostBack)
            {
				

				if (Request["id"] != null)
				{
					cargarDatos();
				}
             
			 }
        }

		private void cargarDatos()
        {
			${table}x = ${table}.get${table}(sf.entero(Request["id"])#foreach( $field in $table.GetArrayOfFields )#if ($field.targetName()=="idportales"  && table.getName()!="portales")>,sf.entero(Request["idportal"])#end#end );#set ($count = 0)
			#foreach( $field in $table.GetArrayOfFields )
				 #if (!$field.isKey())
					 
					 
							  #if ($field.type.toString() == "_integer")
								 #if (! $field.isForeignKey())
									lab${field}.Text = sf.cadena(${table}x.${field});
								 #else												
								 #end
								   #end 
							  #if ($field.type.toString() == "_string")
								 lab${field}.Text = ${table}x.${field};
								 #end 
							  <#case "_bigstring">
								 ftb${field}.Text = ${table}x.${field};
								 #end 
							  #if ($field.type.toString() == "_date")
								 lab${field}.Text = sf.cadena(${table}x.${field});
								 #end 
							  #if ($field.type.toString() == "_boolean")
								 ck${field}.Checked = sf.Bool(${table}x.${field});
								 #end 
							  #if ($field.type.toString() == "_image")
								if (${table}x.${field} != "")
								{
									img${field}.ImageUrl = ${table}x.${field};
									img${field}.Visible = true;
									//img${field}.AlternateText = " " + noticiax.titulo;									
								}
								 #end 
							  #if ($field.type.toString() == "_audio")
								if (${table}x.${field} != "")
								{
									lab${field}.Text = ${table}x.${field};
									lab${field}.Visible = true;
									//img${field}.AlternateText = " " + noticiax.titulo;									
								}
								 #end 
							  #if ($field.type.toString() == "_document")
								if (${table}x.${field} != "")
								{
									img${field}.ImageUrl = ${table}x.${field};
									img${field}.Visible = true;
									//img${field}.AlternateText = " " + noticiax.titulo;									
								}
								 #end 
							  <#default>
								 lab${field}.Text = ${table}x.${field};
					  
				 #end
				#set ($count = $count + 1 )
			 #end 
		  

			<#list table.getRelations() as relation>
			  //lab${relation.getChildKey()}.Text = sf.cadena(${relation.getParentTable()}.get${relation.getParentTable()}(${relation.getChildTable()}x.${relation.getParentKey()}).${relation.getParentKey()}#foreach( $field in $table.GetArrayOfFields )#if ($field.targetName()=="idportales"  && table.getName()!="portales")>,sf.entero(Request["idportal"])#end#end );#set ($count = 0));	
			#end 

        }		 
     
     
        
    } 
}
