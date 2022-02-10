<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="Web.Info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Acerca de</h1>
        
    <br />

    <div>
        <asp:ValidationSummary runat="server" />
    <asp:Label ID="labelInfo" Text="" runat="server" />
    </div>
        <br />

    <div class="row">
    <div class="col-sm-6">
        <p>SeriesPlus es una startup española en la que podrás encontrar las mejores series.</p>
        <p>Regístrate e inicia sesión en SeriosPlus para ver tus series favoritas. Es muy fácil: explora nuestra biblioteca de series y añade las que te interesen en modo compra o alquiler a la cesta, tramita tu pedido, realiza el pago con tu tarjeta de crédito y las series estarán disponibles para verlas siempre que desees.</p>
        <p>Añade las series que te gustaría ver el el futuro a series pendientes para que nunca se te olvide nada.</p>
        <p></p>
    </div>
    <div class="col-sm-6">
        <h2>Contacta con nosotros</h2>
        <p>Si tienes cualquier duda o sugerencia utiliza el formulario de contacto. Te responderemos lo antes posible.</p>
        <div class="form-group">
            <label for="NombreTextBox" class="col-sm-12">Tu nombre</label>
            <div class="col-sm-12">     
                <asp:TextBox ID="NombreTextBox" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ControlToValidate="NombreTextBox" runat="server" ErrorMessage="No has introducido tu nombre" Text="Introduce tu nombre" />
            </div>
        </div>
        <div class="form-group">
            <label for="EmailTextBox" class="col-sm-12">Tu e-mail</label>
            <div class="col-sm-12">     
                <asp:TextBox ID="EmailTextBox" runat="server"  CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator ControlToValidate="EmailTextBox" runat="server" ErrorMessage="No has introducido tu e-mail" Text="Introduce tu e-mail" />
           
            </div>
        </div>
        <div class="form-group">
            <label for="MensajeTextBox" class="col-sm-12">Tu mensaje</label>
            <div class="col-sm-12">     
                <asp:TextBox ID="MensajeTextBox" runat="server"  TextMode="MultiLine"  CssClass="form-control" />
                <asp:RequiredFieldValidator ControlToValidate="MensajeTextBox" runat="server" ErrorMessage="No has introducido tu mensaje" Text="Introduce tu mensaje" />
           
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-12">     
               <asp:Button ID="EnviarButton" Text="Enviar" runat="server" CssClass="btn btn-primary" OnClick="EnviarButton_Click" />
             </div>
        </div>
    </div>
        </div>
</asp:Content>
