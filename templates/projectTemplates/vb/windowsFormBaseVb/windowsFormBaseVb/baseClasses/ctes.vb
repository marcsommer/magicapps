


' en esta clase irian las constantes...
Public Class ctes

    Public Shared serverServicesWeb As New String("")

    Public Shared directorioAplicacion As String = System.AppDomain.CurrentDomain.BaseDirectory
    'Public Shared conStringAdoSqlServer As String = ""
    'Public Shared conStringAdoMySql As String = ""
    'Public Shared conStringOleDb As String = "PROVIDER=MICROSOFT.JET.OLEDB.4.0;DATA SOURCE=" + directorioAplicacion + "/data/estancia.mdb"
    'Public Shared conStringAdoOdbc As String = ""

    Public Shared conStringAdo As String = "PROVIDER=MICROSOFT.JET.OLEDB.4.0;DATA SOURCE=" + directorioAplicacion + "/data/estancia.mdb"


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
