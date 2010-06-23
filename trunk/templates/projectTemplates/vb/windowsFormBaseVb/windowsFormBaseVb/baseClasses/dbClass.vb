Imports System.Data.SqlClient



' para copiar
'Dim db As New dbClass(ctes.conStringAdoSvAdmin)
'Dim reg As Object
'        Try
'            reg = db.sql(sql)
'            If reg.read() Then

'           End If
'       Catch ex As Exception
'       Finally
'           db.dispose()
'       End Try

' clase para acceso a bd

Public Class dbClass

    ' para tener una sola conexion global
    Public conexion As SqlClient.SqlConnection
    Public miComando As SqlClient.SqlCommand '= conexion.CreateCommand()
    Public miLector As SqlClient.SqlDataReader

    Public Function sql(ByVal texto As String) As Object

        
        Try
            'ConnectionState.Closed
            If Me.conexion.State <> ConnectionState.Open Then
                Me.conexion.Open()
            End If
            ' miComando.Connection = Me.conexion
            miComando.CommandText = texto
            miComando.CommandTimeout = 30
            miLector = miComando.ExecuteReader(CommandBehavior.CloseConnection)
            miComando.Dispose()
            Return miLector
        Catch ex As SqlException

            Call lo.tratarError(ex, " dbclass.sql" & texto & "Estado de la conexion:" & Me.conexion.State, "")

        Catch em As Exception


            Call lo.tratarError(em, " dbclass.sql" & texto & "Estado de la conexion:" & Me.conexion.State, "")

        Finally

        End Try


    End Function

    Public Function sqlDataset(ByVal texto As String) As DataSet
        Try

            Dim midata As DataSet
            Dim myCommand As New System.Data.SqlClient.SqlCommand(texto, Me.conexion)
            'SqlCommand((texto, Me.conexion)
            miComando.CommandTimeout = 30
            Dim myAdapter As New System.Data.SqlClient.SqlDataAdapter(myCommand)
            Dim ds As New DataSet
            myAdapter.Fill(ds)

            'Set the datagrid's datasource to the DataSet and databind    
            Return ds



        Catch ex As SqlException
            Call lo.tratarError(ex, " dbclass.sqlDataSet" & texto & "Estado de la conexion:" & Me.conexion.State, "")

        Catch em As Exception
            ' cerramos la conexion porque si  no perdemos conexiones
            Me.conexion.Close()

            Call lo.tratarError(em, " dbclass.sqlDataSet" & texto & "Estado de la conexion:" & Me.conexion.State, "")
        End Try

    End Function

    Public Function ejecutar(ByVal texto As String) As Boolean
        ' comento el try para capturar el error en su sitio
        Try
            If Me.conexion.State <> ConnectionState.Open Then
                Me.conexion.Open()
            End If
            miComando.CommandText = texto
            miComando.CommandTimeout = 30
            miComando.ExecuteNonQuery()
            miComando.Dispose()

        Catch sx As SqlException

            Call lo.tratarError(sx, " dbclass.Ejecutar" & texto & "Estado de la conexion:" & Me.conexion.State, "")
            Return False

        Catch ex As Exception
            ' cerramos la conexion porque si  no perdemos conexiones
            Me.conexion.Close()


            Call lo.tratarError(ex, " dbclass.Ejecutar" & texto & "Estado de la conexion:" & Me.conexion.State, "")
            Return False
        End Try
        Return True
        ' para mysql
        'myOdbcCommand.ExecuteNonQuery()
    End Function

    Public Sub New(ByVal cadconexion As String)

        ' para evitar ...
        If cadconexion = "" Then
            Call ctes.inidatos()

        End If
        conexion = New SqlClient.SqlConnection(cadconexion)
        miComando = New SqlClient.SqlCommand("")
        miComando.Connection = conexion
        miComando.CommandTimeout = 30

        conexion.ConnectionString = cadconexion
        Try
            conexion.Open()
        Catch ex As SqlException
            Call lo.tratarError(ex, " dbclass.new " & "Estado de la conexion:" & Me.conexion.State, "")

        Catch em As Exception
            Call lo.tratarError(em, " dbclass.new" & "Estado de la conexion:" & Me.conexion.State, "")
        End Try

    End Sub

    Public Sub dispose()

        Try
            Me.conexion.Close()
            Me.conexion.Dispose()
            Me.conexion = Nothing
            Me.miComando = Nothing
            Me.miLector = Nothing


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



    ' EJEMPLO DE RECORRIDO DE CAMPOS POR NOMBRE Y VALOR EN UNA TABLA
    'Dim ds As DataSet
    '    ds = db.sqlDataset(sqlx)
    'Dim columna As System.Data.DataColumn

    '    For Each columna In ds.Tables(0).Columns
    'Dim nombreColumna As String
    '        nombreColumna = columna.ColumnName
    'Dim valorColumna As String = ds.Tables(0).Rows(0)(nombreColumna).ToString
    '    Next
End Class
