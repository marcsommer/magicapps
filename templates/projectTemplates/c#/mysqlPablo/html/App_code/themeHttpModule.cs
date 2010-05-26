using System;
using System.Web;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.Web.UI;


public class themeHttpModule : IHttpModule
{


    void System.Web.IHttpModule.Dispose()
    {

    }

    void System.Web.IHttpModule.Init(System.Web.HttpApplication context)
    {

        // hay que a�adirle el manejador a mano.
        //   AddHandler context.BeginRequest, _
        //   AddressOf Me.Application_BeginRequest

        //   AddHandler context.Error, _
        //   AddressOf Me.Application_Error

        //  AddHandler context.AcquireRequestState, _
        //   AddressOf Me.Application_AcquireRequestState

        context.PreRequestHandlerExecute += context_PreRequestHandlerExecute;
        context.Error += Application_Error;

    }


    public void context_PreRequestHandlerExecute(object sender, EventArgs e)
    {
        try
        {
            Page page = (Page)HttpContext.Current.CurrentHandler;
            if ((page != null))
            {
                page.PreInit += page_PreInit;

            }
        }

        catch (Exception ex)
        {

        }

    }

    public void page_PreInit(object sender, EventArgs e)
    {

        Page page = (Page)HttpContext.Current.CurrentHandler;

        //Page page = (Page)sender;
        // HttpContext.Current.Response.Write(sf.cadena(page.Title));
        //En webconfig esta la lista de portales, se numeran segun el orden.
        ctes.initData();
        page.Title = ctes.tituloPortal;


        string pagina = page.ToString();

        // si estamos en /admin controlamos el tema del login
        //if (pagina.Contains("admin") && !pagina.Contains("login"))
        //{
        //    if (HttpContext.Current.Session["turismoConsultasSqlServer"] == null)
        //    {
        //        HttpContext.Current.Response.Redirect("/admin/login/login.aspx");
        //    }            
        //}

        if (page.Theme == null)
        {
            if ((pagina.Contains("admin")))
            {
                page.Theme = "admin";
            }
            else
            {
                page.Theme = "normal";
            }

        }
        if ((page.Session["tamanio"] != null))
        {
            page.Theme = "normal" + page.Session["tamanio"];
        }
        if (page.Session["version"] != null)
        {
            if (sf.cadena(page.Session["version"]) == "texto")
            {
                if (page.Session["tamanio"] == null)
                    page.Theme = page.Session["version"].ToString();
                else
                    page.Theme = page.Session["version"].ToString() + page.Session["tamanio"].ToString();

            }
            else
            {
                if (page.Session["tamanio"] == null)
                    page.Theme = page.Session["version"].ToString();
                else
                    page.Theme = page.Session["version"].ToString() + page.Session["tamanio"].ToString();
            }
        }







    }


    public void InitializeCulture(object sender, EventArgs e)
    {
        Page page = (Page)sender;
        System.Globalization.CultureInfo lang;
        //If Not Request("idioma") Is Nothing Then
        //    page.Session["idioma"] = Request("idioma")
        //Else
        if (page.Session["idioma"] == null)
        {
            page.Session["idioma"] = "1";
        }
        //End If

        if ((page.Session["idioma"] != null))
        {
            try
            {
                switch ((int)page.Session["idioma"])
                {
                    case 2:
                        lang = new System.Globalization.CultureInfo("en-US", false);
                        break;
                    case 3:
                        lang = new System.Globalization.CultureInfo("fr-FR", false);
                        break;
                    default:
                        lang = new System.Globalization.CultureInfo("es-ES", false);
                        break;
                }
                System.Threading.Thread.CurrentThread.CurrentCulture = lang;
                System.Threading.Thread.CurrentThread.CurrentUICulture = lang;
            }

            catch (Exception ex)
            {
                // Response.Write(ex.Message)
            }
        }
    }
    public void Application_BeginRequest(object sender, EventArgs e)
    {

        // para poder utilizar context..
        HttpApplication aplicacion = (HttpApplication)sender;
        HttpContext contexto = aplicacion.Context;
        // contexto.Response.Write("<h3><font color=red>HelloWorldModule: Beginning of Request</font></h3><hr>")

    }
    public void Application_Error(object sender, EventArgs e)
    {
        //// Se desencadena cuando ocurre un error
        try
        {



            System.Exception ex;

            ex = HttpContext.Current.Server.GetLastError();
            //if (sf.cadena(HttpContext.Current.Request.Url.AbsoluteUri).Contains("images") & (sf.cadena(ex.ToString()).Contains("El archivo no existe")))
            if ((sf.cadena(ex.ToString()).Contains("El archivo no existe")))
            {

            }
            else
            {
                if (sf.cadena(HttpContext.Current.Request.Url.AbsoluteUri).Contains("portal/feeds"))
                { }
                else
                    lo.tratarError(ex, "Error general capturado en moduloSeguro.", "");
            }
            // con esto evito el dichoso mensajito al arrancar el visual studio
        }

        // no salta a error.aspx en el web.config

        //HttpContext.Current.Server.ClearError()

        catch (System.Exception ex3)
        {
        }

    }
}
