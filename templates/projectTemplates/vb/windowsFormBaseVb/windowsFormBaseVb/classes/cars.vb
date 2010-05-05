

Imports Microsoft.VisualBasic

Imports System
Imports System.Data
Imports System.Collections.Generic

Imports System.Text
Imports System.Io

Public Class cars



#Region "Variables"
    Private s_description As New String("")
    Private s_idCar As Integer
    Private s_idManufacturer As Integer
    Private s_image As New String("")
    Private s_model As New String("")

#End Region




#Region "Propiedades"
    Public Property description() As String
        Get
            Return s_description
        End Get
        Set(ByVal Value As String)
            s_description = Value
        End Set
    End Property
    Public Property idCar() As Integer
        Get
            Return s_idCar
        End Get
        Set(ByVal Value As Integer)
            s_idCar = Value
        End Set
    End Property
    Public Property idManufacturer() As Integer
        Get
            Return s_idManufacturer
        End Get
        Set(ByVal Value As Integer)
            s_idManufacturer = Value
        End Set
    End Property
    Public Property image() As String
        Get
            Return s_image
        End Get
        Set(ByVal Value As String)
            s_image = Value
        End Set
    End Property
    Public Property model() As String
        Get
            Return s_model
        End Get
        Set(ByVal Value As String)
            s_model = Value
        End Set
    End Property



