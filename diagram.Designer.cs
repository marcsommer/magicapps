namespace myWay
{
    partial class diagram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(diagram));
            this.diagramControl2 = new Netron.Diagramming.Win.DiagramControl();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.diagramControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // diagramControl2
            // 
            this.diagramControl2.AllowDrop = true;
            this.diagramControl2.AutoScroll = true;
            this.diagramControl2.BackColor = System.Drawing.Color.White;
            this.diagramControl2.BackgroundType = Netron.Diagramming.Core.CanvasBackgroundTypes.FlatColor;
            this.diagramControl2.Document = ((Netron.Diagramming.Core.Document)(resources.GetObject("diagramControl2.Document")));
            this.diagramControl2.EnableAddConnection = true;
            this.diagramControl2.Location = new System.Drawing.Point(12, 12);
            this.diagramControl2.Magnification = new System.Drawing.SizeF(100F, 100F);
            this.diagramControl2.Name = "diagramControl2";
            this.diagramControl2.Origin = new System.Drawing.Point(0, 0);
            this.diagramControl2.ShowPage = false;
            this.diagramControl2.ShowRulers = false;
            this.diagramControl2.Size = new System.Drawing.Size(305, 257);
            this.diagramControl2.TabIndex = 0;
            this.diagramControl2.Text = "diagramControl2";
            this.diagramControl2.OnShowCanvasProperties += new System.EventHandler<Netron.Diagramming.Core.SelectionEventArgs>(this.diagramControl2_OnShowCanvasProperties);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(348, 12);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(336, 257);
            this.propertyGrid1.TabIndex = 1;
            // 
            // diagram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 300);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.diagramControl2);
            this.Name = "diagram";
            this.Text = "diagram";
            this.Load += new System.EventHandler(this.diagram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.diagramControl2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Netron.Diagramming.Win.DiagramControl diagramControl2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}