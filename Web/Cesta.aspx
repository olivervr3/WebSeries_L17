<%@ Page Title="Cesta" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Cesta.aspx.cs" Inherits="Web.Cesta"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1>Cesta</h1>
    
    <div>
        <asp:Label ID="labelCesta" Text="" runat="server" />
    </div>

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
        <asp:ListView ID="lineasCesta" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:HyperLink ID="LinkInfoSerie" runat="server" Text='<%# String.Format("{0}", Eval("nombre")) %>'  NavigateUrl='<%# String.Format("~/InfoSerie.aspx?nSerie={0}", Eval("nombre")) %>' />
                    </td>
                    <td>
                        <%#Eval("tipo")%>
                    </td>
                    <td>
                        <%#Eval("precio")%>
                    </td>
                    <td>
                        <asp:HyperLink ID="LinkBorrarLinea" runat="server" Text="Eliminar"  NavigateUrl='<%# String.Format("~/Cesta.aspx?nSerie={0}", Eval("nombre")) %>' CssClass="btn btn-warning" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </table>

    <br />
    <div>
        <asp:Label ID="totalLabel" runat="server" Text="0" />
        </div>
    
    <br />

    <div> 
          <asp:Button ID="BotonTramitarPedido" runat="server" Text="Tramitar pedido" OnClick="BotonTramitarPedido_Click" CssClass="btn btn-primary float-left" />
    
          <asp:Button ID="BotonVaciarCesta" runat="server" Text="Vaciar cesta" OnClick="BotonVaciarCesta_Click" CssClass="btn btn-danger float-right" />
    </div>

</asp:Content>
