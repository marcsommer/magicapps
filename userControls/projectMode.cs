using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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

namespace myWay.userControls
{
    public partial class projectMode : System.Windows.Forms.UserControl
    {
        public project actualProject;

        protected List<string> errores = new List<string>();


        public projectMode()
        {
            InitializeComponent();
        }

        private void projectMode_Load(object sender, EventArgs e)
        {
            this.Disposed += new System.EventHandler(this.projectMode_Disposed);
            

            string numberOfLinesWrittenBefore = sf.toLong(System.Configuration.ConfigurationManager.AppSettings["numberOfLinesWritten"]).ToString();
            
            string labNumberOfAppsBefore = sf.toLong(System.Configuration.ConfigurationManager.AppSettings["labNumberOfAppsWritten"]).ToString();
            labNumberOfApps.Values.Text = sf.cadena(labNumberOfAppsBefore) + " apps written with myWay";


            // lets load config files of project templates ...
            ctes.listaProjectConfigFiles.Clear();
            traverseDirectorySearchProjectConfigFiles(util.projectTemplates_dir);
            if (ctes.listaProjectConfigFiles.Count == 0)
                AsyncMessage("No hemos encontrado proyectos", Color.Red);

            foreach (projectconfigfiles item in ctes.listaProjectConfigFiles)
            {
                lbProjectTemplate.Items.Add(item.Name);
            }

          
        }



        public void refreshDataWithActualProject()
        {
            if (general.actualProject != null)
            {
                general.actualTable = general.actualProject.actualTable;

                //if (general.actualProject.nameSpace != null)
                //    txtNameSpace.Text = general.actualProject.nameSpace;

                

                general.templateSelected = general.actualProject.templateSelected;
                general.templateSelectedFullUri = general.actualProject.templateSelectedFullUri;


                general.projectTemplateSelected = general.actualProject.projectTemplatesDirectorySmall;
                general.projectTemplateSelectedFullUri = general.actualProject.projectTemplatesDirectory;


                kbTargetDirectory.Text = general.actualProject.targetDirectory;
                general.targetDirectory = general.actualProject.targetDirectory;

                //if (general.projectTemplateSelectedFullUri != null)
                //{
                //    kbProjectTemplate.Text = general.projectTemplateSelected;
                //    kbTemplate.Text = general.templateSelected;
                //}

                int contador = 0;
                int contadorFinal = 0;
                if (general.actualProject.projectTemplatesDirectory != null)
                {
                    if (lbProjectTemplate.Items.Count >= 1)
                    {
                        foreach (object item in lbProjectTemplate.Items)
                        {
                            if (item.ToString() == general.actualProject.projectTemplatesDirectorySmall)
                            {
                                contadorFinal = contador;
                            }
                            contador += 1;
                        }
                        // lbProjectTemplate.Text = general.actualProject.projectTemplatesDirectorySmall;
                    }
                    lbProjectTemplate.SetSelected(contadorFinal, true);
                }
                
                                

            }

        } // refreshDataWithActualProject


