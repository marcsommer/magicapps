


' en esta clase irian las constantes...
Public Class ctes

    Public Shared serverServicesWeb As New String("")
    Public Shared conStringAdo As String = "Data Source=192.168.10.135\SQL2005;Network Library=DBMSSOCN;Initial Catalog=cars;User ID=sa;Password=xx;"



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
