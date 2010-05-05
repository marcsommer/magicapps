<#-- 
 
 crea una 
 Author : Luis Molina...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="Details">
<#assign extensionFile="aspx">
<#assign languageGenerated="c#">
<#assign description="c#">
<#assign targetDirectory="${table}">
<#assign appliesToAllTables="true">
<#-- END variables used internally by the generator... -->

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<${project}.Models.${table}>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>
    <fieldset>
        <legend>Fields</legend>
			#foreach( $field in $table.GetArrayOfFields )	
				 
				 
					  #if ($field.type.toString() == "_integer")
						 <p>
							${field}:
							<%= Html.Encode(Model.${field}) %>
						</p>
						 #end 
					  #if ($field.type.toString() == "_string")
						  <p>
							${field}:
							<%= Html.Encode(Model.${field}) %>
						</p>
						 #end 
					  #if ($field.type.toString() == "_date")
						 <p>
							${field}:
							<%= Html.Encode(Model.${field}) %>
						</p>
						 #end 
					  #if ($field.type.toString() == "_boolean")
						  <p>
							${field}:
							<%= Html.Encode(Model.${field}) %>
						</p>
						 #end 
					  <#default>
						  <p>
							${field}:
							<%= Html.Encode(Model.${field}) %>
						</p>
				 
			#end 
        

    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

 
</asp:Content>

 