

Imports System.Reflection

Public Class Validator
    Public Messages As New ArrayList
    Public Function IsValid(ByVal anObject As Object) As Boolean
        Dim isValidx As Boolean = True
        Dim fields As FieldInfo() = anObject.GetType().GetFields((BindingFlags.Public Or BindingFlags.Instance))
        Dim field As FieldInfo
        For Each field In fields
            If Not isValidField(field, anObject) Then
                isValidx = False
            End If
        Next field
        Return isValidx
    End Function 'IsValid
    Private Overloads Function isValidField(ByVal aField As FieldInfo, ByVal anObject As Object) As Boolean
        Dim attributes As Object() = aField.GetCustomAttributes(GetType(ValidLengthAttribute), True)
        If attributes.GetLength(0) = 0 Then
            Return True
        End If
        Return isValidField(aField, anObject, CType(attributes(0), ValidLengthAttribute))
    End Function 'isValidField
    Private Overloads Function isValidField(ByVal aField As FieldInfo, ByVal anObject As Object, ByVal anAttr As ValidLengthAttribute) As Boolean
        Dim theValue As String = CStr(aField.GetValue(anObject))
        If anAttr.IsValid(theValue) Then
            Return True
        End If
        addMessages(aField, anAttr)
        Return False
    End Function 'isValidField
    Private Sub addMessages(ByVal aField As FieldInfo, ByVal anAttr As ValidLengthAttribute)
        If Not (anAttr.message Is Nothing) Then
            Messages.Add(anAttr.message)
            Return
        End If
        Messages.Add(("Invalid range for " + aField.Name + ". Valid range is between " + anAttr.min + " and " + anAttr.max))
    End Sub 'addMessages
End Class 'Validator