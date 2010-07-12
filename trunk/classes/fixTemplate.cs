using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Threading;

namespace myWay.classes
{
    public class fixTemplate
    {


        private void revisarTemplates(string path)
        {
            traverseDirectory(new DirectoryInfo(util.templates_dir).FullName);
            traverseDirectory(path);
            //traverseDirectory("I:\\proyectos\\desktop\\tarta\\tarta\\templates");

        }



        public void traverseDirectory(string Folder)
        {
            try
            {


                DirectoryInfo dir = new DirectoryInfo(Folder);
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

                string textoArchivo = "";
                textoArchivo = util.loadFile(file.ToString());


                textoArchivo = textoArchivo.Replace("<#if (field.getisKey() || field.getTargetType() == \"_image\")>", "#if ( !$field.isKey() || $field.TargetType() == \"_image\")");
                textoArchivo = textoArchivo.Replace("<#if (field.getisKey() || field.getTargetType()==\"_image\")>", "#if ( !$field.isKey() || $field.TargetType() == \"_image\")");

                textoArchivo = textoArchivo.Replace("<#if (field.getisKey() || field.getTargetType() == \"_audio\")>", "#if ( !$field.isKey() || $field.TargetType() == \"_audio\")");
                textoArchivo = textoArchivo.Replace("<#if (field.getisKey() || field.getTargetType()==\"_audio\")>", "#if ( !$field.isKey() || $field.TargetType() == \"_audio\")");

                textoArchivo = textoArchivo.Replace("<#if (field.getisKey() || field.getTargetType() == \"_document\")>", "#if ( !$field.isKey() || $field.TargetType() == \"_document\")");
                textoArchivo = textoArchivo.Replace("<#if (field.getisKey() || field.getTargetType()==\"_document\")>", "#if ( !$field.isKey() || $field.TargetType() == \"_document\")");




                textoArchivo = textoArchivo.Replace("<#case \"_audio\">", "#if ($field.type.toString() == \"_audio\")");
                textoArchivo = textoArchivo.Replace("<#case \"_documento\">", "#if ($field.type.toString() == \"_document\")");
                textoArchivo = textoArchivo.Replace("<#case \"_image\">", "#if ($field.type.toString() == \"_image\")");




              textoArchivo = textoArchivo.Replace("<#if (count!=0)>", "#if ($count!=0)");


                      textoArchivo = textoArchivo.Replace("${project.host}", "{$project.host}"); 
textoArchivo = textoArchivo.Replace("${", "{$"); 



                textoArchivo = textoArchivo.Replace("<#if (field.getisKey() || field.getTargetType() == \"_image\")>", "#if ($field.isKey() || $field.TargetType() == \"_image\")");
                textoArchivo = textoArchivo.Replace("<#if (field.getisKey() || field.getTargetType() == \"_image\")>", "#if ($field.isKey() || $field.TargetType() == \"_image\")");


                textoArchivo = textoArchivo.Replace("<#if (field.getisKey())>", "#if ($field.isKey())");
                textoArchivo = textoArchivo.Replace("<#if (field.getisKey() )>", "#if ($field.isKey())");
                textoArchivo = textoArchivo.Replace("<#if (!field.getisKey())>", "#if (!$field.isKey())");

                textoArchivo = textoArchivo.Replace("#if (! $field.isForeignKey())", "#if (! $field.isForeignKey())");


                textoArchivo = textoArchivo.Replace("<#if (!field.getisForeignKey())>", "#if (! $field.isForeignKey())");
                textoArchivo = textoArchivo.Replace("<#if (!field.getisForeignKey())>", "#if (! $field.isForeignKey())");
                textoArchivo = textoArchivo.Replace("<#if (!field.getisForeignKey())>", "#if (! $field.isForeignKey())");
                textoArchivo = textoArchivo.Replace("<#if (field.getisForeignKey())>", "#if ( $field.isForeignKey())");


                textoArchivo = textoArchivo.Replace("<#if (field.getSize()", "#if ( $field.size()");

                textoArchivo = textoArchivo.Replace("<<", "<");
                textoArchivo = textoArchivo.Replace("<#else>", "#else");

                textoArchivo = textoArchivo.Replace("<#if (field != \"idportal\")>", "#if ($field != \"idportal\")");
                textoArchivo = textoArchivo.Replace("<#if (field == \"idportal\")>", "#if ($field == \"idportal\")");
                textoArchivo = textoArchivo.Replace("<#if (field != \"idportal\")>", "#if ($field != \"idportal\")");
                textoArchivo = textoArchivo.Replace("<#if (field.getTargetName()", "#if ($field.targetName()");
                textoArchivo = textoArchivo.Replace("<#if (field.getisForeignKey() )>", "#if ($field.isForeignKey() )");
                textoArchivo = textoArchivo.Replace("<#if (field.getisForeignKey() )>", "#if ($field.isForeignKey() )");

                textoArchivo = textoArchivo.Replace("<#if (relation.getParentTable() == \"categorias\"+ relation.childTable())>", "#if ($relation.ParentTable() == \"categorias\"+ $relation.ChildTable())");
                textoArchivo = textoArchivo.Replace("<#if (field=='idportal')>", "#if ($field == \"idportal\")");



                textoArchivo = textoArchivo.Replace("<#if (count <=2 && count >=1)>", "#if ($count <=2 && $count >=1)");


                textoArchivo = textoArchivo.Replace("<#if (table.getNumberOfFields() -  $count  != 1)>,#end", "#if ($table.GetFields.count() -  $count  != 1) , #end");
                textoArchivo = textoArchivo.Replace("#if (table.getNumberOfFields()", "#if ($table.GetFields.count");
                textoArchivo = textoArchivo.Replace("<<#if ($table.GetFields.count", "<#if ($table.GetFields.count");


                textoArchivo = textoArchivo.Replace("<#if (countx==0)>", "#if ($count==0)");
                textoArchivo = textoArchivo.Replace("<#if (!field.getisKey())>", "#if ($field.isKey())");



                textoArchivo = textoArchivo.Replace("<#if (field.getType()==\"string\")>", "#if ($field.type.toString() == \"_string\")");


                textoArchivo = textoArchivo.Replace("</#if>", "#end");
                textoArchivo = textoArchivo.Replace("<#assign count=0>", "#set ($count = 0)");


                textoArchivo = textoArchivo.Replace("<#assign count = count+1>", "#set ($count = $count + 1 )");
                textoArchivo = textoArchivo.Replace("<#assign countx = countx+1>", "#set ($count = $count + 1 )");




                textoArchivo = textoArchivo.Replace("<#list table.getFields() as field>", "#foreach( $field in $table.GetFields )");
                textoArchivo = textoArchivo.Replace("</#list>", "#end ");

                textoArchivo = textoArchivo.Replace("<#break>", "#end");

                textoArchivo = textoArchivo.Replace("<#case \"_int\">", "#if ($field.type.toString() == \"_integer\")");
                textoArchivo = textoArchivo.Replace("<#case \"_string\">", "#if ($field.type.toString() == \"_string\")");
                textoArchivo = textoArchivo.Replace("<#case \"_date\">", "#if ($field.type.toString() == \"_date\")");
                textoArchivo = textoArchivo.Replace("<#case \"_boolean\">", "#if ($field.type.toString() == \"_boolean\")");
                textoArchivo = textoArchivo.Replace("<#case \"_bigString\">", "#if ($field.type.toString() == \"_bigString\")");

                textoArchivo = textoArchivo.Replace("<#case \"_document\">", "#if ($field.type.toString() == \"_document\")");
                textoArchivo = textoArchivo.Replace("<#case \"_audio\">", "#if ($field.type.toString() == \"_audio\")");
                textoArchivo = textoArchivo.Replace("<#case \"_image\">", "#if ($field.type.toString() == \"_image\")");
                textoArchivo = textoArchivo.Replace("<#case \"_float\">", "#if ($field.type.toString() == \"_doble\")");


                textoArchivo = textoArchivo.Replace("<#if ($field.type.toString() == \"_image\")", "#if ($field.type.toString() == \"_image\")");
                textoArchivo = textoArchivo.Replace("<#if ($field.type.toString() == \"_audio\")", "#if ($field.type.toString() == \"_audio\")");
                textoArchivo = textoArchivo.Replace("<#if ($field.type.toString() == \"_document\")", "#if ($field.type.toString() == \"_document\")");


                textoArchivo = textoArchivo.Replace("<#-- segun el tipo de campo...   -->", "");
                textoArchivo = textoArchivo.Replace("<#switch field.getType()>", "");
                textoArchivo = textoArchivo.Replace("<#switch field.getTargetType()>", "");
                textoArchivo = textoArchivo.Replace("</#switch>", "");


                util.saveTextToFile(file.ToString(), textoArchivo);

               // AsyncWriteLine("buscando letra para " + archivito);


            }
            catch (Exception ex)
            {
                //AsyncWriteLine("Error " + ex.Message);
                //throw;
            }
        }


 //public void AsyncWriteLine(String Text)
 //       {
 //           try
 //           {
 //               rt1.BeginInvoke(new MethodInvoker(delegate
 //               {

 //                   rt1.AppendText(Text + "\n");

 //               }));

 //           }
 //           catch (Exception exx)
 //           {
 //               // AsyncWriteLine("Error: " + exx.Message.ToString() + "\n");
 //           }

 //       }

    }


     

}
