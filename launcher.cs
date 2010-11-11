using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;


using Nini.Config;


using Velocity = NVelocity.App.Velocity;
using VelocityContext = NVelocity.VelocityContext;
using ParseErrorException = NVelocity.Exception.ParseErrorException;
using MethodInvocationException = NVelocity.Exception.MethodInvocationException;

using ComponentFactory.Krypton.Toolkit;

using System.Threading;
 

// sound
using System.Media;

// reg expr
using System.Text.RegularExpressions;

// para app.config
using System.Configuration;

namespace myWay
{
    public partial class launcher : Form
    {

        protected List<string> errores = new List<string>();
        protected string mode;

        public launcher()
        {
            InitializeComponent();
        }

        private void launcher_Load(object sender, EventArgs e)
        {
            // vemos si existe un conf.xml o ultimo proyecto utilizado...
            project pr = new project();
            pr = project.loadProject(Path.Combine(util.conf_dir, "conf.xml"));
            if (pr != null)
            {
                general.actualProject = pr;
                this.Text = "myWay " + pr.name;
            }
            loadControls();
        }

        private void loadControls()
        {
            mode = sf.cadena(System.Configuration.ConfigurationManager.AppSettings["mode"]);
            switch (mode)
            {
                case "project":
                    panel1.Controls.Clear();
                    myWay.userControls.projectMode uc = new myWay.userControls.projectMode();
                    uc.actualProject = general.actualProject;
                    panel1.Controls.Add(uc);
                     uc.refreshDataWithActualProject();
                   break;
                case "template":
                    panel1.Controls.Clear();
                    myWay.userControls.templateMode ucx = new myWay.userControls.templateMode();
                    //ucx.realProject = general.actualProject;
                    panel1.Controls.Add(ucx);
                     ucx.refreshDataWithActualProject();
                   break;
                default:
                    panel1.Controls.Clear();
                    myWay.userControls.projectMode uc3 = new myWay.userControls.projectMode();
                    uc3.actualProject = general.actualProject;
                    panel1.Controls.Add(uc3);
                    uc3.refreshDataWithActualProject();
                    mode = "project";
                    break;
            }
        }


        private void kryptonButton1_Click(object sender, EventArgs e)
        {
             
            switch (mode)
            {
                case "template":
                    panel1.Controls.Clear();
                    myWay.userControls.projectMode uc = new myWay.userControls.projectMode();
                    uc.actualProject = general.actualProject;
                    panel1.Controls.Add(uc);
                    uc.refreshDataWithActualProject();
                    mode="project";
                    break;

                case "project":
                    panel1.Controls.Clear();
                    myWay.userControls.templateMode ucx = new myWay.userControls.templateMode();
                 //   ucx.realProject = general.actualProject;
                    panel1.Controls.Add(ucx);
                    ucx.refreshDataWithActualProject();
                    mode = "template";
                    break;
            }
            try
            {
                // save data...
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["mode"].Value = sf.cadena(mode);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex2)
            {

                throw;
            }

            
        }

        private void launcher_FormClosing(object sender, FormClosingEventArgs e)
        {
            //try
            //{
            //    project pr = new project();
            //    pr = general.actualProject;
                
            //    pr.templateSelectedFullUri = general.templateSelectedFullUri;

            //    pr.templateSelected = general.templateSelected;
            //    pr.templateSelectedFullUri = general.templateSelectedFullUri;

            //    pr.targetDirectory = general.targetDirectory;                 


            //    pr.saveProject(Path.Combine(util.conf_dir, "conf.xml"));
            //    pr.saveProject(Path.Combine(util.projects_dir, general.actualProject.name) + ".xml");


            //}
            //catch (Exception)
            //{

            //    //throw;
            //}

            try
            {
                // save data...
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["mode"].Value = sf.cadena(mode);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex2)
            {

                throw;
            }

        }

        private void butOpenProject2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fil = new OpenFileDialog();
            fil.DefaultExt = "xml";
            fil.InitialDirectory = util.projects_dir;

            if (fil.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(fil.FileName);
                general.actualProject = project.loadProject(fil.FileName);


                // lo guardamos como conf.xml
                if (general.actualProject != null)
                {
                    this.Text = "myWay " + general.actualProject.name;
                   // groupBox1.Text = general.actualProject.name;
                    general.actualProject.saveProject(Path.Combine(util.projects_dir, "conf.xml"));

                    loadControls();


                }

            }
        }

        private void butNewProject2_Click(object sender, EventArgs e)
        {
            newProject np = new newProject();
            np.ShowDialog();

            if (np.DialogResult == DialogResult.Cancel)
            {
            }

            else
            {
                if (np.DialogResult == DialogResult.Yes)
                {
                    general.actualProject = np.pr;
                    this.Text = "myWay " + general.actualProject.name;
                    loadControls();
                }

            }
        }

        private void butEditModel_Click(object sender, EventArgs e)
        {
            model ed = new model();
            ed.actualProject = general.actualProject;
            ed.ShowDialog();

            // actualizamos los datos...
            general.actualProject = ed.actualProject;
            loadControls();
        }

        private void butReload_Click(object sender, EventArgs e)
        {
            modifyProject np = new modifyProject();
            np.pr = general.actualProject;
            np.ShowDialog();

            if (np.DialogResult == DialogResult.Cancel)
            {
            }

            else
            {
                if (np.DialogResult == DialogResult.Yes)
                {
                    // if we found tables...
                    if (np.pr.tables.Count >= 1)
                    {
                        general.actualProject = np.pr;
                        loadControls();
                    }

                }


            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            help hp = new help();
            hp.ShowDialog();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
