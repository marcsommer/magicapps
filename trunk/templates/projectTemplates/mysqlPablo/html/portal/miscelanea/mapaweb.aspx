<%@ Page Language="C#" MasterPageFile="~/portal/master/masterWeb.Master" AutoEventWireup="true"
    Codebehind="mapaweb.aspx.cs" Inherits="juleweb.portal.miscelanea.mapaweb" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="parteCentral">
        <div id="bloqueInicio">
            <span>
                <asp:HyperLink ID="hplInicio" runat="server">Inicio</asp:HyperLink></span> &gt;
            Mapa web
        </div>
        <div class="puntosH">
        </div>
        <div class="textobloque2">
            <div class="titulo">
                <h2>
                    Mapa web
                </h2>
            </div>
            <!--mapa web-->
            <p>
                Encuentre todos nuestros apartados del sitio en cualquier ubicaci&oacute;n:</p>
            <ul id="menubar">
                <li>
                    <asp:HyperLink ID="hplInicio2" runat="server">Inicio</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="hplQuienes" runat="server">Quienes somos</asp:HyperLink></li>
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
                    <asp:HyperLink ID="hplGaleria" runat="server">Galería de imágenes</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="hplAgenda" runat="server">Agenda</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="hplResponsable" runat="server">Responsable Web</asp:HyperLink></li>    
                <li>
                    <asp:HyperLink ID="hplAccesibilidad" runat="server">Accesibilidad</asp:HyperLink></li>                                                                
            </ul>
            <!--mapa web-->
        </div>
    </div>
</asp:Content>
