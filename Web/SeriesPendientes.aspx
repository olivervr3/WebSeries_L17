<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="SeriesPendientes.aspx.cs" Inherits="Web.SeriesPendientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/seriesBiblio.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Series Pendientes</h1>

        <div class="search">
        <asp:Button ID="Button3" runat="server" Text="Categoria" OnClick="Button3_Click" style="width:100px;height:30px;border-radius: 40px;"/>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="categoria" DataValueField="categoria"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:miconexion %>" SelectCommand="SELECT DISTINCT [categoria] FROM [Series]"></asp:SqlDataSource>
       
        <div class="busqueda">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="Buscar.." OnClick="Button2_Click" style="width:80px;height:30px;border-radius: 40px;"/>
        </div>
    </div>


    <ul class="lProducts" style="background-color:red">
        <asp:ListView ID="ListProducts" runat="server">
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
                        <p><label><%#Eval("precio") %> €</label></p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </ul>
</asp:Content>
