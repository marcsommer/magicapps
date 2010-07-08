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
             this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
             this.SuspendLayout();
         
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(348, 12);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(336, 257);
            this.propertyGrid1.TabIndex = 1;
             

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}