#End Region


    ' devuelve un arraylist de ...
    Public Shared Function getArrayList() As ArrayList
        Dim db As New dbClass(ctes.conStringAdo)
        Dim sql As String
        Dim reg As Object


        Try
            sql = "select * from cars"
            reg = db.sql(sql)
            Do While reg.read()
                Dim pp As New cars

                pp.description = sf.Cadena(reg("description"))
                pp.idCar = sf.Entero(reg("idCar"))
                pp.idManufacturer = sf.Entero(reg("idManufacturer"))
                pp.image = sf.Cadena(reg("image"))
                pp.model = sf.Cadena(reg("model"))


                getArrayList.Add(pp)
                pp = Nothing
            Loop
            reg.close()
        Catch ex As Exception
        Finally
            db.dispose()
        End Try

    End Function


    ' devuelve un List de ...
    Public Shared Function getList() As List(Of cars)
        Dim db As New dbClass(ctes.conStringAdo)
        Dim sql As String
        Dim reg As Object
        Dim lista As New List(Of cars)

        Try
            sql = "select * from cars"
            reg = db.sql(sql)
            Do While reg.read()
                Dim pp As New cars
                pp.description = sf.Cadena(reg("description"))
                pp.idCar = sf.Entero(reg("idCar"))
                pp.idManufacturer = sf.Entero(reg("idManufacturer"))
                pp.image = sf.Cadena(reg("image"))
                pp.model = sf.Cadena(reg("model"))

                lista.Add(pp)
                pp = Nothing
            Loop
            reg.close()
        Catch ex As Exception
        Finally
            db.dispose()
        End Try
        Return lista
        lista = Nothing

    End Function


    Public Shared Function update(ByVal carsx As cars) As Boolean
        Dim db As New dbClass(ctes.conStringAdo)
        Dim sqlt As String
        Try

            sqlt = " update cars set  "
            sqlt += " description='" & sf.Cadena(carsx.description) & "', "
            sqlt += " idCar=" & sf.Cadena(carsx.idCar) & ","
            sqlt += " idManufacturer=" & sf.Cadena(carsx.idManufacturer) & ","
            sqlt += " image='" & sf.Cadena(carsx.image) & "', "
            sqlt += " model='" & sf.Cadena(carsx.model) & "' "


            sqlt += " where description =" & carsx.description
            db.ejecutar(sqlt)
            Return True
        Catch ex As Exception
            Return False

        Finally
            db.dispose()
        End Try
    End Function



    Public Shared Function getcars(ByVal descriptionx As Integer) As cars
        Dim salida As New cars
        Dim db As New dbClass(ctes.conStringAdo)
        Dim reg As Object
        Dim sqlt As String

        Try
            sqlt = " select * from cars where description=" & descriptionx

            reg = db.sql(sqlt)
            If reg.Read() Then

                salida.description = sf.Cadena(reg("description"))
                salida.idCar = sf.Entero(reg("idCar"))
                salida.idManufacturer = sf.Entero(reg("idManufacturer"))
                salida.image = sf.Cadena(reg("image"))
                salida.model = sf.Cadena(reg("model"))


            End If
            reg.close()
        Catch ex As Exception
        Finally
            db.dispose()
        End Try
        Return salida
    End Function

    ' devuelve un arraylist de...
    Public Shared Function getArraycars() As cars()
        Dim av() As cars
        Dim db As New dbClass(ctes.conStringAdo)
        Dim reg As Object
        Dim sqlt As String
        Dim contador As Integer
        contador = 0

        Try
            sqlt = " select * from cars "

            reg = db.sql(sqlt)
            Do While reg.read()
                Dim pp As New cars

                pp.description = sf.Cadena(reg("description"))
                pp.idCar = sf.Entero(reg("idCar"))
                pp.idManufacturer = sf.Entero(reg("idManufacturer"))
                pp.image = sf.Cadena(reg("image"))
                pp.model = sf.Cadena(reg("model"))

                ReDim Preserve av(contador)
                av.SetValue(pp, contador)
                contador += 1
                pp = Nothing
            Loop

        Catch ex As Exception
        Finally
            db.dispose()
        End Try
        Return av
    End Function

    Public Function readDb(ByVal descriptionx As Integer) As Boolean
        Dim db As New dbClass(ctes.conStringAdo)
        Dim reg As Object
        Dim sqlt As String

        Try
            sqlt = " select * from cars where description=" & descriptionx

            reg = db.sql(sqlt)
            If reg.Read() Then

                Me.description = sf.Cadena(reg("description"))
                Me.idCar = sf.Entero(reg("idCar"))
                Me.idManufacturer = sf.Entero(reg("idManufacturer"))
                Me.image = sf.Cadena(reg("image"))
                Me.model = sf.Cadena(reg("model"))

            End If
            reg.close()
        Catch ex As Exception
        Finally
            db.dispose()
        End Try
    End Function


    ' sirve para comprobar que hay un cars con el mismo id ...
    Public Shared Function exists(ByVal carsObj As cars) As Boolean
        Dim db As New dbClass(ctes.conStringAdo)
        Dim reg As Object
        Dim sqlt As String
        Dim salida As Boolean
        Try
            sqlt = " select * from cars  where description <> 0 and ( "
            sqlt += " )"

            reg = db.sql(sqlt)
            salida = reg.read()

        Catch ex As Exception
        Finally
            db.dispose()
        End Try
        Return salida
    End Function


    Public Shared Function insert(ByVal objcars As cars) As String
        Dim db As New dbClass(ctes.conStringAdo)

        Dim reg As Object
        Dim sqlt As String
        Try

            sqlt = " insert into cars (description,idManufacturer,image,model "
            sqlt += " ) values ("

            sqlt += "'" & sf.Cadena(objcars.description) & "' ,"
            sqlt += " " & objcars.idManufacturer.ToString & ","
            sqlt += "'" & sf.Cadena(objcars.image) & "' ,"
            sqlt += "'" & sf.Cadena(objcars.model) & "' "

            sqlt += " )"

            db.ejecutar(sqlt)
            reg = db.sql("select @@identity as id from cars")
            If reg.Read() Then
                Return reg("id").ToString
            Else
                Return ""
            End If
            reg.close()


        Catch ex As Exception
        Finally
            db.dispose()
        End Try


    End Function 'insertarEnBd()


    Public Function deletecars(ByVal descriptionx As Integer)
        Dim db As New dbClass(ctes.conStringAdo)

        Dim sqlt As String
        Try
            sqlt = " delete from cars where description=" & descriptionx
            db.ejecutar(sqlt)

        Catch ex As Exception
        Finally
            db.dispose()
        End Try
    End Function









    Public Function deletecarsBydescription(ByVal descriptionx As Integer)
        Dim db As New dbClass(ctes.conStringAdo)

        Dim sqlt As String
        Try
            sqlt = " delete from cars where description=" & descriptionx
            db.ejecutar(sqlt)

        Catch ex As Exception
        Finally
            db.dispose()
        End Try
    End Function





    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub



    Public Sub New()

    End Sub


    Public Sub New(ByVal descriptionx As Integer)
        Dim db As New dbClass(ctes.conStringAdo)
        Dim reg As Object
        Dim sqlt As String

        Try
            sqlt = " select * from cars where description=" & descriptionx

            reg = db.sql(sqlt)
            If reg.Read() Then

                Me.description = sf.Cadena(reg("description"))
                Me.idCar = sf.Entero(reg("idCar"))
                Me.idManufacturer = sf.Entero(reg("idManufacturer"))
                Me.image = sf.Cadena(reg("image"))
                Me.model = sf.Cadena(reg("model"))

            End If
            reg.close()
        Catch ex As Exception
        Finally
            db.dispose()
        End Try
    End Sub

    Public Shared Function delete(ByVal descriptionx As Integer)
        Dim db As New dbClass(ctes.conStringAdo)

        Dim sqlt As String
        Try
            sqlt = " delete from cars where description=" & descriptionx
            db.ejecutar(sqlt)

        Catch ex As Exception
        Finally
            db.dispose()
        End Try
    End Function

End Class