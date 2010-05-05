using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


// para la serializacion
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;


    [Serializable()]
    public class conf : ISerializable
    {

        project _pr;
        table _actualTable;
        
        String _templateSelected;
        String _templateSelectedFullUri;
        

        public project pr
        {
            get { return _pr; }
            set { _pr = value; }
        }

        public table actualTable
        {
            get { return _actualTable; }
            set { _actualTable = value; }
        }

        public string templateSelectedFullUri
        {
            get { return _templateSelectedFullUri; }
            set { _templateSelectedFullUri = value; }
        }

        public string templateSelected
        {
            get { return _templateSelected; }
            set { _templateSelected = value; }
        }

        

        public void save (string filename)
        {
            // Create an instance of the XmlSerializer class;
            // specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(conf));
            TextWriter writer = new StreamWriter(filename);
            conf po = new conf();
            po = this;

            // Serialize and close the TextWriter.
            serializer.Serialize(writer, po);
            writer.Close();


        }

        public static conf load(string filename)
        {
            // Declare an object variable of the type to be deserialized.
            conf po;
            try
            {

                // Create an instance of the XmlSerializer class;
                // specify the type of object to be deserialized.
                XmlSerializer serializer = new XmlSerializer(typeof(conf));

                // A FileStream is needed to read the XML document.
                FileStream fs = new FileStream(filename, FileMode.Open);

                /* Use the Deserialize method to restore the object's state with data from the XML document. */
                po = (conf)serializer.Deserialize(fs);
                fs.Close();
            
                return po;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        //Serialization function.

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {

        }

    }
 
