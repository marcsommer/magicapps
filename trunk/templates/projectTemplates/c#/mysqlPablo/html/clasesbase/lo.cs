using System;
using System.IO;
using System.Web;

using System.Net;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data;
// para el correo
using System.Web.Mail;
using MySql.Data.MySqlClient;
// para construirmensajeerror
using System.Text;
using System.Globalization;

public class lo
{
    public static int Int(string Number)
    {
        int i = 0;
        int salida = 0;
        bool salir = false;
        bool sindecimal = false;
        while (i < Number.Length & salir != true)
        {
            if (Number[i] == ',')
                salir = true;
            i++;
            if (i == Number.Length)
            {
                i = 0;
                sindecimal = true;
                salir = true;
            }
        }
        if (sindecimal) salida = sf.entero(Number);
        else salida = sf.entero(sf.Left(Number, i - 1));
        return salida;
    }
    public static string RedondearEmp(string Numero)
    {
        string ReEmp;
        string ParteDecimal;
        int ndecimales;
        string user;
        string tx;
        bool negativa;
        negativa = false;
        double numx;
        if (sf.Doble(Numero) < 0)
        {
            negativa = true;
            Numero = sf.cadena(sf.entero(Numero) * -1);
        }
        string ParteEntera;
        ParteEntera = sf.cadena(Int(Numero));
        numx = sf.Doble(Numero);
        Numero = sf.cadena(numx);
        ParteDecimal = "";
        ndecimales = 2;
        // ndecimales = empresa.getdecimales();
        if (!(sf.Right(Numero, 1) == ","))
        {
            if (!(Int(Numero) == sf.entero(Numero)) | sf.entero(ParteEntera) == 0)
            {
                if (!(Numero.Length == ParteEntera.Length))
                {
                    ParteDecimal = sf.Right(Numero, Numero.Length - ParteEntera.Length - 1);
                }
                double Num;
                if (ParteDecimal.Length >= ndecimales + 1)
                {
                    ParteDecimal = sf.Left(ParteDecimal, ndecimales + 1);
                    if (sf.entero(ParteDecimal.Substring(ndecimales, 1)) >= 6)
                    {
                        ParteDecimal = sf.Left(ParteDecimal, ndecimales);
                        if (sf.Left(ParteDecimal, 1) == "0")
                        {
                            int numer;
                            numer = sf.entero(sf.Right(ParteDecimal, ndecimales));
                            numer = numer + 1;
                            ParteDecimal = sf.Left(ParteDecimal, ndecimales - 1) + sf.cadena(numer);
                        }
                        else
                        {
                            Num = Convert.ToUInt64(ParteDecimal);
                            Num = Num + 1;
                            ParteDecimal = sf.cadena(Num);
                        }
                    }
                }
                if (ParteDecimal.Length > ndecimales)
                    ParteDecimal = sf.Left(ParteDecimal, ndecimales);
                int x;
                x = 1;

                while (ParteDecimal.Length < ndecimales)
                {
                    ParteDecimal += "0";
                    x = x + 1;
                }
                ReEmp = ParteEntera + "," + ParteDecimal;
            }
            else
            {
                int i;
                ParteDecimal = "";
                for (i = 1; i == ndecimales; i++)
                    ParteDecimal += "0";


                int x;
                x = 1;
                while (ParteDecimal.Length < ndecimales)
                {
                    ParteDecimal += "0";
                    x = x + 1;
                }
                ReEmp = Numero + "," + ParteDecimal;
            }
        }
        else
        {
            Numero = Numero.Substring(0, Numero.Length - 1);
            int i = 0;
            ParteDecimal = "";
            for (i = 1; i == ndecimales; i++)
                ParteDecimal += "0";
            int x;
            x = 1;
            while (ParteDecimal.Length < ndecimales)
            {
                ParteDecimal += "0";
                x = x + 1;
            }
            ReEmp = Numero + "," + ParteDecimal;

        }
        if (negativa)
        {
            ReEmp = sf.cadena(sf.entero(ReEmp) * -1);
        }
        return ReEmp;
    }

    public static void attachFile(string filex)
    {

        System.IO.FileInfo file = new System.IO.FileInfo(HttpContext.Current.Server.MapPath(Path.Combine("../../bddocumentos/", filex)));

        if (file.Exists)
        {

            HttpContext.Current.Response.Clear();

            HttpContext.Current.Response.ContentType = "application/octet-stream";

            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name + "");

            HttpContext.Current.Response.Flush();

            HttpContext.Current.Response.WriteFile(HttpContext.Current.Server.MapPath(Path.Combine("../../bddocumentos/", filex)));

            HttpContext.Current.Response.End();

        }

