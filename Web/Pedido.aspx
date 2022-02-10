<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Pedido.aspx.cs" Inherits="Web.Pedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Pedido</h1>
    <br />
    <table class="table table">
        <thead>
            <tr>
                <th>Nombre de serie</th>
                <th>Tipo de compra</th>
                <th>Precio</th>
                <th></th>
            </tr>
        </thead>
        <asp:ListView ID="lineasPedido" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:HyperLink ID="LinkInfoSerie" runat="server" Text='<%# String.Format("{0}", Eval("nombre")) %>' NavigateUrl='<%# String.Format("~/InfoSerie.aspx?nSerie={0}", Eval("nombre")) %>' />
                    </td>
                    <td>
                        <%#Eval("tipo")%>
                    </td>
                    <td>
                        <%#Eval("precio")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </table>

    <br />
    <div>
        <asp:Label ID="totalLabel" runat="server" Text="0" />
        <asp:Label ID="label1" runat="server" Text="Label"></asp:Label>
    </div>

    <br />

    <div> 
        <asp:Button ID="BotonTramitarPedido" runat="server" Text="Tramitar pedido" OnClick="BotonTramitarPedido_Click" CssClass="btn btn-primary" /> 
        <asp:Button ID="BotonCancelarPedido" runat="server" Text="Cancelar Pedido" OnClick="BotonCancelarPedido_Click" CssClass="btn btn-danger" />
        
    </div>
</asp:Content>
