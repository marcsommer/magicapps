using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

using Antlr3.ST;

using Velocity = NVelocity.App.Velocity;
using VelocityContext = NVelocity.VelocityContext;
using ParseErrorException = NVelocity.Exception.ParseErrorException;
using MethodInvocationException = NVelocity.Exception.MethodInvocationException;

using ComponentFactory.Krypton.Toolkit;

// para usar avalonEdit
// son necesarias las siguientes dll-referencias (copiadas del framework 3.0 la mayoria)
// ICSharpCode.AvalonEdit - PresentationCore - PresentationFramework - WindowsBase - WindowsFormsIntegration
       
using System.Windows.Forms.Integration;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.CodeCompletion;


using System.Threading;
using System.Windows.Input;

// ComboBoxItem
using System.Windows.Controls;

// sound
using System.Media;

// reg expr
using System.Text.RegularExpressions;

// para app.config
using System.Configuration;

namespace myWay
{
    public partial class Form1 : Form
    {

        protected List<string> errores = new List<string>();
        


        public Form1()
        {
            InitializeComponent();

            // diagraming...
        // http://www.dalssoft.com/diagram/


            // nos aseguramos de que existen los directorios...
            if (!Directory.Exists(util.projects_dir))
            {
                Directory.CreateDirectory(util.projects_dir);
            }

            // vemos si existe un conf.xml o ultimo proyecto utilizado...
            project pr = new project();
            pr = project.loadProject(Path.Combine(util.conf_dir, "conf.xml"));
            if (pr != null)
            {
                this.Text = "myWay " + pr.name;
                groupBox1.Text = pr.name;
                this.Text = "myWay " + pr.name;
                general.actualProject = pr;

                refreshDataWithActualProject();

            }
           
            

            //cargarArbol();


        }


       

        private void Form1_Load(object sender, EventArgs e)
        {
            //diagram di = new diagram();
            //di.ShowDialog();

            //model ed = new model();
            //ed.actualProject = actualProject;
            //ed.ShowDialog();

            //// para apañar templates antiguos...
            //myWay.classes.fixTemplate fi = new myWay.classes.fixTemplate();
            //fi.traverseDirectory("I:\\proyectos\\desktop\\myWay\\templates\\vb");
             
            // para crear el control avalonEdit
            // son necesarias las siguientes dll (copiadas del framework 3.0 la mayoria)
            // ICSharpCode.AvalonEdit - PresentationCore - PresentationFramework - WindowsBase - WindowsFormsIntegration
       
            ElementHost host = new ElementHost();
            host.Name = "editor";
            host.Dock = DockStyle.Fill;
            TextEditor uc = new TextEditor();
            uc.Options.IndentationSize = 4;
            uc.Background = System.Windows.Media.Brushes.White;
            uc.ShowLineNumbers = true;
            uc.WordWrap = true;

            IHighlightingDefinition highlightDefinition = HighlightingManager.Instance.GetDefinition("C#");
            uc.SyntaxHighlighting = highlightDefinition;
            host.Child = uc;

            // in the constructor:
            uc.TextArea.TextEntering += textEditor_TextArea_TextEntering;
            uc.TextArea.TextEntered += textEditor_TextArea_TextEntered;


            panel1.Controls.Add(host);
            //this.Controls.Add(host);

            // if there is a template selected early we load it..
            if (general.templateSelectedFullUri != null)
            {
                //  rt1.Text = util.loadFile(templateSelectedFullUri);
                writeText(util.loadFile(general.templateSelectedFullUri));
            }

        }

       

# region ["avalonEdit events"]
        CompletionWindow completionWindow;

