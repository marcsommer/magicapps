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