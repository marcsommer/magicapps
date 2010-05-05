
' para fechaEspanola
Imports System.Globalization




' clase que utilizamos a la hora de leer de la base 
' de datos para evitar problemas

Public Class sf

    Public Shared Function SafeSql( _
ByVal inputSQL As String) As String
        Dim s As String = inputSQL
        s = inputSQL.Replace("'", "''")
        s = s.Replace("[", "[[]")
        s = s.Replace("_", "[_]")
        Return s
    End Function


#Region "PreparaObjeto"
    ' esta funcion arregla los datos para que no haya ningun null
    ' util a la hora de hacer un update
    Public Function preparaObjeto(ByVal objeto As Object)
        Try
            Dim contador As Integer = 0
            Dim pi As System.Reflection.PropertyInfo

            For Each pi In objeto.GetType().GetProperties()

                If (pi.CanWrite) Then

                    Select Case pi.PropertyType.ToString
                        Case "System.String"
                            If pi.GetValue(Me, Nothing) Is Nothing Then
                                pi.SetValue(Me, "", Nothing)
                            End If
                        Case "System.Boolean"
                            If pi.GetValue(Me, Nothing) Is Nothing Then
                                pi.SetValue(Me, False, Nothing)
                            End If
                        Case "System.int32"
                            If pi.GetValue(Me, Nothing) Is Nothing Then
                                pi.SetValue(Me, 0, Nothing)
                            End If
                        Case "System.int64"
                            If pi.GetValue(Me, Nothing) Is Nothing Then
                                pi.SetValue(Me, 0, Nothing)
                            End If

                        Case "System.Double"
                            If pi.GetValue(Me, Nothing) Is Nothing Then
                                pi.SetValue(Me, 0, Nothing)
                            End If

                        Case "System.single"
                            If pi.GetValue(Me, Nothing) Is Nothing Then
                                pi.SetValue(Me, 0.0, Nothing)
                            End If

                        Case "System.Date"
                            If pi.GetValue(Me, Nothing) Is Nothing Then
                                pi.SetValue(Me, Date.MinValue, Nothing)
                            End If

                    End Select


                End If
            Next
        Catch ex As System.Exception
        End Try

    End Function
#End Region

#Region "Single"
    Public Shared Function aSingle(ByVal valor As String)
        Try
            If valor = "" Then
                Return 0.0 'Single.MinValue
            Else
                valor = valor.Replace(".", ",")
                Return System.Convert.ToSingle(valor)
            End If
        Catch ex As System.Exception
            Return 0.0 'Single.MinValue
        End Try

    End Function

    Public Shared Function aSingle(ByVal valor As Integer)
        Try
            If valor = "" Then
                Return 0.0 'Single.MinValue
            Else
                Return System.Convert.ToSingle(valor)
            End If
        Catch ex As System.Exception
            Return 0.0 'Single.MinValue
        End Try
    End Function


    Public Shared Function aSingle(ByVal valor As Single)
        If valor = Single.MinValue Then
            Return 0
        Else
            Return (valor)
        End If
    End Function


