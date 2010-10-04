namespace myWay.userControls
{
    partial class projectMode
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbProjectTemplate = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.labNumberOfApps = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kbTargetDirectory = new ComponentFactory.Krypton.Toolkit.KryptonDropButton();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.rt1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.labHelp = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbProjectTemplate);
            this.groupBox2.Controls.Add(this.labNumberOfApps);
            this.groupBox2.Controls.Add(this.kbTargetDirectory);
            this.groupBox2.Controls.Add(this.kryptonLabel4);
            this.groupBox2.Controls.Add(this.kryptonButton1);
            this.groupBox2.Controls.Add(this.kryptonLabel3);
            this.groupBox2.Location = new System.Drawing.Point(18, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 208);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Project generation";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lbProjectTemplate
            // 
            this.lbProjectTemplate.Location = new System.Drawing.Point(114, 25);
            this.lbProjectTemplate.Name = "lbProjectTemplate";
            this.lbProjectTemplate.Size = new System.Drawing.Size(268, 89);
            this.lbProjectTemplate.TabIndex = 42;
            this.lbProjectTemplate.SelectedIndexChanged += new System.EventHandler(this.lbProjectTemplate_SelectedIndexChanged);
            // 
            // labNumberOfApps
            // 
            this.labNumberOfApps.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
            this.labNumberOfApps.Location = new System.Drawing.Point(13, 163);
            this.labNumberOfApps.Name = "labNumberOfApps";
            this.labNumberOfApps.Size = new System.Drawing.Size(21, 25);
            this.labNumberOfApps.TabIndex = 41;
            this.labNumberOfApps.Values.Text = "--";
            // 
            // kbTargetDirectory
            // 
            this.kbTargetDirectory.Location = new System.Drawing.Point(114, 126);
            this.kbTargetDirectory.Name = "kbTargetDirectory";
            this.kbTargetDirectory.Size = new System.Drawing.Size(268, 25);
            this.kbTargetDirectory.TabIndex = 33;
            this.kbTargetDirectory.Values.Text = "Select a target directory";
            this.kbTargetDirectory.Click += new System.EventHandler(this.kbTargetDirectory_Click);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(10, 132);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(90, 19);
            this.kryptonLabel4.TabIndex = 32;
            this.kryptonLabel4.Values.Text = "Target directory";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(215, 163);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(167, 25);
            this.kryptonButton1.TabIndex = 30;
            this.kryptonButton1.Values.Image = global::myWay.Properties.Resources.application_lightning;
            this.kryptonButton1.Values.Text = "Apply project template";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(10, 25);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(92, 19);
            this.kryptonLabel3.TabIndex = 30;
            this.kryptonLabel3.Values.Text = "Project template";
            // 
            // rt1
            // 
            this.rt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rt1.Location = new System.Drawing.Point(17, 19);
            this.rt1.Name = "rt1";
            this.rt1.Size = new System.Drawing.Size(376, 332);
            this.rt1.TabIndex = 37;
            this.rt1.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.labHelp);
            this.groupBox1.Location = new System.Drawing.Point(18, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 145);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Help";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(19, 52);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(249, 85);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "1. choose the project type you want\n2. choose target directory\n3. click on button" +
                "\n\nmagic appears..";
            // 
            // labHelp
            // 
            this.labHelp.AutoSize = true;
            this.labHelp.Location = new System.Drawing.Point(16, 25);
            this.labHelp.Name = "labHelp";
            this.labHelp.Size = new System.Drawing.Size(236, 13);
            this.labHelp.TabIndex = 0;
            this.labHelp.Text = "Use this form to create proejct from the database\r\n";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rt1);
            this.groupBox3.Location = new System.Drawing.Point(417, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(404, 359);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Results";
            // 
            // projectMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "projectMode";
            this.Size = new System.Drawing.Size(857, 390);
            this.Load += new System.EventHandler(this.projectMode_Load);
            this.VisibleChanged += new System.EventHandler(this.projectMode_VisibleChanged);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.projectMode_ControlRemoved);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox lbProjectTemplate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labNumberOfApps;
        private ComponentFactory.Krypton.Toolkit.KryptonDropButton kbTargetDirectory;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private System.Windows.Forms.RichTextBox rt1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labHelp;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox3;

    }
}