        public void traverseDirectorySearchProjectConfigFiles(string Folder)
        {
            try
            {
              
           
                DirectoryInfo dir = new DirectoryInfo(Folder);
                DirectoryInfo[] subDirs = dir.GetDirectories();
                FileInfo[] files = dir.GetFiles();

                foreach (FileInfo fi in files)
                {

                    // Console.WriteLine("NOmbre completo" + fi.FullName);

                    string originalFilename = fi.FullName;   // only the filename 
                    if (originalFilename.EndsWith("pcf"))
                    {
                        XmlConfigSource source = new XmlConfigSource(fi.FullName);

                        //IConfigSource source = new IniConfigSource(fi.FullName);
                        string pName = source.Configs["Config"].Get("Name", "Default");
                        string pDirectory = fi.Directory.ToString(); // source.Configs["Config"].Get("Directory", "Default");
                        string pDescription = source.Configs["Config"].Get("Description", "Default");
                        string pImage = source.Configs["Config"].Get("Image", "Default");
                        string pUrl = source.Configs["Config"].Get("Url", "Default");
                        source = null;


                        projectconfigfiles pcf = new projectconfigfiles();
                        pcf.Name = pName;
                        pcf.Directory = pDirectory;
                        pcf.Description = pDescription;
                        pcf.Image = pImage;
                        pcf.Url = pUrl;

                        ctes.listaProjectConfigFiles.Add(pcf);
                        pcf = null;


                    }



                    //  Console.WriteLine(cadenaFinal);

                }

                if (subDirs != null)
                {
                    foreach (DirectoryInfo sd in subDirs)
                    {
                        traverseDirectorySearchProjectConfigFiles(Folder + @"\\" + sd.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void projectMode_ControlRemoved(object sender, ControlEventArgs e)
        {

        }

        // evento cuando desaparece el control ...
        private void projectMode_VisibleChanged(object sender, EventArgs e)
        {
            saveData();

        }

        // jumps when parent form closes
        private void projectMode_Disposed(object sender, EventArgs e)
        {
            saveData();

        }


        private void saveData()
        {
            try
            {
                project pr = new project();
                pr = general.actualProject;
                //pr.templateSelectedFullUri = general.templateSelectedFullUri;

                pr.targetDirectory = general.actualProject.targetDirectory;

                // save the project template from the listbox
                if (lbProjectTemplate.Items.Count != 0)
                {
                    string pt = lbProjectTemplate.SelectedItem.ToString();
                    foreach (projectconfigfiles item in ctes.listaProjectConfigFiles)
                    {
                        if (item.Name == pt)
                        {
                            pr.projectTemplatesDirectory = item.Directory;
                        }
                    }

                    pr.projectTemplatesDirectorySmall = pt;
                }

                pr.saveProject(Path.Combine(util.conf_dir, "conf.xml"));
                pr.saveProject(Path.Combine(util.projects_dir, general.actualProject.name) + ".xml");


            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void kbTargetDirectory_Click(object sender, EventArgs e)
        {
            string targetDirectoryx = "";

            // Display the openFile dialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();

            // OK button was pressed.
            if (result == DialogResult.OK)
            {
                targetDirectoryx = folderBrowserDialog1.SelectedPath;

                general.targetDirectory = targetDirectoryx;
                kbTargetDirectory.Text = general.targetDirectory;

                // update project
                general.actualProject.targetDirectory = targetDirectoryx;
                general.actualProject.saveProject(Path.Combine(util.projects_dir, general.actualProject.name) + ".xml");

            }

            // Cancel button was pressed.
            else if (result == DialogResult.Cancel)
            {
                return;
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (general.actualProject.targetDirectory != null && general.actualProject.projectTemplatesDirectory != null)
            {
                AsyncCleanMessage("");
                // lo primero comprobamos que todas las tablas tienen campo clave...
                foreach (table tablita in general.actualProject.tables)
                {
                    if (tablita.GetKey.Equals(""))
                    {
                        AsyncMessage("Please review tables.", Color.SpringGreen);
                        AsyncMessage("Table " + tablita.Name + " doesnt have a key field", Color.Moccasin);
                        timer1.Enabled = true;
                        timer1.Start();
                    }
                }


                rt1.Text = "";
                rt1.Focus();
                // tratarARchivo
                Thread t = new Thread(new ParameterizedThreadStart(initTraverse));
                t.Start(new DirectoryInfo(general.actualProject.projectTemplatesDirectory).FullName);
                //traverseDirectory(new DirectoryInfo(actualProject.projectTemplatesDirectory).FullName);

                // number of applications written with generator
                try
                {
                    long numberOfApplications = 0;

                    numberOfApplications = 1 + sf.toLong(System.Configuration.ConfigurationManager.AppSettings["numberOfApplications"]);

                    labNumberOfApps.Values.Text = sf.cadena(numberOfApplications) + " apps written with myWay";
                    // save data...
                    System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["numberOfApplications"].Value = sf.cadena(numberOfApplications);
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
                catch (Exception)
                {

                    throw;
                }



            }
            else
            {
                if (general.actualProject.targetDirectory == null)
                {
                    AsyncMessage("Please fill the target directory", Color.Tomato);
                    timer1.Enabled = true;
                    timer1.Start();

                    //Thread.Sleep(2000);
                    //AsyncMessage("Please fill the target directory2", Color.Gainsboro);
                    //Thread.Sleep(2000);
                    //AsyncMessage("Please fill the target directory3", Color.White);
                }
            }
        } // kryptonButton1_Click


        public void initTraverse(object Folder)
        {
            traverseDirectory(Folder);

            // ended traverse .. lets put errors at last
            Thread.Sleep(500);
            SystemSounds.Asterisk.Play();
            AsyncWriteLine("finish");

            AsyncMessage("Ok. project finished", Color.GreenYellow);
            Thread.Sleep(500);             
           
           //' timer1.Enabled = true;
           //' timer1.Start();
            foreach (string item in errores)
            {
                AsyncWriteLine("Error en template: \n ");
                AsyncWriteLine("file://" + item);
            }

           
             // hay que cambiar el folder por el de la aplicacion final...

            // now if its an access app we try to copy the database
            try
            {
                if (general.actualProject.dbDataType == project.databaseType.access2003 || general.actualProject.dbDataType == project.databaseType.access2007)
                {
                    string originalPath = general.actualProject.database;
                    string targetDirectory = general.actualProject.projectTemplatesDirectory;
                    string onlyDirectoryOfTargetDirectory = util.ExtractLastDirectory(targetDirectory);
                    string finalPath = traverseDirectorySearchingDataFolder(new DirectoryInfo(Path.Combine(general.actualProject.targetDirectory, onlyDirectoryOfTargetDirectory)).FullName);
                    if (!finalPath.Equals(""))
                        File.Copy(general.actualProject.database, Path.Combine(finalPath, util.ExtractFilename(general.actualProject.database)));
                }
            }
            catch (Exception)
            {
              //  throw;
            }
           



        }


        public void traverseDirectory(object Folder)
        {
            try
            {


                DirectoryInfo dir = new DirectoryInfo(Folder.ToString());
                DirectoryInfo[] subDirs = dir.GetDirectories();
                FileInfo[] files = dir.GetFiles();

                foreach (FileInfo fi in files)
                {
                    Console.WriteLine(fi.FullName);

                    // skip project configuration files
                    if (!fi.Name.EndsWith("pcf"))
                    {
                        // tratarARchivo
                        Thread t = new Thread(new ParameterizedThreadStart(tratarFile));
                        t.Start(fi.FullName);
                    }



                }

                if (subDirs != null)
                {
                    foreach (DirectoryInfo sd in subDirs)
                    {
                        traverseDirectory(Folder + @"\\" + sd.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


        private void tratarFile(object file)
        {



            // ahora tratamos cada archivo en una nueva tarea...
            try
            {

                string archivito = "";
                archivito = file.ToString();


                AsyncWriteLine("Procesando " + archivito);

                char tabCaracter = '\u0009';
                try
                {

                    String plantilla = util.loadFile(archivito);

                    // sacamos las variables de la plantilla
                    variablesTemplate var = new variablesTemplate();
                    var = util.getVariablesFromTemplate(plantilla);


                    // vamos a sacar unas variables que luego nos serviran...
                    string nombreArchivo = "";
                    string nombreArchivoFinal = "";
                    string nombreDirectorioAgrabar = "";

                    string rutaArchivoFinal = "";

                    nombreArchivo = util.ExtractFilename(archivito);

                    // sacamos de la ruta el directorio del archivo ...
                    nombreDirectorioAgrabar = archivito;
                    nombreDirectorioAgrabar = nombreDirectorioAgrabar.Replace(general.actualProject.projectTemplatesDirectory, "");
                    nombreDirectorioAgrabar = nombreDirectorioAgrabar.Replace(nombreArchivo, "");


                    if (nombreDirectorioAgrabar.StartsWith("\\") && !nombreDirectorioAgrabar.Equals(""))
                        nombreDirectorioAgrabar = nombreDirectorioAgrabar.Substring(1, nombreDirectorioAgrabar.Length - 2);


                    rutaArchivoFinal = Path.Combine(general.targetDirectory, nombreDirectorioAgrabar);

                    if (var.namefile != null)
                    {
                        nombreArchivoFinal = Path.Combine(rutaArchivoFinal, var.namefile + "." + var.extensionFile);
                    }
                    else
                    {
                        nombreArchivoFinal = Path.Combine(rutaArchivoFinal, nombreArchivo);
                    }


                    if (!Directory.Exists(Path.Combine(general.targetDirectory, nombreDirectorioAgrabar)))
                        Directory.CreateDirectory(Path.Combine(general.targetDirectory, nombreDirectorioAgrabar));


                    // si no tiene variables de configuracion es que no es un template...
                    if (var.description == null && var.extensionFile == null)
                    // no es una plantilla...
                    {
                        // simplemente lo grabamos a disco
                        //util.saveTextToFile(nombreArchivoFinal, plantilla);
                        System.IO.File.Copy(archivito, nombreArchivoFinal, true);

                    }

                    else
                    // es una plantilla...
                    {

                        try
                        {
                            // si da un error en singleton es que falta la libreria commons o log4net..
                            Velocity.Init();

                            //VelocityEngine velocityEngine = new VelocityEngine();
                            //ExtendedProperties props = new ExtendedProperties();
                            //props.AddProperty("input.encoding", "UTF-8");
                            //props.AddProperty("output.encoding", "UTF-8");
                            //velocityEngine.Init(props);
                        }
                        catch (System.Exception exx)
                        {
                            AsyncWriteLine("Problem initializing Velocity : " + exx.Message);
                            return;
                        }

                        if (var.appliesToAllTables.Equals("true"))
                        {
                            foreach (table item in general.actualProject.tables)
                            {
                                if (item.excludeFromGeneration)
                                {

                                }
                                else
                                {
                                    // tenemos que aplicar esta plantilla una vez por cada tabla...
                                    // lets make a Context and put data into it
                                    VelocityContext context = new VelocityContext();
                                    context.Put("project", general.actualProject);
                                    context.Put("table", item);

                                    // lets render a template
                                    StringWriter writer = new StringWriter();
                                    try
                                    {

                                        //Velocity.MergeTemplate(plantilla, context, writer);
                                        Velocity.Evaluate(context, writer, "prueba", plantilla);

                                        // sacamos las variables del archivo antes de borrarlas
                                        variablesTemplate varT = new variablesTemplate();
                                        varT = util.getVariablesFromTemplate(writer.GetStringBuilder().ToString());
                                        if (varT.namefile != null)
                                        {
                                            if (!Directory.Exists(Path.Combine(rutaArchivoFinal, varT.targetDirectory)))
                                                Directory.CreateDirectory(Path.Combine(rutaArchivoFinal, varT.targetDirectory));

                                            nombreArchivoFinal = Path.Combine(Path.Combine(rutaArchivoFinal, varT.targetDirectory), varT.namefile + "." + var.extensionFile);
                                        }


                                        // now we delete the variables from the template cause there are no needed...
                                        string finalText = util.deleteVariablesFromTemplate(writer.GetStringBuilder().ToString());
                                        // todo...

                                        // le quitamos saltos de linea extra
                                        finalText = finalText.Replace("\r\n\r\n", "\r\n").Replace("\r\n\r\n\r\n", "").Replace("\r\n\r\n\r\n\r\n", "");

                                        // le quitamos los tabuladores extra
                                        finalText = finalText.Replace(tabCaracter.ToString(), " ");



                                        // grabamos segun el 
                                        util.saveTextToFile(nombreArchivoFinal, finalText);

                                    }
                                    catch (System.Exception exx)
                                    {
                                        // file
                                        AsyncCleanRt1("");
                                        AsyncWriteLine("Problem with the template : " + file.ToString());
                                        AsyncWriteLine("Error : " + exx.Message);
                                        AsyncWriteLine("file://" + file.ToString());

                                        errores.Add(file.ToString());

                                        //AsyncAddControl(file.ToString());

                                        //rt1.Text = exx.Message;
                                        //System.Console.Out.WriteLine("Problem merging template : " + exx);
                                        System.Console.Out.WriteLine("Problem evaluating template : " + exx);
                                    }


                                }// end de else excludeFromGeneration

                            } // end de for each
                        }

                        else
                        {
                            // es un template que no utiliza las tablas...
                            // lets make a Context and put data into it
                            VelocityContext context = new VelocityContext();
                            context.Put("project", general.actualProject);
                            //context.Put("table", tab);

                            // lets render a template
                            StringWriter writer = new StringWriter();
                            try
                            {

                                //Velocity.MergeTemplate(plantilla, context, writer);
                                Velocity.Evaluate(context, writer, "prueba", plantilla);

                                // now we delete the variables from the template cause there are no needed...
                                string finalText = util.deleteVariablesFromTemplate(writer.GetStringBuilder().ToString());
                                // todo...

                                // le quitamos saltos de linea extra
                                finalText = finalText.Replace("\r\n\r\n", "\r\n").Replace("\r\n\r\n\r\n", "").Replace("\r\n\r\n\r\n\r\n", "");



                                // le quitamos los tabuladores extra
                                finalText = finalText.Replace(tabCaracter.ToString(), " ");

                                util.saveTextToFile(nombreArchivoFinal, finalText);

                            }
                            catch (System.Exception exx)
                            {
                                rt1.Text = exx.Message;
                                //System.Console.Out.WriteLine("Problem merging template : " + exx);
                                System.Console.Out.WriteLine("Problem evaluating template : " + exx);
                            }
                        }


                    }








                    //                



                    //StringTemplate hello = new StringTemplate(plantilla);
                    //hello.SetAttribute("table", tab);
                    //rt1.Text = hello.ToString();


                }
                catch (Exception ex)
                {
                    AsyncWriteLine(ex.Message);
                }



            }
            catch (Exception ex)
            {
                AsyncWriteLine("Error " + ex.Message);
                //throw;
            }
        } // tratarFile



        public string traverseDirectorySearchingDataFolder(object Folder)
        {
            try
            {
                //string directorio = "";
                //string directorioParaInfo = "";
                //directorio = Folder.ToString();
                //if (!directorio.Trim().EndsWith(@"\"))
                //{
                //    directorio += "\\";
                //}

                DirectoryInfo dir = new DirectoryInfo(Folder.ToString());
                DirectoryInfo[] subDirs = dir.GetDirectories();
                FileInfo[] files = dir.GetFiles();

                             
                if (subDirs != null)
                {
                    foreach (DirectoryInfo sd in subDirs)
                    {
                        if (sd.Name.ToLower().IndexOf("data") != -1)
                            return Folder.ToString() + @"\\" + sd.Name;

                        traverseDirectorySearchingDataFolder(Folder.ToString() + @"\\" + sd.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return "";
        }


        public void AsyncWriteLine(String Text)
        {
            try
            {
                rt1.BeginInvoke(new MethodInvoker(delegate
                {

                    rt1.AppendText(Text + "\n");

                }));

            }
            catch (Exception exx)
            {
                //rt1.AppendText("Error: " + exx.Message.ToString() + "\n");
            }

        } // AsyncWriteLine

        public void AsyncCleanRt1(String Text)
        {
            try
            {
                rt1.BeginInvoke(new MethodInvoker(delegate
                {
                    rt1.Clear();
                }));

            }
            catch (Exception exx)
            {
                //rt1.AppendText("Error: " + exx.Message.ToString() + "\n");
            }

        } // AsyncCleanRt1


        public void AsyncCleanMessage(String Text)
        {
            try
            {
                rtMessage.BeginInvoke(new MethodInvoker(delegate
                {
                    rtMessage.Clear();
                }));

            }
            catch (Exception exx)
            {
                //rt1.AppendText("Error: " + exx.Message.ToString() + "\n");
            }

        } // AsyncCleanRt1

        public void AsyncMessage(String Text, Color color)
        {
            try
            {
                rtMessage.BeginInvoke(new MethodInvoker(delegate
                {
                    rtMessage.BackColor = color;
                    rtMessage.AppendText(Text + "\n");

                }));

            }
            catch (Exception exx)
            {
                //rt1.AppendText("Error: " + exx.Message.ToString() + "\n");
            }

        } // AsyncWriteLine


        private void lbProjectTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // save the project template from the listbox
            if (lbProjectTemplate.Items.Count != 0)
            {
                string pt = lbProjectTemplate.SelectedItem.ToString();
                foreach (projectconfigfiles item in ctes.listaProjectConfigFiles)
                {
                    if (item.Name == pt)
                    {
                        general.actualProject.projectTemplatesDirectory = item.Directory;
                    }
                }

                general.actualProject.projectTemplatesDirectorySmall = pt;

            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //rtMessage.Text = "";
            rtMessage.BackColor = Color.White;
            timer1.Enabled = false;
            //timer2.Enabled = true;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            rtMessage.ForeColor = Color.Blue;
            rtMessage.BackColor = Color.NavajoWhite;
            timer1.Enabled = false;
            timer2.Enabled = false;
        } // lbProjectTemplate_SelectedIndexChanged




    }
}
