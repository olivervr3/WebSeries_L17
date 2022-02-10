<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="InfoSerie.aspx.cs" Inherits="Web.InfoSerie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/seriePage.css" rel="stylesheet"/>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div id="Fondo1" runat="server" style="background-color: #0B1F3A; background-size:auto; width: auto; margin-right: -120px; margin-left: -120px;" >  
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton id="id_atras" AlternateText ="Ir atrás" ToolTip ="Ir atrás" runat="server" ImageUrl="https://pngimage.net/wp-content/uploads/2018/05/button-back-png-3.png" Height="40px" Width="40px"   OnClick="Button_Back"/>
        <br />
        <div id="contID" runat="server" class="container" > 
            ​
        	<div class="row">
               <div class="col-xs-4 item-photo">
                    <asp:Image ID="Image1" runat="server"/>
                </div>
                <div class="col-xs-5" style="border:0px solid gray; top: 0px; left: 0px; background-color: rgb(0, 0, 0); opacity:0.7; color: #fff;">
                    <h3> <asp:Label id="title" Text="" runat="server"/> </h3>
                    <!-- Datos de la serie -->   
                    <asp:Label id="desc" Text="" runat="server"/>
                    <h6 class="title-price"><small>TEMPORADAS: </small></h6>
                    <asp:Label id="temporadas" Text="" runat="server"/>
                    <!-- Precios -->
                    <h6 class="title-price"><small>PRECIO: </small></h6>
                    <asp:Label id="pvp" Text="" runat="server"/>
                    €
                    <h6 class="title-price"><small>TIPO DE COMPRA: </small></h6>
                    <asp:radioButtonList id="cBL1"  runat="server">
                        <asp:ListItem Value="1">Comprar</asp:ListItem>
                        <asp:ListItem Value="2">Alquilar</asp:ListItem>
                    </asp:radioButtonList>
                    <asp:Button id="Button4" Text ="Confirmar" OnClick="Button_TipoCompra" ToolTip ="Confirmar tipo de compra" runat="server" ForeColor="Black" />
                    <!-- Botones -->
                    <div class="section" style="padding-bottom:20px;">
                        
                        <asp:Button id="Button1" class="glyphicon glyphicon-shopping-cart" Text ="Ver tráiler" OnClick="Button_trailer" ToolTip ="Enlace de YouTube" runat="server" ForeColor="Black"/>
                        
                        <asp:Button id="Button2" class="glyphicon glyphicon-shopping-cart" Text ="Añadir a la cesta" OnClick="Button_Cesta" runat="server" ForeColor="Black"/>
                        
                        <asp:Button id="Button3" class="glyphicon glyphicon-shopping-cart" Text ="Añadir a pendientes" OnClick="Button_Pendientes" runat="server" ForeColor="Black"/>
                        <br /><br />
                        <asp:ImageButton id="facebook" runat="server" AlternateText="Compartir en Facebook" ImageUrl="https://cdn.pixabay.com/photo/2018/05/08/18/25/facebook-3383596_1280.png" OnClick="Button_Facebook"  Height="30px" Width="30px"/>
                        &nbsp;
                        <asp:ImageButton id="twitter" runat="server" AlternateText="Compartir en Twitter" ImageUrl="https://1000marcas.net/wp-content/uploads/2019/11/Logo-Twitter.png" OnClick="Button_Twitter"  Height="30px" Width="40px"/>
                        &nbsp;&nbsp;
                        <asp:Label ID="mensaje" runat="server" Text="">
                            
                        </asp:Label>
                    </div>                                        
                </div>                              	
            </div>
        </div> 
    </div> 
</asp:Content>