#End Region





    Public Shared Function Entero(ByVal valor As String) As Int32
        Dim retorno As New Int32
        Int32.TryParse(valor, retorno)
        Return retorno


    End Function

    Public Shared Function Entero(ByVal valor As Double) As Int32

        Dim retorno As New Int32
        Int32.TryParse(valor, retorno)
        Return retorno



    End Function

    Public Shared Function Entero(ByVal valor As System.DBNull) As Int32
        Return 0
    End Function


    Public Shared Function Entero(ByVal valor As Boolean) As Int32

        Try
            If valor = True Then
                Return 1
            Else
                Return 0
            End If
        Catch ex As System.Exception
            Return 0
        End Try

    End Function

    Public Shared Function Doble(ByVal valor As Double) As Double

        Dim retorno As New Double
        Double.TryParse(valor, retorno)
        Return retorno

    End Function
    Public Shared Function Doble(ByVal valor As String) As Double

        Dim retorno As New Double
        Double.TryParse(valor, retorno)
        Return retorno


        'Try
        '    If valor = "" Then
        '        Return 0
        '    Else
        '        valor = valor.Replace(",", ".")
        '        Return System.Convert.ToDouble(valor)
        '    End If
        'Catch ex As System.Exception
        '    Return 0
        'End Try

    End Function

    Public Shared Function Doble(ByVal valor As Boolean) As Double
        Dim retorno As New Double
        Double.TryParse(valor, retorno)
        Return retorno

        'Try
        '    If valor = True Then
        '        Return 1
        '    Else
        '        Return 0
        '    End If
        'Catch ex As System.Exception
        '    Return 0
        'End Try
    End Function

    Public Shared Function Fecha(ByVal valor As String) As Date
        Dim retorno As New Date
        Date.TryParse(valor, retorno)
        Return retorno

        
    End Function


    ' el system.dbnull ya lo controla el tryparse
    'Public Shared Function Fecha(ByVal valor As System.DBNull) As Date
    '    Dim retorno As New Date
    '    Date.TryParse(valor, retorno)
    '    Return retorno


    '    Try
    '        ' nos aseguramos que vaya a espa�ol
    '        Dim culture As CultureInfo = New CultureInfo("es-ES")

    '        Return Date.MinValue

    '    Catch ex As System.Exception
    '        Return Date.MinValue
    '    End Try
    'End Function

    Public Shared Function Fecha(ByVal valor As System.DBNull) As Date
        'Return New Date(1901, 1, 1)
        Return Date.MinValue
    End Function

    Public Shared Function Fecha(ByVal valor As Date) As Date
        Dim retorno As New Date
        Date.TryParse(valor, retorno)
        Return retorno

        'Try

        '    Return valor

        'Catch ex As System.Exception
        '    Return Date.MinValue
        'End Try
    End Function

    ' esta funcion devuelve la fecha en formato short
    ' devolvemos Date.MinValue como fecha minima

    Public Shared Function FechaCorta(ByVal valor As String) As String
        Try
            If valor = "" Then
                Return New Date(1901, 1, 1).ToShortDateString 'Date.MinValue.ToShortDateString
            Else
                Return System.Convert.ToDateTime(valor).ToShortDateString
            End If
        Catch ex As System.Exception
            Return Date.MinValue.ToShortDateString 'New Date(1901, 1, 1).ToShortDateString 'Date.MinValue.ToShortDateString
        End Try
    End Function

    Public Shared Function FechaCorta(ByVal valor As Date) As String
        Try
            Return valor.ToShortDateString
        Catch ex As System.Exception
            Return Date.MinValue.ToShortDateString 'Date.MinValue.ToShortDateString
        End Try
    End Function

    Public Shared Function FechaIso(ByVal dteDate)
        'Version 1.0
        If esFecha(dteDate) = True Then
            Dim dteDay, dteMonth, dteYear As Integer
            dteDay = dteDate.Day
            dteMonth = dteDate.Month
            dteYear = dteDate.Year

            Dim dteMonthSt As String
            Dim dtedaySt As String
            dteMonthSt = CStr(dteMonth + 100)
            dtedaySt = CStr(dteDay + 100)

            FechaIso = dteYear & _
               "-" & dteMonthSt.Substring(dteMonthSt.Length - 2, 2) & _
               "-" & dtedaySt.Substring(dtedaySt.Length - 2, 2)
        Else
            FechaIso = Nothing
        End If
    End Function


    ' funciones para sql server de fechas
    '--------------------------------------------
    '--------------------------------------------

    ' la insercion siempre con formato yyyymmdd hh:mm
    Public Shared Function fechaSql(ByVal fecha As Date) As String
        Try
            Dim cadena As String

            ' Return Date.MinValue.ToString

            cadena = fecha.Year.ToString.PadLeft(4, "0") + fecha.Month.ToString.PadLeft(2, "0") + fecha.Day.ToString.PadLeft(2, "0") + " " + fecha.Hour.ToString.PadLeft(2, "0") + ":" + fecha.Minute.ToString.PadLeft(2, "0")
            Return cadena
        Catch ex As System.Exception
            ' devolvemos la cadena vacia ya que no se permite
            ' insertar del date.minvalue en formato iso, es
            ' mejor dejarlo en blanco que es lo mismo
            Return ""

        End Try

    End Function

    ' la insercion siempre con formato yyyymmdd hh:mm
    Public Shared Function fechaSqlCorta(ByVal fecha As Date) As String
        Try
            Dim cadena As String

            ' Return Date.MinValue.ToString

            cadena = fecha.Year.ToString.PadLeft(4, "0") + fecha.Month.ToString.PadLeft(2, "0") + fecha.Day.ToString.PadLeft(2, "0")
            Return cadena
        Catch ex As System.Exception
            ' devolvemos la cadena vacia ya que no se permite
            ' insertar del date.minvalue en formato iso, es
            ' mejor dejarlo en blanco que es lo mismo
            Return ""

        End Try

    End Function

    Public Shared Function esFecha(ByVal fecha As Date) As Boolean
        Try
            Select Case fecha.ToShortDateString
                Case "01/01/0001", "01/01/1900"
                    Return False
            End Select

            Dim fechita As Date = New Date().Parse(fecha.ToString)


            Return True
        Catch ex As System.Exception
            Return False
        End Try

    End Function

    Public Shared Function esFecha(ByVal fecha As String) As Boolean
        Try
            Select Case fecha
                Case "01/01/0001", "01/01/1900"
                    Return False
            End Select
            Dim fechita As Date = New Date().Parse(fecha)


            Return True
        Catch ex As System.Exception
            Return False
        End Try

    End Function

    Public Shared Function fechaSql(ByVal fecha As String) As String
        Try

            Select Case fecha
                Case "01/01/0001", "01/01/1900", ""
                    Return ""
            End Select



            ' primera comprobacion
            Dim fechita As Date = Date.Parse(fecha)

            ' sql server no admite a�os anteriores a 1700
            If fechita.Year < 1700 Then
                Return ""
            End If


            Dim cadena As String
            cadena = fechita.Year.ToString.PadLeft(4, "0") + fechita.Month.ToString.PadLeft(2, "0") + fechita.Day.ToString.PadLeft(2, "0") + " " + fechita.Hour.ToString.PadLeft(2, "0") + ":" + fechita.Minute.ToString.PadLeft(2, "0")



            Return cadena
        Catch ex As System.Exception
            Return ""
        End Try

    End Function

    ' siempre esperamos dd-mm-yyyy formato 105 de convert de sql server
    Public Shared Function sqlFecha(ByVal fecha As String) As Date
        Try
            Dim fechita As New Date(sf.Entero(fecha.Substring(6, 4)), sf.Entero(fecha.Substring(3, 2)), sf.Entero(fecha.Substring(0, 2)))



            Return fechita
        Catch ex As System.Exception
            Return Date.MinValue
        End Try

    End Function

    Public Shared Function fechaEspanola(ByVal fecha As Date) As Date
        Try
            Dim culture As CultureInfo = New CultureInfo("es-ES")
            Return System.Convert.ToDateTime(fecha, culture)
        Catch ex As System.Exception
            Return Date.MinValue
        End Try

    End Function



