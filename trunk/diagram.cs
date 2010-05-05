using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Netron.Diagramming.Core;
using Netron.Diagramming.Core.Analysis;




namespace myWay
{
    public partial class diagram : Form
    {

        
        public diagram()
        {
            InitializeComponent();
        }

        private void diagram_Load(object sender, EventArgs e)
        {
           // http://www.orbifold.net/default/?p=716

           // this.diagramControl2.RunActivity("Standard TreeLayout");
            ClassShape shape = new ClassShape();
            shape.Text = "Root";
            shape.Visible = true;

          
            //shape.PropertiesNode.Entries.Add(


         
            ClassShape shape2 = new ClassShape();
            shape2.Text = "Root";
            // para que salgan las propiedades...
            shape2.BodyType = BodyType.List;
            shape2.Visible = true;
            shape2.Title = "ll";
            shape2.SubTitle = "by me";
            shape2.Expand();

           // shape2.MethodsNode.Visible = true;
            shape2.MethodsNode.Text = "Address";
            shape2.MethodsNode.Entries.Add(new IconLabelMaterial("Tel: +32-2-457896", "Resources.DialHS.png"));
            shape2.MethodsNode.Entries.Add(new IconLabelMaterial("San Jose, CA 95112", "Resources.HomeHS.png"));



            Random rnd = new Random();

           
            
            //shape.Transform(rnd.Next(10, this.Width - 30), rnd.Next(10, this.Height - 30), shape.Width, shape.Height);
            this.diagramControl2.AddShape(shape);

            //shape2.Transform(rnd.Next(10, this.Width - 30), rnd.Next(10, this.Height - 30), shape2.Width, shape2.Height);
            this.diagramControl2.AddShape(shape2);
            this.diagramControl2.AddConnection(shape.Connectors[0], shape2.Connectors[3]);


        }


        // se ejecuta cuando damos a botón derecho propiedades...
        private void diagramControl2_OnShowCanvasProperties(object sender, SelectionEventArgs e)
        {
           // propertyGrid1.SelectedObject = e.SelectedObjects;
            this.propertyGrid1.SelectedObjects = diagramControl2.SelectedItems.ToArray();


        }

        //private void graphControl1_ShowNodeProperties(object sender, Netron.GraphLib.PropertyBag props)
        //{
        //    propertyGrid1.SelectedObject = props;
        //}

    }
}
