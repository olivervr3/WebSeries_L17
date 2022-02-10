<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Web.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/login.css" rel="stylesheet"/>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Image class="centrarlogo" id ="logo" alt="Logo de SeriesPlus" runat="server" src="../logo/logo_size.jpg"/>
    <div class="wrapper fadeInDown" id="divID" runat="server">
    <div id="formContent" style="border:0px solid gray; top: 0px; left: 0px; background-color: #f4c654; opacity:0.9; color: #9b1617;">

    <!-- Login Form -->
    <form>
        <h1>
            <strong>Iniciar Sesión
        </strong>
        </h1>
        <asp:TextBox ID="TBemail" runat="server" placeholder="email" TextMode="Email"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="UserNameReq" runat="server"
            ControlToValidate="TBemail" ErrorMessage="Introduce el email !!">
        </asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="TBpassword" runat="server" placeholder="contraseña" TextMode="Password"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="PasswordReq" runat="server"
            ControlToValidate="TBpassword" ErrorMessage="Introduce la contraseña !!">
        </asp:RequiredFieldValidator>
        <br />
        <asp:Button id="Button1"
          Text ="Log In"
          OnClick="Button_Login" 
          ToolTip="Iniciar sesión en SeriesPlus"
          runat="server"/>
          &nbsp;
        <br />
        <asp:Label id="Label1" 
                 Text=" " 
                 runat="server"/>
    </form>

    <!-- Crear nuevo usuario -->
    <div id="formFooter">
      <a class="underlineHover" href="Contrasena.aspx">¿Has olvidado tu contraseña?</a>
        <br />
      <a class="underlineHover" href="CrearUsuario.aspx">Crear nuevo usuario</a>
    </div>

  </div>
</div>
</asp:Content>

