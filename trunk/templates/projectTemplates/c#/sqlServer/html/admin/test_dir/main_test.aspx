<%@ Page Language="C#" MasterPageFile="~/admin/master/masterAdmin.Master" AutoEventWireup="true"
    Codebehind="main_test.aspx.cs" Inherits="juleweb.admin.test_dir.main_test" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="lineaForm">
        <label for="Column">
            <span class="etiqueta">Column: </span>
            <asp:TextBox ID="txtColumn" runat="server"></asp:TextBox>
        </label>
    </div>
    <div class="lineaForm">
        <label for="Date">
            <span class="etiqueta">Date: </span>
            <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
        </label>
    </div>
</asp:Content>
