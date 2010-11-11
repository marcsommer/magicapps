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

using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;


namespace myWay.userControls
{
    public partial class templateMode : System.Windows.Forms.UserControl
    {

        //  public project realProject;

        private bool blocked;

        public templateMode()
        {
            InitializeComponent();
        }

        private void templateMode_Load(object sender, EventArgs e)
        {
            this.Disposed += new System.EventHandler(this.templateMode_Disposed);
            //CSharp Formatter Initilaization
            t1.SetHighlighting("C#");
            t1.TabIndex = 4;

        }


        public void refreshDataWithActualProject()
        {
            if (general.actualProject != null)
            {
                blocked = true;
                string numberOfLinesWrittenBefore = sf.toLong(System.Configuration.ConfigurationManager.AppSettings["numberOfLinesWritten"]).ToString();
                labNumberOfLinesWritten.Values.Text = sf.cadena(numberOfLinesWrittenBefore) + " lines written with myWay";
                if (general.actualProject.nameSpace != null)
                    txtNameSpace.Text = general.actualProject.nameSpace;


                if (general.actualProject.templateSelected != null)
                {
                    kbTemplate.Text = general.actualProject.templateSelected;
                }


                //kbTemplate.Text = general.templateSelected;


                fillComboWithTables();

                if (general.actualProject.actualTable != null)
                {
                    int index = cmbTablesx.FindStringExact(general.actualProject.actualTable.Name);
                    cmbTablesx.SelectedIndex = index;
                }

                blocked = false;

            }

        } // refreshDataWithActualProject



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

        private void templateMode_VisibleChanged(object sender, EventArgs e)
        {
            saveData();
        } // templateMode_VisibleChanged

        // jumps when parent form closes
        private void templateMode_Disposed(object sender, EventArgs e)
        {
            //saveData();
        } //templateMode_Disposed


        private void saveData()
        {
            //project pr = new project();
            //pr = general.actualProject;

            //pr.templateSelected = general.actualProject.templateSelected;
            //pr.templateSelectedFullUri = general.actualProject.templateSelectedFullUri;


            //String tableSelected = cmbTablesx.Text;
            //foreach (table item in general.actualProject.tables)
            //{
            //    string numberoffields = item.fields.Count.ToString();
            //    if (item.Name.Equals(tableSelected))
            //        pr.actualTable = item;
            //}

            //pr.saveProject(Path.Combine(util.conf_dir, "conf.xml"));
            //pr.saveProject(Path.Combine(util.projects_dir, general.actualProject.name) + ".xml");

        }

        private void butApplyTemplate2_Click(object sender, EventArgs e)
        {
            char tabCaracter = '\u0009';
            try
            {
                AsyncCleanRt1("");
                String plantilla = util.loadFile(general.actualProject.templateSelectedFullUri);

                // clean cmbGotocode
                cmbGoToCode.Items.Clear();

                table tab = new table();
                String tableSelected = cmbTablesx.Text;

                if (tableSelected.Equals(""))
                {
                    // rt1.Text = "Please, select a table";
                    t1.Text = "Please, select a table";
                }

                foreach (table item in general.actualProject.tables)
                {
                    if (item.Name.Equals(tableSelected))
                    {
                        tab = item;
                        if (tab.GetKey == null)
                        {
                            MessageBox.Show("Alert, review data, table doesnt have a key");
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
                    t1.Text = "Problem initializing Velocity : " + exx;
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
                    AsyncWriteLine(finalText);


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
                    t1.Text = exx.Message;
                    //System.Console.Out.WriteLine("Problem merging template : " + exx);
                    System.Console.Out.WriteLine("Problem evaluating template : " + exx);
                }



                SystemSounds.Exclamation.Play();

                //util.playSimpleSound(Path.Combine(util.sound_dir, "risapetergriffin.wav"));



            }
            catch (Exception ex)
            {
                // util.playSimpleSound(Path.Combine(util.sound_dir, "zasentodalaboca.wav"));
                SystemSounds.Asterisk.Play();
                t1.Text = ex.Message;
            }
        } // butApplyTemplate2_Click



        public void AsyncWriteLine(String Text)
        {
            try
            {
                t1.BeginInvoke(new MethodInvoker(delegate
                {

                    //t1.AppendText(Text + "\n");
                    t1.Text = t1.Text + Text + "\n";

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
                t1.BeginInvoke(new MethodInvoker(delegate
                {
                    t1.Text = "";
                    // t1.Clear();
                }));

            }
            catch (Exception exx)
            {
                //rt1.AppendText("Error: " + exx.Message.ToString() + "\n");
            }

        }

        private void kbTemplate_Click(object sender, EventArgs e)
        {
            showTemplates sho = new showTemplates();
            sho.searchTemplate = kbTemplate.Text;
            sho.ShowDialog();

            if (sho.templateSelected != null)
            {
                t1.Text = sho.text;

                kbTemplate.Text = sho.smallTitle;

                general.actualProject.templateSelectedFullUri = sho.templateSelected;
                general.actualProject.templateSelected = sho.smallTitle;

                general.actualProject.saveProject(Path.Combine(util.conf_dir, "conf.xml"));
                general.actualProject.saveProject(Path.Combine(util.projects_dir, general.actualProject.name) + ".xml");


            }
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            t1.SetHighlighting(((System.Windows.Forms.ComboBox)(sender)).Text);
        }

        private void cmbTablesx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!blocked)
            {
                String tableSelected = cmbTablesx.Text;

                foreach (table item in general.actualProject.tables)
                {
                    string numberoffields = item.fields.Count.ToString();
                    if (item.Name.Equals(tableSelected))
                        general.actualProject.actualTable = item;
                }

                general.actualProject.saveProject(Path.Combine(util.conf_dir, "conf.xml"));
                general.actualProject.saveProject(Path.Combine(util.projects_dir, general.actualProject.name) + ".xml");

            }

        }

        private void cmbGoToCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string st = "";
                int numLinea = 0;
                st = cmbGoToCode.SelectedItem.ToString().Trim();

                for (int lineNumber = 1; lineNumber <= t1.Document.TotalNumberOfLines - 1; lineNumber++)
                {
                    LineSegment lineSegment = t1.Document.GetLineSegment(lineNumber);
                    string pp = t1.Document.GetText(lineSegment);
                    if (pp.IndexOf(st) >= 0)
                        numLinea = lineNumber;
                }

                TextAreaControl txtAreaControl = t1.ActiveTextAreaControl;
                txtAreaControl.JumpTo(numLinea);
                txtAreaControl.ScrollTo(numLinea + 8);
            }
            catch (Exception)
            {

                throw;
            }






        }

    }
}
