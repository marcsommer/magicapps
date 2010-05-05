<#-- 
 
 crea el menu admin para la tabla  ${table}...
 Author : Luis Molina...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="menuAdmin">
<#assign extensionFile="ascx">
<#assign languageGenerated="c#">
<#assign description="description">
<#assign targetDirectory="">
<#assign appliesToAllTables="true">
<#-- END variables used internally by the generator... -->
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menuAdmin.ascx.cs" Inherits="juleweb.admin.master.menuAdmin" %>
<ul id="menu">
	#set ($count = 0)
	<#list project.getTables() as name>
		<li><span class="esqIzq"></span><a href="../${name}_dir/listado_${name}.aspx">${name}</a><span class="esqDcha"></span></li>
	 #end 
</ul>