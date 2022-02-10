<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Contrasena.aspx.cs" Inherits="Web.Contrasena" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/login.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper fadeInDown" id="divID" runat="server">
  <div id="formContent" style="border:0px solid gray; top: 0px; left: 0px; background-color: #f4c654; opacity:0.9; color: #9b1617;">
    <form>
        <h1>
            <strong>Recuperar Contraseña
        </strong>
        </h1>
        <asp:TextBox ID="TBemail" runat="server" placeholder="email"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="UserNameReq" runat="server"
            ControlToValidate="TBemail" ErrorMessage="Introduce el email !!">
        </asp:RequiredFieldValidator>
        <br />
        <asp:Button id="Button1"
          Text ="Recuperar"
          OnClick="Button_Recuperar" 
          ToolTip ="Solicitar mi antigua contraseña"
          runat="server"/>
          &nbsp;
        <br />
        <asp:Label id="Label1"  
                 runat="server"/>
    </form>

    <!-- Iniciar Sesión -->
    <div id="formFooter">
      <a class="underlineHover" href="Inicio.aspx">Iniciar Sesión </a>
    </div>

  </div>
</div>
</asp:Content>
