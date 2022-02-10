<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Trailer.aspx.cs" Inherits="Web.Trailer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Fondo1" runat="server" style="background-color: #0B1F3A; background-size:auto; width: auto; margin-right: -120px; margin-left: -120px;" >  
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton id="id_atras" AlternateText ="Ir atrás" ToolTip ="Ir atrás" runat="server" ImageUrl="https://pngimage.net/wp-content/uploads/2018/05/button-back-png-3.png" Height="40px" Width="40px"   OnClick="Button_Back"/>
        <br />
    <p align="center"><iframe id="youtube" runat="server" width="1000" height="480" 
    src="https://www.youtube.com/embed/YlnmVLoIsRk?autoplay=1" alt ="Tráiler de YouTube" 
    allowfullscreen></iframe> </p>
    </div>
</asp:Content>
