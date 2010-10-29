<%@ Control Language="C#" AutoEventWireup="true" Codebehind="menuPortal.ascx.cs" Inherits="juleweb.portal.master.menuPortal" %>
<div id="bloqueMenu">
    <span class="mensaje"><strong>Comienza la navegaci&oacute;n principal:</strong></span>
    <h3 class="menuTit">
        <span>Men&uacute;</span></h3>
    <div class="puntosH">
    </div>
    <ul id="menubar">
        <li>
            <asp:HyperLink ID="hplQuienes" runat="server" NavigateUrl="~/portal/miscelanea/condiciones.aspx">Quienes somos</asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="hplContacto" runat="server">Contacto</asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="hplProgramas" runat="server">Programas</asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="hplAsociaciones" runat="server">Asociaciones</asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="hplDocumentos" runat="server">Documentos</asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="hplNoticias" runat="server">Noticias</asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="hplEnlaces" runat="server">Enlaces</asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="hplGaleria" runat="server">Galer�a de im�genes</asp:HyperLink></li>
    </ul>
    <!--acaba capa MENU-->
</div>
