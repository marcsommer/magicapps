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
    public partial class userControlEditTable : UserControl
    {

        public string oldName;
        protected table tablita;

        // para los delegados
        public Delegate userFunctionPointer; 

        public userControlEditTable()
        {
            InitializeComponent();

            tablita = new table();
            txtTable.Focus();
        }

        private void userControlEditTable_Load(object sender, EventArgs e)
        {
            userControlEditTable control = sender as userControlEditTable;
            if (control != null)
            {
                if (control.ParentForm.AcceptButton == null)
                    control.ParentForm.AcceptButton = control.butModify;
            }
        }

        private void butModify_Click(object sender, EventArgs e)
        {
            tablita.Name = txtTable.Text;
            tablita.deleted = false;
            userFunctionPointer.DynamicInvoke( oldName,tablita); 
        }
    }
}
