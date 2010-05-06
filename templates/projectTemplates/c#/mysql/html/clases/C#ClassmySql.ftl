 
 <#-- 
 
 crea una clase para c# para la tabla  ${table}...
 Author : Pablo Garcia Mu�oz...
 
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
	using System.Collections;
    using System.Web;
    using System.Collections.Generic;
    using MySql.Data.MySqlClient;   
	using System.ComponentModel; 
    
    
[System.ComponentModel.DataObject]
    public partial class ${table} 
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
		#if ($field.isKey())
				// for the objectDataSource
				[DataObjectField(true,true)]
        #end
		 
		 
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



    public static void Delete(${table.getListParameters()}#foreach( $field in $table.GetArrayOfFields )#if ($field.targetName()=="idportal"  && table.getName()!="portales")>,int idportal#end#end #set ($count = 0))
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
        sqlt.Append( " insert into ${table} ( ${table.getlistWithAllFieldsExceptKeys()} )"); 
        sqlt.Append( " values (");
			#set ($count = 0)	
			#foreach( $field in $table.GetArrayOfFields ) 
				#if (!$field.isKey())
					 
					 
							  #if ($field.type.toString() == "_integer")
			 					 sqlt.Append(sf.entero(obj${table}.${field}) + " ,") ;
								 #end 
							  #if ($field.type.toString() == "_string")
								 sqlt.Append( sf.cadenaMySql(obj${table}.${field}) + " ,") ;
								 #end 
							  #if ($field.type.toString() == "_date")
								 sqlt.Append( sf.cadenaMySql(sf.fechaIso(obj${table}.${field})) + " , ")  ;
								 #end 
							  #if ($field.type.toString() == "_boolean")
								 sqlt.Append( sf.entero(obj${table}.${field})  + " ,");
								 #end 
							  <#default>
								 sqlt.Append( sf.cadenaMySql(obj${table}.${field}) + " <#if ($table.GetArrayOfFields.count -  count  != 1)>+ " ,"#end") ;
					  
				#end
			 #set ($count = $count + 1 )
			#end 	 
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
			string sqlx="";
            dbClass db = new dbClass(ctes.conStringAdoGeneral);
            try
            {
            sqlt = "select ${table.getListWithAllFields()} from ${table}";
            sqlt += " where idportal=" + idportal +"  and (";              
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
			sqlt  =  sqlt +sqlx;
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
 
 		public static ${table} get${table}(${table.getListParameters()}#foreach( $field in $table.GetArrayOfFields )#if ($field.targetName()=="idportal"  && table.getName()!="portales")>,int idportal#end#end )
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
			    #if ($field == "idportal")   
				     sqlt += " and idportal=" + sf.entero(idportal);
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
			#if ($field.isKey())
			#else
				 
				 
					  #if ($field.type.toString() == "_integer")
						sqlt.Append(" ${field}=" + sf.cadena(obj${table}.${field})+ ", ") ;
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
		
           sqlt.Append(" where 1!=0");          
		#foreach( $field in $table.GetArrayOfFields )
			#if ($field.isKey())
			 
			 
				  #if ($field.type.toString() == "_integer")
					sqlt.Append( " and ${field}=" + obj${table}.${field});
					 #end 
				  #if ($field.type.toString() == "_string")
					  sqlt.Append( " and ${field}='" + obj${table}.${field} + "'");
					 #end 
				  #if ($field.type.toString() == "_date")
					 sqlt.Append(" and ${field}='" + obj${table}.${field} + "'");
					 #end 
				  #if ($field.type.toString() == "_boolean")
					 sqlt.Append( " and ${field}=" + obj${table}.${field});
					 #end 
				  <#default>
					 sqlt.Append( " and ${field}='" + obj${table}.${field} + "'");
			  
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
			#if ($field.isKey())
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
		 
 
            public ${table}(${table.getListParameters()}#foreach( $field in $table.GetArrayOfFields )#if ($field.targetName()=="idportal"  && table.getName()!="portales")>,int idPortal#end#end )
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
		
#set ($count = 0)	
#foreach( $relation in $table.getRelations() )

  
    #set ($count = $count + 1 ) 
 
		// devuelve una lista de ${table}
 
 		public static List< ${table} > getListBy${relation.parentField()}(int ${relation.parentField()})
		{
		    List< ${table} > lista${table} = new List< ${table} >();
            MySqlDataReader reg;
            string sqlt;
            dbClass db = new dbClass(ctes.conStringAdoGeneral);
            try
            {
            sqlt = "select ${table.getListOfFields(",")} from ${table}";
            sqlt += " where ${relation.parentField()}=" + sf.cadena(${relation.parentField()});  
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
							 pp.${field} = sf.boolean(reg["${field}"].ToString());
							 #end 
						 #if ($field.type.toString() == "_doble")
							 pp.${field} = sf.doble(reg["${field}"].ToString());
						 #end 
						  
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
 
 
        public static ${table} get${table}By${relation.parentField()}(int ${relation.parentField()})
        {
            ${table} ${table}x = new ${table}();
            MySqlDataReader reg;
            string sqlt;
                ${table} obj${table} = new ${table}();


            dbClass db = new dbClass(ctes.conStringAdoGeneral);
            try
            {
            sqlt = "select * from ${relation.getChildTable()}";
          
            sqlt += " where ${relation.parentField()}=" + sf.cadena(${relation.parentField()});  

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
                                     obj${table}.${field} = sf.boolean(reg["${field}"].ToString());
                                     #end 
                                  #if ($field.type.toString() == "_doble")
                                     obj${table}.${field} = sf.doble(reg["${field}"].ToString());
                                     #end 
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
    
	
	 public static  bool delete${relation.getChildTable()}By${relation.parentField()} (int ${relation.parentField()}x)
	 {
		 dbClass db=new  dbClass(ctes.conStringAdoGeneral);
		 String  sqlt;
		 
		try
		{
		  sqlt = " delete from ${table} where ${relation.parentField()}=" + sf.cadena(${relation.parentField()}x) ;
			db.ejecutar(sqlt);
		}
		finally
		{db.Dispose();}
		return ! ${table}.exists(${relation.parentField()}x);

	}  
	

#end 



// funciones extra para campos extra
		#set ($count = 0)
		#foreach( $field in $table.GetArrayOfFields )
			#if (!$field.isKey())
				
				 
						  #if ($field.type.toString() == "_image")
							public string deleteImg${field}()
							{
								string sqlt;
								string retorno = "";
								dbClassSqlServer db = new dbClassSqlServer(ctes.conStringAdoGeneral);
								try
								{
									sqlt = " update ${table} set";
									sqlt += " ${field}='' ";
									sqlt += " where 1!=0";
									sqlt += " and ${table.getKey()}=" + this.${table.getKey()};
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
								return retorno;
							}
							 
							 #end 
						  #if ($field.type.toString() == "_document")
							public string deleteDoc${field}()
							{
								string sqlt;
								string retorno = "";
								dbClass db = new dbClass(ctes.conStringAdoGeneral);
								try
								{
									sqlt = " update ${table} set";
									sqlt += " ${field}='' ";
									sqlt += " where 1!=0";
									sqlt += " and ${table.getKey()}=" + this.${table.getKey()};
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
								return retorno;
							}
							 
							 #end 									 
						  	
				  
			#end
			#set ($count = $count + 1 )
		#end 


}

	




       