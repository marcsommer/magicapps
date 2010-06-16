using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


// para fechaEspanola
using System.Globalization; 



// clase que utilizamos a la hora de leer de la base 
// de datos para evitar problemas

public class sf
{



    #region "PreparaObjeto"
    //         esta funcion arregla los datos para que no haya ningun null
    //         util a la hora de hacer un update
    public void preparaObjeto(object objeto)
    {
        try
        {
            int contador = 0;
            //System.Reflection.PropertyInfo pi;

            foreach (System.Reflection.PropertyInfo pi in objeto.GetType().GetProperties())
            {

                if (pi.CanWrite)
                {

                    switch (pi.PropertyType.ToString())
                    {
                        case "System.string":
                            if (pi.GetValue(this, null) == null)
                            {
                                pi.SetValue(this, "", null);
                            }
                            break;
                        case "System.bool":
                            if (pi.GetValue(this, null) == null)
                            {
                                pi.SetValue(this, false, null);
                            }
                            break;
                        case "System.int32":
                            if (pi.GetValue(this, null) == null)
                            {
                                pi.SetValue(this, 0, null);
                            }
                            break;
                        case "System.int64":
                            if (pi.GetValue(this, null) == null)
                            {
                                pi.SetValue(this, 0, null);
                            }
                            break;
                        case "System.double":
                            if (pi.GetValue(this, null) == null)
                            {
                                pi.SetValue(this, 0, null);
                            }
                            break;
                        case "System.single":
                            if (pi.GetValue(this, null) == null)
                            {
                                pi.SetValue(this, 0.0, null);
                            }
                            break;

                        case "System.DateTime":
                            if (pi.GetValue(this, null) == null)
                            {
                                pi.SetValue(this, System.DateTime.MinValue, null);
                            }
                            break;
                    }


                }
            }
        }
        catch (System.Exception ex)
        {
        }

    }
    #endregion



    #region "Numericos"

    public static float aFloat(string valor)
    {
        try
        {
            if (valor == "")
                return (float)0.0; //Single.MinValue
            else
            {
                float salida;
                valor = valor.Replace(".", ",");
                float.TryParse(valor, out  salida);
                return salida;

            }
        }
        catch (System.Exception ex)
        {
            return (float)0.0; //Single.MinValue
        }

    }

    public static float aFloat(int valor)
    {
        try
        {
            if (valor == 0)
                return (float)0.0; //Single.MinValue
            else
                return System.Convert.ToSingle(valor);

        }
        catch (System.Exception ex)
        {
            return (float)0.0; //Single.MinValue
        }
    }


    public static float aFloat(float valor)
    {
        if (valor == float.MinValue)
            return 0;
        else
            return (valor);

    }


    public static int entero(string valor)
    {
        int salida = 0;
        int.TryParse(valor, out salida);
        return salida;

    }

    public static int entero(double valor)
    {
        return System.Convert.ToInt32(valor);

    }
    public static int entero(object valor)
    {

        int salida = 0;
        int.TryParse(valor.ToString(), out salida);


        return salida;
        //if (valor == null)
        //{
        //    return 0;
        //}
        //else
        //{
        //    return System.Convert.ToInt32(valor);

        //}

        //try
        //{
        //    return System.Convert.ToInt32(valor);
        //}
        //catch (Exception)
        //{

        //    return 0;
        //}
       
    }
    public static int entero(System.DBNull valor)
    {
        return 0;
    }


    public static int entero(bool valor)
    {

        try
        {
            if (valor == true)
                return 1;
            else
                return 0;
        }
        catch (System.Exception ex)
        {
            return 0;
        }

    }

    public static double doble(double valor)
    {
        return System.Convert.ToDouble(valor);
    }


    public static double doble(string valor)
    {
        double salida;
        double.TryParse(valor, out  salida);
        return salida;

    }

    public static double doble(bool valor)
    {
        return System.Convert.ToDouble(valor);
    }
   
    public static double doble(object valor)
    {
        return Math.Round(System.Convert.ToDouble(valor), 4);
    }


