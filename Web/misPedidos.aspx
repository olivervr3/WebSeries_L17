<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="misPedidos.aspx.cs" Inherits="Web.misPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ListView ID="ListProducts" runat="server">
        <div class="pedidos">
            <p><label>Fecha: <%#Eval("fecha") %></label></p>
            <p><label>Total: <%#Eval("precio") %></label></p>
        </div>
    </asp:ListView>                 
</asp:Content>
