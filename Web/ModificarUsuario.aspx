<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="Web.ModificarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/login.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper fadeInDown">
    <div id="formContent" style="border:0px solid gray; top: 0px; left: 0px; background-color: #f4c654; opacity:0.9; color: #9b1617;">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Modificar Usuario -->
    <form>
        <h1>
            Modificar Usuario
        </h1>
      <asp:Label id="Label1" 
                 Text="**Email**" 
                 runat="server"/>
        <br />
      <asp:TextBox ID="TBNombre" runat="server" placeholder="nombre"></asp:TextBox>
        <asp:RequiredFieldValidator ID="UserNameReq" runat="server"
            ControlToValidate="TBNombre" ErrorMessage="Introduce el nombre !!">
        </asp:RequiredFieldValidator>

        <asp:TextBox ID="TBApellido1" runat="server" placeholder="primer apellido"></asp:TextBox>
        <asp:RequiredFieldValidator ID="UserSurname1Req" runat="server"
            ControlToValidate="TBApellido1" ErrorMessage="Introduce el primer apellido !!">
        </asp:RequiredFieldValidator>

        <asp:TextBox ID="TBApellido2" runat="server" placeholder="segundo apellido"></asp:TextBox>
        <asp:RequiredFieldValidator ID="UserSurname2Req" runat="server"
            ControlToValidate="TBApellido2" ErrorMessage="Introduce el segundo apellido !!">
        </asp:RequiredFieldValidator>
        <asp:TextBox ID="TBContrasena" runat="server" placeholder="contraseña"></asp:TextBox>
        <asp:RequiredFieldValidator ID="UserPassReq" runat="server"
            ControlToValidate="TBContrasena" ErrorMessage="Introduce la contraseña !!">
        </asp:RequiredFieldValidator>
        <ajaxToolkit:PasswordStrength ID="PasswordStrength1" runat="server"  TargetControlID="TBContrasena"
           RequiresUpperAndLowerCaseCharacters="true"
            MinimumNumericCharacters="0" 
            MinimumSymbolCharacters="1" 
            PreferredPasswordLength="8"
            DisplayPosition="RightSide" 
            StrengthIndicatorType="BarIndicator" 
            BarBorderCssClass="BarBorder" 
            StrengthStyles="BarIndicatorweak;BarIndicatoraverage;BarIndicatorgood;"/>
        <br />
        <asp:RegularExpressionValidator ID="UserPassREV" runat="server"
            ControlToValidate="TBContrasena" ErrorMessage="Formato no válido (4 - 10 caracteres y el primer carácter debe ser una letra) !!" ValidationExpression="[a-zA-Z]\w{3,9}">
        </asp:RegularExpressionValidator>

        <asp:TextBox ID="TBConfirmar" runat="server" placeholder="confirmar contraseña"></asp:TextBox>
        <asp:RequiredFieldValidator ID="UserConfReq" runat="server"
            ControlToValidate="TBConfirmar" ErrorMessage="Introduce la contraseña !!">
        </asp:RequiredFieldValidator>
        <br />
        <asp:CompareValidator ID="UserConfCV" runat="server"
            ControlToValidate="TBConfirmar" ErrorMessage="Las conreaseñas no coinciden !!" Type="String" Operator="Equal" ControlToCompare="TBContrasena">
        </asp:CompareValidator>

        <asp:TextBox ID="TBNif" runat="server" placeholder="nif"></asp:TextBox>
        <asp:RequiredFieldValidator ID="UserNifReq" runat="server"
            ControlToValidate="TBNif" ErrorMessage="Introduce el nif !!">
        </asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator ID="UserNifREV" runat="server"
            ControlToValidate="TBNif" ErrorMessage="Formato no válido (ddddddddL) !!" ValidationExpression="\d{8}[A-Z]">
        </asp:RegularExpressionValidator>

        <asp:TextBox ID="TBTelefono" runat="server" placeholder="número de teléfono"></asp:TextBox>
        <asp:RequiredFieldValidator ID="UserTelReq" runat="server"
            ControlToValidate="TBTelefono" ErrorMessage="Introduce el número de teléfono !!">
        </asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator ID="UserTelREV" runat="server"
            ControlToValidate="TBTelefono" ErrorMessage="Formato no válido !!" ValidationExpression="\d{9}">
        </asp:RegularExpressionValidator>

        <asp:TextBox ID="TBTarjeta" runat="server" placeholder="tarjeta de crédito"></asp:TextBox>
        <asp:RequiredFieldValidator ID="UserTarReq" runat="server"
            ControlToValidate="TBTarjeta" ErrorMessage="Introduce el número de la tarjeta de débito !!">
        </asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator ID="UserTarREV" runat="server"
            ControlToValidate="TBTarjeta" ErrorMessage="Formato no válido (dddd-dddd-dddd-dddd) !!" ValidationExpression="\d{4}-\d{4}-\d{4}-\d{4}">
        </asp:RegularExpressionValidator>

        <asp:TextBox ID="TBCaducidad" runat="server" placeholder="número de caducidad"></asp:TextBox>
        <asp:RequiredFieldValidator ID="UserCadReq" runat="server"
            ControlToValidate="TBCaducidad" ErrorMessage="Introduce la fecha de caducidad de la tarjeta !!">
        </asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
            ControlToValidate="TBCaducidad" ErrorMessage="Formato no válido (dd-dd) !!" ValidationExpression="\d{2}-\d{2}">
        </asp:RegularExpressionValidator>

        <asp:TextBox ID="TBSeguridad" runat="server" placeholder="número de seguridad"></asp:TextBox>
        <asp:RequiredFieldValidator ID="UserSegReq" runat="server"
            ControlToValidate="TBSeguridad" ErrorMessage="Introduce el número de seguridad de la tarjeta !!">
        </asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator ID="UserSegREV" runat="server"
            ControlToValidate="TBSeguridad" ErrorMessage="Formato no válido (ddd) !!" ValidationExpression="\d{3}">
        </asp:RegularExpressionValidator>
        <br />

      <asp:Button id="Button1"
          Text ="Confirmar"
          OnClick="Button_Update" 
          ToolTip="Modififar los datos"
          runat="server"/>
          &nbsp;
    <asp:Button id="Button2"
          Text ="Borrar usuario"
          OnClick="Button_Delete" 
          ToolTip="Darme de baja en SeriesPlus"
          runat="server"/>
          &nbsp;
    <br />
    <asp:Label id="Label2" 
         Text=" " 
         runat="server"/>
    </form>
  </div>
</div>
</asp:Content>
