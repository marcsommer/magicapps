using System.Web.SessionState;
using System.IO;

// para leer web.config
using System.Configuration;


public static class ctes
{

    public static bool mostrarErrores = true;

    public static string ErroresDireccionCorreoDestino;
    public static string ErroresDireccionCorreoRemitente;
    public static string ErroresServidorSmtp;
    public static string ErroresUsuarioSmtp;
    public static string ErroresClaveSmtp;

    public static string AsociacionDireccionCorreoDestino;
    public static string AsociacionDireccionCorreoRemitente;
    public static string AsociacionServidorSmtp;
    public static string AsociacionUsuarioSmtp;
    public static string AsociacionClaveSmtp;


    public static string Portal;
    public static string tituloPortal;
    public static string nombreAplicacion;

    public static tipoBd tipoBaseDatos = tipoBd.mysql;
    public static bool cteError;
    public static string ultimoError = "";
    public static string conStringAdoGeneral;

    public static void initData()
    {
        if (ErroresDireccionCorreoDestino == null)
        {
            mostrarErrores = sf.boolean(System.Web.Configuration.WebConfigurationManager.AppSettings["mostrarErrores"]);
            ErroresDireccionCorreoDestino = System.Web.Configuration.WebConfigurationManager.AppSettings["ErroresDireccionCorreoDestino"];
            ErroresDireccionCorreoRemitente = System.Web.Configuration.WebConfigurationManager.AppSettings["ErroresDireccionCorreoRemitente"];
            ErroresServidorSmtp = System.Web.Configuration.WebConfigurationManager.AppSettings["ErroresServidorSmtp"];
            ErroresUsuarioSmtp = System.Web.Configuration.WebConfigurationManager.AppSettings["ErroresUsuarioSmtp"];
            ErroresClaveSmtp = System.Web.Configuration.WebConfigurationManager.AppSettings["ErroresClaveSmtp"];

            AsociacionDireccionCorreoDestino = System.Web.Configuration.WebConfigurationManager.AppSettings["AsociacionDireccionCorreoDestino"];
            AsociacionDireccionCorreoRemitente = System.Web.Configuration.WebConfigurationManager.AppSettings["AsociacionDireccionCorreoRemitente"];
            AsociacionServidorSmtp = System.Web.Configuration.WebConfigurationManager.AppSettings["AsociacionServidorSmtp"];
            AsociacionUsuarioSmtp = System.Web.Configuration.WebConfigurationManager.AppSettings["AsociacionUsuarioSmtp"];
            AsociacionClaveSmtp = System.Web.Configuration.WebConfigurationManager.AppSettings["AsociacionClaveSmtp"];
            
            Portal = System.Configuration.ConfigurationManager.AppSettings["portal"];
            tituloPortal = System.Configuration.ConfigurationManager.AppSettings["tituloPortal"];
            nombreAplicacion = System.Configuration.ConfigurationManager.AppSettings["nombreAplicacion"];

            conStringAdoGeneral = System.Web.Configuration.WebConfigurationManager.AppSettings["conStringAdoGeneral"].ToString();

        }
    }



    #region " Enumerados "


    public enum RolesSeguridad
    {
        admin = 8,
        otros = 4
    };

    public enum eTipoCampo
    {
        id = 0,
        texto = 1,
    };

    public enum tipoBd
    {
        access = 1,
        mysql = 0,
        sqlServer = 2,
    };

    #endregion
}