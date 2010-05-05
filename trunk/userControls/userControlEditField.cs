using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace myWay.userControls
{
    public partial class userControlEditField : UserControl
    {

        public string oldNameTable;
        public string oldNameField;
        protected field campito;


        // para los delegados
        public Delegate userFunctionPointerField; 


        public userControlEditField()
        {
            InitializeComponent();
            campito = new field();
            txtField.Focus();

        }

        private void userControlEditField_Load(object sender, EventArgs e)
        {
            userControlEditTable control = sender as userControlEditTable;
            if (control != null)
            {
                if (control.ParentForm.AcceptButton == null)
                    control.ParentForm.AcceptButton = control.butModify;
            }
        } // load

        private void butModifyField_Click(object sender, EventArgs e)
        {
            campito.Name = txtField.Text;
            campito.deleted = false;
            userFunctionPointerField.DynamicInvoke(oldNameTable, oldNameField, campito); 
        } 




    }
}
