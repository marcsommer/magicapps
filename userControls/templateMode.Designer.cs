namespace myWay.userControls
{
    partial class templateMode
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.butApplyTemplate2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.labNumberOfLinesWritten = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kLabNameSpace = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kbTemplate = new ComponentFactory.Krypton.Toolkit.KryptonDropButton();
            this.txtNameSpace = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbTablesx = new System.Windows.Forms.ComboBox();
            this.cmbGoToCode = new System.Windows.Forms.ComboBox();
            this.butCopy = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.t1 = new ICSharpCode.TextEditor.TextEditorControl();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(15, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 184);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generation";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.54545F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.45454F));
            this.tableLayoutPanel1.Controls.Add(this.butApplyTemplate2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labNumberOfLinesWritten, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.kLabNameSpace, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.kbTemplate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtNameSpace, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbTablesx, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.3871F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.6129F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(330, 153);
            this.tableLayoutPanel1.TabIndex = 44;
            // 
            // butApplyTemplate2
            // 
            this.butApplyTemplate2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butApplyTemplate2.Location = new System.Drawing.Point(187, 112);
            this.butApplyTemplate2.Name = "butApplyTemplate2";
            this.butApplyTemplate2.Size = new System.Drawing.Size(140, 25);
            this.butApplyTemplate2.TabIndex = 34;
            this.butApplyTemplate2.Values.Image = global::myWay.Properties.Resources.application_lightning;
            this.butApplyTemplate2.Values.Text = "Apply template";
            this.butApplyTemplate2.Click += new System.EventHandler(this.butApplyTemplate2_Click);
            // 
            // labNumberOfLinesWritten
            // 
            this.labNumberOfLinesWritten.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
            this.labNumberOfLinesWritten.Location = new System.Drawing.Point(3, 112);
            this.labNumberOfLinesWritten.Name = "labNumberOfLinesWritten";
            this.labNumberOfLinesWritten.Size = new System.Drawing.Size(21, 25);
            this.labNumberOfLinesWritten.TabIndex = 40;
            this.labNumberOfLinesWritten.Values.Text = "--";
            // 
            // kLabNameSpace
            // 
            this.kLabNameSpace.Location = new System.Drawing.Point(3, 3);
            this.kLabNameSpace.Name = "kLabNameSpace";
            this.kLabNameSpace.Size = new System.Drawing.Size(70, 19);
            this.kLabNameSpace.TabIndex = 38;
            this.kLabNameSpace.Values.Text = "NameSpace";
            // 
            // kbTemplate
            // 
            this.kbTemplate.Location = new System.Drawing.Point(83, 77);
            this.kbTemplate.Name = "kbTemplate";
            this.kbTemplate.Size = new System.Drawing.Size(244, 25);
            this.kbTemplate.TabIndex = 37;
            this.kbTemplate.Values.Text = "Select a template";
            this.kbTemplate.Click += new System.EventHandler(this.kbTemplate_Click);
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(83, 3);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(244, 22);
            this.txtNameSpace.TabIndex = 39;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(3, 77);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(57, 19);
            this.kryptonLabel2.TabIndex = 36;
            this.kryptonLabel2.Values.Text = "Template";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 39);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(37, 19);
            this.kryptonLabel1.TabIndex = 35;
            this.kryptonLabel1.Values.Text = "Table";
            // 
            // cmbTablesx
            // 
            this.cmbTablesx.FormattingEnabled = true;
            this.cmbTablesx.Location = new System.Drawing.Point(83, 39);
            this.cmbTablesx.Name = "cmbTablesx";
            this.cmbTablesx.Size = new System.Drawing.Size(244, 21);
            this.cmbTablesx.TabIndex = 33;
            this.cmbTablesx.SelectedIndexChanged += new System.EventHandler(this.cmbTablesx_SelectedIndexChanged);
            // 
            // cmbGoToCode
            // 
            this.cmbGoToCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGoToCode.FormattingEnabled = true;
            this.cmbGoToCode.Location = new System.Drawing.Point(6, 19);
            this.cmbGoToCode.Name = "cmbGoToCode";
            this.cmbGoToCode.Size = new System.Drawing.Size(234, 21);
            this.cmbGoToCode.TabIndex = 41;
            this.cmbGoToCode.SelectedIndexChanged += new System.EventHandler(this.cmbGoToCode_SelectedIndexChanged);
            // 
            // butCopy
            // 
            this.butCopy.Location = new System.Drawing.Point(249, 15);
            this.butCopy.Name = "butCopy";
            this.butCopy.Size = new System.Drawing.Size(68, 26);
            this.butCopy.TabIndex = 40;
            this.butCopy.Values.Image = global::myWay.Properties.Resources.css;
            this.butCopy.Values.Text = "Copy";
            // 
            // t1
            // 
            this.t1.IsReadOnly = false;
            this.t1.Location = new System.Drawing.Point(6, 47);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(422, 304);
            this.t1.TabIndex = 42;
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            "C#",
            "HTML",
            "VBNET",
            "SQL"});
            this.cmbLanguage.Location = new System.Drawing.Point(323, 19);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(99, 21);
            this.cmbLanguage.TabIndex = 43;
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbGoToCode);
            this.groupBox2.Controls.Add(this.butCopy);
            this.groupBox2.Controls.Add(this.t1);
            this.groupBox2.Controls.Add(this.cmbLanguage);
            this.groupBox2.Location = new System.Drawing.Point(376, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(442, 357);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            // 
            // templateMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "templateMode";
            this.Size = new System.Drawing.Size(837, 397);
            this.Load += new System.EventHandler(this.templateMode_Load);
            this.VisibleChanged += new System.EventHandler(this.templateMode_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labNumberOfLinesWritten;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNameSpace;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kLabNameSpace;
        private ComponentFactory.Krypton.Toolkit.KryptonDropButton kbTemplate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton butApplyTemplate2;
        private System.Windows.Forms.ComboBox cmbTablesx;
        private System.Windows.Forms.ComboBox cmbGoToCode;
        private ComponentFactory.Krypton.Toolkit.KryptonButton butCopy;
        private ICSharpCode.TextEditor.TextEditorControl t1;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;

    }
}
