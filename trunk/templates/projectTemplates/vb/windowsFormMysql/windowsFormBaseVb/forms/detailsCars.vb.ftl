<#-- 
 
 crea una clase para c# para la tabla  ${table}...
 Author : Luis Molina...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="details${table}">
<#assign extensionFile="vb">
<#assign languageGenerated="vb">
<#assign description="vb">
<#assign targetDirectory="">
<#assign appliesToAllTables="true">
<#-- END variables used internally by the generator... -->
Public Class details${table}

	Private Sub details${table}_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' ejemplo para rellenar el formulario....
        Dim last As New ${table}()
        last.readDb(1)
		
		#set ($count = 0)
                #foreach( $field in $table.GetArrayOfFields )
                     #if (!$field.isKey())
                         
                         
                                  #if ($field.type.toString() == "_integer")
									 #if (! $field.isForeignKey())
										Me.txt${field}.Text = last.${field}
									 #end
									 
									   #end 
                                  #if ($field.type.toString() == "_string")
									#if ( $field.size() >= 251)>
										Me.txt${field}.Text = last.${field}
                                    #else
										Me.txt${field}.Text = last.${field}
                                     #end		
                                     
                                     #end 
                                  #if ($field.type.toString() == "_date")
										Me.txt${field}.Text = last.${field}
                                     #end 
                                  #if ($field.type.toString() == "_boolean")
										Me.txt${field}.Text = last.${field}
                                     #end 
								#if ($field.type.toString() == "_doble")
										Me.txt${field}.Text = last.${field}
                                     #end 
								#if ($field.type.toString() == "_image")
                                     
                                     #end 
                                  <#default>
                                     #if ( $field.size() >= 251)>
										Me.txt${field}.Text = last.${field}
                                    #else
										Me.txt${field}.Text = last.${field}
                                     #end		
                          
                     #end
                    #set ($count = $count + 1 )
                 #end 
        
        
        
		last = Nothing


    End Sub
	
End Class