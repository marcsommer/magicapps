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
            this.labNumberOfLinesWritten = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtNameSpace = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kLabNameSpace = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kbTemplate = new ComponentFactory.Krypton.Toolkit.KryptonDropButton();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.butApplyTemplate2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cmbTablesx = new System.Windows.Forms.ComboBox();
            this.cmbGoToCode = new System.Windows.Forms.ComboBox();
            this.butCopy = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.t1 = new ICSharpCode.TextEditor.TextEditorControl();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labNumberOfLinesWritten);
            this.groupBox1.Controls.Add(this.txtNameSpace);
            this.groupBox1.Controls.Add(this.kLabNameSpace);
            this.groupBox1.Controls.Add(this.kbTemplate);
            this.groupBox1.Controls.Add(this.kryptonLabel2);
            this.groupBox1.Controls.Add(this.kryptonLabel1);
            this.groupBox1.Controls.Add(this.butApplyTemplate2);
            this.groupBox1.Controls.Add(this.cmbTablesx);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 184);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generation";
            // 
            // labNumberOfLinesWritten
            // 
            this.labNumberOfLinesWritten.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
            this.labNumberOfLinesWritten.Location = new System.Drawing.Point(114, 158);
            this.labNumberOfLinesWritten.Name = "labNumberOfLinesWritten";
            this.labNumberOfLinesWritten.Size = new System.Drawing.Size(21, 25);
            this.labNumberOfLinesWritten.TabIndex = 40;
            this.labNumberOfLinesWritten.Values.Text = "--";
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(114, 19);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(268, 22);
            this.txtNameSpace.TabIndex = 39;
            // 
            // kLabNameSpace
            // 
            this.kLabNameSpace.Location = new System.Drawing.Point(13, 25);
            this.kLabNameSpace.Name = "kLabNameSpace";
            this.kLabNameSpace.Size = new System.Drawing.Size(70, 19);
            this.kLabNameSpace.TabIndex = 38;
            this.kLabNameSpace.Values.Text = "NameSpace";
            // 
            // kbTemplate
            // 
            this.kbTemplate.Location = new System.Drawing.Point(114, 78);
            this.kbTemplate.Name = "kbTemplate";
            this.kbTemplate.Size = new System.Drawing.Size(268, 25);
            this.kbTemplate.TabIndex = 37;
            this.kbTemplate.Values.Text = "Select a template";
            this.kbTemplate.Click += new System.EventHandler(this.kbTemplate_Click);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(10, 78);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(57, 19);
            this.kryptonLabel2.TabIndex = 36;
            this.kryptonLabel2.Values.Text = "Template";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 50);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(37, 19);
            this.kryptonLabel1.TabIndex = 35;
            this.kryptonLabel1.Values.Text = "Table";
            // 
            // butApplyTemplate2
            // 
            this.butApplyTemplate2.Location = new System.Drawing.Point(242, 109);
            this.butApplyTemplate2.Name = "butApplyTemplate2";
            this.butApplyTemplate2.Size = new System.Drawing.Size(140, 25);
            this.butApplyTemplate2.TabIndex = 34;
            this.butApplyTemplate2.Values.Image = global::myWay.Properties.Resources.application_lightning;
            this.butApplyTemplate2.Values.Text = "Apply template";
            this.butApplyTemplate2.Click += new System.EventHandler(this.butApplyTemplate2_Click);
            // 
            // cmbTablesx
            // 
            this.cmbTablesx.FormattingEnabled = true;
            this.cmbTablesx.Location = new System.Drawing.Point(114, 50);
            this.cmbTablesx.Name = "cmbTablesx";
            this.cmbTablesx.Size = new System.Drawing.Size(268, 21);
            this.cmbTablesx.TabIndex = 33;
            // 
            // cmbGoToCode
            // 
            this.cmbGoToCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGoToCode.FormattingEnabled = true;
            this.cmbGoToCode.Location = new System.Drawing.Point(402, 14);
            this.cmbGoToCode.Name = "cmbGoToCode";
            this.cmbGoToCode.Size = new System.Drawing.Size(234, 21);
            this.cmbGoToCode.TabIndex = 41;
            // 
            // butCopy
            // 
            this.butCopy.Location = new System.Drawing.Point(642, 10);
            this.butCopy.Name = "butCopy";
            this.butCopy.Size = new System.Drawing.Size(68, 26);
            this.butCopy.TabIndex = 40;
            this.butCopy.Values.Image = global::myWay.Properties.Resources.css;
            this.butCopy.Values.Text = "Copy";
            // 
            // t1
            // 
            this.t1.IsReadOnly = false;
            this.t1.Location = new System.Drawing.Point(414, 53);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(410, 285);
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
            this.cmbLanguage.Location = new System.Drawing.Point(725, 14);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(99, 21);
            this.cmbLanguage.TabIndex = 43;
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            // 
            // templateMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.cmbGoToCode);
            this.Controls.Add(this.butCopy);
            this.Controls.Add(this.groupBox1);
            this.Name = "templateMode";
            this.Size = new System.Drawing.Size(857, 376);
            this.Load += new System.EventHandler(this.templateMode_Load);
            this.VisibleChanged += new System.EventHandler(this.templateMode_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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

    }
}
