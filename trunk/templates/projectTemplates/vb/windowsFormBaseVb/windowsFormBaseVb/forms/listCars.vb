Public Class listCars

    Private Sub listCars_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' rellenamos el grid con una lista
        Dim listaCars As New List(Of cars)
        listaCars = cars.getList()
        DataGridView1.DataSource = listaCars

    End Sub

    

    ' cuando se selecciona una fila...
    Private Sub DataGridView1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim ca As New cars
            ca = CType(DataGridView1.SelectedRows.Item(0).DataBoundItem, cars)
            ca = Nothing

        End If
    End Sub
End Class