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
using mvc_prueba.Models;

namespace mvc_prueba.Controllers
{
    public class noticiasController : Controller
    {
        //
        // GET: /noticias/

        public ActionResult Index()
        {
            
            return View();
        }

        //
        // GET: /noticias/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /noticias/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /noticias/Create

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
        // GET: /noticias/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /noticias/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
