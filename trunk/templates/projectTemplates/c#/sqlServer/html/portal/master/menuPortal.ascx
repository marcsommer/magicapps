<%@ Control Language="C#" AutoEventWireup="true" Codebehind="menuPortal.ascx.cs"
    Inherits="juleweb.portal.master.menuPortal" %>
<div id="bloqueMenu">
    <span class="mensaje"><strong>Comienza la navegaci&oacute;n principal:</strong></span>
    <h3 class="menuTit">
        <span>Men&uacute;</span></h3>
    <div class="puntosH">
    </div>
    <ul id="menubar">
			<li>
				<asp:HyperLink ID="hplTest" runat="server"  NavigateUrl="~/portal/main_test/listado_test.aspx">test</asp:HyperLink>
			</li>
	</ul>
    <!--acaba capa MENU-->
</div>
