Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'MsgBox(ctes.conStringAdo)
        Dim bdt As New benefiDataTable
        bdt.fillMe()
        d1.DataSource = bdt

        Dim fm As New benefiDetail
        fm.ShowDialog()

    End Sub
End Class