    public static long toLong(string valor)
    {
        long salida;
        long.TryParse(valor, out  salida);
        return salida;
    }

    #endregion


    #region "Fechas"

    public static System.DateTime Fecha(string valor)
    {
        System.DateTime retorno;
        System.DateTime.TryParse(valor, out retorno);

        return retorno;

    }



    //        ' el system.dbnull ya lo controla el tryparse
    //        'public static Function Fecha(ByVal valor As System.DBNull) As Date
    //        '    Dim retorno = newDate
    //        '    Date.TryParse(valor, retorno)
    //        '    return retorno


    //        '    try
    //        '        ' nos aseguramos que vaya a español
    //        '        Dim culture As CultureInfo = New CultureInfo("es-ES")

    //        '        return Date.MinValue

    //        '    catch ex As System.Exception
    //        '        return Date.MinValue
    //        '    }
    //        '}


    public static System.DateTime fecha(System.DateTime valor)
    {
        //System.DateTime retorno;
        //System.DateTime.TryParse(valor, out  retorno);

        return System.Convert.ToDateTime(valor);


    }

    public static System.DateTime fecha(String valor)
    {
        System.DateTime retorno;
        System.DateTime.TryParse(valor, out  retorno);
        return retorno;
    }

    //        ' esta funcion devuelve la fecha en formato short
    //        ' devolvemos 01/01/1901 como fecha minima

    //        public static Function FechaCorta(ByVal valor As string) As string
    //            try
    //                if ( valor = "" )  {
    //                    return New Date(1901, 1, 1).ToShortDateString 'Date.MinValue.ToShortDateString
    //                else
    //                    return System.Convert.ToDateTime(valor).ToShortDateString
    //                }
    //            catch ex As System.Exception
    //                return New Date(1901, 1, 1).ToShortDateString 'Date.MinValue.ToShortDateString
    //            }
    //        }

    //        public static Function FechaCorta(ByVal valor As Date) As string
    //            try
    //                return valor.ToShortDateString
    //            catch ex As System.Exception
    //                return New Date(1901, 1, 1).ToShortDateString 'Date.MinValue.ToShortDateString
    //            }
    //        }

    //public static string fechaIso(string dte)
    //{
    //    //
    //    if (esFecha(dte))
    //    {
    //        if(dte.Length>10)
    //        dte = sf.Left(dte, 10);
    //      //  lo.enviarCorreoError(ctes.direccionCorreoErroresDestino, ctes.direccionCorreoErroresRemitente, dte, ctes.nombreAplicacion + " - PABLO fecha a introducir1. " + "");

    //        int dteDay, dteMonth, dteYear;
    //      int  x = 0;
    //      string mesx = "";
    //      string yearx = "";
    //      dteMonth = 1;
    //      dteDay = 1;
    //        while (dte[x] != '/' & x<10)
    //        {
    //            dteDay = sf.entero(sf.Left(dte, x+1));
    //            x++;
    //        }
    //        x++;

    //        while (dte[x] != '/' & x < 10)
    //        {
    //            mesx = mesx + dte[x].ToString();

    //            x++;
    //        }
    //        dteMonth = sf.entero(mesx);
    //        //dteDay = sf.entero(sf.Left(dte, 2));
    //        //dteMonth = sf.entero(sf.Right(sf.Left(dte, 5), 2));
    //        x =0;
    //        //while (dte[x] != '/' % x > 0)
    //        //{
    //        //    dteYear = sf.entero(sf.Left(dte, x + 1));
    //        //    x--;
    //        //}
    //        x = dte.Length-1;
    //        while (dte[x] != '/' & x >0 )
    //        {
    //            yearx = dte[x].ToString()+yearx  ;

    //            x--;
    //        }
    //        dteYear = sf.entero(yearx);
    //      // lo.enviarCorreoError(ctes.direccionCorreoErroresDestino, ctes.direccionCorreoErroresRemitente, dteYear + "-" + dteMonth + "-" + dteDay, ctes.nombreAplicacion + " - PABLO fecha a introducir2. " + "");

