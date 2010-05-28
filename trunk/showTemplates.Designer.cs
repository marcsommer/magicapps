namespace myWay
{
    partial class showTemplates
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(showTemplates));
            this.imageListFiles = new System.Windows.Forms.ImageList(this.components);
            this.trTemplates = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // imageListFiles
            // 
            this.imageListFiles.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFiles.ImageStream")));
            this.imageListFiles.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListFiles.Images.SetKeyName(0, "folder.png");
            this.imageListFiles.Images.SetKeyName(1, "layout_sidebar.png");
            // 
            // trTemplates
            // 
            this.trTemplates.ImageIndex = 0;
            this.trTemplates.ImageList = this.imageListFiles;
            this.trTemplates.Location = new System.Drawing.Point(67, 12);
            this.trTemplates.Name = "trTemplates";
            this.trTemplates.SelectedImageIndex = 0;
            this.trTemplates.Size = new System.Drawing.Size(522, 326);
            this.trTemplates.TabIndex = 5;
            this.trTemplates.DoubleClick += new System.EventHandler(this.trTemplates_DoubleClick);
            this.trTemplates.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trTemplates_AfterSelect);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(595, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 44);
            this.button1.TabIndex = 6;
            this.button1.Text = "Change Path";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // showTemplates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 387);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trTemplates);
            this.Name = "showTemplates";
            this.Text = "showTemplates";
            this.Load += new System.EventHandler(this.showTemplates_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageListFiles;
        private System.Windows.Forms.TreeView trTemplates;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}