<%@ Page Title="Mis series" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="MisSeries.aspx.cs" Inherits="Web.MisSeries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="css/seriesBiblio.css" rel="stylesheet"/>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Mis series</h1>

    <div>
        <asp:Label ID="labelMisSeries" Text="" runat="server" />
    </div>
    
    <br />

    <ul class="lProducts">
        <asp:ListView ID="misSeries" runat="server">
            <ItemTemplate>
                  <div class="productData">
                    <div class="productsContainer">
                        <div class="productImage">
                            <p><label><img src="../imagenes series/<%#Eval("imagen")%>" /></label></p>
                        </div>

                        <div class="text">
                            <p><label><a style="color:black"> <%#Eval("nombre") %></a></label></p>
                        </div>
                        <asp:HyperLink  ID="Button1" runat="server" Text="+info"  NavigateUrl='<%# String.Format("~/InfoSerie.aspx?nSerie={0}", Eval("nombre")) %>' style="width:60px;height:30px;border-radius: 40px;"/>
                        <asp:HyperLink ID="LinkBorrarSerie" runat="server" Text="Quitar"  NavigateUrl='<%# String.Format("~/MisSeries.aspx?nSerie={0}", Eval("nombre")) %>' CssClass="btn btn-warning" />
                   
                        <p><label><%#Eval("precio") %> €</label></p>
                    </div>
                </div>

              
            </ItemTemplate>
        </asp:ListView>
    </ul>

</asp:Content>