    //        return (dteYear + "-" + dteMonth + "-" + dteDay);
    //    }
    //    else
    //        return null;




    //}

    public static string fechaSql(string dte)
    {
        //
        if (esFecha(dte))
        {
            int dteDay, dteMonth, dteYear;
            dteDay = sf.entero(sf.Left(dte, 2));
            dteMonth = sf.entero(sf.Right(sf.Left(dte, 5), 2));
            dteYear = sf.entero(sf.Right(dte, 4));

            return (dteYear + "-" + dteMonth + "-" + dteDay);
        }
        else
            return null;




    }

    public static string fechaSql(int day, int month, int year)
    {
        //
        return (year + "-" + month + "-" + day);
    }

    public static string fechaSql(System.DateTime dte)
    {
        if (esFecha(dte))
        {
            return (dte.Year + "-" + dte.Month + "-" + dte.Day);
        }
        else
            return null;
    }


    public static string fechaMysql(System.DateTime dte)
    {
        if (esFecha(dte))
        {
            return (dte.Year + "-" + dte.Month + "-" + dte.Day);
        }
        else
            return null;
    }

    public static string fechaIso(System.DateTime dte)
    {
        ////
        //if ( esFecha(dte) )
        //{
        //    int  dteDay, dteMonth, dteYear;
        //    dteDay = dte.Day;
        //    dteMonth = dte.Month;
        //    dteYear = dte.Year;

        //    string dteMonthSt;
        //    string dtedaySt;
        //    //dteMonthSt = CStr(dteMonth + 100);
        //    //dtedaySt = CStr(dteDay + 100);

        //   return (dteYear + "-" + dteMonthSt.Substring(dteMonthSt.Length - 2, 2) + "-" + dtedaySt.Substring(dtedaySt.Length - 2, 2));
        //}
        //else
        //    return  null;

        //Version 2.0
        if (esFecha(dte))
        {

            return (dte.Year + "-" + dte.Month + "-" + dte.Day);
        }
        else
            return null;

    }




    //        ' funciones para sql server de fechas
    //        '--------------------------------------------
    //        '--------------------------------------------

    //        ' la insercion siempre con formato yyyymmdd hh:mm
    //        public static Function fechaSql(ByVal fecha As Date) As string
    //            try
    //                Dim cadena As string

    //                ' return Date.MinValue.ToString

    //                cadena = fecha.Year.ToString.PadLeft(4, "0") + fecha.Month.ToString.PadLeft(2, "0") + fecha.Day.ToString.PadLeft(2, "0") + " " + fecha.Hour.ToString.PadLeft(2, "0") + ":" + fecha.Minute.ToString.PadLeft(2, "0")
    //                return cadena
    //            catch ex As System.Exception
    //                ' devolvemos la cadena vacia ya que no se permite
    //                ' insertar del date.minvalue en formato iso, es
    //                ' mejor dejarlo en blanco que es lo mismo
    //                return ""

    //            }

    //        }

    //        ' la insercion siempre con formato yyyymmdd hh:mm
    //        public static Function fechaSqlCorta(ByVal fecha As Date) As string
    //            try
    //                Dim cadena As string

    //                ' return Date.MinValue.ToString

    //                cadena = fecha.Year.ToString.PadLeft(4, "0") + fecha.Month.ToString.PadLeft(2, "0") + fecha.Day.ToString.PadLeft(2, "0")
    //                return cadena
    //            catch ex As System.Exception
    //                ' devolvemos la cadena vacia ya que no se permite
    //                ' insertar del date.minvalue en formato iso, es
    //                ' mejor dejarlo en blanco que es lo mismo
    //                return ""

    //            }

    //        }

    public static bool esFecha(System.DateTime fecha)
    {
        try
        {
            switch (fecha.ToShortDateString().ToString())
            {
                case "01/01/0001":
                    return false;
                    break;
                case "01/01/1900":
                    return false;
                    break;
            }

            System.DateTime fechita = new System.DateTime();
            fechita = System.DateTime.Parse(fecha.ToString());


            return true;
        }
        catch (System.Exception ex)
        {
            return false;
        }

    }

