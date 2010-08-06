Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        d1.AutoGenerateColumns = False
        d1.DataSource = BANCOS.getList()
        d1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill


        ' Dim fm As New bancos_list
        ' fm.ShowDialog()

        Dim fm As New bancosDetail
        fm.ShowDialog()

        ' Dim fm As New benefiDetail
        ' ' fm.createNewItem = True
        ' ' ctes.last = "33"
        ' fm.ShowDialog()

    End Sub

    Private Sub d1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles d1.CellContentClick

    End Sub

    Private Sub d1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles d1.KeyDown

    End Sub
End Class
