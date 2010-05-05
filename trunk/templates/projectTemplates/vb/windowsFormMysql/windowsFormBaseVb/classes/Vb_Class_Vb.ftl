 <#-- 
 
 crea una clase para c# para la tabla  ${table}...
 Author : Luis Molina...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="${table}">
<#assign extensionFile="vb">
<#assign languageGenerated="vb">
<#assign description="vb">
<#assign targetDirectory="">
<#assign appliesToAllTables="true">
<#-- END variables used internally by the generator... -->


Imports Microsoft.VisualBasic

Imports System
Imports System.Data
Imports System.Collections.Generic

Imports System.Text
Imports System.Io

  Public Class ${table}
  


#Region "Variables"
	#foreach( $field in $table.GetArrayOfFields )	
		 
		 
			  #if ($field.type.toString() == "_integer")
			     Private s_${field} As Integer
			     #end 
			  #if ($field.type.toString() == "_string")
			     Private s_${field} As New String("")
			     #end 
			  #if ($field.type.toString() == "_date")
			     Private s_${field} As Date
			     #end 
			  #if ($field.type.toString() == "_boolean")
			     Private s_${field} As Boolean
			     #end 
			  <#default>
			     Private s_${field} As New String("")
		  	 
	#end 
    
 #End Region 




#Region "Propiedades"
	#foreach( $field in $table.GetArrayOfFields )	
		 
		 
			  #if ($field.type.toString() == "_integer")
			    Public Property ${field}() As Integer
					Get
						Return s_${field}
					End Get
					Set(ByVal Value As Integer)
						s_${field} = Value
					End Set
				End Property
			     #end 
			  #if ($field.type.toString() == "_string")
			    Public Property ${field}() As String
					Get
						Return s_${field}
					End Get
					Set(ByVal Value As String)
						s_${field} = Value
					End Set
				End Property
			     #end 
			  #if ($field.type.toString() == "_date")
			    Public Property ${field}() As Date
					Get
						Return s_${field}
					End Get
					Set(ByVal Value As Date)
						s_${field} = Value
					End Set
				End Property
			     #end 
			  #if ($field.type.toString() == "_boolean")
			     	Public Property ${field}() As Boolean
						Get
							Return s_${field}
						End Get
						Set(ByVal Value As Boolean)
							s_${field} = Value
						End Set
					End Property
			     #end 
			  <#default>
			    Public Property ${field}() As String
					Get
						Return s_${field}
					End Get
					Set(ByVal Value As String)
						s_${field} = Value
					End Set
				End Property
		  	 
	#end 
   
  
   
