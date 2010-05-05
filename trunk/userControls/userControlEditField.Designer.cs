namespace myWay.userControls
{
    partial class userControlEditField
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
            this.butModifyField = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtField = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonHeader2 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.SuspendLayout();
            // 
            // butModifyField
            // 
            this.butModifyField.Location = new System.Drawing.Point(84, 113);
            this.butModifyField.Name = "butModifyField";
            this.butModifyField.Size = new System.Drawing.Size(136, 26);
            this.butModifyField.TabIndex = 20;
            this.butModifyField.Values.Image = global::myWay.Properties.Resources.table_edit;
            this.butModifyField.Values.Text = "Modify";
            this.butModifyField.Click += new System.EventHandler(this.butModifyField_Click);
            // 
            // txtField
            // 
            this.txtField.Location = new System.Drawing.Point(18, 55);
            this.txtField.Name = "txtField";
            this.txtField.Size = new System.Drawing.Size(202, 22);
            this.txtField.TabIndex = 21;
            // 
            // kryptonHeader2
            // 
            this.kryptonHeader2.Location = new System.Drawing.Point(3, 3);
            this.kryptonHeader2.Name = "kryptonHeader2";
            this.kryptonHeader2.Size = new System.Drawing.Size(130, 29);
            this.kryptonHeader2.TabIndex = 22;
            this.kryptonHeader2.Values.Description = "";
            this.kryptonHeader2.Values.Heading = "Modify field";
            // 
            // userControlEditField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonHeader2);
            this.Controls.Add(this.txtField);
            this.Controls.Add(this.butModifyField);
            this.Name = "userControlEditField";
            this.Size = new System.Drawing.Size(244, 205);
            this.Load += new System.EventHandler(this.userControlEditField_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ComponentFactory.Krypton.Toolkit.KryptonButton butModifyField;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtField;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader2;
    }
}
