<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class listCarsWithObjectDataSource
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IdCarDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IdManufacturerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ImageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ModelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DescriptionDataGridViewTextBoxColumn, Me.IdCarDataGridViewTextBoxColumn, Me.IdManufacturerDataGridViewTextBoxColumn, Me.ImageDataGridViewTextBoxColumn, Me.ModelDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.BindingSource1
        Me.DataGridView1.Location = New System.Drawing.Point(54, 21)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(591, 216)
        Me.DataGridView1.TabIndex = 0
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(windowsFormBaseVb.cars)
        '
        'DescriptionDataGridViewTextBoxColumn
        '
        Me.DescriptionDataGridViewTextBoxColumn.DataPropertyName = "description"
        Me.DescriptionDataGridViewTextBoxColumn.HeaderText = "description"
        Me.DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        '
        'IdCarDataGridViewTextBoxColumn
        '
        Me.IdCarDataGridViewTextBoxColumn.DataPropertyName = "idCar"
        Me.IdCarDataGridViewTextBoxColumn.HeaderText = "idCar"
        Me.IdCarDataGridViewTextBoxColumn.Name = "IdCarDataGridViewTextBoxColumn"
        '
        'IdManufacturerDataGridViewTextBoxColumn
        '
        Me.IdManufacturerDataGridViewTextBoxColumn.DataPropertyName = "idManufacturer"
        Me.IdManufacturerDataGridViewTextBoxColumn.HeaderText = "idManufacturer"
        Me.IdManufacturerDataGridViewTextBoxColumn.Name = "IdManufacturerDataGridViewTextBoxColumn"
        '
        'ImageDataGridViewTextBoxColumn
        '
        Me.ImageDataGridViewTextBoxColumn.DataPropertyName = "image"
        Me.ImageDataGridViewTextBoxColumn.HeaderText = "image"
        Me.ImageDataGridViewTextBoxColumn.Name = "ImageDataGridViewTextBoxColumn"
        '
        'ModelDataGridViewTextBoxColumn
        '
        Me.ModelDataGridViewTextBoxColumn.DataPropertyName = "model"
        Me.ModelDataGridViewTextBoxColumn.HeaderText = "model"
        Me.ModelDataGridViewTextBoxColumn.Name = "ModelDataGridViewTextBoxColumn"
        '
        'listCarsWithObjectDataSource
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(741, 327)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "listCarsWithObjectDataSource"
        Me.Text = "listCarsWithObjectDataSource"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdCarDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdManufacturerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModelDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