#End Region


 ' devuelve un arraylist de ...
    Public shared Function getArrayList() As ArrayList
        Dim db As New dbClassMysql(ctes.conStringAdo)
        Dim sql As String
        Dim reg As Object
         

        Try
            sql = "select * from ${table}"
            reg = db.sql(sql)
            Do While reg.read()
                Dim pp As New ${table}
                
				#foreach( $field in $table.GetArrayOfFields )	
				 
				 
					  #if ($field.type.toString() == "_integer")
						 pp.${field} = sf.Entero(reg("${field}"))
						 #end 
					  #if ($field.type.toString() == "_string")
						 pp.${field} = sf.Cadena(reg("${field}"))
						 #end 
					  #if ($field.type.toString() == "_date")
						 pp.${field} = sf.Fecha(reg("${field}"))
						 #end 
					  #if ($field.type.toString() == "_boolean")
						 pp.${field} = sf.Bool(reg("${field}"))
						 #end 
					  <#default>
						 pp.${field} = sf.Cadena(reg("${field}"))
				  	 
			#end 
	 
                
                getArrayList.Add(pp)
                pp = Nothing
            Loop
            reg.close()
        Catch ex As Exception
        Finally
            db.dispose()
        End Try
        
    End Function


 ' devuelve un List de ...
    Public shared Function getList() As List (of ${table})
        Dim db As New dbClassMysql(ctes.conStringAdo)
        Dim sql As String
        Dim reg As Object
        Dim lista as new List (of ${table})
        
        Try
            sql = "select * from ${table}"
            reg = db.sql(sql)
            Do While reg.read()
                Dim pp As New ${table}
        	#foreach( $field in $table.GetArrayOfFields )	
				 
				 
					  #if ($field.type.toString() == "_integer")
						 pp.${field} = sf.Entero(reg("${field}"))
						 #end 
					  #if ($field.type.toString() == "_string")
						 pp.${field} = sf.Cadena(reg("${field}"))
						 #end 
					  #if ($field.type.toString() == "_date")
						 pp.${field} = sf.Fecha(reg("${field}"))
						 #end 
					  #if ($field.type.toString() == "_boolean")
						 pp.${field} = sf.Bool(reg("${field}"))
						 #end 
					  <#default>
						 pp.${field} = sf.Cadena(reg("${field}"))
				  	 
			#end 
                
                lista.Add(pp)
                pp = Nothing
            Loop
            reg.close()
        Catch ex As Exception
        Finally
            db.dispose()
        End Try
        return lista
        lista=nothing
        
    End Function


 Public shared Function update  (Byval ${table}x As ${table}) As Boolean
        Dim db As New dbClassMysql(ctes.conStringAdo)
        Dim sqlt As String
        Try

          sqlt = " update ${table} set  "
		  #set ($count = 0)
		  #foreach( $field in $table.GetArrayOfFields )	
				 
				 
					  #if ($field.type.toString() == "_integer")
						 sqlt += " ${field}=" & sf.cadena(${table}x.${field})  & "#if ($table.GetArrayOfFields.count() -  $count  != 1) , #end"
						 #end 
					  #if ($field.type.toString() == "_string")
						 sqlt += " ${field}='" & sf.cadena(${table}x.${field}) & "'#if ($table.GetArrayOfFields.count() -  $count  != 1) , #end " 
						 #end 
					  #if ($field.type.toString() == "_date")
						 sqlt += " ${field}='" & sf.fechaSql(${table}x.${field}) & "'#if ($table.GetArrayOfFields.count() -  $count  != 1) , #end " 
						 #end 
					  #if ($field.type.toString() == "_boolean")
						 sqlt += " ${field}=" & sf.Entero(${table}x.${field}).toString()  & "#if ($table.GetArrayOfFields.count() -  $count  != 1) , #end"
						 #end 
					  <#default>
						 sqlt += " ${field}='" & sf.cadena(${table}x.${field}) & "'#if ($table.GetArrayOfFields.count() -  $count  != 1) , #end " 
				  	
				#set ($count = $count + 1 )
			#end 
           
           
            sqlt += " where ${table.getKey()} =" & ${table}x.${table.getKey()}
            db.ejecutar(sqlt)
           return true
        Catch ex As Exception
        	return false
        
        Finally
            db.dispose()
        End Try
    End Function



Public shared Function get${table} (ByVal ${table.getKey()}x As integer) As ${table}
        dim salida as new ${table}
        Dim db As New dbClassMysql(ctes.conStringAdo)
        Dim reg As Object
        Dim sqlt As String

        Try
            sqlt = " select * from ${table} where ${table.getKey()}=" & ${table.getKey()}x

            reg = db.sql(sqlt)
            If reg.Read() Then
              
            #foreach( $field in $table.GetArrayOfFields )	
				 
				 
					  #if ($field.type.toString() == "_integer")
						 salida.${field} = sf.Entero(reg("${field}"))
						 #end 
					  #if ($field.type.toString() == "_string")
						 salida.${field} = sf.Cadena(reg("${field}"))
						 #end 
					  #if ($field.type.toString() == "_date")
						 salida.${field} = sf.Fecha(reg("${field}"))
						 #end 
					  #if ($field.type.toString() == "_boolean")
						 salida.${field} = sf.Bool(reg("${field}"))
						 #end 
					  <#default>
						 salida.${field} = sf.Cadena(reg("${field}"))
				  	 
			#end 
              
              
            End If
            reg.close()
        Catch ex As Exception
        Finally
            db.dispose()
        End Try
		return salida
    End Function

