using System.Web.SessionState;
using System.IO;

// para leer web.config
using System.Configuration;


public class ctes
{

    public static bool mostrarErrores = true;

    public static string direccionCorreoErroresDestino = "";
    public static string direccionCorreoErroresRemitente = "";

    public static string direccionCorreoasociacionDestino = "";
    public static string direccionCorreoasociacionRemitente = "";

    public static string servidorSmtpErrores = "";
    public static string servidorSmtpasociacion = "";

    public static string Portal = "";
    public static string tituloPortal = "";
    public static string nombreAplicacion = "prueba-mvc";
    public static string user = "";

    public static tipoBd tipoBaseDatos = tipoBd.mysql;
    public static bool cteError;
    public static string ultimoError = "";

     public static string conStringAdoGeneral = "Data Source=192.168.10.135\\SQL2005;Network Library=DBMSSOCN;Initial Catalog=portalMvc;User ID=sa;Password=santa25;";
   // public static string conStringAdoEmpleo = System.Web.Configuration.WebConfigurationManager.AppSettings["conStringAdoEmpleo"].ToString();


    public static string brevesRSS = "";
    public static string modoVision = "normal";


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