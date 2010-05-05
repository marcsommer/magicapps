<#-- 
 
 crea una clase para c# para la tabla  ${table}...
 Author : Luis Molina...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="list${table}">
<#assign extensionFile="vb">
<#assign languageGenerated="vb">
<#assign description="vb">
<#assign targetDirectory="">
<#assign appliesToAllTables="true">
<#-- END variables used internally by the generator... -->
Public Class list${table}

    Private Sub list${table}_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' rellenamos el grid con una lista
        Dim lista${table} As New List(Of ${table})
        lista${table} = ${table}.getList()
        DataGridView1.DataSource = lista${table}

    End Sub

    

    ' cuando se selecciona una fila...
    Private Sub DataGridView1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedObject As New ${table}
            selectedObject = CType(DataGridView1.SelectedRows.Item(0).DataBoundItem, ${table})
            selectedObject = Nothing

        End If
    End Sub
End Class