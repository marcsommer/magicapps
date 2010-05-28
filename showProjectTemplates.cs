using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace myWay
{
    public partial class showProjectTemplates : Form
    {


        public String templateSelected;
        public String text;
        public String smallTitle;


        public showProjectTemplates()
        {
            InitializeComponent();
            cargar();

        }

        private void cargar()
        {
            trTemplates.Nodes.Clear();
            loadTreeTemplates(util.projectTemplates_dir, null);
            //trTemplates.ExpandAll();
        }




        private void loadTreeTemplates(String dir, TreeNode parentNode)
        {
            TreeNode nodo = new TreeNode();
            nodo.Text = new DirectoryInfo(dir).Name;
            nodo.ImageIndex = 0;
            nodo.SelectedImageIndex = 0;
            nodo.Tag = new DirectoryInfo(dir).FullName;

            foreach (DirectoryInfo item in new DirectoryInfo(dir).GetDirectories())
            {
                loadTreeTemplates(item.FullName, nodo);
            }

           

            //foreach (FileInfo fil in new DirectoryInfo(dir).GetFiles())
            //{
            //    TreeNode tf = new TreeNode();
            //    tf.Text = fil.Name;
            //    tf.ImageIndex = 1;
            //    tf.SelectedImageIndex = 1;
            //    tf.Tag = fil.FullName;
            //    nodo.Nodes.Add(tf);
            //}


            if (parentNode != null)
            {
                parentNode.Nodes.Add(nodo);
            }
            else
            {
                trTemplates.Nodes.Add(nodo);
            }



        }

        // event when click or double click on template...
        private void trTemplates_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            String seleccionado = e.Node.Tag.ToString();
            templateSelected = seleccionado;
            smallTitle = e.Node.Text;
            
            //if (seleccionado.Equals("dir"))
            //{
            //    templateSelected = seleccionado;
            //    text = util.loadFile(seleccionado);
            //    smallTitle = seleccionado.Substring(seleccionado.LastIndexOf("\\") + 1, seleccionado.Length - seleccionado.LastIndexOf("\\") - 1);

            //}
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string targetDirectoryx = "";

            // Display the openFile dialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();

            // OK button was pressed.
            if (result == DialogResult.OK)
            {
                util.templates_dir = folderBrowserDialog1.SelectedPath;


                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["templatesPath"].Value = sf.cadena(folderBrowserDialog1.SelectedPath.ToString());
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");



                cargar();
            }

            // Cancel button was pressed.
            else if (result == DialogResult.Cancel)
            {
                return;
            }

        }

        private void trTemplates_DoubleClick(object sender, EventArgs e)
        {

            this.Close();
        }

        private void showTemplates_Load(object sender, EventArgs e)
        {

        }


    }
}
