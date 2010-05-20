using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

// para arraylist
using System.Collections;

using System.Threading;


using System.Media;

namespace myWay
{
    public partial class newProject : Form
    {

        public project pr;

        public newProject()
        {
            InitializeComponent();

            // fill the combobox with enum...

            cmbDataType.DataSource = Enum.GetValues(typeof(project.databaseType));


            if (pr != null)
            {
                txtName.Text = pr.name;
                txtHost.Text = pr.host;
                txtDatabase.Text = pr.database;
                txtUser.Text = pr.user;
                txtPassword.Text = pr.password;
                cmbDataType.SelectedItem = pr.dbDataType.ToString();

                
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
             // search metadata...
            Thread t = new Thread(new ParameterizedThreadStart(search));
            // we need to pass data through object
            //project pro = new project();
            pr.name = txtName.Text;
            pr.nameSpace = txtName.Text;
            pr.host = txtHost.Text;
            pr.database = txtDatabase.Text;
            pr.user = txtUser.Text;
            pr.password = txtPassword.Text;
            pr.dbDataType = (project.databaseType)cmbDataType.SelectedItem;


            t.Start(pr);

            // use this for debugging
            //search(pro);
            
         
        }

        

        private void butSave_Click(object sender, EventArgs e)
        {
            if (pr != null)
            {
                // lets select some data from 
                if (pr.tables.Count > 0)
                {
                    pr.tableSelected = pr.tables[0].ToString();
                    pr.actualTable = (table) pr.tables[0];
                }

                pr.saveProject(Path.Combine(util.projects_dir, pr.name + ".xml"));
                AsyncWriteLine("Project saved... \n");

                this.DialogResult = DialogResult.Yes;
            }

        }

        private void search(object file)
        {
            bool right = false;

            AsyncEnableButton(false);
            try
            {
                project pro = new project();
                pro = (project)file;

                Cursor.Current = Cursors.WaitCursor;

                switch (pro.dbDataType)
                {
                    case project.databaseType.mySql:
                        String connectionString = null;

                        String message = null;


                        connectionString = "Server=" + pro.host + ";Database=" + pro.database + ";Uid=" + pro.user + ";Pwd=" + pro.password + ";";



                        dbMySql db = new dbMySql();
                        message = db.test(connectionString);
                        if (message.Equals(""))
                        {
                            AsyncWrite("");
                            AsyncWriteLine("Success connection \n");
                            //pr = new project();
                            //pr.name = pro.name;

                            // lets get the tables...
                            List<table> lista = new List<table>();
                            lista = db.getTables(connectionString, pro.database);
                            //lista.Sort();
                            foreach (table item in lista)
                            {
                                AsyncWriteLine("Found table... " + item.Name + "\n");

                                // now lets get the fields for each table...
                                List<field> listaField = new List<field>();
                                listaField = db.getFields(connectionString, pro.database, item.Name);
                                if (listaField != null)
                                {
                                    foreach (field fi in listaField)
                                    {
                                        item.fields.Add(fi);
                                        AsyncWriteLine("Found field... " + fi.Name + "\n");
                                    }

                                }

                                // lets get primary keys and foreign keys for the table...
                                db.getKeys(connectionString, item, pro.database);


                                // lets sort the fields in the table...
                                // we order but put first key fields
                                item.fields.Sort(new compareFields(compareFields.CompareByOptions.name));
                                item.fields.Sort(new compareFields(compareFields.CompareByOptions.key));

                                pr.tables.Add(item);


                            }

                            pr.tables.Sort();


                            //// now lets get the relations ...
                            List<relation> listarelation = new List<relation>();
                            listarelation = db.getRelations(connectionString, pro.database);
                            if (listarelation != null)
                            {
                                foreach (relation re in listarelation)
                                {

                                    if (!pr.existsRelation(re.parentTable, re.childTable))
                                    {
                                        pr.relations.Add(re);
                                        AsyncWriteLine("Found relation... " + re.name + "\n");
                                    }

                                    // now if the relation has to do with the tables...
                                    foreach (table item in pr.tables)
                                    {
                                        // we put the relation in the child table...
                                        if (item.Name.Equals(re.childTable))
                                            item.relations.Add(re);
                                    }

                                }

                            }


                            // also we can get relations about the field names
                            foreach (table tab in pr.tables)
                            {
                                foreach (field campo in tab.fields)
                                {
                                    if (campo.isKey)
                                    {
                                        foreach (table tab2 in pr.tables)
                                        {
                                            if (!tab.Name.Equals(tab2.Name))
                                            {
                                                foreach (field campo2 in tab2.fields)
                                                {
                                                    if (campo.Name.Equals(campo2.Name))
                                                    {
                                                        // check if relation exists..
                                                        if (!pr.existsRelation(tab.Name, tab2.Name))
                                                        {
                                                            relation rel = new relation();
                                                            rel.name = tab.Name + "_" + tab2.Name;
                                                            if (!pr.relations.Contains(rel.name))
                                                            {
                                                                rel.parentTable = tab.Name;
                                                                rel.parentField = campo.Name;

                                                                rel.childTable = tab2.Name;
                                                                rel.childField = campo2.Name;


                                                                pr.relations.Add(rel);

                                                                // now if the relation has to do with the tables...
                                                                foreach (table item in pr.tables)
                                                                {
                                                                    if (item.Name.Equals(tab2.Name))
                                                                        item.relations.Add(rel);
                                                                }
                                                            }



                                                        }

                                                    }
                                                }
                                            }

                                        }
                                    }
                                }
                            }

                            right = true;
                            pr.host = pro.host;
                            pr.database = pro.database;
                            pr.user = pro.user;
                            pr.password = pro.password;
                            pr.dbDataType = pro.dbDataType;

                            //pr.saveProject(Path.Combine(util.projects_dir, pro.name + ".xml"));

                            // lets save it for next load of application...
                            // pr.saveProject(Path.Combine(util.projects_dir, "conf.xml"));
                            //  AsyncWriteLine("Project saved... \n");



                        }
                        else
                        {
                            AsyncWrite(message);
                        }
                        break;

                    case project.databaseType.SqlServer:
                       
                        String messageSqlServer = null;
 
                        connectionString = "Data Source=" + pro.host + ";Network Library=DBMSSOCN;Initial Catalog=" + pro.database + ";User ID=" + pro.user + ";Password=" + pro.password + ";";
                        // connectionStringOleDb = "Provider=SQLNCLI;Server=" + txtHost.Text + ";Database=" + txtDatabase.Text + ";Uid=" + txtUser.Text + ";Pwd=" + txtPassword.Text + ";";



                        dbSql2005 dbSqlServer = new dbSql2005();
                        messageSqlServer = dbSqlServer.test(connectionString);
                        if (messageSqlServer.Equals(""))
                        {
                            AsyncWrite("");
                            AsyncWriteLine("Success connection \n");
                            //pr = new project();
                            //pr.name = pro.name;

                            // lets get the tables...
                            List<table> lista = new List<table>();
                            lista = dbSqlServer.getTables(connectionString, pro.database);
                            //lista.Sort();
                            foreach (table item in lista)
                            {
                                AsyncWriteLine("Found table... " + item.Name + "\n");

                                // now lets get the fields for each table...
                                List<field> listaField = new List<field>();
                                listaField = dbSqlServer.getFields(connectionString, item.Name);
                                if (listaField != null)
                                {
                                    foreach (field fi in listaField)
                                    {
                                        item.fields.Add(fi);
                                        AsyncWriteLine("Found field... " + fi.Name + "\n");
                                    }

                                }

                                // lets get primary keys and foreign keys for the table...
                                dbSqlServer.getKeys(connectionString, item);

                                // lets sort the fields in the table...
                                // we order but put first key fields
                                item.fields.Sort(new compareFields(compareFields.CompareByOptions.name));
                                item.fields.Sort(new compareFields(compareFields.CompareByOptions.key));

                                pr.tables.Add(item);


                            }

                            pr.tables.Sort();
                            // now lets get the relations ...
                            List<relation> listarelation = new List<relation>();
                            listarelation = dbSqlServer.getRelations(connectionString);
                            if (listarelation != null)
                            {
                                foreach (relation re in listarelation)
                                {
                                    //  item.fields.Add(re);
                                    pr.relations.Add(re);
                                    AsyncWriteLine("Found relation... " + re.name + "\n");

                                }

                            }


                            // also we can get relations about the field names
                            foreach (table tab in pr.tables)
                            {
                                foreach (field campo in tab.fields)
                                {
                                    if (campo.isKey)
                                    {
                                        foreach (table tab2 in pr.tables)
                                        {
                                            if (!tab.Name.Equals(tab2.Name))
                                            {
                                                foreach (field campo2 in tab2.fields)
                                                {
                                                    if (campo.Name.Equals(campo2.Name))
                                                    {
                                                        relation rel = new relation();
                                                        rel.name = tab.Name + "_" + tab2.Name;
                                                        if (!pr.relations.Contains(rel.name))
                                                        {
                                                            rel.parentTable = tab.Name;
                                                            rel.parentField = campo.Name;

                                                            rel.childTable = tab2.Name;
                                                            rel.childField = campo2.Name;
                                                            pr.relations.Add(rel);
                                                        }

                                                    }
                                                }
                                            }

                                        }
                                    }
                                }
                            }

                            right = true;
                            pr.host = pro.host;
                            pr.database = pro.database;
                            pr.user = pro.user;
                            pr.password = pro.password;
                            pr.dbDataType = pro.dbDataType;

                            //pr.saveProject(Path.Combine(util.projects_dir, pro.name + ".xml"));

                            // lets save it for next load of application...
                            // pr.saveProject(Path.Combine(util.projects_dir, "conf.xml"));
                            //AsyncWriteLine("Project saved... \n");



                        }
                        else
                        {
                            AsyncWrite(messageSqlServer);
                        }

                        break;
                }

                Cursor.Current = Cursors.Default;
               
                switch (right)
                {
                    case true:
                            AsyncWriteLine("All right. Now you can save the project...");
                            AsyncEnableButton(true);
                            SystemSounds.Exclamation.Play();
                            break;

                    case false:
                            AsyncWriteLine("Error, review the configuration.");
                            AsyncEnableButton(false);
                            util.playSimpleSound(Path.Combine(util.sound_dir, "zasentodalaboca.wav"));
                            break;

                }

                // we have finished with new project
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {

                AsyncWrite(ex.Message);
            }

        }

        public void AsyncEnableButton(bool enabled)
        {
            try
            {
                butSave.BeginInvoke(new MethodInvoker(delegate
                {
                    butSave.Enabled = enabled;

                }));

            }
            catch (Exception exx)
            {
                //  AsyncWriteLine("Error: " + exx.Message.ToString() + "\n");
            }

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
                //  AsyncWriteLine("Error: " + exx.Message.ToString() + "\n");
            }

        }

        public void AsyncWrite(String Text)
        {
            try
            {
                rt1.BeginInvoke(new MethodInvoker(delegate
                {

                    rt1.Text = Text + "\n";

                }));

            }
            catch (Exception exx)
            {
                //  AsyncWriteLine("Error: " + exx.Message.ToString() + "\n");
            }

        }

        private void rt1_TextChanged(object sender, EventArgs e)
        {
            SuspendLayout();
            Point pt = rt1.GetPositionFromCharIndex(rt1.SelectionStart);
            if (pt.Y > rt1.Height)
            {
                rt1.ScrollToCaret();
            }
            ResumeLayout(true);
        }

        private void newProject_Load(object sender, EventArgs e)
        {
            pr = new project();
        }
    }
}
