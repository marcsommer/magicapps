Imports System.data
Imports DevExpress.XtraEditors

Class lo

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
    ' funciones generales

    ' listas - listbox

    ' me creo una clase para rellenar listbox
    Class nodoLista
        Public id As String
        Public text As String

        Public Sub New()

        End Sub

        Public Overrides Function ToString() As String
            Return text
        End Function

    End Class


    ' funciones para listas (listbox)
    ' .---------------------------------------------

    'Public Class listas
    'Public Sub New()

    'End Sub

    Public Sub listaRellenarDb(ByRef lista As ListBox, ByVal sql As String, ByVal campoId As String, ByVal campoNombre As String)
        'ByVal dataset As DataSet,
        ' borro la lista
        lista.Items.Clear()

        Dim db As New dbClass(ctes.conStringAdo)
        Try
            Dim ds As New DataSet
            ds = db.sqlDataset(sql)
            Dim myDataRow As DataRow
            For Each myDataRow In ds.Tables(0).Rows

                Dim nodo As New nodoLista
                nodo.id = myDataRow(campoId).ToString()
                nodo.text = myDataRow(campoNombre).ToString()
                lista.Items.Add(nodo)
            Next
            ds = Nothing

        Catch ex As Exception
        Finally
            db.dispose()

        End Try

    End Sub



    Sub listaVaciar(ByVal pp As ListBox)
        Call pp.Items.Clear()
    End Sub

    ' actual ...
    Public Function listaValorSEleccionado(ByRef tmpList As ListBox, Optional ByVal tipoCampo As eTipoCampo = eTipoCampo.id) As String
        ' Me da el text/id del elemento seleccionado seg�n el par�metro tipoCampo
        Dim retorno As String

        If (tmpList.SelectedIndex < 0) Then
            retorno = "-1"
        Else
            If (tipoCampo = eTipoCampo.id) Then
                retorno = CType(CType(tmpList.SelectedItem, Object), lo.nodoLista).id
            Else
                retorno = CType(CType(tmpList.SelectedItem, Object), lo.nodoLista).text
            End If
        End If

        If (retorno = "") Then
            retorno = "-1"
        End If

        Return (retorno)
    End Function


    Public Function ListaIsEmpty(ByRef tmpList As ListBox) As Boolean
        Return (tmpList.Items.Count <= 0)
    End Function

    'Public Sub listaSeleccionarItem(ByRef tmpList As ListBox, ByVal cadBusqueda As String, Optional ByVal tipoCampo As eTipoCampo = eTipoCampo.id)
    '    ' Busca el nodo que me dan y le colocan el focus
    '    Dim index As Integer

    '    Dim cont As Integer
    '    Dim pos As Integer
    '    Dim seguir As Boolean

    '    Dim tmpItem As String

    '    index = -1
    '    cont = 0
    '    seguir = True
    '    If Not (ListaIsEmpty(tmpList)) Then


    '        Do While (cont < tmpList.Items.Count) And (seguir)
    '            Select Case tipoCampo
    '                Case eTipoCampo.id
    '                    pos = 0
    '                    tmpItem = tmpList.Items(cont).id 'Value
    '                Case eTipoCampo.texto
    '                    pos = 1
    '                    tmpItem = tmpList.Items(cont).Text
    '            End Select

    '            If tmpItem.ToLower = cadBusqueda.ToLower Then
    '                index = cont
    '                seguir = False
    '            End If
    '            cont = cont + 1
    '        Loop
    '    End If

    '    tmpList.SelectedIndex = index
    '    'tmpList.Items.FindByText(cadBusqueda).Selected = True '.Value()

    'End Sub
    'End Class




