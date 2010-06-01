using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

//using BrightIdeasSoftware;

namespace myWay
{
    public partial class model : Form
    {

        // delegados para las llamadas desde los user control..
        public delegate void functioncall(string oldName, object oa);
        private event functioncall formFunctionPointer;

        public delegate void functioncallField(string oldNameTable, string oldNameField, object oa);
        private event functioncallField formFunctionPointerField; 


        public project actualProject;
        protected string tableBeingEdited = "";

        public model()
        {
            InitializeComponent();
        }

        private void model_Load(object sender, EventArgs e)
        {

            cargarTablas();

           
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
    
            


    //this.BackgroundImage =
    //  (Bitmap)resources.GetObject("$this.BackgroundImage");


            //pcb1.Image = (Bitmap)resources.GetObject("$this.database_48.png");
            //fillGridTables();

        }


        private void cargarTablas()
        {
            if (actualProject != null)
            {
                lbTables.Items.Clear();
                foreach (table item in actualProject.tables)
                {
                    if (!item.deleted)
                    {
                       // lbTables.Items.Add(item);

                        ComponentFactory.Krypton.Toolkit.KryptonListItem kl = new ComponentFactory.Krypton.Toolkit.KryptonListItem();
                       // kl.LongText = item.Name;
                        kl.ShortText = item.Name;
                        lbTables.Items.Add(kl);
                    }
                    
                }


            }
            lbFields.Items.Clear();

             
        }


        private void cargarCampos()
        {
           
            if (lbTables.SelectedItem != null)
            {
                lbFields.Items.Clear();

                foreach (table item in actualProject.tables)
                {
                    if (item.Name.Equals(lbTables.SelectedItem.ToString()))
                    {

                        foreach (field campito in item.fields)
                        {
                            if (!campito.deleted)
                            {
   //lbFields.Items.Add(item);
                                ComponentFactory.Krypton.Toolkit.KryptonListItem kl = new ComponentFactory.Krypton.Toolkit.KryptonListItem();
                                kl.LongText = campito.type.ToString();
                                kl.ShortText = campito.Name;
                                
                                //  kl.ShortText=item.TargetName;
                                lbFields.Items.Add(kl);
                            }
                             
                            
                        }
                        
                    }
                }

            }
            lbFields.SelectedIndex = 0;

        }


        private void cargarValidationRules()
        {
            lbValidationRules.Items.Clear();
             
            foreach (table item in actualProject.tables)
            {
                if (!item.deleted && item.Name.Equals(lbTables.SelectedItem.ToString()))
                {
                    foreach (field fi in item.fields)
                    {
                        if (fi.Name.Equals(lbFields.SelectedItem.ToString()))
                        {
                            
                             foreach (validationRule vali in fi.validationRules)
                            {
                                ComponentFactory.Krypton.Toolkit.KryptonListItem kl = new ComponentFactory.Krypton.Toolkit.KryptonListItem();
                                kl.ShortText = vali.name;
                                //kl.LongText = campito.type.ToString();
                                //  kl.ShortText=item.TargetName;
                                lbValidationRules.Items.Add(kl);
                            }
                            

                          
                        }
                    }
                }

            }


        }


        //private void cargarArbol()
        //{
        //    if (actualProject != null)
        //    {

        //        // lets clean
        //        trActualProject.Nodes.Clear();

        //        foreach (table item in actualProject.tables)
        //        {
        //            tableNode parent = new tableNode(item);
        //            parent.ImageIndex = 4;
        //            parent.SelectedImageIndex = 3;
        //            parent.Tag = "table";

        //            foreach (field fi in item.fields)
        //            {
        //                fieldNode child = new fieldNode(fi );
        //                if (fi.isKey)
        //                {
        //                    child.ImageIndex = 5;
        //                    child.SelectedImageIndex = 5;
        //                }


        //                else
        //                {
        //                    child.ImageIndex = 4;
        //                    child.SelectedImageIndex = 4;
        //                }

        //                child.Tag = "field";
        //                parent.Nodes.Add(child);
        //            }
        //            trActualProject.Nodes.Add(parent);

        //        }
        //    }

        //}


      

        private void kryptonListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTables();

        }

     

       

         

        private void lbFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                // assign propertyGrid to this field..
                foreach (table item in actualProject.tables)
                {
                    if (!item.deleted && item.Name.Equals(lbTables.SelectedItem.ToString()))
                    {
                        foreach (field fi in item.fields)
                        {
                            if (fi.Name.Equals(lbFields.SelectedItem.ToString()))
                            {
                                propertyGrid1.SelectedObject = fi;

                                // now fill the validation rules
                                cargarValidationRules();

                                myWay.userControls.userControlEditField uc = new myWay.userControls.userControlEditField();
                                uc.txtField.Text = lbFields.SelectedItem.ToString();
                                uc.oldNameTable = lbTables.SelectedItem.ToString();
                                uc.oldNameField = lbFields.SelectedItem.ToString();
                                formFunctionPointerField += new functioncallField(alterField);
                                uc.userFunctionPointerField = formFunctionPointerField;


                                kp1.Controls.Clear();
                                kp1.Controls.Add(uc);
                                uc.txtField.Focus();


                            }
                        }
                    }

                 

                }


               
                //// obsolete
                //if (lbFields.SelectedItem is field)
                //{
                //    field fi= new field();
                //    fi = (field)lbFields.SelectedItem;

                    


