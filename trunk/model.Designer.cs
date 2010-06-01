namespace myWay
{
    partial class model
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(model));
            this.imageListTables = new System.Windows.Forms.ImageList(this.components);
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.lbTables = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.kryptonHeader1 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.lbFields = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.kryptonContextMenu1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            this.kryptonContextMenuHeading1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuHeading();
            this.kryptonContextMenuLinkLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuLinkLabel();
            this.kryptonHeader2 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.butNewField = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.butNewTable = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtValidationRule = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonHeader3 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.lbValidationRules = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.butDeleteTable = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton3 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonContextMenuImageSelect1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuImageSelect();
            this.kryptonContextMenuItems1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuItems2 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.klRelations = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.kryptonHeader4 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.kp1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.butDeleteField = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kp1)).BeginInit();
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
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(12, 345);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(277, 195);
            this.propertyGrid1.TabIndex = 5;
            this.propertyGrid1.Click += new System.EventHandler(this.propertyGrid1_Click);
            // 
            // lbTables
            // 
            this.lbTables.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ContextMenuItemImageColumn;
            this.lbTables.ItemStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorOverflow;
            this.lbTables.Location = new System.Drawing.Point(12, 58);
            this.lbTables.Name = "lbTables";
            this.lbTables.Size = new System.Drawing.Size(240, 218);
            this.lbTables.TabIndex = 7;
            this.lbTables.SelectedIndexChanged += new System.EventHandler(this.kryptonListBox1_SelectedIndexChanged);
            this.lbTables.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbTables_MouseDown);
            this.lbTables.Click += new System.EventHandler(this.lbTables_Click);
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.Location = new System.Drawing.Point(12, 33);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.Size = new System.Drawing.Size(82, 29);
            this.kryptonHeader1.TabIndex = 8;
            this.kryptonHeader1.Values.Description = "";
            this.kryptonHeader1.Values.Heading = "Tables";
            // 
            // lbFields
            // 
            this.lbFields.ItemStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorOverflow;
            this.lbFields.KryptonContextMenu = this.kryptonContextMenu1;
            this.lbFields.Location = new System.Drawing.Point(258, 58);
            this.lbFields.Name = "lbFields";
            this.lbFields.Size = new System.Drawing.Size(202, 217);
            this.lbFields.TabIndex = 12;
            this.lbFields.SelectedIndexChanged += new System.EventHandler(this.lbFields_SelectedIndexChanged);
            // 
            // kryptonContextMenu1
            // 
            this.kryptonContextMenu1.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuHeading1,
            this.kryptonContextMenuLinkLabel1});
            // 
            // kryptonContextMenuHeading1
            // 
            this.kryptonContextMenuHeading1.ExtraText = "";
            this.kryptonContextMenuHeading1.Text = "Type";
            // 
            // kryptonContextMenuLinkLabel1
            // 
            this.kryptonContextMenuLinkLabel1.ExtraText = "";
            this.kryptonContextMenuLinkLabel1.Text = "int";
            this.kryptonContextMenuLinkLabel1.Click += new System.EventHandler(this.changeType);
            // 
            // kryptonHeader2
            // 
            this.kryptonHeader2.Location = new System.Drawing.Point(258, 33);
            this.kryptonHeader2.Name = "kryptonHeader2";
            this.kryptonHeader2.Size = new System.Drawing.Size(76, 29);
            this.kryptonHeader2.TabIndex = 13;
            this.kryptonHeader2.Values.Description = "";
            this.kryptonHeader2.Values.Heading = "Fields";
            // 
            // butNewField
            // 
            this.butNewField.Location = new System.Drawing.Point(379, 249);
            this.butNewField.Name = "butNewField";
            this.butNewField.Size = new System.Drawing.Size(39, 26);
            this.butNewField.TabIndex = 16;
            this.butNewField.Values.Image = global::myWay.Properties.Resources.table_add;
            this.butNewField.Values.Text = "";
            this.butNewField.Click += new System.EventHandler(this.butNewField_Click);
            // 
            // butNewTable
            // 
            this.butNewTable.Location = new System.Drawing.Point(177, 250);
            this.butNewTable.Name = "butNewTable";
            this.butNewTable.Size = new System.Drawing.Size(36, 26);
            this.butNewTable.TabIndex = 20;
            this.butNewTable.Values.Image = global::myWay.Properties.Resources.table_add;
            this.butNewTable.Values.Text = "";
            this.butNewTable.Click += new System.EventHandler(this.butNewTable_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(533, 250);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(186, 26);
            this.kryptonButton1.TabIndex = 25;
            this.kryptonButton1.Values.Text = "Modify";
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(466, 250);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(61, 26);
            this.kryptonButton2.TabIndex = 24;
            this.kryptonButton2.Values.Text = "New";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // txtValidationRule
            // 
            this.txtValidationRule.Location = new System.Drawing.Point(466, 221);
            this.txtValidationRule.Name = "txtValidationRule";
            this.txtValidationRule.Size = new System.Drawing.Size(253, 22);
            this.txtValidationRule.TabIndex = 23;
            // 
            // kryptonHeader3
            // 
            this.kryptonHeader3.Location = new System.Drawing.Point(466, 33);
            this.kryptonHeader3.Name = "kryptonHeader3";
            this.kryptonHeader3.Size = new System.Drawing.Size(158, 29);
            this.kryptonHeader3.TabIndex = 22;
            this.kryptonHeader3.Values.Description = "";
            this.kryptonHeader3.Values.Heading = "Validation rules";
            // 
            // lbValidationRules
            // 
            this.lbValidationRules.ItemStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorOverflow;
            this.lbValidationRules.Location = new System.Drawing.Point(466, 58);
            this.lbValidationRules.Name = "lbValidationRules";
            this.lbValidationRules.Size = new System.Drawing.Size(253, 157);
            this.lbValidationRules.TabIndex = 21;
            this.lbValidationRules.SelectedIndexChanged += new System.EventHandler(this.lbValidationRules_SelectedIndexChanged);
            // 
            // butDeleteTable
            // 
            this.butDeleteTable.Location = new System.Drawing.Point(219, 250);
            this.butDeleteTable.Name = "butDeleteTable";
            this.butDeleteTable.Size = new System.Drawing.Size(32, 25);
            this.butDeleteTable.TabIndex = 26;
            this.butDeleteTable.Values.Image = global::myWay.Properties.Resources.table_delete;
            this.butDeleteTable.Values.Text = "";
            this.butDeleteTable.Click += new System.EventHandler(this.butDeleteTable_Click);
            // 
            // kryptonButton3
            // 
            this.kryptonButton3.Location = new System.Drawing.Point(601, 316);
            this.kryptonButton3.Name = "kryptonButton3";
            this.kryptonButton3.Size = new System.Drawing.Size(131, 58);
            this.kryptonButton3.TabIndex = 27;
            this.kryptonButton3.Values.Image = global::myWay.Properties.Resources.refresh_48;
            this.kryptonButton3.Values.Text = "Refresh";
            // 
            // klRelations
            // 
            this.klRelations.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ContextMenuItemImageColumn;
            this.klRelations.ItemStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorOverflow;
            this.klRelations.Location = new System.Drawing.Point(324, 380);
            this.klRelations.Name = "klRelations";
            this.klRelations.Size = new System.Drawing.Size(203, 160);
            this.klRelations.TabIndex = 28;
            this.klRelations.SelectedIndexChanged += new System.EventHandler(this.klRelations_SelectedIndexChanged);
            // 
            // kryptonHeader4
            // 
            this.kryptonHeader4.Location = new System.Drawing.Point(324, 345);
            this.kryptonHeader4.Name = "kryptonHeader4";
            this.kryptonHeader4.Size = new System.Drawing.Size(105, 29);
            this.kryptonHeader4.TabIndex = 29;
            this.kryptonHeader4.Values.Description = "";
            this.kryptonHeader4.Values.Heading = "Relations";
            // 
            // kp1
            // 
            this.kp1.AutoSize = true;
            this.kp1.Location = new System.Drawing.Point(739, 58);
            this.kp1.Name = "kp1";
            this.kp1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.PanelCustom1;
            this.kp1.Size = new System.Drawing.Size(209, 218);
            this.kp1.TabIndex = 30;
            // 
            // butDeleteField
            // 
            this.butDeleteField.Location = new System.Drawing.Point(424, 249);
            this.butDeleteField.Name = "butDeleteField";
            this.butDeleteField.Size = new System.Drawing.Size(32, 25);
            this.butDeleteField.TabIndex = 31;
            this.butDeleteField.Values.Image = global::myWay.Properties.Resources.table_delete;
            this.butDeleteField.Values.Text = "";
            this.butDeleteField.Click += new System.EventHandler(this.butDeleteField_Click);
            // 
            // model
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 565);
            this.Controls.Add(this.butDeleteField);
            this.Controls.Add(this.kp1);
            this.Controls.Add(this.kryptonHeader4);
            this.Controls.Add(this.klRelations);
            this.Controls.Add(this.kryptonButton3);
            this.Controls.Add(this.butDeleteTable);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.kryptonButton2);
            this.Controls.Add(this.txtValidationRule);
            this.Controls.Add(this.kryptonHeader3);
            this.Controls.Add(this.lbValidationRules);
            this.Controls.Add(this.butNewTable);
            this.Controls.Add(this.butNewField);
            this.Controls.Add(this.kryptonHeader2);
            this.Controls.Add(this.lbFields);
            this.Controls.Add(this.kryptonHeader1);
            this.Controls.Add(this.lbTables);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "model";
            this.Text = "model";
            this.Load += new System.EventHandler(this.model_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kp1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ImageList imageListTables;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox lbTables;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader1;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox lbFields;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton butNewField;
        private ComponentFactory.Krypton.Toolkit.KryptonButton butNewTable;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtValidationRule;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader3;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox lbValidationRules;
        private ComponentFactory.Krypton.Toolkit.KryptonButton butDeleteTable;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton3;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu kryptonContextMenu1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuHeading kryptonContextMenuHeading1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuLinkLabel kryptonContextMenuLinkLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuImageSelect kryptonContextMenuImageSelect1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems2;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox klRelations;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader4;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kp1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton butDeleteField;
    }
}