#Region "ComboBox -------------------------------------------"


    Shared Sub comboVaciar(ByRef pp As System.Windows.Forms.ComboBox)
        Call pp.Items.Clear()
    End Sub

    Shared Sub comboEstaticoAddItem(ByRef pp As System.Windows.Forms.ComboBox, ByVal cadena As String, ByVal valor As Integer)
        Dim cb As New cNodoBox(cadena, valor)
        pp.Items.Add(cb)
    End Sub

    Public Shared Sub comboSeleccionarItem(ByRef tmpList As System.Windows.Forms.ComboBox, ByVal cadBusqueda As String, Optional ByVal tipoCampo As eTipoCampo = eTipoCampo.id)
        ' Busca el nodo que me dan y le colocan el focus
        
        If cadBusqueda <> "-1" Then
            If Not (comboIsEmpty(tmpList)) Then

                Select Case tipoCampo
                    Case eTipoCampo.id
                        tmpList.SelectedValue = cadBusqueda
                    Case eTipoCampo.texto
                        ' Find the first match for the typed value.
                        Dim index As New Integer
                        index = tmpList.FindString(cadBusqueda)

                        'if index > -1 then a match was found.
                        If (index > -1) Then
                            tmpList.SelectedIndex = index
                        End If
                End Select

            End If
        End If

    End Sub



    Public Shared Function comboValorSeleccionado(ByRef tmpList As System.Windows.Forms.ComboBox, Optional ByVal tipoCampo As eTipoCampo = eTipoCampo.id) As String
        ' Me da el text/id del elemento seleccionado seg�n el par�metro tipoCampo
        Dim retorno As String

      
        If (tipoCampo = eTipoCampo.id) Then
            If (tmpList.SelectedIndex < 0) Then
                retorno = "-1"
            Else
                retorno = tmpList.SelectedValue.ToString() 'CType(CType(tmpList.SelectedItem, Object), lo.nodoLista).id
            End If
        Else
            retorno = tmpList.Text 'CType(CType(tmpList.SelectedItem, Object), lo.nodoLista).text
        End If
        'End If

        'If (retorno = "") Then
        '    retorno = "-1"
        'End If

        Return (retorno)
    End Function

    Public Shared Function comboIsEmpty(ByRef tmpList As System.Windows.Forms.ComboBox) As Boolean
        Return (tmpList.Items.Count <= 0)
    End Function

    'Public Shared Sub comboFill(ByRef tmpCombo As System.Windows.Forms.ComboBox, ByVal textoSql As String, ByVal connectionString As String, ByRef Texto As String, ByRef Value As String)
    '    ' Rellena el combo que me pasan con la select pasada
    '    ' En el campo texto me pasan el campo a mostrar
    '    ' En el campo value me pasan el campo a almacenar
    '    Dim adoNET As New dbClass(connectionString)
    '    Try

    '        Dim aRegistros As Object
    '        aRegistros = adoNET.sql(textoSql)

    '        Do While aRegistros.read()
    '            Call insertarNodo(tmpCombo, aRegistros(Texto), aRegistros(Value))
    '        Loop
    '        aRegistros.close()

    '    Catch ex As Exception
    '    Finally
    '        adoNET.dispose()
    '    End Try

    'End Sub

    Public Shared Sub insertarNodo(ByRef tmpCombo As System.Windows.Forms.ComboBox, ByVal tmpTexto As String, ByVal tmpId As String)
        Dim tmpNodo As cNodoBox

        tmpNodo = New cNodoBox(tmpTexto, tmpId)
        tmpCombo.Items.Add(tmpNodo)
    End Sub

    'Public Shared Function comboValorSEleccionado(ByRef tmpCombo As System.Windows.Forms.ComboBox, ByVal campoBusqueda As eTipoCampo) As Object
    '    '  Me da el text/id del nodo seleccionado seg�n el par�metro flagValue
    '    Dim tmpRetorno As cNodoBox
    '    Dim retorno As Object

    '    If (tmpCombo.SelectedIndex = -1) Then
    '        Select Case campoBusqueda
    '            Case eTipoCampo.id
    '                retorno = 0
    '            Case Else
    '                retorno = "-1"
    '        End Select
    '    Else
    '        tmpRetorno = tmpCombo.SelectedItem
    '        Select Case campoBusqueda
    '            Case eTipoCampo.id
    '                retorno = tmpRetorno.id
    '            Case eTipoCampo.texto
    '                retorno = tmpRetorno.text
    '                'Case eTipoCampo.nodo
    '                '    retorno = tmpRetorno
    '        End Select
    '    End If

    '    Return (retorno)
    'End Function

    Public Shared Sub comboFill(ByRef tmpList As System.Windows.Forms.ComboBox, ByVal textoSql As String, ByVal connectionString As String)
        ' Rellena la lista que me pasan con la select pasada
        ' pillo el segundo campo que me pasan en la select para el campo texto
        ' pillo el primer campo que me pasan en la select para el el campo value me pasan el campo a almacenar
        ' ejemplo select banco_, nombre from bancos
        Dim pp As New dbClass(ctes.conStringAdo)
        Dim ds As System.Data.DataSet

        Try
            ds = pp.sqlDataset(textoSql)

            tmpList.DataSource = ds.Tables(0)
            tmpList.DisplayMember = ds.Tables(0).Columns(1).ColumnName.ToString
            tmpList.ValueMember = ds.Tables(0).Columns(0).ColumnName.ToString

            'tmpList.DataBind()

            'Dim per As New ListItem
            'per.Value = 0
            'per.Text = "Elija ..."
            'tmpList.Items.Insert(0, per) ' "Elija ...")

        Catch ex As Exception
        Finally
            pp.dispose()
        End Try

    End Sub


    Public Shared Sub comboXFill(ByRef cm As DevExpress.XtraEditors.ImageComboBoxEdit, ByVal textoSql As String, ByVal campoId As String, ByVal campoTexto As String, ByVal connectionString As String)
        ' Rellena la lista que me pasan con la select pasada
        ' pillo el segundo campo que me pasan en la select para el campo texto
        ' pillo el primer campo que me pasan en la select para el el campo value me pasan el campo a almacenar
        ' ejemplo select banco_, nombre from bancos
        Dim pp As New dbClass(ctes.conStringAdo)
        Dim ds As System.Data.DataSet

        Try

            Dim aRegistros As Object
            aRegistros = pp.sql(textoSql)

            Do While aRegistros.read()
                Dim im As New Controls.ImageComboBoxItem
                im.Description = aRegistros(campoTexto)
                im.Value = aRegistros(campoId)
                cm.Properties.Items.Add(im)
            Loop
            aRegistros.close()


            'Dim per As New ListItem
            'per.Value = 0
            'per.Text = "Elija ..."
            'tmpList.Items.Insert(0, per) ' "Elija ...")

        Catch ex As Exception
        Finally
            pp.dispose()
        End Try

    End Sub


