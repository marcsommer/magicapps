namespace myWay.userControls
{
    partial class userControlEditTable
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
            this.butModify = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtTable = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.SuspendLayout();
            // 
            // butModify
            // 
            this.butModify.Location = new System.Drawing.Point(88, 80);
            this.butModify.Name = "butModify";
            this.butModify.Size = new System.Drawing.Size(101, 26);
            this.butModify.TabIndex = 22;
            this.butModify.Values.Image = global::myWay.Properties.Resources.table_add;
            this.butModify.Values.Text = "Modify";
            this.butModify.Click += new System.EventHandler(this.butModify_Click);
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(14, 38);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(175, 22);
            this.txtTable.TabIndex = 21;
            // 
            // userControlEditTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.butModify);
            this.Controls.Add(this.txtTable);
            this.Name = "userControlEditTable";
            this.Size = new System.Drawing.Size(208, 192);
            this.Load += new System.EventHandler(this.userControlEditTable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ComponentFactory.Krypton.Toolkit.KryptonButton butModify;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTable;
    }
}
