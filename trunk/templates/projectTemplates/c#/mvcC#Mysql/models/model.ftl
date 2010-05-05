<#-- 
 
 crea una extension para la clase para c# para la tabla  ${table}...
 basicamente para su uso como objectDataSource ...
 Author : Luis Molina...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="${table}">
<#assign extensionFile="cs">
<#assign languageGenerated="c#">
<#assign description="c#">
<#assign targetDirectory="">
<#assign appliesToAllTables="true">
<#-- END variables used internally by the generator... -->
using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace mvc_prueba.Models
{
    public class ${table}
    {

        #region["Variables"]
		 
		 
	#foreach( $field in $table.GetArrayOfFields )
		 
		 
			  #if ($field.type.toString() == "_integer")
			     private int _${field};
			     #end 
			  #if ($field.type.toString() == "_string")
			     private string _${field};
			     #end 
			  #if ($field.type.toString() == "_date")
			     private DateTime _${field};
			     #end 
			  #if ($field.type.toString() == "_boolean")
			     private bool _${field};
			     #end 
			  <#default>
			     private string _${field};
		  
	#end 
	
	#endregion
	
	
	#region["Propiedades"]
	
	
	#foreach( $field in $table.GetArrayOfFields )
		 
		 
			  #if ($field.type.toString() == "_integer")
			      public int ${field}
		                {
			                get {return _${field};}
			                set {_${field} = value;}
		                }
			     #end 
			  #if ($field.type.toString() == "_string")
			      public string ${field}
		                {
			                get {return _${field};}
			                set {_${field} = value;}			                
		                }
			     #end 
			  #if ($field.type.toString() == "_date")
			       public DateTime ${field}
		                {
			                get {return _${field};}
			                set {_${field} = value;}
		                }
			     #end 
			  #if ($field.type.toString() == "_boolean")
			     public bool ${field}
                 {
                     get { return _${field}; }
                     set { _${field} = value; }
                 }
				 #end 
			  <#default>
			      public string ${field}
		                {
			                get {return _${field};}
			                set {_${field} = value;}			                
		                }
		  	 
	#end 	  
	
    #endregion
		
	
		
		
        public ${table}()
        {
        }
        // devuelve  ${table}

      

    public static void Delete(${table.getListParameters()})
    {
        string sqlt;
        dbClass db = new dbClass(ctes.conStringAdoGeneral);
        try { 
        sqlt = " delete from ${table} ";
        sqlt += " where 1!=0";  
        
        #set ($count = 0)	
        #foreach( $field in $table.GetArrayOfFields )
            #if ($field.isKey())
                #if ($field.type.toString() == "_string")
                    sqlt += " and ${field}='" + sf.cadena(${field})';
                #else
                     sqlt += " and ${field}=" + sf.cadena(${field});
                #end
            #end
         #set ($count = $count + 1 )
		#end 
           db.ejecutar(sqlt);

           }
           catch (Exception ex)
           {
               // Argument is optional, no "When" keyword 
           }
           finally
           {
               db.Dispose();

           }



    }

    public static string Insert(${table} obj${table})
    {
            
        System.Text.StringBuilder sqlt = new System.Text.StringBuilder();
        string retorno = "";
        dbClass db = new dbClass(ctes.conStringAdoGeneral);
        MySqlDataReader reg;
        try
        {
        sqlt.Append( " insert into ${table} ( ${table.getListFieldsWithQuotes()} )"); 
        sqlt.Append( " values (");
			#set ($count = 0)	
			#foreach( $field in $table.GetArrayOfFields ) 
				#if (!$field.isKey())
					 
					 
							  #if ($field.type.toString() == "_integer")
			 					 sqlt.Append( sf.mySql(obj${table}.${field}) + " ,") ;
								 #end 
							  #if ($field.type.toString() == "_string")
								 sqlt.Append( sf.mySql(obj${table}.${field}) + " ,") ;
								 #end 
							  #if ($field.type.toString() == "_date")
								 sqlt.Append( sf.mySql(obj${table}.${field}) + " , ")  ;
								 #end 
							  #if ($field.type.toString() == "_boolean")
								 sqlt.Append( sf.mySql(obj${table}.${field})  + " ,");
								 #end 
							  <#default>
								 sqlt.Append( sf.mySql(obj${table}.${field})) + " ," ;
					  
				#end
			 #set ($count = $count + 1 )
			#end 	 
			sqlt.Remove(sqlt.Length - 1, 1);
            sqlt.Append(" )");

            db.ejecutar(sqlt.ToString());
            reg = db.sql("select @@identity as id from ${table}");
            if (reg.Read())
                {
                  retorno = sf.cadena(reg["id"].ToString());
                }
                reg.Close();
            }
                 
            catch (Exception ex)
            {
                // Argument is optional, no "When" keyword 
            }
            finally
            {
                db.Dispose();
              
            }
            return retorno;
       }


// devuelve una lista de ${table}
 
 		public static List< ${table} > getList()
		{
		    List< ${table} > lista${table} = new List< ${table} >();
            MySqlDataReader reg;
            string sqlt;
            dbClass db = new dbClass(ctes.conStringAdoGeneral);
            try
            {
            sqlt = "select ${table.getListWithAllFields()} from ${table}";
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

 
 
 // devuelve una lista de ${table}
 
 		public static List< ${table} > getListByBusquedaGeneral(String cadena)
		{
		    List< ${table} > lista${table} = new List< ${table} >();
            MySqlDataReader reg;
            string sqlt;
            dbClass db = new dbClass(ctes.conStringAdoGeneral);
            try
            {
            sqlt = "select ${table.getListWithAllFields()} from ${table}";
            sqlt += " where 1!=0  and (";              
			<#assign countx=0>				
			#foreach( $field in $table.GetArrayOfFields ) 
				
				
					  #if ($field.type.toString() == "_integer")					  
						 #end 
					  #if ($field.type.toString() == "_string")
						#if ($count==0)
							sqlt += "  ${field} like '%" + cadena + "%'"; 	
							#set ($count = $count + 1 )
						#else
							 sqlt += " or ${field} like '%" + cadena + "%'"; 	
						#end				  
						#end 
					  #if ($field.type.toString() == "_date")					 
						 #end 
					  #if ($field.type.toString() == "_boolean")					 
						 #end 
					  <#default>					 
				  
			#end 
			sqlt += " )";  
            
		
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
 
 		public static ${table} get${table}(${table.getListParameters()})
		{
            ${table} ${table}x = new ${table}();
            MySqlDataReader reg;
            string sqlt;
                ${table} obj${table} = new ${table}();


            dbClass db = new dbClass(ctes.conStringAdoGeneral);
            try
            {
            sqlt = "select ${table.getListWithAllFields()} from ${table}";          
            sqlt += " where 1!=0";  
            #foreach( $field in $table.GetArrayOfFields )
              #if ($field.isKey())   
                     
                     
                              #if ($field.type.toString() == "_integer")
                                sqlt += " and ${field}=" + sf.cadena(${field});
                                 #end 
                              #if ($field.type.toString() == "_string")
                                  sqlt += " and ${field}='" + sf.cadena(${field}) + "'";
                                 #end 
                              #if ($field.type.toString() == "_date")
                                 sqlt += " and ${field}='" + sf.cadena(${field}) + "'";
                                 #end 
                              #if ($field.type.toString() == "_boolean")
                                 sqlt += " and ${field}=" + sf.cadena(${field});
                                 #end 
                              <#default>
                                  sqlt += " and ${field}='" + sf.cadena(${field}) + "'";
                      
              #end
            #end 
			
            reg = db.sql(sqlt);
            if (reg.Read())
            {          
              #foreach( $field in $table.GetArrayOfFields )
                         
                         
                                  #if ($field.type.toString() == "_integer")
                                     obj${table}.${field} = sf.entero(reg["${field}"].ToString());
                                     #end 
                                  #if ($field.type.toString() == "_string")
                                     obj${table}.${field} = sf.cadena(reg["${field}"].ToString());	  					
                                     #end 
                                  #if ($field.type.toString() == "_date")
                                    obj${table}.${field} = sf.fecha(reg["${field}"].ToString());
                                     #end 
                                  #if ($field.type.toString() == "_boolean")
                                     obj${table}.${field} = sf.Bool(reg["${field}"].ToString());
                                     #end 
                                  <#default>
                                     obj${table}.${field} = sf.cadena(reg["${field}"].ToString());	  					
                          
                #end 		 
           
               }
            reg.Close();
            }
            catch (Exception ex)
            {
                // Argument is optional, no "When" keyword 
            }
            finally
            {
                db.Dispose();
              
            }
            return  obj${table} ;
       }



 public static bool Update(${table} obj${table})
		{
            MySqlDataReader reg;
            System.Text.StringBuilder sqlt = new System.Text.StringBuilder();
            dbClass db = new dbClass(ctes.conStringAdoGeneral);
            try
            {
            sqlt.Append(" update ${table} set");
		#set ($count = 0)		
		#foreach( $field in $table.GetArrayOfFields )
			#if ( !$field.isKey() || $field.TargetType() == "_image")
			#else
				 
				 
					  #if ($field.type.toString() == "_integer")
						sqlt.Append(" ${field}=" + sf.cadena(obj${table}.${field})+ "', ") ;
						#set ($count = $count + 1 )		
						#end 
					  #if ($field.type.toString() == "_string")
						sqlt.Append(" ${field}='" + sf.cadena(obj${table}.${field})+ "', "); 
						 #set ($count = $count + 1 )		
						 #end 
					  #if ($field.type.toString() == "_date")
						 sqlt.Append(" ${field}='" + sf.fechaIso(obj${table}.${field}) + "', " );
						 #set ($count = $count + 1 )		
						 #end 
					  #if ($field.type.toString() == "_boolean")
						 sqlt.Append(" ${field}=" + sf.Bool(obj${table}.${field}) + "', ");
						 #set ($count = $count + 1 )		
						 #end 
					  <#default>
						sqlt.Append(" ${field}='" + sf.cadena(obj${table}.${field})+ "', ") ;
						#set ($count = $count + 1 )							 
				
			#end				
		#end 
             reg = db.sql(sqlt.ToString());
             return (reg!=null);
              }   
            catch (Exception ex)
            {
                // Argument is optional, no "When" keyword 
            }
            finally
            {
                db.Dispose();              
            }
             return true;
       }
		
			
		
  public void Update()
		{
            MySqlDataReader reg;
            System.Text.StringBuilder sqlt = new System.Text.StringBuilder();
            dbClass db = new dbClass(ctes.conStringAdoGeneral);
            try
            {
            sqlt.Append(" update ${table} set");
		#set ($count = 0)		
		#foreach( $field in $table.GetArrayOfFields )
			#if ( !$field.isKey() || $field.TargetType() == "_image")
			#else
				
				 
					  #if ($field.type.toString() == "_integer")
						sqlt.Append( " ${field}=" + sf.cadena(this.${field}) + "," ) ;
						#set ($count = $count + 1 )
						 #end 
					  #if ($field.type.toString() == "_string")
						  sqlt.Append(" ${field}='" + sf.cadena(this.${field}) + "'," );
						  #set ($count = $count + 1 )
						 #end 
					  #if ($field.type.toString() == "_date")
						  sqlt.Append( " ${field}='" + sf.fechaIso(this.${field}) + "',") ;
						  #set ($count = $count + 1 )
						 #end 
					  #if ($field.type.toString() == "_boolean")
						sqlt.Append(" ${field}=" + sf.cadena(this.${field})  + "," );
						#set ($count = $count + 1 )
						 #end 
					  <#default>
						  sqlt.Append(" ${field}='" + sf.cadena(this.${field}) + "'," );
						  #set ($count = $count + 1 )
				
			#end				
		#end  
            sqlt.Remove(sqlt.Length - 1, 1);
            sqlt.Append(" where 1!=0");          
		#foreach( $field in $table.GetArrayOfFields )
			#if ($field.isKey())
			 
			 
				  #if ($field.type.toString() == "_integer")
					sqlt.Append( " and ${field}=" + this.${field});
					 #end 
				  #if ($field.type.toString() == "_string")
					  sqlt.Append( " and ${field}='" + this.${field} + "'");
					 #end 
				  #if ($field.type.toString() == "_date")
					 sqlt.Append(" and ${field}='" + this.${field} + "'");
					 #end 
				  #if ($field.type.toString() == "_boolean")
					 sqlt.Append( " and ${field}=" + this.${field});
					 #end 
				  <#default>
					 sqlt.Append( " and ${field}='" + this.${field} + "'");
			  
		  #end
		#end 
              reg = db.sql(sqlt.ToString());
              }   
            catch (Exception ex)
            {
                // Argument is optional, no "When" keyword 
            }
            finally
            {
                db.Dispose();
              
            }

       }


// comprueba si existe

 		public static bool exists(${table.getListParameters()} )
		{
           
            MySqlDataReader reg;
            string sqlt;
            bool retorno=false;
           
            dbClass db = new dbClass(ctes.conStringAdoGeneral);
            try
            {
            sqlt = "select * from ${table}";
            sqlt += " where 1!=0";  
            #foreach( $field in $table.GetArrayOfFields )
                #if ($field.isKey())
                     
                     
                              #if ($field.type.toString() == "_integer")
                                sqlt += " and ${field}=" + sf.cadena(${field});
                                 #end 
                              #if ($field.type.toString() == "_string")
                                  sqlt += " and ${field}='" + sf.cadena(${field}) + "'";
                                 #end 
                              #if ($field.type.toString() == "_date")
                                 sqlt += " and ${field}='" + sf.cadena(${field}) + "'";
                                 #end 
                              #if ($field.type.toString() == "_boolean")
                                 sqlt += " and ${field}=" + sf.cadena(${field});
                                 #end 
                              <#default>
                                  sqlt += " and ${field}='" + sf.cadena(${field}) + "'";
                      
              #end
            #end 
          
            reg = db.sql(sqlt);
            if (reg.Read()) retorno=true;
            else retorno=false;
               
            reg.Close();
            }
            catch (Exception ex)
            {
                // Argument is optional, no "When" keyword 
            }
            finally
            {
                db.Dispose();
              
            }
            return  retorno;
       }
		 
 
            public ${table}(${table.getListParameters()})
            {

                MySqlDataReader reg;
                string sqlt;
                dbClass db = new dbClass(ctes.conStringAdoGeneral);
                try
                {
                sqlt = "select * from ${table}";
                sqlt += " where 1!=0"; 
                #foreach( $field in $table.GetArrayOfFields )
                    #if ($field.isKey())
                         
                         
                                  #if ($field.type.toString() == "_integer")
                                    sqlt += " and ${field}=" + ${field};
                                     #end 
                                  #if ($field.type.toString() == "_string")
                                      sqlt += " and ${field}='" + ${field} + "'";
                                     #end 
                                  #if ($field.type.toString() == "_date")
                                     sqlt += " and ${field}='" + ${field} + "'";
                                     #end 
                                  #if ($field.type.toString() == "_boolean")
                                     sqlt += " and ${field}=" + ${field};
                                     #end 
                                  <#default>
                                      sqlt += " and ${field}='" + ${field} + "'";
                          
                  #end
                #end 
                reg = db.sql(sqlt);
                if (reg.Read())
                {        
                #foreach( $field in $table.GetArrayOfFields )
					 
					 
							  #if ($field.type.toString() == "_integer")
								 this.${field} = sf.entero(reg["${field}"].ToString());
								 #end 
							  #if ($field.type.toString() == "_string")
								 this.${field} = sf.cadena(reg["${field}"]);
								 #end 
							  #if ($field.type.toString() == "_date")
								 this.${field} = sf.fecha(reg["${field}"].ToString());
								 #end 
							  #if ($field.type.toString() == "_boolean")
								 this.${field} = sf.Bool(reg["${field}"]);
								 #end 
							  <#default>
								 this.${field} = sf.cadena(reg["${field}"]);
					
                #end 
           
               }
            reg.Close();
            }
            catch (Exception ex)
            {
                // Argument is optional, no "When" keyword 
            }
            finally
            {
                db.Dispose();
              
            }

       }
		

<#assign x=0>


<#list table.getRelations() as relation>  
    <#assign x = x+1>
 
        public static ${table} get${table}By${relation.getParentKey()}(int ${relation.getParentKey()})
        {
            ${table} ${table}x = new ${table}();
            MySqlDataReader reg;
            string sqlt;
            ${table} obj${table} = new ${table}();

            dbClass db = new dbClass(ctes.conStringAdoGeneral);
            try
            {
            sqlt = "select * from ${relation.getChildTable()}";          
            sqlt += " where ${relation.getParentKey()}=" + sf.cadena(${relation.getParentKey()});  

            reg = db.sql(sqlt);
            if (reg.Read())
            {
          
              #foreach( $field in $table.GetArrayOfFields )

                         
                         
                                  #if ($field.type.toString() == "_integer")
                                     obj${table}.${field} = sf.entero(reg["${field}"].ToString());
                                     #end 
                                  #if ($field.type.toString() == "_string")
                                     obj${table}.${field} = sf.cadena(reg["${field}"].ToString());	  					
                                     #end 
                                  #if ($field.type.toString() == "_date")
                                    obj${table}.${field} = sf.fecha(reg["${field}"].ToString());
                                     #end 
                                  #if ($field.type.toString() == "_boolean")
                                     obj${table}.${field} = sf.Bool(reg["${field}"].ToString());
                                     #end 
                                  <#default>
                                     obj${table}.${field} = sf.cadena(reg["${field}"].ToString());	  					
                          
                #end 		 	  			                 
           
               }
            reg.Close();
            }
            catch (Exception ex)
            {
                // Argument is optional, no "When" keyword 
            }
            finally
            {
                db.Dispose();              
            }
            return  obj${table} ;
       }
    
	
	 public void delete${relation.getParentTable()}By${relation.getParentKey()} (int ${relation.getParentKey()}x)
	 {
		 dbClass db=new  dbClass(ctes.conStringAdoGeneral);
		 String  sqlt;
		 
		try
		{
		  sqlt = " delete from ${table} where ${relation.getParentKey()}=" + ${relation.getParentKey()}x ;
			db.ejecutar(sqlt);
		}
		finally
		{db.Dispose();}
		  

	}  

#end 
	}
}