#End Region





    'Public Function listaValorSEleccionado(ByRef tmpList As System.Windows.Forms.ComboBox, Optional ByVal tipoCampo As eTipoCampo = eTipoCampo.id) As String
    '    ' Me da el text/id del elemento seleccionado seg�n el par�metro tipoCampo
    '    Dim retorno As String

    '    If (tmpList.SelectedIndex < 0) Then
    '        retorno = "-1"
    '    Else
    '        If (tipoCampo = eTipoCampo.id) Then
    '            retorno = tmpList.SelectedItem.Value '.SelectedIndex 'SelectedValue
    '        Else
    '            retorno = tmpList.SelectedItem.ToString

    '        End If
    '    End If

    '    If (retorno = "") Then
    '        retorno = "-1"
    '    End If

    '    Return (retorno)
    'End Function




    'Public Sub listaSeleccionarItem(ByRef tmpList As System.Windows.Forms.ComboBox, ByVal cadBusqueda As String, Optional ByVal tipoCampo As eTipoCampo = eTipoCampo.id)
    '    ' Busca el nodo que me dan y le colocan el focus
    '    Dim index As Integer

    '    Dim cont As Integer
    '    Dim pos As Integer
    '    Dim seguir As Boolean

    '    Dim tmpItem As String

    '    index = -1
    '    cont = 0
    '    seguir = True
    '    If Not (comboIsEmpty(tmpList)) Then

    '        Do While (cont < tmpList.Items.Count) And (seguir)
    '            Select Case tipoCampo
    '                Case eTipoCampo.id
    '                    pos = 0
    '                    tmpItem = tmpList.Items(cont).Value
    '                Case eTipoCampo.texto
    '                    pos = 1
    '                    tmpItem = tmpList.Items(cont).Text
    '            End Select

    '            If tmpItem.ToLower = cadBusqueda.ToLower Then
    '                index = cont
    '                seguir = False
    '            End If
    '            cont = cont + 1
    '        Loop
    '    End If

    '    tmpList.SelectedIndex = index
    '    'tmpList.Items.FindByText(cadBusqueda).Selected = True '.Value()

    'End Sub






    ' funciones generales
    Function formateaNumDecimales(ByRef cadena As String, ByRef numDecimales As Short) As String
        Dim retorno As String
        Dim cadAux As String
        Dim i As Short

        retorno = cadena
        If (IsNumeric(numDecimales)) Then
            If (numDecimales >= 0) Then
                cadAux = "0."
                For i = 1 To numDecimales
                    cadAux = cadAux & "0"
                Next i
                retorno = "0" 'System.Convert.ToDouble(.ToDecimal(.ChangeType(cadena, cadAux)
            End If
        End If
        formateaNumDecimales = retorno
    End Function


    Public Shared Function tratarError(ByVal ex As Exception, ByVal titulo As String, ByVal descripcion As String)
        'If Not ctes.mostrarErrores Then
        '    Call lo.enviarCorreo(ctes.direccionCorreoErrores, "ax" & ctes.direccionCorreoErrores, lo.construirMensajeError(exc, descripcion), "sv_Izfe - error controlado. " & descripcion)

        '    ctes.ultimaExcepcion = exc
        '    HttpContext.Current.Response.Redirect("../error.aspx")

        'Else
        '    HttpContext.Current.Response.Write(lo.construirMensajeError(exc, descripcion))
        '    HttpContext.Current.Response.End()
        'End If

        Debug.WriteLine("·...........", "Error")
        Debug.WriteLine(titulo, "error")
        Debug.WriteLine(ex.Message, "error")
        Debug.WriteLine(descripcion, "error")
        Debug.WriteLine("·...........", "error")

    End Function

    Public Sub enviarCorreo(ByVal destinatario As String, ByVal remitente As String, ByVal texto As String, ByVal asunto As String)


        Try
            'Dim correo As New System.Net.Mail.MailMessage
            'correo.To = destinatario
            'correo.From = remitente
            'correo.BodyFormat = MailFormat.Html
            'correo.Body = texto
            'correo.Subject = asunto

            'Dim pp As System.Web.Mail.SmtpMail
            ''necesario para arsys
            'pp.SmtpServer = ctes.servidorSmtp
            'pp.Send(correo)
        Catch ex As Exception

        End Try

    End Sub





End Class

Public Class cNodoBox

#Region " Estructura "

#Region " Estructura interna "

    ' Objeto de apoyo para manejo de informaci�n en un comboBox
    Private dataText As String
    Private dataId As String

#End Region

#End Region

    Public Property text() As String
        Get
            Return (Me.dataText)
        End Get
        Set(ByVal Value As String)
            Me.dataText = Value
        End Set
    End Property

    Public Property id() As String
        Get
            Return (Me.dataId)
        End Get
        Set(ByVal Value As String)
            Me.dataId = Value
        End Set
    End Property

    Public Sub New(ByVal tmpTexto As String, ByVal tmpId As Long)
        dataText = tmpTexto
        dataId = tmpId
    End Sub

    Public Overrides Function toString() As String
        Return (Me.dataText)
    End Function

End Class

