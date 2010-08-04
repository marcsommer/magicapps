


' en esta clase irian las constantes...
Public Class ctes

    Public Enum tipoMensaje
        info = 1
        fallo = 2
        exito = 3
    End Enum

    Public Shared serverServicesWeb As New String("")

    Public Shared directorioAplicacion As String = System.AppDomain.CurrentDomain.BaseDirectory
    'Public Shared conStringAdoSqlServer As String = ""
    'Public Shared conStringAdoMySql As String = ""
    'Public Shared conStringOleDb As String = "PROVIDER=MICROSOFT.JET.OLEDB.4.0;DATA SOURCE=" + directorioAplicacion + "/data/estancia.mdb"
    'Public Shared conStringAdoOdbc As String = ""

    Public Shared conStringAdo As String = System.IO.Path.Combine("PROVIDER=MICROSOFT.JET.OLEDB.4.0;DATA SOURCE=" + directorioAplicacion, "data\estancia.mdb") ';Persist Security info=""False"""

    ' used at creating new items, cause i cant pass the text to the list...
    Public Shared last As New String("")

#Region " Enumerados "

    Public Enum eTipoCampo As Integer
        id = 0
        texto = 1
    End Enum

    Public Enum tipoBd As Integer
        access = 0
        mysql = 1
        sqlServer = 2
    End Enum

#End Region


    Public Shared Sub inidatos()



    End Sub


End Class
