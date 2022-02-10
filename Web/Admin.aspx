<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Web.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Panel de administración</h2>
    <p>Desde esta sección se puede administrar la parte privada de la aplicación</p>
    
    <p>Contador de visitas: <asp:Label ID="visitasLabel" runat="server"  Text=""/></p>
    
    <ul class="list-group">
        <li class="list-group-item">
            <asp:HyperLink NavigateUrl="~/ListarUsuarios.aspx" Text="Listar usuarios" runat="server" />
        </li>
         <li class="list-group-item">
            <asp:HyperLink NavigateUrl="~/CrearSerie.aspx" Text="Crear serie" runat="server" />
        </li>
    </ul>
</asp:Content>