        file = null;

    }
    public static string Redondear(string Numero)
    {

        string ReEmp;
        string ParteDecimal;
        int ndecimales;
        string user;
        string tx;
        bool negativa;
        negativa = false;
        double numx;
        if (sf.Doble(Numero) < 0)
        {
            negativa = true;
            Numero = sf.cadena(sf.entero(Numero) * -1);
        }
        string ParteEntera;
        ParteEntera = sf.cadena(Int(Numero));
        numx = sf.Doble(Numero);
        Numero = sf.cadena(numx);
        ParteDecimal = "";
        ndecimales = 2;//empresa.getDecimal;
        if (!(sf.Right(Numero, 1) == ","))
        {
            //mal
            if (!(Int(Numero) == sf.Doble(Numero)))
            //mal
            {
                if (!(Numero.Length == ParteEntera.Length))
                {
                    ParteDecimal = sf.Right(Numero, Numero.Length - ParteEntera.Length - 1);
                }
                double Num;
                if (ParteDecimal.Length >= ndecimales + 1)
                {
                    ParteDecimal = sf.Left(ParteDecimal, ndecimales + 1);
                    if (sf.entero(ParteDecimal.Substring(ndecimales, 1)) >= 6)
                    {
                        ParteDecimal = sf.Left(ParteDecimal, ndecimales);
                        if (sf.Left(ParteDecimal, 1) == "0")
                        {
                            int numer;
                            numer = sf.entero(sf.Right(ParteDecimal, ndecimales));
                            numer = numer + 1;
                            ParteDecimal = sf.Left(ParteDecimal, ndecimales - 1) + sf.cadena(numer);
                        }
                        else
                        {
                            Num = Convert.ToUInt64(ParteDecimal);
                            Num = Num + 1;
                            ParteDecimal = sf.cadena(Num);
                        }
                    }
                }
                if (ParteDecimal.Length > ndecimales)
                    ParteDecimal = sf.Left(ParteDecimal, ndecimales);
                int x;
                x = 1;

                while (ParteDecimal.Length < ndecimales)
                {
                    ParteDecimal += "0";
                    x = x + 1;
                }
                ReEmp = ParteEntera + "," + ParteDecimal;
            }
            else
            {
                int i;
                ParteDecimal = "";
                for (i = 1; i == ndecimales; i++)
                    ParteDecimal += "0";


                int x;
                x = 1;
                while (ParteDecimal.Length < ndecimales)
                {
                    ParteDecimal += "0";
                    x = x + 1;
                }
                ReEmp = Numero + "," + ParteDecimal;
            }
        }
        else
        {
            Numero = Numero.Substring(0, Numero.Length - 1);
            int i = 0;
            ParteDecimal = "";
            for (i = 1; i == ndecimales; i++)
                ParteDecimal += "0";
            int x;
            x = 1;
            while (ParteDecimal.Length < ndecimales)
            {
                ParteDecimal += "0";
                x = x + 1;
            }
            ReEmp = Numero + "," + ParteDecimal;

        }
        if (negativa)
        {
            ReEmp = sf.cadena(sf.entero(ReEmp) * -1);
        }
        return ReEmp;
    }

    /*   
     public static bool VALIDA_CC(string ENTIDAD , string sucursal ,string DC,string CC)
     {
         int suma ;
         int[] Pesos = {4,8,5,10,9,7,3,6};
         string Primera_Parte , Segunda_Parte ;
         string Primer_Digito , Segundo_Digito ;
         string DC_2;
         byte I ;
         ReDim Pesos[8];

         Pesos[0] = 4;
         Pesos[1] = 8;
         Pesos[2] = 5;
         Pesos[3] = 10;
         Pesos[4] = 9;
         Pesos[5] = 7,
         Pesos[6] = 3;
         Pesos[7] = 6;


         suma = 0;

      //   '  *********PRIMERA PARTE**********

         Primera_Parte = ENTIDAD + sucursal;
         for (I = 0; I == 7; I++) {   
             suma = suma + (sf.Doble(Mid(Primera_Parte, I + 1, 1)) * Pesos(I));
         }

         string resto;
         resto = sf.cadena(arriba % abajo);
         int a = suma%11;
         string aw;
         aw = "a";
         return true;
        // Primer_Digito = Trim(Str(11 - (suma 11)));

         if (Primer_Digito = "10")
             Primer_Digito = "1";
         else
             {
             if (Primer_Digito = "11")
                 Primer_Digito = "0";
             }
        

         //' ********* SEGUNDA PARTE **************
         Segunda_Parte = CC    'CC: Cuenta corriente
         ReDim Pesos(10)

         Pesos(0) = 1
         Pesos(1) = 2
         Pesos(2) = 4
         Pesos(3) = 8
         Pesos(4) = 5
         Pesos(5) = 10
         Pesos(6) = 9
         Pesos(7) = 7
         Pesos(8) = 3
         Pesos(9) = 6
         suma = 0
         For I = 0 To 9
             suma = suma + (Val(Mid(Segunda_Parte, I + 1, 1)) * Pesos(I))
         Next
         Segundo_Digito = Trim(Str(11 - (suma Mod 11)))

         If Segundo_Digito = "10" Then
             Segundo_Digito = "1"
         Else
             If Segundo_Digito = "11" Then
                 Segundo_Digito = "0"
             End If
         End If

         DC_2 = Primer_Digito & Segundo_Digito


         If DC <> DC_2 Then
             VALIDA_CC = False
         Else
             VALIDA_CC = True
         End If


    
     }*/





    #region "Funciones para listbox"
    // listas - listbox
    void ListboxVaciar(System.Web.UI.WebControls.ListBox pp)
    {
        pp.Items.Clear();
    }



    void ListboxRellenar2(System.Web.UI.WebControls.ListBox tmpList, string textoSql, string nombreCampoValor, string nombreCampoTExto)
    {
        //dbClass pp = new dbClass(ctes.conStringAdoGeneral);
        //DataSet reg;
        //try
        //{
        //    reg = new DataSet( pp.sql(textoSql));
        //    do {

        //        ListItem it = new System.Web.UI.WebControls.ListItem();
        //        it.Text = reg[nombreCampoTExto];
        //        it.Value = reg[nombreCampoValor];
        //        tmpList.Items.Add(it);

        //    }while (reg.Read);
        //    reg.Close();
        //}
        //catch (Exception ex)
        //{
        //}
        //finally
        //{
        //    pp.Dispose();
        //    }


    }
    /*
        Public Function listBoxValorSEleccionado(ByRef tmpList As System.Web.UI.WebControls.ListBox, Optional ByVal tipoCampo As eTipoCampo = ctes.eTipoCampo.id) As String
            ' Me da el text/id del elemento seleccionado según el parámetro tipoCampo
            Dim retorno As String

            If (tmpList.SelectedIndex < 0) Then
                retorno = "-1"
            Else
                If (tipoCampo = ctes.eTipoCampo.id) Then
                    retorno = tmpList.SelectedItem.Value '.SelectedIndex 'SelectedValue
                Else
                    retorno = tmpList.SelectedItem.Text

                End If
            End If

            If (retorno = "") Then
                retorno = "-1"
            End If

            Return (retorno)
        End Function


        Public Function ListBoxisEmpty(ByRef tmpList As System.Web.UI.WebControls.ListBox) As Boolean
            ' Me devuevel el estado del combo
            Dim retorno As Boolean

            If (tmpList.Items.Count <= 0) Then
                retorno = True
            Else
                retorno = False
            End If

            Return (retorno)
        End Function

        Public void listBoxSeleccionarItem(ByRef tmpList As System.Web.UI.WebControls.ListBox, ByVal cadBusqueda As String, Optional ByVal tipoCampo As eTipoCampo = ctes.eTipoCampo.id)
            ' Busca el nodo que me dan y le colocan el focus
            Dim index As Integer

            Dim cont As Integer
            Dim pos As Integer
            Dim seguir As Boolean

            Dim tmpItem As String = ""

            index = -1
            cont = 0
            seguir = True
            If Not (ListBoxisEmpty(tmpList)) Then


                Do While (cont < tmpList.Items.Count) And (seguir)
                    Select Case tipoCampo
                        Case ctes.eTipoCampo.id
                            pos = 0
                            tmpItem = tmpList.Items(cont).Value
                        Case eTipoCampo.texto
                            pos = 1
                            tmpItem = tmpList.Items(cont).Text
                    End Select

                    If tmpItem.ToLower = cadBusqueda.ToLower Then
                        index = cont
                        seguir = False
                    End If
                    cont = cont + 1
                Loop
            End If

            tmpList.SelectedIndex = index
            'tmpList.Items.FindByText(cadBusqueda).Selected = True '.Value()

        }*/
    #endregion


    /*
#Region "Funciones para combo-dropdownlist"
    ' ---------------------------------
    ' combos - dropdownlist


    Public Function comboIsEmpty(ByRef tmpList As System.Web.UI.WebControls.DropDownList) As Boolean
        ' Me devuevel el estado del combo
        Dim retorno As Boolean

        If (tmpList.Items.Count <= 0) Then
            retorno = True
        Else
            retorno = False
        End If

        Return (retorno)
    End Function




    void comboVaciar(ByVal pp As System.Web.UI.WebControls.DropDownList)
        Call pp.Items.Clear()
    }




    Public void comboSeleccionarItem(ByRef tmpList As System.Web.UI.WebControls.DropDownList, ByVal cadBusqueda As String, Optional ByVal tipoCampo As eTipoCampo = ctes.eTipoCampo.id)
        If Not cadBusqueda Is Nothing Then
            ' Busca el nodo que me dan y le colocan el focus
            Dim index As Integer

            Dim cont As Integer
            Dim pos As Integer
            Dim seguir As Boolean

            Dim tmpItem As String = ""

            index = -1
            cont = 0
            seguir = True
            If Not (comboIsEmpty(tmpList)) Then


                Do While (cont < tmpList.Items.Count) And (seguir)
                    Select Case tipoCampo
                        Case ctes.eTipoCampo.id
                            pos = 0
                            tmpItem = tmpList.Items(cont).Value
                        Case eTipoCampo.texto
                            pos = 1
                            tmpItem = tmpList.Items(cont).Text
                    End Select

                    If tmpItem.ToLower = cadBusqueda.ToLower Then
                        index = cont
                        seguir = False
                    End If
                    cont = cont + 1
                Loop
            End If

            tmpList.SelectedValue = tmpItem
            'tmpList.Items.FindByText(cadBusqueda).Selected = True '.Value()

        End If

    }
    Public void comboSeleccionarItem2(ByRef tmpList As System.Web.UI.WebControls.DropDownList, ByVal cadBusqueda As String, Optional ByVal tipoCampo As eTipoCampo = ctes.eTipoCampo.id)
        ' Busca el nodo que me dan y le colocan el focus
        Dim index As Integer

        Dim cont As Integer
        Dim pos As Integer
        Dim seguir As Boolean

        Dim tmpItem As String = ""

        index = -1
        cont = 0
        seguir = True
        If Not (comboIsEmpty(tmpList)) Then


            Do While (cont < tmpList.Items.Count) And (seguir)
                Select Case tipoCampo
                    Case ctes.eTipoCampo.id
                        pos = 0
                        tmpItem = tmpList.Items(cont).Text
                    Case eTipoCampo.texto
                        pos = 1
                        tmpItem = tmpList.Items(cont).Text
                End Select

                If tmpItem.ToLower = cadBusqueda.ToLower Then
                    index = cont
                    seguir = False
                End If
                cont = cont + 1
            Loop
        End If

        tmpList.SelectedValue = tmpItem
        'tmpList.Items.FindByText(cadBusqueda).Selected = True '.Value()

    }


*/
    public static string comboValorSeleccionado(ref System.Web.UI.WebControls.DropDownList tmpList)
    {
        // Me da el text/id del elemento seleccionado según el parámetro tipoCampo
        string retorno = "";
        try
        {
            if ((tmpList.SelectedIndex < 0))
            {
                retorno = "-1";
            }
            else
            {

                retorno = tmpList.SelectedItem.Value;

            }

            if ((retorno == ""))
            {
                retorno = "-1";
            }
        }

        catch (Exception ex)
        {
        }

        return (retorno);

    }

    public static string comboValorSeleccionado(ref System.Web.UI.WebControls.DropDownList tmpList, ctes.eTipoCampo tipoCampo)
    {
        // Me da el text/id del elemento seleccionado según el parámetro tipoCampo
        string retorno = "";
        try
        {
            if ((tmpList.SelectedIndex < 0))
            {
                retorno = "-1";
            }
            else
            {
                if ((tipoCampo == ctes.eTipoCampo.id))
                {
                    retorno = tmpList.SelectedItem.Value;
                    //.SelectedIndex 'SelectedValue
                }
                else
                {
                    retorno = tmpList.SelectedItem.ToString();

                }
            }

            if ((retorno == ""))
            {
                retorno = "-1";
            }
        }

        catch (Exception ex)
        {
        }

        return (retorno);

    }

    public static void comboRellenar(System.Web.UI.WebControls.DropDownList combo, string textoSql, string cadenaConexion, string mensajeInicial)
    {

        if (cadenaConexion == "" || cadenaConexion == null)
        {
            cadenaConexion = ctes.conStringAdoGeneral;
        }
        dbClass pp = new dbClass(cadenaConexion);
        try
        {
            combo.Items.Clear();

            MySql.Data.MySqlClient.MySqlDataReader reg;
            // 'SqlClient.SqlDataReader
            DataTable esquema;
            reg = pp.sql(textoSql);
            esquema = reg.GetSchemaTable();
            combo.DataSource = reg; //myDataReader
            combo.DataTextField = sf.cadena(esquema.Rows[1].ItemArray[0]);
            combo.DataValueField = sf.cadena(esquema.Rows[0].ItemArray[0]);
            //.Columns(1).ColumnName.ToString '.Item(0).ColumnName.ToString;
            //'"idlicencias" 'myDataReader.Fields(0).Name;
            combo.DataBind();
            //   mensajeInicial = "<Elija una opcion>";
            if (mensajeInicial != "")
            {
                ListItem per = new ListItem();
                per.Value = sf.cadena(0);
                per.Text = mensajeInicial;
                combo.Items.Insert(0, per);
            }


        }
        catch (Exception ex)
        {

            lo.tratarError(ex, "Error en lo.combo", textoSql);
        }
        finally
        {
            pp.Dispose();
        }


    }
    public static void comboRellenarExtra(System.Web.UI.WebControls.DropDownList combo, string textoSql, string cadenaConexion, string mensajeInicial, string mensajeFinal)
    {

        if (cadenaConexion == "" || cadenaConexion == null)
        {
            cadenaConexion = ctes.conStringAdoGeneral;
        }
        dbClass pp = new dbClass(cadenaConexion);
        try
        {
            combo.Items.Clear();

            MySql.Data.MySqlClient.MySqlDataReader reg;
            // 'SqlClient.SqlDataReader
            DataTable esquema;
            reg = pp.sql(textoSql);
            esquema = reg.GetSchemaTable();
            combo.DataSource = reg; //myDataReader
            combo.DataTextField = sf.cadena(esquema.Rows[1].ItemArray[0]);
            combo.DataValueField = sf.cadena(esquema.Rows[0].ItemArray[0]);
            //.Columns(1).ColumnName.ToString '.Item(0).ColumnName.ToString;
            //'"idlicencias" 'myDataReader.Fields(0).Name;
            combo.DataBind();
            //   mensajeInicial = "<Elija una opcion>";
            if (mensajeInicial != "")
            {
                ListItem per = new ListItem();
                per.Value = sf.cadena(0);
                per.Text = mensajeInicial;
                combo.Items.Insert(0, per);
            }
            if (mensajeFinal != "")
            {
                ListItem per = new ListItem();
                per.Value = sf.cadena(0);
                per.Text = mensajeFinal;
                combo.Items.Insert(combo.Items.Count, per);
            }


        }
        catch (Exception ex)
        {

            lo.tratarError(ex, "Error en lo.combo", textoSql);
        }
        finally
        {
            pp.Dispose();
        }


    }

    public static void comboRellenarSinInicial(System.Web.UI.WebControls.DropDownList combo, string textoSql, string cadenaConexion)
    {

        if (cadenaConexion == "" || cadenaConexion == null)
        {
            cadenaConexion = ctes.conStringAdoGeneral;
        }
        dbClass pp = new dbClass(cadenaConexion);
        try
        {
            combo.Items.Clear();

            MySql.Data.MySqlClient.MySqlDataReader reg;
            // 'SqlClient.SqlDataReader
            DataTable esquema;
            reg = pp.sql(textoSql);
            esquema = reg.GetSchemaTable();
            combo.DataSource = reg; //myDataReader
            combo.DataTextField = sf.cadena(esquema.Rows[1].ItemArray[0]);
            combo.DataValueField = sf.cadena(esquema.Rows[0].ItemArray[0]);
            //.Columns(1).ColumnName.ToString '.Item(0).ColumnName.ToString;
            //'"idlicencias" 'myDataReader.Fields(0).Name;
            combo.DataBind();
            //   mensajeInicial = "<Elija una opcion>";
        }
        catch (Exception ex)
        {

            lo.tratarError(ex, "Error en lo.combo", textoSql);
        }
        finally
        {
            pp.Dispose();
        }


    }
    public static void comboSeleccionarItem(System.Web.UI.WebControls.DropDownList tmpList, int cadBusqueda, string tipoCampo)
    {
        //Public Sub comboSeleccionarItem(ByRef tmpList As System.Web.UI.WebControls.DropDownList, ByVal cadBusqueda As String, Optional ByVal tipoCampo As eTipoCampo = ctes.eTipoCampo.id)

        int index;

        int cont;
        int pos;
        bool seguir;

        string tmpItem = "";
        string cadenaB = sf.cadena(cadBusqueda);
        index = -1;
        cont = 0;
        seguir = true;
        if (!comboIsEmpty(tmpList))
        {
            do
            {
                switch (tipoCampo)
                {
                    case "Id":
                        {
                            pos = 0;
                            tmpItem = tmpList.Items[cont].Value;
                            break;
                        }
                    case "Texto":
                        {
                            pos = 1;
                            tmpItem = tmpList.Items[cont].Text;
                            break;
                        }
                }
                string a = tmpItem.ToLower(new CultureInfo("en-US", false));
                string b = cadenaB.ToLower(new CultureInfo("en-US", false));

                if (a == b)
                {
                    index = cont;
                    seguir = false;
                }
                else
                {
                    cont = cont + 1;
                }
            }
            while (cont < tmpList.Items.Count && (seguir == true));
            tmpList.SelectedIndex = cont;
        }
    }
    public static void comboSeleccionarItem(System.Web.UI.WebControls.DropDownList tmpList, string cadBusqueda, string tipoCampo)
    {
        //Public Sub comboSeleccionarItem(ByRef tmpList As System.Web.UI.WebControls.DropDownList, ByVal cadBusqueda As String, Optional ByVal tipoCampo As eTipoCampo = ctes.eTipoCampo.id)

        int index;

        int cont;
        int pos;
        bool seguir;

        string tmpItem = "";

        index = -1;
        cont = 0;
        seguir = true;
        if (!comboIsEmpty(tmpList))
        {
            do
            {
                switch (tipoCampo)
                {
                    case "Id":
                        {
                            pos = 0;
                            tmpItem = tmpList.Items[cont].Value;
                            break;
                        }
                    case "Texto":
                        {
                            pos = 1;
                            tmpItem = tmpList.Items[cont].Text;
                            break;
                        }
                }
                string a = tmpItem.ToLower(new CultureInfo("en-US", false));
                string b = cadBusqueda.ToLower(new CultureInfo("en-US", false));

                if (a == b)
                {
                    index = cont;
                    seguir = false;
                }
                else
                {
                    cont = cont + 1;
                }
            }
            while (cont < tmpList.Items.Count && (seguir == true));
            tmpList.SelectedIndex = cont;
        }
    }
    public static bool comboIsEmpty(System.Web.UI.WebControls.DropDownList tmpList)
    {
        bool retorno;
        if (tmpList.Items.Count <= 0)
        {
            retorno = true;
        }
        else
        {
            retorno = false;
        }

        return (retorno);
    }
    /*}

    'esta sirve para cuando solo tenemos un campo, no dos,
    'el campo id se va rellenando con incrementos
    void comboRellenarConIdAuto(ByRef combo As System.Web.UI.WebControls.DropDownList, ByVal textoSql As String, ByVal cadenaConexion As String, ByVal campoClave As String, Optional ByVal mensajeInicial As String = "")


        ' Rellena la lista que me pasan con la select pasada
        ' pillo el primer campo que me pasan en la select para el campo texto
        ' pillo el segundo campo que me pasan en la select para el el campo value me pasan el campo a almacenar
        Dim contador As New Integer
        If cadenaConexion = "" Then cadenaConexion = ctes.conStringAdoGeneral
        Dim pp As New dbClass(cadenaConexion)
        Dim reg As System.Data.Odbc.OdbcDataReader
        'Object 'SqlClient.SqlDataReader



        Try
            If mensajeInicial <> "" Then
                Dim per As New ListItem
                per.Value = 0
                per.Text = mensajeInicial
                combo.Items.Insert(0, per)
                per = Nothing
            End If

            contador += 1
            reg = pp.sql(textoSql)
            Do While reg.Read()
                Dim per As New ListItem
                per.Value = contador
                per.Text = reg(campoClave).ToString
                combo.Items.Add(per)
                per = Nothing
                contador += 1
            Loop


        Catch ex As Exception
        Finally
            pp.dispose()
        End Try



    }
#End Region

*/

    public static void rellenarComboDB(ref System.Web.UI.WebControls.DropDownList tmpList, string textoSql, string connectionString)
    {

        // Rellena el combobox que me pasan con la select pasada

        // pillo el segundo campo que me pasan en la select para el campo texto

        // pillo el primer campo que me pasan en la select para el el campo value me pasan el campo a almacenar

        // version cambiada para que tire de dataset en vez de datareader

        tmpList.Items.Clear();

        dbClass pp = new dbClass(connectionString);

        try
        {

            DataSet ds = new DataSet();

            ds = pp.sqlDataset(textoSql);

            tmpList.DataSource = ds.Tables[0].DefaultView;

            tmpList.DataTextField = ds.Tables[0].Columns[1].ToString();

            tmpList.DataValueField = ds.Tables[0].Columns[0].ToString();

            tmpList.DataBind();

            ListItem per = new ListItem();

            per.Value = "0";

            per.Text = "Todos --";

            tmpList.Items.Insert(0, per);
            //(0, "Todos")

            ds = null;
        }

        catch (Exception ex)
        {
        }

        finally
        {

            pp.Dispose();

        }

    }


    #region "control de errores"

    public static void tratarError(Exception exc, string descripcion, string datos)
    {
        bool bot = false;
        ctes.mostrarErrores = false;//quitar
        if (ctes.mostrarErrores)
        {
            if (sf.cadena(HttpContext.Current.Request.ServerVariables["URL"]).Contains("chat"))
            {
                bot = true;
            }

            if (sf.cadena(HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"]).Contains("http://www.google.com/bot.html"))
            {
                bot = true;
            }
            if (sf.cadena(HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"]).Contains("http://help.yahoo.com/help/us/ysearch/slurp"))
            {
                bot = true;
            }
            if (sf.cadena(HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"]).Contains("http://search.msn.com/msnbot.htm"))
            {
                bot = true;
            }

            if (bot == false)
            {
                // HttpContext.Current.Response.Write(lo.construirMensajeError(exc, ""));
                lo.enviarCorreoError("errores@micasoft.com", "error@micasoft.com", lo.construirMensajeError(exc, datos), ctes.nombreAplicacion + " - error controlado. " + descripcion);
            }
            string pat = HttpContext.Current.Request.Url.Authority.ToString();

            HttpContext.Current.Response.Redirect("http://" + pat + "/error.aspx");
            // HttpContext.Current.Response.Redirect("../errorPage.aspx")

        }

        else
        {
            string pat = HttpContext.Current.Request.Url.Authority.ToString();

            //HttpContext.Current.Response.Redirect("http://" +pat+"/error_fede.aspx");
            //HttpContext.Current.Response.Write(lo.construirMensajeError(exc, datos));
            //HttpContext.Current.Response.End();
        }



        // ctes.ultimaExcepcion = exc



    }



    public static void enviarCorreo(string destinatario, string remitente, string texto, string asunto, string archivoAdjunto)
    {

        try
        {


            System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();

            correo.Subject = asunto;

            correo.Body = texto;

            correo.To.Add(destinatario);

            correo.From = new System.Net.Mail.MailAddress("no-responder@fedesp.es");

            correo.IsBodyHtml = true;

            if (archivoAdjunto != "")
            {
                System.Net.Mail.Attachment adjunto = new System.Net.Mail.Attachment(archivoAdjunto);
                correo.Attachments.Add(adjunto);
            }
            System.Net.Mail.SmtpClient Smtpx = new System.Net.Mail.SmtpClient();

            System.Net.NetworkCredential basicAuthenticationInfo = new NetworkCredential("no-responder@fedesp.es", "noreply1");

            Smtpx.Host = "mail.fedesp.es";

            Smtpx.UseDefaultCredentials = false;

            Smtpx.Credentials = basicAuthenticationInfo;

            Smtpx.Send(correo);

        }

        catch (Exception ex)
        {

            lo.tratarError(ex, "", "");
        }

    }



    public static void enviarCorreoError(string destinatario, string remitente, string texto, string asunto)
    {

        try
        {

            System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();

            correo.Subject = asunto;

            correo.Body = texto;

            correo.To.Add("errores@micasoft.com");

            correo.From = new System.Net.Mail.MailAddress("error@micasoft.com");

            correo.IsBodyHtml = true;

            System.Net.Mail.SmtpClient Smtpx = new System.Net.Mail.SmtpClient();

            System.Net.NetworkCredential basicAuthenticationInfo = new NetworkCredential("error@micasoft.com", "Error85");

            Smtpx.Host = "mail.micasoft.com";

            Smtpx.UseDefaultCredentials = false;

            Smtpx.Credentials = basicAuthenticationInfo;

            Smtpx.Send(correo);

        }

        catch (Exception ex)

        { }

    }

    public static string construirMensajeError(Exception exc, string cadenaSql)
    {

        System.Web.UI.Page pagina = new System.Web.UI.Page();



        StringBuilder strMessage = new StringBuilder();

        try
        {


            strMessage.Append("<style type=" + "text/css" + ">");

            strMessage.Append("<!--");

            strMessage.Append(".basix {");

            strMessage.Append("font-family: Verdana, Arial, Helvetica, sans-serif;");

            strMessage.Append("font-size: 12px;");

            strMessage.Append("}");

            strMessage.Append(".header1 {");

            strMessage.Append("font-family: Verdana, Arial, Helvetica, sans-serif;");

            strMessage.Append("font-size: 12px;");

            strMessage.Append("font-weight: bold;");

            strMessage.Append("color: #000099;");

            strMessage.Append("}");

            strMessage.Append(".tlbbkground1 {");

            strMessage.Append("background-color: #000099;");

            strMessage.Append("}");

            strMessage.Append("-->");

            strMessage.Append("</style>");

            strMessage.Append("<table width=" + "85%" + " border=" + "0" + " align=" + "center" + " cellpadding=" + "5" + " cellspacing=" + "1" + " class=" + "tlbbkground1" + ">");

            strMessage.Append("<tr bgcolor=" + "#eeeeee" + ">");

            strMessage.Append("<td colspan=" + "2" + " class=" + "header1" + ">Page Error</td>");

            strMessage.Append("</tr>");

            strMessage.Append("<tr>");

            strMessage.Append("<td width=" + "100" + " align=" + "right" + " bgcolor=" + "#eeeeee" + " class=" + "header1" + " nowrap>IP Address</td>");

            strMessage.Append("<td bgcolor=" + "#FFFFFF" + " class=" + "basix" + ">" + HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] + "</td>");

            strMessage.Append("</tr>");

            strMessage.Append("<tr>");

            strMessage.Append("<td width=" + "100" + " align=" + "right" + " bgcolor=" + "#eeeeee" + " class=" + "header1" + " nowrap>User Agent</td>");

            strMessage.Append("<td bgcolor=" + "#FFFFFF" + " class=" + "basix" + ">" + HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"] + "</td>");

            strMessage.Append("</tr>");

            strMessage.Append("<tr>");

            strMessage.Append("<td width=" + "100" + " align=" + "right" + " bgcolor=" + "#eeeeee" + " class=" + "header1" + " nowrap>Page</td>");

            strMessage.Append("<td bgcolor=" + "#FFFFFF" + " class=" + "basix" + ">" + HttpContext.Current.Request.Url.AbsoluteUri + "</td>");

            strMessage.Append("</tr>");

            strMessage.Append("<tr>");

            strMessage.Append("<td width=" + "100" + " align=" + "right" + " bgcolor=" + "#eeeeee" + " class=" + "header1" + " nowrap>Time</td>");

            strMessage.Append("<td bgcolor=" + "#FFFFFF" + " class=" + "basix" + ">" + System.DateTime.Now + " EST</td>");

            strMessage.Append("</tr>");

            strMessage.Append("<tr>");

            strMessage.Append("<td width=" + "100" + " align=" + "right" + " bgcolor=" + "#eeeeee" + " class=" + "header1" + " nowrap>Details</td>");





            strMessage.Append("<td bgcolor=" + "#FFFFFF" + " class=" + "basix" + ">" + exc.ToString() + exc.StackTrace.ToString() + exc.Source + "</td>");

            strMessage.Append("</tr>");

            strMessage.Append("<tr>");

            strMessage.Append("<td width=" + "100" + " align=" + "right" + " bgcolor=" + "#eeeeee" + " class=" + "header1" + " nowrap>cadena Sql</td>");

            strMessage.Append("<td bgcolor=" + "#FFFFFF" + " class=" + "basix" + ">" + cadenaSql + "</td>");
            strMessage.Append("</tr>");

            strMessage.Append("</table>");

        }

        catch (Exception ex)
        {

        }



        pagina = null;

        return strMessage.ToString();

    }

    public static string construirMensajeConfirmacionCorreo(string nombre, string user, string pass, string hash, int id, int idportal)
    {
        if (nombre == "")
            nombre = user;
        //System.Web.UI.Page pagina = new System.Web.UI.Page();
        string mensaje = "Estimado " + nombre + " Gracias por registrarse en fedesp.es.<br/> ";
        string mensalink = "HAGA CLIC EN ESTE LINK PARA COMPLETAR EL REGISTRO Y HACERLO EFECTIVO. <a href='http://www.fedesp.es/portal/foro/confirmar.aspx?hs=" + hash + "&us=" + id + "&idportal=" + idportal + "'>http://www.fedesp.es/portal/foro/confirmar.aspx?hs=" + hash + "&us=" + id + "</a>";
        string mensaje2 = "Al finalizar este proceso, usted podrá acceder al foro del sistema.  Si necesita ponerse en contacto con nosotros, por favor póngase en contacto en <a href='mailto:info@fedesp.es'>info@fedesp.es</a>.";



        string mensaje3 = "Su información de registro:<br /> Login: " + user;
        mensaje3 += "<br /> Contraseña:" + pass;

        mensaje3 += "<br /><br />Un atento saludo, fedesp.es";

        StringBuilder strMessage = new StringBuilder();

        try
        {

            strMessage.Append("<style type=" + "text/css" + ">");

            strMessage.Append("<!--");

            strMessage.Append(".basix {");

            strMessage.Append("font-family: Verdana, Arial, Helvetica, sans-serif;");

            strMessage.Append("font-size: 12px;");

            strMessage.Append("}");

            strMessage.Append(".header1 {");

            strMessage.Append("font-family: Verdana, Arial, Helvetica, sans-serif;");

            strMessage.Append("font-size: 12px;");

            strMessage.Append("font-weight: bold;");

            strMessage.Append("color: #000099;");

            strMessage.Append("}");

            strMessage.Append(".tlbbkground1 {");

            strMessage.Append("background-color: #000099;");

            strMessage.Append("}");

            strMessage.Append("-->");

            strMessage.Append("</style>");

            strMessage.Append("<table width=" + "85%" + " border=" + "0" + " align=" + "center" + " cellpadding=" + "5" + " cellspacing=" + "1" + " class=" + "tlbbkground1" + ">");

            strMessage.Append("<tr bgcolor=" + "#eeeeee" + ">");

            strMessage.Append("<td colspan=" + "2" + " class=" + "header1" + ">Confirmación usuario " + System.DateTime.Now + " EST</td>");

            strMessage.Append("</tr>");

            strMessage.Append("<tr>");

            strMessage.Append("<td width=" + "100" + " align=" + "right" + " bgcolor=" + "#eeeeee" + " class=" + "header1" + " nowrap> </td>");

            strMessage.Append("<td bgcolor=" + "#FFFFFF" + " class=" + "basix" + ">" + mensaje + "</td>");

            strMessage.Append("</tr>");


            strMessage.Append("<tr>");

            strMessage.Append("<td width=" + "100" + " align=" + "right" + " bgcolor=" + "#eeeeee" + " class=" + "header1" + " nowrap> </td>");

            strMessage.Append("<td bgcolor=" + "#FFFFFF" + " class=" + "basix" + ">" + mensalink + "</td>");

            strMessage.Append("</tr>");

            strMessage.Append("<tr>");

            strMessage.Append("<td width=" + "100" + " align=" + "right" + " bgcolor=" + "#eeeeee" + " class=" + "header1" + " nowrap> </td>");

            strMessage.Append("<td bgcolor=" + "#FFFFFF" + " class=" + "basix" + ">" + "</td>");

            strMessage.Append("</tr>");

            strMessage.Append("<tr>");

            strMessage.Append("<td width=" + "100" + " align=" + "right" + " bgcolor=" + "#eeeeee" + " class=" + "header1" + " nowrap> </td>");

            strMessage.Append("<td bgcolor=" + "#FFFFFF" + " class=" + "basix" + ">" + mensaje2 + "</td>");

            strMessage.Append("</tr>");

            strMessage.Append("<tr>");




            strMessage.Append("<tr>");

            strMessage.Append("<td width=" + "100" + " align=" + "right" + " bgcolor=" + "#eeeeee" + " class=" + "header1" + " nowrap> </td>");

            strMessage.Append("<td bgcolor=" + "#FFFFFF" + " class=" + "basix" + ">" + mensaje3 + "</td>");

            strMessage.Append("</tr>");




            strMessage.Append("</table>");

        }

        catch (Exception ex)
        {

        }



        string firma = "</br></br>Un saludo</br>  <img src='http://fedesp.es/images/centralfirma.gif' width='500' height='80' border='0' usemap='#Map' /><map name='Map' id='Map'>  <area shape='rect' coords='360,54,448,70' href='http://www.fedesp.es' /></map> </br></br> No responda a este mensaje.";

        return strMessage.ToString() + firma;

    }



    #endregion
}

