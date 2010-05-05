<#-- 
 
 crea el menu admin para la tabla  ${table}...
 Author : Luis Molina...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="menuPortal">
<#assign extensionFile="ascx">
<#assign languageGenerated="c#">
<#assign description="description">
<#assign targetDirectory="">
<#assign appliesToAllTables="true">
<#-- END variables used internally by the generator... --><%@ Control Language="C#" AutoEventWireup="true" Codebehind="menuPortal.ascx.cs"
    Inherits="juleweb.portal.master.menuPortal" %>
<div id="bloqueMenu">
    <span class="mensaje"><strong>Comienza la navegaci&oacute;n principal:</strong></span>
    <h3 class="menuTit">
        <span>Men&uacute;</span></h3>
    <div class="puntosH">
    </div>
    <ul id="menubar">
	#set ($count = 0)
		<#list project.getTables() as name>
			<li>
				<asp:HyperLink ID="hpl${name}" runat="server"  NavigateUrl="~/portal/main_${name}/listado_${name}.aspx">${name}</asp:HyperLink>
			</li>
		 #end 
    </ul>
    <!--acaba capa MENU-->
</div>