                //    // we fill the validation rule listbox...
                //    lbValidationRules.Items.Clear();
                //    foreach (validationRule item in fi.validationRules)
                //    {
                //        lbValidationRules.Items.Add(item);
                //    }
                     
                //}

            }
            catch (Exception)
            {


            }
        }

        private void butNewTable_Click(object sender, EventArgs e)
        {
            // create a user control to edit the table
            myWay.userControls.userControlEditTable uc = new myWay.userControls.userControlEditTable();
            uc.txtTable.Text = "";
            uc.butModify.Text = "Insert";
            uc.oldName = "";
            formFunctionPointer += new functioncall(alterTable);
            uc.userFunctionPointer = formFunctionPointer;
            
            kp1.Controls.Clear();
            kp1.Controls.Add(uc);
            //kp1.Controls[0].Focus();
            uc.txtTable.Focus();           
            
         
        }

        private void butDeleteTable_Click(object sender, EventArgs e)
        {
            foreach (table item in actualProject.tables)
            {
                if (item.Name.Equals(lbTables.SelectedItem.ToString()))
                {
                    item.deleted=true;
                    actualProject.saveProject(Path.Combine(util.projects_dir, actualProject.name) + ".xml");
                   
                    // extra clean...
                    kp1.Controls.Clear();
                }
            }
            cargarTablas();
        }


        private void changeType(object sender, EventArgs e)
        {
                        
            cargarTablas();
        }

        

        private void butNewField_Click(object sender, EventArgs e)
        {
            if (!lbTables.SelectedItem.ToString().Equals(""))
            {
                // create a user control to edit the table
                myWay.userControls.userControlEditField uc = new myWay.userControls.userControlEditField();
                uc.txtField.Text = "";
                uc.butModifyField.Text = "Insert";
                uc.oldNameTable = lbTables.SelectedItem.ToString();
                uc.oldNameField = "";

                formFunctionPointerField += new functioncallField(alterField);
                uc.userFunctionPointerField = formFunctionPointerField;

                kp1.Controls.Clear();
                kp1.Controls.Add(uc);
                //kp1.Controls[0].Focus();
                uc.txtField.Focus();     
            }
           

            //if (lbTables.SelectedItem != null)
            //{
            //    foreach (table item in actualProject.tables)
            //    {
            //        if (item.Name.Equals(lbTables.SelectedItem.ToString()))
            //        {
            //            // lets create the field
            //            field campito = new field();
            //            campito.Name = txtField.Text;
            //            campito.type = field.fieldType._integer;
            //            campito.createdNew = true;
            //            item.fields.Add(campito);
                        
            //            cargarCampos();                        


            //        }
            //    }

            //}
        }

        private void klRelations_SelectedIndexChanged(object sender, EventArgs e)
        {
            // assign propertyGrid to this relation..
            foreach (table item in actualProject.tables)
            {
                if (!item.deleted && item.Name.Equals(lbTables.SelectedItem.ToString()))
                {
                    foreach (relation rel in item.relations)
                    {
                        if (rel.name.Equals(klRelations.SelectedItem.ToString()))
                        {
                            propertyGrid1.SelectedObject = rel;
                        }
                    }
                }

            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (!txtValidationRule.Text.Equals(""))
            {
                // assign propertyGrid to this field..
                foreach (table item in actualProject.tables)
                {
                    if (!item.deleted && item.Name.Equals(lbTables.SelectedItem.ToString()))
                    {
                        foreach (field fi in item.fields)
                        {
                            if (fi.Name.Equals(lbFields.SelectedItem.ToString()))
                            {
                                bool exists = false;
                                // check if validation rule exists ...
                                foreach (validationRule vali in fi.validationRules)
                                {
                                    if (vali.name == txtValidationRule.Text)
                                        exists = true;
                                }
                                if (!exists)
                                {
                                    validationRule vr = new validationRule();
                                    vr.name = txtValidationRule.Text;
                                    fi.validationRules.Add(vr);
                                }


                                // propertyGrid1.SelectedObject = vr;
                            }
                        }
                    }

                }
                
                cargarValidationRules();
                
            }
        }

        private void lbValidationRules_SelectedIndexChanged(object sender, EventArgs e)
        {
              // assign propertyGrid to this field..
            foreach (table item in actualProject.tables)
            {
                if (!item.deleted && item.Name.Equals(lbTables.SelectedItem.ToString()))
                {
                    foreach (field fi in item.fields)
                    {
                        if (fi.Name.Equals(lbFields.SelectedItem.ToString()))
                        {

                            foreach (validationRule vali in fi.validationRules)
                            {
                                if (vali.name == lbValidationRules.SelectedItem.ToString())
                                    propertyGrid1.SelectedObject = vali;
                            }



                        }
                    }
                }

            }
        }

   

       
    // funciones llamadas por los user control
        private void alterTable(string oldName, object tablita)
        {
            table tab = new table();
            tab = (table)tablita;

            // if oldName its empty its a new table...
            if (oldName.Equals(""))
            {
                actualProject.tables.Add(tab);
            }

            else
            {
                foreach (table item in actualProject.tables)
                {
                    if (item.Name.Equals(oldName))
                    {
                        item.Name = tab.Name;
                        item.nameChanged = true;
                       
                        
                    }
                }
            }

            actualProject.saveProject(Path.Combine(util.projects_dir, actualProject.name) + ".xml");
            cargarTablas();
            kp1.Controls.Clear();
        } 

    
    
    
    
    
   

     // funciones llamadas por los user control
        private void alterField(string oldNameTable, string oldNameField, object campito)
        {
            field cp = new field();
            cp = (field)campito;

            // if oldName its empty its a new field..
            if (oldNameField.Equals(""))
            {
                foreach (table item in actualProject.tables)
                {
                    if (item.Name.Equals(oldNameTable))
                    {
                        item.fields.Add(campito);
                    }
                }
                
            }

            else
            {
                foreach (table item in actualProject.tables)
                {
                    if (item.Name.Equals(oldNameTable))
                    {
                        foreach (field itemf in item.fields)
                        {
                            if (itemf.Name.Equals(oldNameTable))
                            {
                                itemf.Name = cp.Name;
                                itemf.nameChanged = true;
                            }
                        }                     
                        
                    }
                }
            }

            kp1.Controls.Clear();
            actualProject.saveProject(Path.Combine(util.projects_dir, actualProject.name) + ".xml");
            cargarCampos();
            
        }

        private void butDeleteField_Click(object sender, EventArgs e)
        {
            foreach (table item in actualProject.tables)
            {
                if (item.Name.Equals(lbTables.SelectedItem.ToString()))
                {
                    foreach (field itemf in item.fields)
                    {
                        if (itemf.Name.Equals(lbFields.SelectedItem.ToString()))
                        {
                            itemf.deleted = true;
                           
                        }
                    }
                    
                   
                }
            }
 
            // extra clean...
            kp1.Controls.Clear();
            actualProject.saveProject(Path.Combine(util.projects_dir, actualProject.name) + ".xml");
            cargarCampos();
        }

        private void lbTables_Click(object sender, EventArgs e)
        {
              selectedTables();
        }     // lbTables_Click


        private void selectedTables()
        {
            try
            {
                //txtTable.Text = lbTables.SelectedItem.ToString();

                lbFields.Items.Clear();

                foreach (table item in actualProject.tables)
                {
                    if (!item.deleted && item.Name.Equals(lbTables.SelectedItem.ToString()))
                    {

                        propertyGrid1.SelectedObject = item;

                        cargarCampos();
                        //lbFields.Items.Clear();
                        //foreach (field itemx in item.fields)
                        //{
                        //    //lbFields.Items.Add(item);
                        //    ComponentFactory.Krypton.Toolkit.KryptonListItem kl = new ComponentFactory.Krypton.Toolkit.KryptonListItem();
                        //    kl.ShortText = itemx.Name;
                        //    kl.LongText = itemx.type.ToString();
                        //    //  kl.ShortText=item.TargetName;
                        //    lbFields.Items.Add(kl);
                        //}

                        klRelations.Items.Clear();
                        foreach (relation rel in item.relations)
                        {

                            ComponentFactory.Krypton.Toolkit.KryptonListItem kl = new ComponentFactory.Krypton.Toolkit.KryptonListItem();
                            kl.ShortText = rel.name;
                            //kl.LongText = rel.name.ToString();
                            //  kl.ShortText=item.TargetName;
                            klRelations.Items.Add(kl);
                        }
                    }

                }

                // create a user control to edit the table
                myWay.userControls.userControlEditTable uc = new myWay.userControls.userControlEditTable();
                uc.txtTable.Text = lbTables.SelectedItem.ToString();
                uc.oldName = lbTables.SelectedItem.ToString();
                formFunctionPointer += new functioncall(alterTable);
                uc.userFunctionPointer = formFunctionPointer;
                kp1.Controls.Clear();
                kp1.Controls.Add(uc);
                uc.txtTable.Focus();


            }
            catch (Exception)
            {


            }
        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }

        private void lbTables_MouseDown(object sender, MouseEventArgs e)
        {
            selectedTables();
        }



    } 
}