    public static bool esFecha(string fecha)
    {
        try
        {
            switch (fecha)
            {
                case "01/01/0001":
                    return false;
                    break;
                case "01/01/1900":
                    return false;
                    break;
            }
            //Dim fechita As Date = New Date().Parse(fecha)
            System.DateTime fechita = new System.DateTime();
            fechita = System.DateTime.Parse(fecha.ToString());


            return true;
        }
        catch (System.Exception ex)
        {
            return false;
        }

    }
    //public static string quitarhora(string fecha)
    //{
    //    try
    //    {

    //        fecha = Left(fecha, 10);


    //    }
    //    catch (System.Exception ex)
    //    {

    //    }
    //    return fecha;
    //}
    public static string Left(string param, int length)
    {
        //we start at 0 since we want to get the characters starting from the
        //left and with the specified lenght and assign it to a variable
        if (param != "")
        {
            string result = param.Substring(0, length);
            return result;
        }
        else
            return "";
        //return the result of the operation

    }
    public static string Right(string param, int length)
    {
        //start at the index based on the lenght of the sting minus
        //the specified lenght and assign it a variable
        string result = param.Substring(param.Length - length, length);
        //return the result of the operation
        return result;
    }
    //        public static Function fechaSql(ByVal fecha As string) As string
    //            try

    //                Select case fecha
    //                    case "01/01/0001", "01/01/1900", ""
    //                        return ""
    //                End Select



    //                ' primera comprobacion
    //                Dim fechita As Date = Date.Parse(fecha)

    //                ' sql server no admite años anteriores a 1700
    //                if ( fechita.Year < 1700 )  {
    //                    return ""
    //                }


    //                Dim cadena As string
    //                cadena = fechita.Year.ToString.PadLeft(4, "0") + fechita.Month.ToString.PadLeft(2, "0") + fechita.Day.ToString.PadLeft(2, "0") + " " + fechita.Hour.ToString.PadLeft(2, "0") + ":" + fechita.Minute.ToString.PadLeft(2, "0")



    //                return cadena
    //            catch ex As System.Exception
    //                return ""
    //            }

    //        }

    //        ' siempre esperamos dd-mm-yyyy formato 105 de convert de sql server
    //        public static Function sqlFecha(ByVal fecha As string) As Date
    //            try
    //                Dim fechita = newDate(sf.entero(fecha.Substring(6, 4)), sf.entero(fecha.Substring(3, 2)), sf.entero(fecha.Substring(0, 2)))



    //                return fechita
    //            catch ex As System.Exception
    //                return Date.MinValue
    //            }

    //        }

    //        public static Function fechaEspanola(ByVal fecha As Date) As Date
    //            try
    //                Dim culture As CultureInfo = New CultureInfo("es-ES")
    //                return System.Convert.ToDateTime(fecha, culture)
    //            catch ex As System.Exception
    //                return Date.MinValue
    //            }

    //        }
    #endregion


    #region "cadenas"


    public static string SafeSql(string inputSQL)
    {
        string s = inputSQL;
        s = inputSQL.Replace("'", "''");
        s = s.Replace("[", "[[]");
        s = s.Replace("_", "[_]");
        return s;
    }
    public static string SafeSqlUDP(string inputSQL)
    {
        string s = inputSQL;
        s = inputSQL.Replace("'", "");
        s = s.Replace("`", "");
        s = s.Replace("’", "");
        s = s.Replace("´", "");
        return s;
    }
    public static string moneda2(string valor)
    {
        int x = 0;
        bool primera;
        primera = false;
        valor = valor.Replace(".", ",");
        if (valor[0] != ',')
        {
            while (valor.Length > x)
            {
                if (valor[x] == ',')
                {
                    if (primera)
                        valor = sf.Left(valor, x);
                    else
                        primera = true;
                }
                x += 1;
            }
        }
        else
            return "0";
        return valor;
    }
    public static string moneda(string valor)
    {
        int x = 0;
        bool primera;
        primera = false;
        valor = valor.Replace(",", ".");
        if (valor[0] != '.')
        {
            while (valor.Length > x)
            {
                if (valor[x] == '.')
                {
                    if (primera)
                        valor = sf.Left(valor, x);
                    else
                        primera = true;
                }
                x += 1;
            }
        }
        else
            return "0";
        return valor;
    }



