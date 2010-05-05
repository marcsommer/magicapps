<#-- 
 
 crea una clase para un listado_...aspx para la tabla  ${table}...
 Author : Pablo Garcia Mu�oz...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="main_${table}">
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
 

namespace ${project}.${table}_dir
{
    public partial class main_${table} : System.Web.UI.Page
    {
	  private static int idportal;
        protected void Page_Load(object sender, EventArgs e) 
        {
			PanelAviso.Visible = false;
			seguridad();

			if (!Page.IsPostBack)
            {
             <#list table.getRelations() as relation>
               lo.comboRellenar(cmb${relation.getChildKey()}, "select ${relation.getChildKey()},nombre from ${relation.getParentTable()} where idportal=" + idportal, ctes.conStringAdoGeneral, "Seleccione");
            #end 
                            
            
            // si nos mandan para borrar...
            if (Request["idb"] != null)
            {
                ${table}.Delete(sf.entero(Request["idb"])#foreach( $field in $table.GetArrayOfFields )#if ($field.targetName()=="idportales"  && table.getName()!="portales")>,sf.entero(Request["idportal"])#end#end );
                Response.Redirect("./listado_${table}.aspx");
            }

            if (Request["id"] != null)
            {
                ${table} res = new ${table}(sf.entero(Request["id"])#foreach( $field in $table.GetArrayOfFields )#if ($field.targetName()=="idportales"  && table.getName()!="portales" && !table.getName()=="idportal")>,sf.entero(Request["idportal"])#end#end );
                //res = ${table}.get${table}(sf.entero(Request["id"]));
               
                #set ($count = 0)
                #foreach( $field in $table.GetArrayOfFields )
                     #if (!$field.isKey())
					 #if ($field != "idportal")	
                         
                         
                                  #if ($field.type.toString() == "_integer")
									 #if (! $field.isForeignKey())
										txt${field}.Text = sf.cadena(res.${field});
									 #end
									   #end 
                                  #if ($field.type.toString() == "_string")
									#if ( $field.size() >= 251)>
                                       txt${field}.Text = res.${field};
                                    #else
                                        txt${field}.Text = res.${field};
                                     #end		
                                     
                                     #end 
                                  #if ($field.type.toString() == "_date")
									${field}.SelectedDate = res.${field};
                                     #end 
                                  #if ($field.type.toString() == "_boolean")
                                     ck${field}.Checked = sf.Bool(res.${field});
                                     #end 
								#if ($field.type.toString() == "_image")
                                     if (sf.cadena(res.${field}) != "")
										{
											img${field}.ImageUrl = res.${field};
											img${field}.Visible = true;
											//imgNoticia.AlternateText = " " + res.titulo;
											btnborrarimagen${field}.Visible = true;
											FileUploadImagen${field}.Visible = false;
										}
                                     #end 
								#if ($field.type.toString() == "_document")
                                     if (sf.cadena(res.${field}) != "")
										{
											lbl${field}.Text = sf.Right(res.${field},res.${field}.Length-19);
											lbl${field}.Visible = true;
											 
											btnborrar${field}.Visible = true;
											FileUpload${field}.Visible = false;
										}
                                     #end 									 
                                  <#default>
                                     #if ( $field.size() >= 251)>
                                       txt${field}.Text = res.${field};
                                    #else
                                        txt${field}.Text = res.${field};
                                     #end		
                         
					 #end	

                     #end
                    #set ($count = $count + 1 )
                 #end 
              

                <#list table.getRelations() as relation>
                  lo.comboSeleccionarItem(cmb${relation.getChildKey()}, sf.cadena(res.${relation.getChildKey()}), "Id");
                #end 

            }
            else
            {
                butModificar.Text = "Insertar";
            }
			 }
        }

        protected void butModificar_Click(object sender, EventArgs e)
        {
            // modificar
            if (Request["id"] != null)
            {
                ${table} res = new ${table}(sf.entero(Request["id"])#foreach( $field in $table.GetArrayOfFields )#if ($field.targetName()=="idportales"  && table.getName()!="portales")>,sf.entero(Request["idportal"])#end#end );
                //res = ${table}.get${table}(sf.entero(Request["id"]));
                #set ($count = 0)
                #foreach( $field in $table.GetArrayOfFields )
                    #if (!$field.isKey())
 #if ($field == "idportal")
res.idportal= sf.entero(HttpContext.Current.Session["admin"]);
 #end					
					#if ($field != "idportal")
                        
                         
                                  #if ($field.type.toString() == "_integer")
                                    #if (! $field.isForeignKey())
                                        res.${field}=sf.entero(txt${field}.Text) ;
                                    #else
                                         res.${field}=sf.entero(cmb${field}.SelectedValue) ;
                                     #end                                   
                                     #end 
                                  #if ($field.type.toString() == "_string")
									#if ( $field.size() >= 251)>
                                       res.${field}=sf.cadena(txt${field}.Text);
                                    #else
                                        res.${field}=sf.cadena(txt${field}.Text) ;
                                     #end		
									#end 
                                  #if ($field.type.toString() == "_date")
									res.${field}=sf.fecha(${field}.SelectedDate) ;
                                     #end 
                                  #if ($field.type.toString() == "_boolean")
                                     res.${field}=sf.Bool(ck${field}.Checked) ;
                                     #end 
								#if ($field.type.toString() == "_image")
                                    if (FileUploadImagen${field}.PostedFile == null) { }
									else
									{
										if (FileUploadImagen${field}.FileName != "")
										{
											if (!System.IO.File.Exists(Server.MapPath("../../bdimages/") + sf.cadena(HttpContext.Current.Session["admin"]) + FileUploadImagen${field}.FileName))
											{
												res.${field} = "../../bdimages/" + sf.cadena(HttpContext.Current.Session["admin"]) + FileUploadImagen${field}.FileName;
												FileUploadImagen${field}.SaveAs(Server.MapPath("../../bdimages/") + sf.cadena(HttpContext.Current.Session["admin"]) + FileUploadImagen${field}.FileName);
												img${field}.ImageUrl = res.${field};
												//img${field}.AlternateText = " " + res.titulo;
												img${field}.Visible = true;
												btnborrarimagen${field}.Visible = true;
												FileUploadImagen${field}.Visible = false;

											}
											else
											{//mensaje("El archivo ya existe, elija otro nombre");
											}
												
										}
									}
                                     #end 
								#if ($field.type.toString() == "_document")
                                    if (FileUpload${field}.PostedFile == null) { }
									else
									{
										if (FileUpload${field}.FileName != "")
										{
											if (!System.IO.File.Exists(Server.MapPath("../../bddocumentos/") + sf.cadena(HttpContext.Current.Session["admin"]) + FileUpload${field}.FileName))
											{
												res.${field} = "../../bddocumentos/" + sf.cadena(HttpContext.Current.Session["admin"]) + FileUpload${field}.FileName;
												FileUpload${field}.SaveAs(Server.MapPath("../../bddocumentos/") + sf.cadena(HttpContext.Current.Session["admin"]) + FileUpload${field}.FileName);
												lbl${field}.Text = res.${field};
												//img${field}.AlternateText = " " + res.titulo;
												lbl${field}.Visible = true;
												btnborrar${field}.Visible = true;
												FileUpload${field}.Visible = false;

											}
											else
											{//mensaje("El archivo ya existe, elija otro nombre");
											}
												
										}
									}
                                     #end 									 
                                  <#default>
                                    res.${field}=sf.cadena(txt${field}.Text) ;
                          
                    #end
					#end
                    #set ($count = $count + 1 )
                #end 
 
                res.Update();
                res = null;
                mensaje("Modificado con exito");
        
            }
            // insertar...
            else
            {

                ${table} res = new ${table}(); 
                #set ($count = 0)
                #foreach( $field in $table.GetArrayOfFields )
 #if ($field == "idportal")
res.idportal= sf.entero(HttpContext.Current.Session["admin"]);
 #end				
				 #if ($field != "idportal")	
                    #if (!$field.isKey())
                        
                         
                                  #if ($field.type.toString() == "_integer")
                                    #if (! $field.isForeignKey())
                                        res.${field}=sf.entero(txt${field}.Text) ;
                                    #else
                                         res.${field}=sf.entero(lo.comboValorSeleccionado(ref cmb${field},ctes.eTipoCampo.id)) ;
                                     #end
                                   
                                     #end 
                                  #if ($field.type.toString() == "_string")
									#if ( $field.size() >= 251)>
                                       res.${field}=sf.cadena(txt${field}.Text);
                                    #else
                                        res.${field}=sf.cadena(txt${field}.Text) ;
                                     #end									
                                     #end 
                                  #if ($field.type.toString() == "_date")
									res.${field}=sf.fecha(${field}.SelectedDate) ;
                                     #end 
                                  #if ($field.type.toString() == "_boolean")
                                     res.${field}=sf.Bool(ck${field}.Checked) ;
                                     #end 
								 #if ($field.type.toString() == "_image")
                                    if (FileUploadImagen${field}.PostedFile == null) { }
									else
									{
										if (FileUploadImagen${field}.FileName != "")
										{
											if (!System.IO.File.Exists(Server.MapPath("../../bdimages/") + sf.cadena(HttpContext.Current.Session["admin"]) + FileUploadImagen${field}.FileName))
											{
												res.${field} = "../../bdimages/" + sf.cadena(HttpContext.Current.Session["admin"]) + FileUploadImagen${field}.FileName;
												FileUploadImagen${field}.SaveAs(Server.MapPath("../../bdimages/") + sf.cadena(HttpContext.Current.Session["admin"]) + FileUploadImagen${field}.FileName);
												img${field}.ImageUrl = res.${field};
												//img${field}.AlternateText = " " + res.titulo;
												img${field}.Visible = true;
												btnborrarimagen${field}.Visible = true;
												FileUploadImagen${field}.Visible = false;

											}
											else
											{//mensaje("El archivo ya existe, elija otro nombre");
											}
												
										}
									}
                                     #end 
								#if ($field.type.toString() == "_document")
                                    if (FileUpload${field}.PostedFile == null) { }
									else
									{
										if (FileUpload${field}.FileName != "")
										{
											if (!System.IO.File.Exists(Server.MapPath("../../bddocumentos/") + sf.cadena(HttpContext.Current.Session["admin"]) + FileUpload${field}.FileName))
											{
												res.${field} = "../../bddocumentos/" + sf.cadena(HttpContext.Current.Session["admin"]) + FileUpload${field}.FileName;
												FileUpload${field}.SaveAs(Server.MapPath("../../bddocumentos/") + sf.cadena(HttpContext.Current.Session["admin"]) + FileUpload${field}.FileName);
												lbl${field}.Text = res.${field};
												//img${field}.AlternateText = " " + res.titulo;
												lbl${field}.Visible = true;
												btnborrar${field}.Visible = true;
												FileUpload${field}.Visible = false;

											}
											else
											{//mensaje("El archivo ya existe, elija otro nombre");
											}
												
										}
									}
                                     #end 										 
                                  <#default>
                                    res.${field}=sf.cadena(txt${field}.Text) ;
                          
                    #end
					#end
                    #set ($count = $count + 1 )
					
                #end 
                
                 ${table}.Insert(res);
                 res = null;
				mensaje("Insertado con exito");
  
                                
                // si tenemos algo en el tracker tiramos para atr�s...
                 track traki = new track();
                 traki = (track)tracker.pop();
                 if (traki != null)
                 {
                     Response.Redirect(traki.url);
                 }
                
            }
        }
        
         <#list table.getRelations() as relation>
       		  protected void ibNew${relation.getChildKey()}_Click(object sender, ImageClickEventArgs e)
				{
				 // lo ponemos en cola...
				tracker.push(new track("../${table}_dir/main_${table}.aspx?id=" + Request["id"], "cmb${relation.getChildKey()}","") );
				Response.Redirect("../${relation.getParentTable()}_dir/main_${relation.getParentTable()}.aspx?url=../${table}_dir/main_${table}.aspx?id=" + Request["id"]);
	     
			 	}   
         #end 
     
        private void mensaje(string p)
        {
            lblinfo.Text = p;
            lblinfo.Visible = true;
            PanelAviso.Visible = true;
        }
         protected void butCancelar_Click(object sender, EventArgs e)
        {
            // si tenemos algo en el tracker tiramos para atr�s...
            track traki=new track();
            traki = (track)tracker.pop();
            if ( traki != null)
            {
                Response.Redirect(traki.url);
            }
        }
		
		
        private void seguridad()
        {
           if(sf.cadena(HttpContext.Current.Session["admin"])=="")
		   {
		   //Sales..
		    //Response.Redirect("../login/login.aspx");
		   }
		   idportal = sf.entero(HttpContext.Current.Session["admin"]);
        }
		
		// funciones extra para campos extra
		#set ($count = 0)
                #foreach( $field in $table.GetArrayOfFields )
                    #if (!$field.isKey())
                        
                         
                                  #if ($field.type.toString() == "_image")
                                     protected void btnborrarimagen${field}_Click(object sender, EventArgs e)
									{
										${table} res = new ${table}(sf.entero(Request["id"])#foreach( $field in $table.GetArrayOfFields )#if ($field.targetName()=="idportales"  && table.getName()!="portales")>,sf.entero(Request["idportal"])#end#end );
										res.deleteImg${field}();
										img${field}.Visible = false;
										btnborrarimagen${field}.Visible = false;
										//txtTextoAlternativo${field}.Text = "";
							 
										if (System.IO.File.Exists(Server.MapPath(img${field}.ImageUrl.ToString())))
											System.IO.File.Delete(Server.MapPath(img${field}.ImageUrl.ToString()));
										FileUploadImagen${field}.Visible = true;
										res.${field} = "";
										
									}
									 
                                     #end 
                                  #if ($field.type.toString() == "_document")
                                     protected void btnborrar${field}_Click(object sender, EventArgs e)
									{
										${table} res = new ${table}(sf.entero(Request["id"])#foreach( $field in $table.GetArrayOfFields )#if ($field.targetName()=="idportales"  && table.getName()!="portales")>,sf.entero(Request["idportal"])#end#end );
										res.deleteDoc${field}();
										lbl${field}.Visible = false;
										btnborrar${field}.Visible = false;
										//txtTextoAlternativo${field}.Text = "";
							 
										if (System.IO.File.Exists(Server.MapPath(lbl${field}.Text.ToString())))
											System.IO.File.Delete(Server.MapPath(lbl${field}.Text.ToString()));
										FileUpload${field}.Visible = true;
										res.${field} = "";
										
									}
									 
                                     #end 									 
                                  <#default>
                                    
                          
                    #end
                    #set ($count = $count + 1 )
                #end 






		
        
    } 
    
}