        void textEditor_TextArea_TextEntered(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == "$")
            {

                ElementHost pp = new ElementHost();
                TextEditor te = new TextEditor();
                pp = (ElementHost)panel1.Controls.Find("editor", true)[0];
                te = (TextEditor)pp.Child;

                // Open code completion after the user has pressed dot:
                completionWindow = new CompletionWindow(te.TextArea);
                IList<ICompletionData> data = completionWindow.CompletionList.CompletionData;
                data.Add(new MyCompletionData("{table}"));
                data.Add(new MyCompletionData("{table.getListOfParameters(\", \")"));
                
                data.Add(new MyCompletionData("Item3"));
                completionWindow.Show();
                completionWindow.Closed += delegate
                {
                    completionWindow = null;
                };
            }
        }

        void textEditor_TextArea_TextEntering(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Length > 0 && completionWindow != null)
            {
                if (!char.IsLetterOrDigit(e.Text[0]))
                {
                    // Whenever a non-letter is typed while the completion window is open,
                    // insert the currently selected element.
                    completionWindow.CompletionList.RequestInsertion(e);
                }
            }
            // Do not set e.Handled=true.
            // We still want to insert the character that was typed.
        }
#endregion
         



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

        }

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

        }

        //// adds a button that loads a template when clicked...
        //public void AsyncAddControl(String Text)
        //{
        //    try
        //    {
        //        rt1.BeginInvoke(new MethodInvoker(delegate
        //        {
        //            System.Windows.Forms.Button bt = new System.Windows.Forms.Button();
        //            bt.Text = "click me";
        //            bt.Click += new System.EventHandler(this.buttonGeneric_Click);
        //            rt1.Controls.Add(bt);

        //        }));

        //    }
        //    catch (Exception exx)
        //    {
        //        //rt1.AppendText("Error: " + exx.Message.ToString() + "\n");
        //    }

        //} // AsyncAddControl


        private void fillComboWithTables()
        {
            try
            {
                cmbTablesx.Items.Clear();
                foreach (table item in general.actualProject.tables)
                {
                    cmbTablesx.Items.Add(item.Name);
                }
                cmbTablesx.SelectedIndex = 1;
            }
            catch (Exception)
            {

                // throw;
            }
        } // fillComboWithTables



        

       

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                project pr = new project();
                pr = general.actualProject;
                pr.templateSelectedFullUri = general.templateSelectedFullUri;


                String tableSelected = cmbTablesx.Text;
                foreach (table item in general.actualProject.tables)
                {
                    string numberoffields = item.fields.Count.ToString();
                    if (item.Name.Equals(tableSelected))
                        pr.actualTable = item;
                }
                //confi.actualTable = actualTable;

                pr.templateSelected = general.templateSelected;
                pr.templateSelectedFullUri = general.templateSelectedFullUri;


                pr.targetDirectory = general.targetDirectory;
                pr.projectTemplatesDirectory = general.projectTemplateSelectedFullUri;
                pr.projectTemplatesDirectorySmall = general.projectTemplateSelected;


                pr.saveProject(Path.Combine(util.conf_dir, "conf.xml"));
                pr.saveProject(Path.Combine(util.projects_dir, general.actualProject.name) + ".xml");


            }
            catch (Exception)
            {

                //throw;
            }

        }

         
       
        private void butEditModel_Click(object sender, EventArgs e)
        {
            model ed = new model();
            ed.actualProject = general.actualProject;
            ed.ShowDialog();

            // actualizamos los datos...
            general.actualProject = ed.actualProject;
            fillComboWithTables();

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
                    general.actualProject = np.pr;
                    fillComboWithTables();
                }


            }
        }

        private void butApplyTemplate2_Click(object sender, EventArgs e)
        {

            
            char tabCaracter = '\u0009';
            try
            {

                String plantilla = util.loadFile(general.templateSelectedFullUri);

             // clean cmbGotocode
                cmbGoToCode.Items.Clear();

                table tab = new table();
                String tableSelected = cmbTablesx.Text;

                if (tableSelected.Equals(""))
                {
                    rt1.Text = "Please, select a table";
                }

                foreach (table item in general.actualProject.tables)
                {
                    if (item.Name.Equals(tableSelected))
                    {
                        tab = item;
                        if (tab.GetKey == null)
                        {
                            MessageBox.Show( "Alert, review data, table doesnt have a key" );
                            AsyncWriteLine("Alert, review data, table doesnt have a key");
                        }
                    }
                }

                string numerocampos = tab.fields.Count.ToString();

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
                    rt1.Text = "Problem initializing Velocity : " + exx;
                    return;
                }

                // lets make a Context and put data into it
                VelocityContext context = new VelocityContext();
                context.Put("project", general.actualProject);
                context.Put("table", tab);

                // lets render a template
                StringWriter writer = new StringWriter();
                try
                {

                    //Velocity.MergeTemplate(plantilla, context, writer);
                    Velocity.Evaluate(context, writer, "prueba", plantilla);

                    // now we got the template , so lets take the variables from the template
                    variablesTemplate var = new variablesTemplate();
                    var = util.getVariablesFromTemplate(writer.GetStringBuilder().ToString());

                    // now we delete the variables from the template cause there are no needed...
                    string finalText = util.deleteVariablesFromTemplate(writer.GetStringBuilder().ToString());


                    // le quitamos saltos de linea extra
                    finalText = finalText.Replace("\r\n\r\n", "\r\n").Replace("\r\n\r\n\r\n", "").Replace("\r\n\r\n\r\n\r\n", "");

                    // le quitamos los tabuladores extra
                    finalText = finalText.Replace(tabCaracter.ToString(), " ");


                    // rt1.Text = finalText; 
                    writeText(finalText);


                    // number of lines written with generator
                    try
                    {
                        long numberOfLinesWrittenBefore = 0;
                        long numberOfLinesWritten = 0;

                        numberOfLinesWrittenBefore = sf.toLong(System.Configuration.ConfigurationManager.AppSettings["numberOfLinesWritten"]);
                        numberOfLinesWritten = numberOfLinesWrittenBefore + util.CountLinesInString(finalText);

                        labNumberOfLinesWritten.Values.Text = sf.cadena(numberOfLinesWritten) + " lines written with myWay";
                        // save data...
                        System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config.AppSettings.Settings["numberOfLinesWritten"].Value = sf.cadena(numberOfLinesWritten);
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                   

                    // now we got all the functions contained in the code
                    // and populate a combo with this...
                    // Instantiating Regex Object
                    Regex re = new Regex(@"(private|public|protected)\s\w(.)*\((.)*\)", RegexOptions.IgnoreCase);
                    MatchCollection mc = re.Matches(finalText);
                    foreach (Match mt in mc)
                    {
                        string st = "";
                        st = mt.ToString();
                        st = st.Replace("public", "");
                        st = st.Replace("private", "");
                        st = st.Replace("static", "");                    
                        st = st.Replace("void", "");

                        cmbGoToCode.Items.Add(st.Trim());
                       // Response.Write(mt.ToString() + "<br />");
                    }
                  

                }
                catch (System.Exception exx)
                {
                    //util.playSimpleSound(Path.Combine(util.sound_dir, "zasentodalaboca.wav"));
                    SystemSounds.Asterisk.Play();

                    AsyncWriteLine(exx.Message);
                    rt1.Text = exx.Message;
                    //System.Console.Out.WriteLine("Problem merging template : " + exx);
                    System.Console.Out.WriteLine("Problem evaluating template : " + exx);
                }

                 

                SystemSounds.Exclamation.Play();

                //util.playSimpleSound(Path.Combine(util.sound_dir, "risapetergriffin.wav"));
               


            }
            catch (Exception ex)
            {
                util.playSimpleSound(Path.Combine(util.sound_dir, "zasentodalaboca.wav"));
                rt1.Text = ex.Message;
            }
        }

        private void butCopy_Click(object sender, EventArgs e)
        {
            // get the control of editor
            ElementHost pp = new ElementHost();
            TextEditor te = new TextEditor();
            pp = (ElementHost)panel1.Controls.Find("editor", true)[0];
            te = (TextEditor)pp.Child;
            System.Windows.Forms.Clipboard.SetText(te.Text);
        }

        private void butOpenProject2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fil = new OpenFileDialog();
            fil.DefaultExt = "xml";
            fil.InitialDirectory = util.projects_dir;
            fil.ShowDialog();

            if (fil.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(fil.FileName);
                general.actualProject = project.loadProject(fil.FileName);


                // lo guardamos como conf.xml
                if (general.actualProject != null)
                {
                    this.Text = "myWay " + general.actualProject.name;
                    groupBox1.Text = general.actualProject.name;
                    general.actualProject.saveProject(Path.Combine(util.projects_dir, "conf.xml"));

                    refreshDataWithActualProject();
                    
                   
                }
              
            }
        }


        private void refreshDataWithActualProject()
        {
            if (general.actualProject != null)
            {
                general.actualTable = general.actualProject.actualTable;
               
                if (general.actualProject.nameSpace != null)
                    txtNameSpace.Text = general.actualProject.nameSpace;

                //string numberoffiels = actualTable.fields.Count.ToString();

                general.templateSelected = general.actualProject.templateSelected;
                general.templateSelectedFullUri = general.actualProject.templateSelectedFullUri;


                general.projectTemplateSelected = general.actualProject.projectTemplatesDirectorySmall;
                general.projectTemplateSelectedFullUri = general.actualProject.projectTemplatesDirectory;


                kbTargetDirectory.Text = general.actualProject.targetDirectory;
                general.targetDirectory = general.actualProject.targetDirectory;

                if (general.projectTemplateSelectedFullUri != null)
                {
                    kbProjectTemplate.Text = general.projectTemplateSelected;
                    kbTemplate.Text = general.templateSelected;
                }

                fillComboWithTables();

                if (general.actualTable != null)
                {
                    int index = cmbTablesx.FindStringExact(general.actualTable.Name);
                    cmbTablesx.SelectedIndex = index;      
                }
                    
            }

        } // refreshDataWithActualProject



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
                    refreshDataWithActualProject();                    
                }

            }

        } // butNewProject2_Click

        private void textBox1_Click_1(object sender, EventArgs e)
        {
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kbTemplate_Click(object sender, EventArgs e)
        {
            showTemplates sho = new showTemplates();
            sho.ShowDialog();

            if (sho.templateSelected != null)
            {
                //rt1.Text = sho.text;

                writeText(sho.text);


                kbTemplate.Text = sho.smallTitle;

                general.templateSelectedFullUri = sho.templateSelected;
                general.templateSelected = sho.smallTitle;
            }
        }

       

        private void kbProjectTemplate_Click(object sender, EventArgs e)
        {
            showProjectTemplates sho = new showProjectTemplates();
            sho.ShowDialog();

            if (sho.templateSelected != null)
            {
                general.projectTemplateSelected = sho.smallTitle;
                general.projectTemplateSelectedFullUri = sho.templateSelected;

                kbProjectTemplate.Text = sho.smallTitle;

                //templateSelectedFullUri = sho.templateSelected;
                //templateSelected = sho.smallTitle;

                // update project
                general.actualProject.projectTemplatesDirectory = sho.templateSelected;

                general.actualProject.projectTemplatesDirectorySmall = sho.smallTitle;
                general.actualProject.saveProject(Path.Combine(util.projects_dir, general.actualProject.name) + ".xml");

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
            // clean errores
            errores.Clear();

            if (general.actualProject.targetDirectory != null && general.actualProject.projectTemplatesDirectory != null)
            {
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

         
        }

        public void initTraverse(object Folder)
        {
            traverseDirectory(Folder);

            // ended traverse .. lets put errors at last
            Thread.Sleep(500);
            SystemSounds.Asterisk.Play();
            AsyncWriteLine("finish");
            foreach (string item in errores)
            {
                AsyncWriteLine("Error en template: \n ");
                AsyncWriteLine("file://" + item);
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


                    // tratarARchivo
                    Thread t = new Thread(new ParameterizedThreadStart(tratarFile));
                    t.Start(fi.FullName);

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
                    nombreDirectorioAgrabar = nombreDirectorioAgrabar.Replace(general.projectTemplateSelectedFullUri, "");
                    nombreDirectorioAgrabar = nombreDirectorioAgrabar.Replace(nombreArchivo, "");


                    if (nombreDirectorioAgrabar.StartsWith("\\"))
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
                        System.IO.File.Copy(archivito, nombreArchivoFinal,true);

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
                                // tenemos que aplicar esta plantilla una vez por cada tabla...
                                // es un template que no utiliza las tablas...
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
                                        if (!Directory.Exists(Path.Combine(rutaArchivoFinal,varT.targetDirectory)))
                                            Directory.CreateDirectory(Path.Combine(rutaArchivoFinal,varT.targetDirectory));

                                        nombreArchivoFinal = Path.Combine(Path.Combine(rutaArchivoFinal,varT.targetDirectory), varT.namefile + "." + var.extensionFile);
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
                            }
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
        }




        // used to write in avalonEdit ...
        private void writeText(string text)
        {
            // get the control of editor
            ElementHost pp = new ElementHost();
            TextEditor te = new TextEditor();
            pp = (ElementHost)panel1.Controls.Find("editor", true)[0];
            te = (TextEditor)pp.Child;
            te.Text = text;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            // get the control of editor
            ElementHost pp = new ElementHost();
            TextEditor te = new TextEditor();
            pp = (ElementHost)panel1.Controls.Find("editor", true)[0];
            te = (TextEditor)pp.Child;
            te.Save(general.templateSelectedFullUri);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void butReturnToScript_Click(object sender, EventArgs e)
        {
            // if there is a template selected early we load it..
            if (general.templateSelectedFullUri != null)
            {
                //  rt1.Text = util.loadFile(templateSelectedFullUri);
                writeText(util.loadFile(general.templateSelectedFullUri));
            }
        } // butReturnToScript_Click

        private void cmbGoToCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            string st = "";
            int numLinea = 0;
            st =  cmbGoToCode.SelectedItem.ToString().Trim();

            // get the control of editor
            ElementHost pp = new ElementHost();
            TextEditor te = new TextEditor();
            pp = (ElementHost)panel1.Controls.Find("editor", true)[0];
            te = (TextEditor)pp.Child;

            foreach (ICSharpCode.AvalonEdit.Document.DocumentLine item in te.Document.Lines)
            {
                if (item.Text.IndexOf(st) != -1)
                {
                    numLinea = item.LineNumber;
                }
            }
            te.ScrollTo(numLinea, 0);


        } // cmbGoToCode_SelectedIndexChanged

        private void txtNameSpace_TextChanged(object sender, EventArgs e)
        {
            project pr = new project();
            pr = general.actualProject;

            pr.nameSpace = txtNameSpace.Text;
            pr.saveProject(Path.Combine(util.conf_dir, "conf.xml"));
            pr.saveProject(Path.Combine(util.projects_dir, general.actualProject.name) + ".xml");


        }
        

        // someone clicks on a error in a template
        private void rt1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (!e.LinkText.Equals(""))
            {
                string url=null;
                string text = null;
                string smallTitle = null;

                // le quitamos el file://
                url=e.LinkText.Replace("file://","") ;

                text = util.loadFile(url);
                smallTitle = url.Substring(url.LastIndexOf("\\") + 1, url.Length - url.LastIndexOf("\\") - 1);

                writeText(text);
                kbTemplate.Text = smallTitle;

                general.templateSelectedFullUri = url;
                general.templateSelected = smallTitle;
            }

        } // buttonGeneric_Click

        

        

        

       


    }
}
