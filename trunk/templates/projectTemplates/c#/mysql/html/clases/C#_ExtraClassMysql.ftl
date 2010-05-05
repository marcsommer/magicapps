<#-- 
 
 crea una extension para la clase para c# para la tabla  ${table}...
 basicamente para su uso como objectDataSource ...
 Author : Pablo Garcia Mu�oz...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="${table}_extra">
<#assign extensionFile="cs">
<#assign languageGenerated="c#">
<#assign description="c#">
<#assign targetDirectory="">
<#assign appliesToAllTables="true">
<#-- END variables used internally by the generator... -->

using System;
    using System.Collections.Generic;
    using MySql.Data.MySqlClient;   
using System.Text;
using System.IO;
using System.Data;
using System.Web;

public partial class ${table}
{
 
  	public static List< ${table} > getListByPortal(int idportal)
		{
 
		    List< ${table} > lista${table} = new List< ${table} >();
            MySqlDataReader reg;
            string sqlt;
            dbClass db = new dbClass(ctes.conStringAdoGeneral);
            try
            {
            sqlt = "select ${table.getListWithAllFields()} from ${table} where idportal=" + idportal;
            reg = db.sql(sqlt);
            while (reg.Read())
                {
               ${table} pp = new ${table}();
#foreach( $field in $table.GetArrayOfFields ) 
	 
	 
		  #if ($field.type.toString() == "_integer")
		     pp.${field} = sf.entero(reg["${field}"].ToString());
		     #end 
		  #if ($field.type.toString() == "_string")
		     pp.${field} = sf.cadena(reg["${field}"].ToString());
		     #end 
		  #if ($field.type.toString() == "_date")
		     pp.${field} = sf.fecha(reg["${field}"].ToString());
		     #end 
		  #if ($field.type.toString() == "_boolean")
		     pp.${field} = sf.Bool(reg["${field}"].ToString());
		     #end 
		  <#default>
		     pp.${field} = sf.cadena(reg["${field}"].ToString());
	   
#end 
               lista${table}.Add(pp);
               }
            reg.Close();
            }
            catch (Exception ex)
            {
                 
            }
            finally
            {
                db.Dispose();
              
            }
            return lista${table};
       }		

 




 
}






 
