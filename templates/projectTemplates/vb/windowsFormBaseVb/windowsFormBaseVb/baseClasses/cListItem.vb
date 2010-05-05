

Imports System
Imports System.Collections.Generic
Imports System.Collections
Imports System.Text

Public Class cListItem


 
    Public pbStr_displayValue As String
    Public pbInt_realValue As Integer
    Public pbStr_realValue As String
    Public pbObj_realValue As Object





    Public Sub New(ByVal tmpStr_displayValue As String, ByVal tmpInt_realValue As Integer)
        Me.pbStr_displayValue = tmpStr_displayValue
        Me.pbInt_realValue = tmpInt_realValue
    End Sub


    Public Sub New(ByVal tmpStr_displayValue As String, ByVal tmpStr_realValue As String)
        Me.pbStr_displayValue = tmpStr_displayValue
        Me.pbStr_realValue = tmpStr_realValue
    End Sub


    Public Sub New(ByVal tmpStr_displayValue As String, ByVal tmpObj_realValue As Object)
        Me.pbStr_displayValue = tmpStr_displayValue
        Me.pbObj_realValue = tmpObj_realValue
    End Sub


    Public Overrides Function ToString() As String
        Return (Me.pbStr_displayValue)
    End Function





End Class
