
<AttributeUsage(AttributeTargets.Property Or AttributeTargets.Field)> _
Public Class ValidLengthAttribute
    Inherits Attribute

    Private _min As Integer
    Private _max As Integer
    Private _message As String

    Public Sub New(ByVal min As Integer, ByVal max As Integer)
        _min = min
        _max = max

    End Sub

    Public Sub New()

    End Sub

    Public Property message() As String
        Get
            Return _message
        End Get
        Set(ByVal value As String)
            _message = value
        End Set
    End Property

    Public Property min() As String
        Get
            Return _min
        End Get
        Set(ByVal value As String)
            _min = value
        End Set
    End Property

    Public Property max() As String
        Get
            Return _max
        End Get
        Set(ByVal value As String)
            _max = value
        End Set
    End Property


    Public Function IsValid(ByVal theValue As String) As Boolean
        Dim length As Integer
        length = theValue.Length
        If (length >= _min And length <= _max) Then Return True
        Return False
    End Function



End Class
