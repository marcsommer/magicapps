<#-- 
 
 crea una  ...
 Author : Luis Molina...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="create">
<#assign extensionFile="aspx">
<#assign languageGenerated="c#">
<#assign description="c#">
<#assign targetDirectory="${table}">
<#assign appliesToAllTables="true">
<#-- END variables used internally by the generator... -->

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<${project}.Models.${table}>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
			#foreach( $field in $table.GetArrayOfFields )	
				 
				 
					  #if ($field.type.toString() == "_integer")
						 <p>
							<label for="${field}">${field}:</label>
							<%= Html.TextBox("${field}") %>
							<%= Html.ValidationMessage("${field}", "*") %>
						</p>
						 #end 
					  #if ($field.type.toString() == "_string")
						  <p>
							<label for="${field}">${field}:</label>
							<%= Html.TextBox("${field}") %>
							<%= Html.ValidationMessage("${field}", "*") %>
						</p>
						 #end 
					  #if ($field.type.toString() == "_date")
						 <p>
							<label for="${field}">${field}:</label>
							<%= Html.TextBox("${field}") %>
							<%= Html.ValidationMessage("${field}", "*") %>
						</p>
						 #end 
					  #if ($field.type.toString() == "_boolean")
						  <p>
							<label for="${field}">${field}:</label>
							<%= Html.TextBox("${field}") %>
							<%= Html.ValidationMessage("${field}", "*") %>
						</p>
						 #end 
					  <#default>
						  <p>
							<label for="${field}">${field}:</label>
							<%= Html.TextBox("${field}") %>
							<%= Html.ValidationMessage("${field}", "*") %>
						</p>
				 
			#end 			
			
			
        <p>
			<input type="submit" value="Create" />
		</p>
        </fieldset>
    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
	<%}%>
    </div>

</asp:Content>
