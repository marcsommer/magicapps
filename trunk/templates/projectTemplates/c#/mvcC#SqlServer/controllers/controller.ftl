<#-- 
 
 crea una extension para la clase para c# para la tabla  ${table}...
 basicamente para su uso como objectDataSource ...
 Author : Luis Molina...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="${table}Controller">
<#assign extensionFile="cs">
<#assign languageGenerated="c#">
<#assign description="c#">
<#assign targetDirectory="">
<#assign appliesToAllTables="true">
<#-- END variables used internally by the generator... -->
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
// necesario para importar los model..
using ${project}.Models;

namespace ${project}.Controllers
{
    public class ${table}Controller : Controller
    {
        //
        // GET: /${table}/

        public ActionResult Index()
        {
            ViewData.Model = ${table}.getList();
            return View();
        }

		//
        // GET: /${table}/List/

        public ActionResult List()
        {
		#foreach( $field in $table.GetArrayOfFields )
		  #if (!$field.isKey())   
			 
			 
					  #if ($field.type.toString() == "_integer")
						#if ( $field.isForeignKey())				
							ViewData["idtiposNoticiasValue"] = "dd";
						#end
						 #end 
					  #if ($field.type.toString() == "_string")
								
						 #end 
					  #if ($field.type.toString() == "_date")
						 #end 
					  #if ($field.type.toString() == "_boolean")	
						 #end 
						#if ($field.type.toString() == "_image")
						#end 
					  <#default>		
			  
			#set ($count = $count + 1 )
		 #end
		#end 		
            
            ViewData.Model = ${table}.getList();
            return View();
        }
		
		
        //
        // GET: /${table}/Details/5

        public ActionResult Details(int id)
        {
			ViewData.Model = new ${table}(id);
            return View();
        }

		
		
		
		
		
        //
        // GET: /${table}/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /${table}/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /${table}/Edit/5
 
        public ActionResult Edit(int id)
        {
            noticias noti = new noticias(id);
            #foreach( $field in $table.GetArrayOfFields )
			  #if (!$field.isKey())   
				 
				 
						  #if ($field.type.toString() == "_integer")
							#if ( $field.isForeignKey())				
								ViewData["tiposNoticiasSet"] = new SelectList(tiposNoticias.getList(), "idTiposNoticias", "descripcion", noti.idTiposNoticias);
							#end
							 #end 
						  #if ($field.type.toString() == "_string")
									
							 #end 
						  #if ($field.type.toString() == "_date")
							 #end 
						  #if ($field.type.toString() == "_boolean")	
							 #end 
							#if ($field.type.toString() == "_image")
							#end 
						  <#default>		
				  
				#set ($count = $count + 1 )
			 #end
			#end 	
			ViewData.Model = noti;           
            return View();
        }

        //
        // POST: /${table}/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
				#foreach( $field in $table.GetArrayOfFields )
				  #if (!$field.isKey())   
					 
					 
							  #if ($field.type.toString() == "_integer")
								#if ( $field.isForeignKey())				
									 var value = collection["tiposNoticiasSet"];
								#end
								 #end 
							  #if ($field.type.toString() == "_string")
										
								 #end 
							  #if ($field.type.toString() == "_date")
								 #end 
							  #if ($field.type.toString() == "_boolean")	
								 #end 
								#if ($field.type.toString() == "_image")
								#end 
							  <#default>		
					  
					#set ($count = $count + 1 )
				 #end
				#end 
				
                noticias noti = new noticias();
                UpdateModel(noti);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
