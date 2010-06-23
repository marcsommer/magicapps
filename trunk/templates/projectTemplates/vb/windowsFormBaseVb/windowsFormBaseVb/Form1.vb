Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'MsgBox(ctes.conStringAdo)

        ' abrimos una nueva ventana..
        'Dim ca As New listCars
        'ca.Show()

        Dim listaben As New List(Of benefi)
        listaben = benefi.getList()

        Dim fm As New benefiDetail
        fm.ShowDialog()

    End Sub
End Class
