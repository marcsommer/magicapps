namespace myWay
{
    partial class launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(launcher));
            this.butNewProject2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.butOpenProject2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.butReload = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.butEditModel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // butNewProject2
            // 
            this.butNewProject2.Location = new System.Drawing.Point(12, 12);
            this.butNewProject2.Name = "butNewProject2";
            this.butNewProject2.Size = new System.Drawing.Size(115, 38);
            this.butNewProject2.TabIndex = 26;
            this.butNewProject2.Values.Image = global::myWay.Properties.Resources.application_osx;
            this.butNewProject2.Values.Text = "New project";
            this.butNewProject2.Click += new System.EventHandler(this.butNewProject2_Click);
            // 
            // butOpenProject2
            // 
            this.butOpenProject2.Location = new System.Drawing.Point(133, 12);
            this.butOpenProject2.Name = "butOpenProject2";
            this.butOpenProject2.Size = new System.Drawing.Size(128, 38);
            this.butOpenProject2.TabIndex = 25;
            this.butOpenProject2.Values.Image = global::myWay.Properties.Resources.briefcase;
            this.butOpenProject2.Values.Text = "Open project";
            this.butOpenProject2.Click += new System.EventHandler(this.butOpenProject2_Click);
            // 
            // butReload
            // 
            this.butReload.Location = new System.Drawing.Point(422, 12);
            this.butReload.Name = "butReload";
            this.butReload.Size = new System.Drawing.Size(122, 38);
            this.butReload.TabIndex = 24;
            this.butReload.Values.Image = global::myWay.Properties.Resources.refreshData;
            this.butReload.Values.Text = "Reload model";
            this.butReload.Click += new System.EventHandler(this.butReload_Click);
            // 
            // butEditModel
            // 
            this.butEditModel.Location = new System.Drawing.Point(303, 12);
            this.butEditModel.Name = "butEditModel";
            this.butEditModel.Size = new System.Drawing.Size(113, 38);
            this.butEditModel.TabIndex = 23;
            this.butEditModel.Values.Image = global::myWay.Properties.Resources.building_edit;
            this.butEditModel.Values.Text = "Edit Model";
            this.butEditModel.Click += new System.EventHandler(this.butEditModel_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorStack;
            this.kryptonButton1.Location = new System.Drawing.Point(599, 12);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(125, 38);
            this.kryptonButton1.TabIndex = 27;
            this.kryptonButton1.Values.Image = global::myWay.Properties.Resources.contrast;
            this.kryptonButton1.Values.Text = "Change mode";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 314);
            this.panel1.TabIndex = 28;
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorStack;
            this.kryptonButton2.Location = new System.Drawing.Point(730, 12);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(97, 38);
            this.kryptonButton2.TabIndex = 29;
            this.kryptonButton2.Values.Image = global::myWay.Properties.Resources.salvavidas;
            this.kryptonButton2.Values.Text = "Help";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(839, 403);
            this.Controls.Add(this.kryptonButton2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.butNewProject2);
            this.Controls.Add(this.butOpenProject2);
            this.Controls.Add(this.butReload);
            this.Controls.Add(this.butEditModel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "launcher";
            this.Text = "launcher";
            this.Load += new System.EventHandler(this.launcher_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.launcher_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton butNewProject2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton butOpenProject2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton butReload;
        private ComponentFactory.Krypton.Toolkit.KryptonButton butEditModel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
    }
}