' devuelve un arraylist de...
    Public shared Function getArray${table}() As ${table}()
        Dim av() As ${table}
        Dim db As New dbClassMysql(ctes.conStringAdo)
        Dim reg As Object
        Dim sqlt As String
        Dim contador As Integer
        contador = 0

        Try
            sqlt = " select * from ${table} "

            reg = db.sql(sqlt)
                do while reg.read()
                Dim pp As New ${table}
                
			#foreach( $field in $table.GetArrayOfFields )	
				 
				 
					  #if ($field.type.toString() == "_integer")
						 pp.${field} = sf.Entero(reg("${field}"))
						 #end 
					  #if ($field.type.toString() == "_string")
						 pp.${field} = sf.Cadena(reg("${field}"))
						 #end 
					  #if ($field.type.toString() == "_date")
						 pp.${field} = sf.Fecha(reg("${field}"))
						 #end 
					  #if ($field.type.toString() == "_boolean")
						 pp.${field} = sf.Bool(reg("${field}"))
						 #end 
					  <#default>
						 pp.${field} = sf.Cadena(reg("${field}"))
				  	 
			#end 
                
                ReDim Preserve av(contador)
                av.SetValue(pp, contador)
                contador+=1
                pp = Nothing
            loop
           
        Catch ex As Exception
        Finally
            db.dispose()
        End Try
        Return av
    End Function

   Public Function readDb(ByVal ${table.getKey()}x As integer) As boolean
        Dim db As New dbClassMysql(ctes.conStringAdo)
        Dim reg As Object
        Dim sqlt As String

        Try
            sqlt = " select * from ${table} where ${table.getKey()}=" & ${table.getKey()}x

            reg = db.sql(sqlt)
            If reg.Read() Then
              
                      #foreach( $field in $table.GetArrayOfFields )	
				 
				 
					  #if ($field.type.toString() == "_integer")
						 Me.${field} = sf.Entero(reg("${field}"))
						 #end 
					  #if ($field.type.toString() == "_string")
						 Me.${field} = sf.Cadena(reg("${field}"))
						 #end 
					  #if ($field.type.toString() == "_date")
						 Me.${field} = sf.Fecha(reg("${field}"))
						 #end 
					  #if ($field.type.toString() == "_boolean")
						 Me.${field} = sf.Bool(reg("${field}"))
						 #end 
					  <#default>
						 Me.${field} = sf.Cadena(reg("${field}"))
				  	 
			#end 
              
            End If
            reg.close()
        Catch ex As Exception
        Finally
            db.dispose()
        End Try
    End Function
    
    
       ' sirve para comprobar que hay un ${table} con el mismo id ...
    Public shared Function exists (ByVal ${table}Obj as ${table}) As Boolean
        Dim db As New dbClassMysql(ctes.conStringAdo)
        Dim reg As Object
        Dim sqlt As String
        Dim salida As Boolean
        Try
            sqlt = " select * from ${table}  where ${table.getKey()} <> 0 and ( "
            sqlt += " )"
           
            reg = db.sql(sqlt)
            salida = reg.read()

        Catch ex As Exception
        Finally
            db.dispose()
        End Try
        Return salida
    End Function

 
  Public shared Function insert (byval obj${table} as ${table}) As String
        Dim db As New dbClassMysql(ctes.conStringAdo)

        Dim reg As Object
        Dim sqlt As String
        Try

            sqlt = " insert into ${table} (${table.getlistWithAllFieldsExceptKeys()} "
            sqlt += " ) values ("

		  #set ($count = 0)
		  #foreach( $field in $table.GetArrayOfFields )
				#if (!$field.isKey())
					 
					 
						  #if ($field.type.toString() == "_integer")
							 sqlt += " " & obj${table}.${field}.ToString &"#if ($table.GetArrayOfFields.count() -  $count  != 1) , #end"
							 #end 
						  #if ($field.type.toString() == "_string")
							 sqlt += "'" & sf.cadena(obj${table}.${field}) & "' #if ($table.GetArrayOfFields.count() -  $count  != 1) , #end"
							 #end 
						  #if ($field.type.toString() == "_date")
							 sqlt += " '" & sf.FechaSql(obj${table}.${field}) & "' #if ($table.GetArrayOfFields.count() -  $count  != 1) , #end"
							 #end 
						  #if ($field.type.toString() == "_boolean")
							 sqlt += " " & sf.Entero(obj${table}.${field}).ToString &"#if ($table.GetArrayOfFields.count() -  $count  != 1) , #end"
							 #end 
						  <#default>
							 sqlt += "'" & sf.cadena(obj${table}.${field}) & "' #if ($table.GetArrayOfFields.count() -  $count  != 1) , #end"
					  
				#end
				#set ($count = $count + 1 )
			#end 			
                      
			 sqlt += " )"

            db.ejecutar(sqlt)
            reg = db.sql("select @@identity as id from ${table}")
            If reg.Read() Then
                return reg("id").ToString
            Else
                return ""
            End If
            reg.close()

           
        Catch ex As Exception
        Finally
            db.dispose()
        End Try


    End Function 'insertarEnBd()


	  public Function delete${table} (byval ${table.getKey()}x as integer)
            Dim db As New dbClassMysql(ctes.conStringAdo)

            Dim sqlt As String
            Try
                sqlt = " delete from ${table} where ${table.getKey()}=" & ${table.getKey()}x
                db.ejecutar(sqlt)

            Catch ex As Exception
            Finally
                db.dispose()
            End Try
       End Function     



 <#assign x=0>
