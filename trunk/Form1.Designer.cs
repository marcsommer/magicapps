namespace myWay
{
    partial class Form1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageListTables = new System.Windows.Forms.ImageList(this.components);
            this.butEditModel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.butReload = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.butCopy = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.butOpenProject2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.butNewProject2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kbProjectTemplate = new ComponentFactory.Krypton.Toolkit.KryptonDropButton();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labNumberOfLinesWritten = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtNameSpace = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kLabNameSpace = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kbTemplate = new ComponentFactory.Krypton.Toolkit.KryptonDropButton();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.butApplyTemplate2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cmbTablesx = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labNumberOfApps = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kbTargetDirectory = new ComponentFactory.Krypton.Toolkit.KryptonDropButton();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rt1 = new System.Windows.Forms.RichTextBox();
            this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.butReturnToScript = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cmbGoToCode = new System.Windows.Forms.ComboBox();
            this.txtBus = new System.Windows.Forms.TextBox();
            this.kryptonButton3 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListTables
            // 
            this.imageListTables.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTables.ImageStream")));
            this.imageListTables.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTables.Images.SetKeyName(0, "table_edit.png");
            this.imageListTables.Images.SetKeyName(1, "table_add.png");
            this.imageListTables.Images.SetKeyName(2, "table_delete.png");
            this.imageListTables.Images.SetKeyName(3, "table.png");
            this.imageListTables.Images.SetKeyName(4, "application_osx.png");
            this.imageListTables.Images.SetKeyName(5, "application_key.png");
            this.imageListTables.Images.SetKeyName(6, "application_link.png");
            // 
            // butEditModel
            // 
            this.butEditModel.Location = new System.Drawing.Point(227, 416);
            this.butEditModel.Name = "butEditModel";
            this.butEditModel.Size = new System.Drawing.Size(167, 58);
            this.butEditModel.TabIndex = 13;
            this.butEditModel.Values.Image = global::myWay.Properties.Resources.tabs_48;
            this.butEditModel.Values.Text = "Edit Model";
            this.butEditModel.Click += new System.EventHandler(this.butEditModel_Click);
            // 
            // butReload
            // 
            this.butReload.Location = new System.Drawing.Point(227, 480);
            this.butReload.Name = "butReload";
            this.butReload.Size = new System.Drawing.Size(167, 58);
            this.butReload.TabIndex = 14;
            this.butReload.Values.Image = global::myWay.Properties.Resources.refresh_48;
            this.butReload.Values.Text = "Reload model";
            this.butReload.Click += new System.EventHandler(this.butReload_Click);
            // 
            // butCopy
            // 
            this.butCopy.Location = new System.Drawing.Point(934, 12);
            this.butCopy.Name = "butCopy";
            this.butCopy.Size = new System.Drawing.Size(68, 26);
            this.butCopy.TabIndex = 18;
            this.butCopy.Values.Image = global::myWay.Properties.Resources.css;
            this.butCopy.Values.Text = "Copy";
            this.butCopy.Click += new System.EventHandler(this.butCopy_Click);
            // 
            // butOpenProject2
            // 
            this.butOpenProject2.Location = new System.Drawing.Point(29, 416);
            this.butOpenProject2.Name = "butOpenProject2";
            this.butOpenProject2.Size = new System.Drawing.Size(167, 58);
            this.butOpenProject2.TabIndex = 21;
            this.butOpenProject2.Values.Text = "Open project";
            this.butOpenProject2.Click += new System.EventHandler(this.butOpenProject2_Click);
            // 
            // butNewProject2
            // 
            this.butNewProject2.Location = new System.Drawing.Point(29, 480);
            this.butNewProject2.Name = "butNewProject2";
            this.butNewProject2.Size = new System.Drawing.Size(167, 58);
            this.butNewProject2.TabIndex = 22;
            this.butNewProject2.Values.Image = global::myWay.Properties.Resources.paper_content_chart_48;
            this.butNewProject2.Values.Text = "New project";
            this.butNewProject2.Click += new System.EventHandler(this.butNewProject2_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(215, 89);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(167, 25);
            this.kryptonButton1.TabIndex = 30;
            this.kryptonButton1.Values.Image = global::myWay.Properties.Resources.application_lightning;
            this.kryptonButton1.Values.Text = "Apply project template";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // kbProjectTemplate
            // 
            this.kbProjectTemplate.Location = new System.Drawing.Point(114, 19);
            this.kbProjectTemplate.Name = "kbProjectTemplate";
            this.kbProjectTemplate.Size = new System.Drawing.Size(268, 25);
            this.kbProjectTemplate.TabIndex = 31;
            this.kbProjectTemplate.Values.Text = "Select a project template";
            this.kbProjectTemplate.Click += new System.EventHandler(this.kbProjectTemplate_Click);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(10, 25);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(92, 19);
            this.kryptonLabel3.TabIndex = 30;
            this.kryptonLabel3.Values.Text = "Project template";
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 184);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generation";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
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
            this.txtNameSpace.TextChanged += new System.EventHandler(this.txtNameSpace_TextChanged);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.kryptonButton3);
            this.groupBox2.Controls.Add(this.labNumberOfApps);
            this.groupBox2.Controls.Add(this.kbTargetDirectory);
            this.groupBox2.Controls.Add(this.kryptonLabel4);
            this.groupBox2.Controls.Add(this.kbProjectTemplate);
            this.groupBox2.Controls.Add(this.kryptonButton1);
            this.groupBox2.Controls.Add(this.kryptonLabel3);
            this.groupBox2.Location = new System.Drawing.Point(12, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 168);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Project generation";
            // 
            // labNumberOfApps
            // 
            this.labNumberOfApps.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
            this.labNumberOfApps.Location = new System.Drawing.Point(114, 128);
            this.labNumberOfApps.Name = "labNumberOfApps";
            this.labNumberOfApps.Size = new System.Drawing.Size(21, 25);
            this.labNumberOfApps.TabIndex = 41;
            this.labNumberOfApps.Values.Text = "--";
            // 
            // kbTargetDirectory
            // 
            this.kbTargetDirectory.Location = new System.Drawing.Point(114, 52);
            this.kbTargetDirectory.Name = "kbTargetDirectory";
            this.kbTargetDirectory.Size = new System.Drawing.Size(268, 25);
            this.kbTargetDirectory.TabIndex = 33;
            this.kbTargetDirectory.Values.Text = "Select a target directory";
            this.kbTargetDirectory.Click += new System.EventHandler(this.kbTargetDirectory_Click);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(10, 58);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(90, 19);
            this.kryptonLabel4.TabIndex = 32;
            this.kryptonLabel4.Values.Text = "Target directory";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(414, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 366);
            this.panel1.TabIndex = 35;
            // 
            // rt1
            // 
            this.rt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rt1.Location = new System.Drawing.Point(414, 416);
            this.rt1.Name = "rt1";
            this.rt1.Size = new System.Drawing.Size(588, 122);
            this.rt1.TabIndex = 36;
            this.rt1.Text = "";
            this.rt1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rt1_LinkClicked);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(649, 12);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(78, 25);
            this.kryptonButton2.TabIndex = 37;
            this.kryptonButton2.Values.Image = global::myWay.Properties.Resources.script_go;
            this.kryptonButton2.Values.Text = "Save";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // butReturnToScript
            // 
            this.butReturnToScript.Location = new System.Drawing.Point(565, 12);
            this.butReturnToScript.Name = "butReturnToScript";
            this.butReturnToScript.Size = new System.Drawing.Size(78, 25);
            this.butReturnToScript.TabIndex = 38;
            this.butReturnToScript.Values.Image = global::myWay.Properties.Resources.table_edit;
            this.butReturnToScript.Values.Text = "Script";
            this.butReturnToScript.Click += new System.EventHandler(this.butReturnToScript_Click);
            // 
            // cmbGoToCode
            // 
            this.cmbGoToCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGoToCode.FormattingEnabled = true;
            this.cmbGoToCode.Location = new System.Drawing.Point(733, 16);
            this.cmbGoToCode.Name = "cmbGoToCode";
            this.cmbGoToCode.Size = new System.Drawing.Size(195, 21);
            this.cmbGoToCode.TabIndex = 39;
            this.cmbGoToCode.SelectedIndexChanged += new System.EventHandler(this.cmbGoToCode_SelectedIndexChanged);
            // 
            // txtBus
            // 
            this.txtBus.Location = new System.Drawing.Point(414, 18);
            this.txtBus.Name = "txtBus";
            this.txtBus.Size = new System.Drawing.Size(145, 20);
            this.txtBus.TabIndex = 0;
            this.txtBus.TextChanged += new System.EventHandler(this.txtBus_TextChanged);
            // 
            // kryptonButton3
            // 
            this.kryptonButton3.Location = new System.Drawing.Point(17, 89);
            this.kryptonButton3.Name = "kryptonButton3";
            this.kryptonButton3.Size = new System.Drawing.Size(147, 25);
            this.kryptonButton3.TabIndex = 42;
            this.kryptonButton3.Values.Image = global::myWay.Properties.Resources.application_lightning;
            this.kryptonButton3.Values.Text = "Refresh templates";
            this.kryptonButton3.Click += new System.EventHandler(this.kryptonButton3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 559);
            this.Controls.Add(this.txtBus);
            this.Controls.Add(this.cmbGoToCode);
            this.Controls.Add(this.butReturnToScript);
            this.Controls.Add(this.kryptonButton2);
            this.Controls.Add(this.rt1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butNewProject2);
            this.Controls.Add(this.butOpenProject2);
            this.Controls.Add(this.butCopy);
            this.Controls.Add(this.butReload);
            this.Controls.Add(this.butEditModel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "myWay";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageListTables;
        private ComponentFactory.Krypton.Toolkit.KryptonButton butEditModel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton butReload;
        private ComponentFactory.Krypton.Toolkit.KryptonButton butCopy;
        private ComponentFactory.Krypton.Toolkit.KryptonButton butOpenProject2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton butNewProject2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonDropButton kbProjectTemplate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonDropButton kbTemplate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton butApplyTemplate2;
        private System.Windows.Forms.ComboBox cmbTablesx;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonDropButton kbTargetDirectory;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rt1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton butReturnToScript;
        private System.Windows.Forms.ComboBox cmbGoToCode;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNameSpace;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kLabNameSpace;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labNumberOfLinesWritten;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labNumberOfApps;
        private System.Windows.Forms.TextBox txtBus;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton3;
    }
}

