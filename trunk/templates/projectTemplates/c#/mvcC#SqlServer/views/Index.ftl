<#-- 
 
 crea una 
 Author : Luis Molina...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="Index">
<#assign extensionFile="aspx">
<#assign languageGenerated="c#">
<#assign description="c#">
<#assign targetDirectory="${table}">
<#assign appliesToAllTables="true">
<#-- END variables used internally by the generator... -->

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<${project}.Models.${table}>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>List</h2>
    <table>
        <tr>
            <th></th>

            #foreach( $field in $table.GetArrayOfFields )	
				 
				 
					  #if ($field.type.toString() == "_integer")
						 <th>
							${field}
						</th>
						 #end 
					  #if ($field.type.toString() == "_string")
						  <th>
							${field}
						</th>
						 #end 
					  #if ($field.type.toString() == "_date")
						 <th>
							${field}
						</th>
						 #end 
					  #if ($field.type.toString() == "_boolean")
						 <th>
							${field}
						</th>
						 #end 
					  <#default>
						  <th>
							${field}
						</th>
				 
			#end 		

        </tr>

    <% foreach (var item in Model) { %>
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.${table.getKey()} }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.${table.getKey()} })%>
            </td>
	
	
             #foreach( $field in $table.GetArrayOfFields )	
				 
				 
					  #if ($field.type.toString() == "_integer")
						#if ( $field.isForeignKey())				
							<td>
								<%= Html.Encode(ViewData["${field}Value"]) %>
							</td>
						</#else>
							 <td>
								<%= Html.Encode(item.${field}) %>
							</td>
						#end
						 #end 
					  #if ($field.type.toString() == "_string")
						  <td>
							<%= Html.Encode(item.${field}) %>
						</td>
						 #end 
					  #if ($field.type.toString() == "_date")
						 <td>
							<%= Html.Encode(item.${field}) %>
						</td>
						 #end 
					  #if ($field.type.toString() == "_boolean")
						 <td>
							<%= Html.Encode(item.${field}) %>
						</td>
						 #end 
					  <#default>
						  <td>
							<%= Html.Encode(item.${field}) %>
						</td>
				 
			#end 
			
    <% } %>
        </tr>
    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>
