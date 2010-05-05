namespace myWay
{
    partial class modifyProject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.rt1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.butSave = new System.Windows.Forms.Button();
            this.butSaveChanges = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(144, 46);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(214, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(144, 83);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(214, 20);
            this.txtHost.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Host";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(144, 157);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(214, 20);
            this.txtUser.TabIndex = 5;
            this.txtUser.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "User";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(144, 200);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(214, 20);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(61, 316);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 9;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // rt1
            // 
            this.rt1.Location = new System.Drawing.Point(376, 46);
            this.rt1.Name = "rt1";
            this.rt1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rt1.Size = new System.Drawing.Size(237, 293);
            this.rt1.TabIndex = 10;
            this.rt1.Text = "";
            this.rt1.TextChanged += new System.EventHandler(this.rt1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Type of database";
            // 
            // cmbDataType
            // 
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Location = new System.Drawing.Point(144, 238);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(214, 21);
            this.cmbDataType.TabIndex = 12;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(144, 121);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(214, 20);
            this.txtDatabase.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Database";
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(144, 316);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(107, 23);
            this.butSave.TabIndex = 15;
            this.butSave.Text = "Test";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butSaveChanges
            // 
            this.butSaveChanges.Location = new System.Drawing.Point(257, 316);
            this.butSaveChanges.Name = "butSaveChanges";
            this.butSaveChanges.Size = new System.Drawing.Size(107, 23);
            this.butSaveChanges.TabIndex = 16;
            this.butSaveChanges.Text = "Save changes";
            this.butSaveChanges.UseVisualStyleBackColor = true;
            this.butSaveChanges.Click += new System.EventHandler(this.butSaveChanges_Click);
            // 
            // modifyProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 371);
            this.Controls.Add(this.butSaveChanges);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbDataType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rt1);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "modifyProject";
            this.Text = "Modify project";
            this.Load += new System.EventHandler(this.newProject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.RichTextBox rt1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDataType;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butSaveChanges;
    }
}