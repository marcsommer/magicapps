<#-- 
 
 crea una clase para c# para la tabla  ${table}...
 Author : Luis Molina...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="ficha_${table}">
<#assign extensionFile="aspx">
<#assign languageGenerated="c#">
<#assign description="c#">
<#assign targetDirectory="main_${table}">
<#assign appliesToAllTables="true">
<#-- END variables used internally by the generator... -->
<%@ Page Language="C#" MasterPageFile="~/portal/master/masterWeb.Master" AutoEventWireup="true"
    Codebehind="ficha_${table}.aspx.cs" Inherits="${project}.portal.main_${table}.ficha_${table}"
    Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
 <!--contenido-->
	<div id="contenido">
	     	
				 
				
				<!--subseccion 1-->
					<div class="subseccion">
					 
		 	
#set ($count = 0)
#foreach( $field in $table.GetArrayOfFields )
  #if (!$field.isKey())

   
     
     
              #if ($field.type.toString() == "_integer")
                #if ( $field.isForeignKey())
						<div class="lineaForm">
							<label for="${field}">		
								<span class="etiqueta">${field.getTargetName()}: </span>
								 <asp:Label ID="lab${field}" text=""  runat="server"></asp:Label>
							</label>
						</div>		
            #else
				<div class="lineaForm">
                <label for="${field}">
                        <span class="etiqueta">${field.getTargetName()}: </span>
                        <asp:Label ID="lab${field}" text=""  runat="server"></asp:Label>
                    </label>
				</div>		
            #end

                
                 #end 
              #if ($field.type.toString() == "_string")
			  	<div class="lineaForm">
                   <label for="${field}">
                        <span class="etiqueta">${field.getTargetName()}: </span>
                        <asp:Label ID="lab${field}"  text=""    runat="server"></asp:Label>
                    </label>
				</div>		
                 #end 
              #if ($field.type.toString() == "_date")
			  	<div class="lineaForm">
                 <label for="${field}">
                        <span class="etiqueta">${field.getTargetName()}: </span>
                        <asp:Label ID="lab${field}"  text=""    runat="server"></asp:Label>
                    </label>
				</div>		
                 #end 
              #if ($field.type.toString() == "_boolean")
			  	<div class="lineaForm">
                  <label for="${field}">
                        <span class="etiqueta">${field.getTargetName()}: </span>
                        <asp:CheckBox ID="ck${field}"   runat="server" />
                    </label>
						</div>		
                 #end 
              #if ($field.type.toString() == "_image")
			  		<div class="lineaForm">
						    <asp:Image ID="img${field}" runat="server" Visible="False" Width="40px" />
                            <br />
                            <asp:Label ID="lblInfo${field}" CssClass="camporojo" runat="server" Text=""></asp:Label>
					</div>
                 #end 
              #if ($field.type.toString() == "_document")
			  		<div class="lineaForm">
						      <asp:Image ID="img${field}" runat="server" Visible="False" Width="40px" />
                            <br />
                            <asp:Label ID="lblInfo${field}" CssClass="camporojo" runat="server" Text=""></asp:Label>
					</div>
                 #end 
				 #if ($field.type.toString() == "_audio")
			  		 <div class="lineaForm">
						   <asp:Label ID="lbl${field}" CssClass="camporojo" runat="server" Text=""></asp:Label>
                            <br />
                            <br />
                     </div>	
                 #end 
				 <#default>
			  	<div class="lineaForm">
                 <label for="${field}">
                        <span class="etiqueta">${field.getTargetName()}: </span>
                        <asp:Label ID="lab${field}"  text=""   runat="server"></asp:Label>
                    </label>
						</div>		
      
    #set ($count = $count + 1 )
 #end
#end 			
			
		    					
					</div><!--subseccion 1-->
					
					
			</div>	<!--contenido-->






</asp:Content>
