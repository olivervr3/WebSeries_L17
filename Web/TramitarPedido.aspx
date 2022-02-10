<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="TramitarPedido.aspx.cs" Inherits="Web.TramitarPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Tramitar pedido</h2>
    <p>¡Ya casi está! Realiza el pago con tu tarjeta de crédito ahora.</p>

    <p>
        <asp:Label ID="totalLabel" runat="server" Text="" />
    </p>

    <p>
        <strong>Tu tarjeta: </strong>       
        <asp:Label ID="tarjetaLabel" runat="server" Text="" />
    </p>

    <p>Para confirmar la operación, introduce el código de seguridad de tu tarjeta.</p>
    <div>
        <asp:TextBox ID="codigoTextBox" runat="server" Text="" MaxLength="3" />
        <asp:RequiredFieldValidator ControlToValidate="codigoTextBox" runat="server" ErrorMessage="No has escrito el código" Text="Debes introducir el código de seguridad" />
             <asp:Label ID="codigoEstadoLabel" runat="server" Text="" />
   
    </div>

    <br />

    <asp:Button ID="pagarBoton" runat="server" Text="Pagar" OnClick="pagarBoton_Click" CssClass="btn btn-primary" />

</asp:Content>