    public static string cadena(double valor)
    {
        string a;
        a = System.Convert.ToString(valor);
        a.Replace("'", "");
        return a;
    }
    public static string cadena(object valor)
    {
        string a;
        a = System.Convert.ToString(valor);
        a.Replace("'", "");
        return a;
    }
    public static string cadena(string valor)
    {



        return System.Convert.ToString(valor);

    }



    public static string cadena(bool valor)
    {
        return System.Convert.ToString(valor);

    }

    public static string cadena(System.DBNull valor)
    {
        try
        {
            return "";
        }
        catch (System.Exception ex)
        {
            return "";
        }

    }
    public static string cadenaRecortada(string valor, int longitud)
    {
        try
        {
            valor = html2text(valor);

            if (longitud > valor.Length)
            {
                longitud = valor.Length;
            }

            return (valor.Substring(0, longitud) + " ...");
        }
        catch (System.Exception ex)
        {
            return "";
        }

    }
    public static string cadenaRecortada(System.DBNull valor, int longitud)
    {
        try
        {
            return "";
        }
        catch (System.Exception ex)
        {
            return "";
        }

    }


    //    ·················································
    //                Funciones HTML2TEXT
    //    ·················································

    public static string html2text(string html)
    {
        // start by completely removing all unwanted tags 
        html = System.Text.RegularExpressions.Regex.Replace(html, @"<[/]?(font|span|xml|del|ins|[ovwxp]:\w+)[^>]*?>", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        // then run another pass over the html (twice), removing unwanted attributes 
        html = System.Text.RegularExpressions.Regex.Replace(html, @"<([^>]*)(?:class|lang|style|size|face|[ovwxp]:\w+)=(?:'[^']*'|""[^""]*""|[^\s>]+)([^>]*)>", "<$1$2>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        html = System.Text.RegularExpressions.Regex.Replace(html, @"<([^>]*)(?:class|lang|style|size|face|[ovwxp]:\w+)=(?:'[^']*'|""[^""]*""|[^\s>]+)([^>]*)>", "<$1$2>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        return html;
    }


    public static string recortaTexto(string texto, int longitud)
    {
        if (texto.Length > longitud)
        {
            return texto.Substring(1, longitud);
        }
        else
        {
            return texto;
        }

    }
    public static string html2text2strict(string html)
    {

        return System.Text.RegularExpressions.Regex.Replace(html, @"<(.|\n)*?>", string.Empty);


    }
    #endregion

    #region "boolean"

    public static bool boolean(string valor)
    {

        bool reto = false;

        bool.TryParse(valor, out reto);

        return reto;

    }

    public static string BoolToString(bool valor)
    {
        if (valor)
            return "1";
        else
            return "0";

    }


    public static bool boolean(int valor)
    {

        try
        {

            return System.Convert.ToBoolean(valor);

        }

        catch (System.Exception ex)
        {

            return false;

        }

    }

    public static bool boolean(System.DBNull valor)
    {

        try
        {

            return false;

        }

        catch (System.Exception ex)
        {

            return false;

        }

    }

    public static bool boolean(bool valor)
    {

        return valor;

    }

    public static bool boolean(object valor)
    {

        try
        {
            if (valor.ToString().Equals("YES"))
                return true;

            if (valor.ToString().Equals("NO"))
                return false;

            return System.Convert.ToBoolean(valor);

        }

        catch (System.Exception ex)
        {

            return false;

        }

    }

    #endregion

}




