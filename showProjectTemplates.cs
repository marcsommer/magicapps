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

        public bool tries = true;
        public showProjectTemplates()
        {
            InitializeComponent();
            cargar();

        }

        private void cargar()
        {
            trTemplates.Nodes.Clear();

            if (!Directory.Exists(util.projectTemplates_dir))
            {
                util.projectTemplates_dir = System.IO.Path.Combine(System.Environment.CurrentDirectory, "templates\\projectTemplates");
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["projectTemplatesPath"].Value = util.projectTemplates_dir;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }

            loadTreeTemplates(util.projectTemplates_dir, null);
            //trTemplates.ExpandAll();

            // try to select node ...
            TreeNode tr;
            tr = SearchTree(trTemplates.Nodes, general.actualProject.projectTemplatesDirectorySmall);

            // if nothing its loaded then its because the path to templates its erroneous ...
            if (trTemplates.Nodes.Count == 0 && tries)
            {
                tries = false;
                butRestorePath_Click(this, null);
            }



        }

        public TreeNode SearchTree(TreeNodeCollection nodes, string searchtext)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Text as string == searchtext)
                {
                    trTemplates.SelectedNode = node;
                    return node;

                }
                SearchTree(node.Nodes, searchtext);
            }
            return null;
        }

        private void loadTreeTemplates(String dir, TreeNode parentNode)
        {
            try
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
            catch (System.IO.DirectoryNotFoundException dfn)
            {
                //// si no encuentra el directorio cargamos el predeterminado
                //util.projectTemplates_dir = System.IO.Path.Combine(System.Environment.CurrentDirectory, "templates\\projectTemplates");
                //System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //config.AppSettings.Settings["projectTemplatesPath"].Value = util.projectTemplates_dir;
                //config.Save(ConfigurationSaveMode.Modified);
                //ConfigurationManager.RefreshSection("appSettings");
                //cargar();
                            

            
            }
            catch (Exception ex)
            {
               
                // throw;
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
 
        private void trTemplates_DoubleClick(object sender, EventArgs e)
        {

            this.Close();
        }

        private void showTemplates_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string targetDirectoryx = "";

            // Display the openFile dialog.
            DialogResult result = folderBrowserDialog2.ShowDialog();

            // OK button was pressed.
            if (result == DialogResult.OK)
            {
                util.projectTemplates_dir = folderBrowserDialog2.SelectedPath;

                util.projectTemplates_dir = sf.cadena(folderBrowserDialog2.SelectedPath.ToString());
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["templatesPath"].Value = sf.cadena(folderBrowserDialog2.SelectedPath.ToString());
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

        private void butRestorePath_Click(object sender, EventArgs e)
        {

            util.projectTemplates_dir = System.IO.Path.Combine(System.Environment.CurrentDirectory, "templates\\projectTemplates");
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["projectTemplatesPath"].Value = util.projectTemplates_dir;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            cargar();
        }

 
    }
}