<#list table.getRelations() as relation>

  
    <#assign x = x+1>
 
      
    
	
	   public Function delete${table}By${table.getKey()} (byval ${table.getKey()}x as integer)
            Dim db As New dbClassMysql(ctes.conStringAdo)

            Dim sqlt As String
            Try
                sqlt = " delete from ${table} where ${table.getKey()}=" & ${table.getKey()}x
                db.ejecutar(sqlt)

            Catch ex As Exception
            Finally
                db.dispose()
            End Try
       End Function     

#end 
 
 
 

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub



    Public Sub New()

    End Sub


    Public Sub new (ByVal ${table.getKey()}x As integer)
            Dim db As New dbClassMysql(ctes.conStringAdo)
            Dim reg As Object
            Dim sqlt As String

            Try
                sqlt = " select * from ${table} where ${table.getKey()}=" & ${table.getKey()}x

                reg = db.sql(sqlt)
                If reg.Read() Then
                  
                               #foreach( $field in $table.GetArrayOfFields )	
				 
				 
					  #if ($field.type.toString() == "_integer")
						 Me.${field} = sf.Entero(reg("${field}"))
						 #end 
					  #if ($field.type.toString() == "_string")
						 Me.${field} = sf.Cadena(reg("${field}"))
						 #end 
					  #if ($field.type.toString() == "_date")
						 Me.${field} = sf.Fecha(reg("${field}"))
						 #end 
					  #if ($field.type.toString() == "_boolean")
						 Me.${field} = sf.Bool(reg("${field}"))
						 #end 
					  <#default>
						 Me.${field} = sf.Cadena(reg("${field}"))
				  	 
			#end 
              
            End If
            reg.close()
        Catch ex As Exception
        Finally
            db.dispose()
        End Try
    End Sub

    public Shared Function delete (byval ${table.getKey()}x as integer)
            Dim db As New dbClassMysql(ctes.conStringAdo)

            Dim sqlt As String
            Try
                sqlt = " delete from ${table} where ${table.getKey()}=" & ${table.getKey()}x
                db.ejecutar(sqlt)

            Catch ex As Exception
            Finally
                db.dispose()
            End Try
       End Function     

End Class