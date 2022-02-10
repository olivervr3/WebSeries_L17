<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="CrearUsuario.aspx.cs" Inherits="Web.CrearUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="css/login.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper fadeInDown" id="divID" runat="server">
  <div id="formContent"  style="border:0px solid gray; top: 0px; left: 0px; background-color: #f4c654; opacity:0.9; color: #9b1617;">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Crear Usuario -->
    <form>
        <h1>
            Crear Usuario
        </h1>
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

        <asp:TextBox ID="TBEmail" runat="server" placeholder="email"></asp:TextBox>
        <asp:RequiredFieldValidator ID="UserEmailReq" runat="server"
            ControlToValidate="TBEmail" ErrorMessage="Introduce el email !!">
        </asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator ID="UserEmailREV" runat="server"
            ControlToValidate="TBEmail" ErrorMessage="Formato no válido !!" ValidationExpression="\S+@\S+\.\S+">
        </asp:RegularExpressionValidator>

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

        <asp:Button id="bt" runat="server" Text="Leer" ToolTip="Leer Política de Privacidad"/>
        <br />

        <asp:CheckBox ID="BTCheck" runat="server"/>
        He leído y acepto la Política de Privacidad</a>
        <br />

            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
                DynamicServicePath="" Enabled="True" TargetControlID="bt" PopupControlID="PanelModal" CancelControlID="CancelButton" 
                >
            </ajaxToolkit:ModalPopupExtender>

        <asp:Panel ID="PanelModal" runat="server" style="display:none; background:white; width:80%; height:auto">
            <div style="font-size:small; text-align:left" >
            <br />
            POLÍTICA DE PRIVACIDAD<br />
            El presente Política de Privacidad establece los términos en que SeriesPlus usa y protege la
            información que es proporcionada por sus usuarios al momento de utilizar su sitio web. Esta
            compañía está comprometida con la seguridad de los datos de sus usuarios. Cuando le pedimos
            llenar los campos de información personal con la cual usted pueda ser identificado, lo hacemos
            asegurando que sólo se empleará de acuerdo con los términos de este documento. Sin embargo
            esta Política de Privacidad puede cambiar con el tiempo o ser actualizada por lo que le
            recomendamos y enfatizamos revisar continuamente esta página para asegurarse que está de
            acuerdo con dichos cambios.<br />
            Información que es recogida<br />
            Nuestro sitio web podrá recoger información personal por ejemplo: Nombre, información de
            contacto como su dirección de correo electrónica e información demográfica. Así mismo cuando
            sea necesario podrá ser requerida información específica para procesar algún pedido o realizar
            una entrega o facturación.<br />
            Uso de la información recogida<br />
            Nuestro sitio web emplea la información con el fin de proporcionar el mejor servicio posible,
            particularmente para mantener un registro de usuarios, de pedidos en caso que aplique, y mejorar
            nuestros productos y servicios. Es posible que sean enviados correos electrónicos
            periódicamente a través de nuestro sitio con ofertas especiales, nuevos productos y otra
            información publicitaria que consideremos relevante para usted o que pueda brindarle algún
            beneficio, estos correos electrónicos serán enviados a la dirección que usted proporcione y
            podrán ser cancelados en cualquier momento.<br />
            SeriesPlus está altamente comprometido para cumplir con el compromiso de mantener su
            información segura. Usamos los sistemas más avanzados y los actualizamos constantemente
            para asegurarnos que no exista ningún acceso no autorizado.<br />
            Cookies<br />
            Una cookie se refiere a un fichero que es enviado con la finalidad de solicitar permiso para
            almacenarse en su ordenador, al aceptar dicho fichero se crea y la cookie sirve entonces para
            tener información respecto al tráfico web, y también facilita las futuras visitas a una web
            recurrente. Otra función que tienen las cookies es que con ellas las web pueden reconocerte
            individualmente y por tanto brindarte el mejor servicio personalizado de su web.
            Nuestro sitio web emplea las cookies para poder identificar las páginas que son visitadas y su
            frecuencia. Esta información es empleada únicamente para análisis estadístico y después la
            información se elimina de forma permanente. Usted puede eliminar las cookies en cualquier
            momento desde su ordenador. Sin embargo las cookies ayudan a proporcionar un mejor servicio
            de los sitios web, estás no dan acceso a información de su ordenador ni de usted, a menos de
            que usted así lo quiera y la proporcione directamente, visitas a una web . Usted puede aceptar o
            negar el uso de cookies, sin embargo la mayoría de navegadores aceptan cookies
            automáticamente pues sirve para tener un mejor servicio web. También usted puede cambiar la
            configuración de su ordenador para declinar las cookies. Si se declinan es posible que no pueda
            utilizar algunos de nuestros servicios.<br />
            Enlaces a Terceros<br />
            Este sitio web pudiera contener en laces a otros sitios que pudieran ser de su interés. Una vez
            que usted de clic en estos enlaces y abandone nuestra página, ya no tenemos control sobre al
            sitio al que es redirigido y por lo tanto no somos responsables de los términos o privacidad ni de la
            protección de sus datos en esos otros sitios terceros. Dichos sitios están sujetos a sus propias
            políticas de privacidad por lo cual es recomendable que los consulte para confirmar que usted
            está de acuerdo con estas.<br />
            Control de su información personal<br />
            En cualquier momento usted puede restringir la recopilación o el uso de la información personal
            que es proporcionada a nuestro sitio web. Cada vez que se le solicite rellenar un formulario,
            como el de alta de usuario, puede marcar o desmarcar la opción de recibir información por correo
            electrónico. En caso de que haya marcado la opción de recibir nuestro boletín o publicidad usted
            puede cancelarla en cualquier momento.<br />
            Esta compañía no venderá, cederá ni distribuirá la información personal que es recopilada sin su
            consentimiento, salvo que sea requerido por un juez con un orden judicial.
            SeriesPlus Se reserva el derecho de cambiar los términos de la presente Política de Privacidad en
            cualquier momento.
            <asp:Button id="CancelButton" runat="server" Text="X"/>
            </div>
        </asp:Panel>

        <asp:Button id="Button1"
          Text ="Crear"
          OnClick="Button_Create" 
          ToolTip ="Confirmar registro y crear usuario"
          runat="server"/>
          &nbsp;
        <br />
        <asp:Label id="Label1" 
                 Text=" " 
                 runat="server"/>
    </form>

    <!-- Iniciar Sesión -->
    <div id="formFooter">
      <a class="underlineHover" href="Inicio.aspx">Iniciar Sesión</a>
    </div>

  </div>
</div>
</asp:Content>