#Region "Cadena"
    Public Shared Function Cadena(ByVal valor As Double) As String

        Try
            If valor = 0 Then
                Return "0"
            Else
                Return valor.ToString
            End If
        Catch ex As System.Exception
            Return 0
        End Try

    End Function

    Public Shared Function Cadena(ByVal valor As String) As String
        Try
            Return valor
        Catch ex As System.Exception
            Return ""
        End Try

    End Function

    Public Shared Function Cadena(ByVal valor As Boolean) As String
        Try
            If valor = True Then
                Return "1"
            Else
                Return "0"
            End If
        Catch ex As System.Exception
            Return "0"
        End Try

    End Function

    Public Shared Function Cadena(ByVal valor As System.DBNull) As String
        Try
            Return ""
        Catch ex As System.Exception
            Return ""
        End Try

    End Function
#End Region


#Region "boolean"

    Public Shared Function Bool(ByVal valor As String) As Boolean

        Dim retorno As New Boolean
        Bool.TryParse(valor, retorno)
        Return retorno
        'Try
        '    Return CBool(valor)

        'Catch ex As System.Exception
        '    Return False
        'End Try

    End Function

    Public Shared Function Bool(ByVal valor As Integer) As Boolean
        Dim retorno As New Boolean
        Bool.TryParse(valor, retorno)
        Return retorno

        'Try
        '    Return CBool(valor.ToString)

        'Catch ex As System.Exception
        '    Return False
        'End Try

    End Function

    Public Shared Function Bool(ByVal valor As System.DBNull) As Boolean
        Try
            Return False

        Catch ex As System.Exception
            Return False
        End Try

    End Function

    Public Shared Function Bool(ByVal valor As Boolean) As Boolean
        Dim retorno As New Boolean
        Bool.TryParse(valor, retorno)
        Return retorno


        'Try
        '    Return valor

        'Catch ex As System.Exception
        '    Return False
        'End Try

    End Function

#End Region

End Class




