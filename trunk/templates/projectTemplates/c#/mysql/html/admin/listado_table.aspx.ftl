
<#-- 
 
 crea una clase para un listado_...aspx para la tabla  ${table}...
 Author : Luis Molina...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="listado_${table}">
<#assign extensionFile="aspx">
<#assign languageGenerated="c#">
<#assign description="description">
<#assign targetDirectory="${table}_dir">
<#assign appliesToAllTables="true">
<#-- END variables used internally by the generator... -->


<#-- 
 
 we need the keyfield...
 -->
#foreach( $field in $table.GetArrayOfFields )
 #if ($field.isKey())
    <#assign keyField=field>
 #end
#end 


<%@ Page Language="C#" MasterPageFile="~/admin/master/masterAdmin.Master" AutoEventWireup="true"  CodeBehind="listado_${table}.aspx.cs" Inherits="${project}.${table}_dir.listado_${table}" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--PARTE DERECHA-->
    <asp:Repeater ID="RepeaterBarraNavegacion" runat="server">
        <ItemTemplate>
            ><a href="<%#Eval("url")%>"><%#Eval("nombre")%></a>
        </ItemTemplate>
    </asp:Repeater> 
 
				<!--contenido-->
				<div id="contenido">
				
				<!--barra titulos-->
				<div class="titulos">
					<div class="itemTit">
					  <h2 class="textoTit">   <asp:Label ID="Label1" runat="server" Text="Mantenimiento de ${table}"></asp:Label>
					  </h2>
					</div>
				</div>
				<!--barra titulos-->
				
			 <div class="addCategorias">
				 <asp:Panel ID="Panel1" DefaultButton="btnBuscar" runat="server">
				<ul  class="pestCat">
					<li><a href="../${table}_dir/main_${table}.aspx" class="add">Nuevo ${table}</a></li>
					<li><a href="../${table}_dir/listado_${table}.aspx" class="mod" >Listado ${table}</a></li>
       		<#list table.getRelations() as relation>
			#if ($relation.ParentTable() == "categorias"+ $relation.ChildTable())		
					<li><a href="../${relation.getParentTable()}_dir/main_${relation.getParentTable()}.aspx" class="addCat">Nuevo ${relation.getParentTable()}</a></li>
					<li><a href="../${relation.getParentTable()}_dir/listado_${relation.getParentTable()}.aspx" class="modCat" >Listado ${relation.getParentTable()}</a></li>
			
				#end			
				#end 	
					<li><asp:TextBox ID="txtBusqueda" runat="server"></asp:TextBox> 
                     <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn" OnClick="btnBuscar_Click" /></li>

				</ul>
				</asp:Panel>
				</div>
		<#list table.getRelations() as relation>
				 
		#if ($relation.ParentTable() == "categorias"+ $relation.ChildTable())					
        <div class="floatLeft">
            <h4>
                Vista de ${table} por Categor&iacute;as
            </h4>
        </div>
        <!--elegir ${table}-->
        <div class="elegirCategoria">
            <h5>
                Categor&iacute;as</h5>
            <ul>
	
                <asp:Repeater ID="Repeater2" runat="server">
                    <ItemTemplate>
                        <li><a href="./listado_${table}.aspx?idcat= <%#Eval("idcategorias${table}")%> "
                            class="btn">
                            <%#Eval("nombre")%>
                        </a>></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>	
				#end			
				#end 			
				<!--subseccion 1-->
					<div class="subseccion">
					<div class="titSubseccion">
					  <h3 class="itemh3"> 
					  <asp:Label ID="Label2" runat="server" Text="Administrar ${table}"></asp:Label></h3>
					  </div>
				<div class="tabla">	  
		  <table cellpadding="0"   summary="Tabla de ${table}" class="activ">
		  				<caption>
						${table}
						</caption>  
    	   <thead>
		  
                      
				<tr>
			 	<th></th>
				     #set ($count = 0)
							#foreach( $field in $table.GetArrayOfFields )
								#if ($field.isKey())
								#else
									#if ($count <=2 && $count >=1)
										 <th align="center">${field.getTargetName()}</th>								
									#end
								#end
								#set ($count = $count + 1 )
							#end 	
 						
	            <th></th>
				</tr>
			</thead>
			  <tbody>
      	 
      		    
                    <asp:Repeater ID="Repeater1" runat="server">
                              <ItemTemplate >
                 				<tr  title="${table}" >
                 			    <td align="center">
									<a href="./main_${table}.aspx?id= <%#Eval("${keyField}")%> " class="btn">Editar</a> 
								</td>
								
                                    #set ($count = 0)
									#foreach( $field in $table.GetArrayOfFields )
										#if ($field.isKey())
										#else
											#if ($count <=2 && $count >=1)
											<td  align="center">
													<%#Eval("${field}")%>
											</td>
											#end
										#end
										#set ($count = $count + 1 )
									#end 								
 
					          
                                    <td align="center">
                                      <a href="./main_${table}.aspx?idb= <%#Eval("${keyField}")%> " class="btn">Borrar</a> 
 
                                </td>
                			 
                				</tr>
                			</ItemTemplate>
                 
                    
                    </asp:Repeater>
	           

			
			 </tbody>
			</table> 
					
					
	</div>
					</div><!--subsecciones-->
				
 
		 

				</div>
				<!--contenido-->
 

</asp:Content>