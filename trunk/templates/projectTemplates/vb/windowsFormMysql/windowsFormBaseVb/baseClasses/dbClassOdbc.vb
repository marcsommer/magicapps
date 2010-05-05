Imports System.Data.Odbc
'Imports System.Web.Mail
Imports System.Text

' clase para acceso a bd

Public Class dbClassOdbc


    Public conexion As System.Data.Odbc.OdbcConnection
    Public miComando As System.Data.Odbc.OdbcCommand
    Public miLector As System.Data.Odbc.OdbcDataReader
    Public cadConexion As String



    Public Function sql(ByVal texto As String) As Object

        Try
            miComando.CommandText = texto
            miLector = miComando.ExecuteReader

            Return miLector

        Catch em As Exception
            lo.tratarError(em, "Error en dbclass.sql", texto)

        End Try


        'Error en la ejecucion
        Return Nothing
    End Function


    ' devuelve un dataset
    Public Function sqlDataset(ByVal texto As String) As Data.DataSet
        Try

        
            Dim myCommand As New System.Data.Odbc.OdbcCommand(texto, Me.conexion)
            'SqlCommand((texto, Me.conexion)

            Dim myAdapter As New System.Data.Odbc.OdbcDataAdapter(myCommand)
            Dim ds As New Data.DataSet
            myAdapter.Fill(ds)

            'Set the datagrid's datasource to the DataSet and databind    

            Return ds

        Catch ex As Exception
            lo.tratarError(ex, "Error en dbclass.sqlDataset", texto)

        End Try

    End Function



    Public Sub ejecutar(ByVal texto As String)
        ' comento el try para capturar el error en su sitio
        Try
            miComando.CommandText = texto
            miComando.ExecuteNonQuery()
        Catch ex As Exception
            ' mandamos un mensaje mas detallado
            lo.tratarError(ex, "Error en dbclass.ejecutar", texto)

        End Try

        ' para mysql
        'myOdbcCommand.ExecuteNonQuery()
    End Sub

    Public Sub New(ByVal cadconexion As String)

        Try
           
            conexion = New OdbcConnection(cadconexion)
            miComando = New OdbcCommand("")
            miComando.Connection = conexion


            conexion.ConnectionString = cadconexion
            conexion.Open()
        Catch ep As Exception
            lo.tratarError(ep, "Error en dbClass.new", "")


        End Try


    End Sub


    Public Sub dispose()

        Try
            conexion.Close()
            conexion.Dispose()
            conexion = Nothing
            miComando = Nothing
            miLector = Nothing


        Catch ep As Exception
            'MsgBox(ep.Message)

        End Try
    End Sub

    Protected Overrides Sub Finalize()
        Try
            conexion.Dispose()
            conexion = Nothing
            miComando = Nothing
            miLector = Nothing

            'conexion.Close()
        Catch em As Exception

        End Try

        'pp.hide()


        MyBase.Finalize()
    End Sub



End Class


