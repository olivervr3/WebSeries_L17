<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="CrearSerie.aspx.cs" Inherits="Web.CrearSerie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Crear serie</h2>

    <br />
    <asp:Label ID="CrearSerieLabel" Text="" runat="server" />
    <asp:ValidationSummary runat="server" />
    <br />

    <div class="row">

    <div class="col-sm-6">
    
        <div class="form-group">
            <label for="TextBoxNombre" class="col-sm-3 control-label">Nombre *</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBoxNombre" runat="server" CssClass="form-control" MaxLength="32" />
                <asp:RequiredFieldValidator ControlToValidate="TextBoxNombre" ErrorMessage="Debes introducir el nombre de la serie" Text="Introduce el nombre" runat="server" CssClass="help-block" />
            </div>
        </div>

           <div class="form-group">
            <label for="TextBoxCategoria" class="col-sm-3 control-label">Categoría *</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBoxCategoria" runat="server" CssClass="form-control" MaxLength="16" />
                <asp:RequiredFieldValidator ControlToValidate="TextBoxCategoria" ErrorMessage="Debes introducir la categoria de la serie" Text="Introduce la categoría" runat="server" CssClass="help-block" />
            </div>
        </div>

        <div class="form-group">
            <label for="TextBoxImagen" class="col-sm-3 control-label">URL imagen *</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBoxImagen" runat="server" CssClass="form-control" MaxLength="16" />
                <asp:RequiredFieldValidator ControlToValidate="TextBoxImagen" ErrorMessage="Debes introducir la imagen de la serie" Text="Introduce la url de la imagen " runat="server" CssClass="help-block" />
            </div>
        </div>

        <div class="form-group">
            <label for="TextBoxDescripcion" class="col-sm-3 control-label">Descripción *</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBoxDescripcion" runat="server" CssClass="form-control" MaxLength="512" TextMode="MultiLine" />
                <asp:RequiredFieldValidator ControlToValidate="TextBoxDescripcion" ErrorMessage="Debes introducir la descripción de la serie " Text="Introduce una descripción " runat="server" CssClass="help-block" />
            </div>
        </div>

      


        





       
    
    </div>

    <div class="col-sm-6">
          <div class="form-group">
            <label for="TextBoxTrailer" class="col-sm-3 control-label">Trailer *</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBoxTrailer" runat="server" CssClass="form-control" MaxLength="64" />
                <asp:RequiredFieldValidator ControlToValidate="TextBoxTrailer" ErrorMessage="Debes introducir el trailer de la serie " Text="Introduce un trailer " runat="server" CssClass="help-block" />
            </div>
        </div>

           <div class="form-group">
            <label for="TextBoxPrecio" class="col-sm-3 control-label">Precio *</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBoxPrecio" runat="server" CssClass="form-control" TextMode="Number" Text="0" />
                <asp:RequiredFieldValidator ControlToValidate="TextBoxPrecio" ErrorMessage="Debes introducir el precio de la serie " Text="Introduce el precio" runat="server" CssClass="help-block" />
            </div>
        </div>

           <div class="form-group">
            <label for="TextBoxTemporadas" class="col-sm-3 control-label">Temporadas *</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBoxTemporadas" runat="server" CssClass="form-control" TextMode="Number" Text="1" />
                <asp:RequiredFieldValidator ControlToValidate="TextBoxTemporadas" ErrorMessage="Debes introducir el número de temporadas de la serie" Text="Introduce las temporaas" runat="server" CssClass="help-block" />
            </div>
        </div>
    </div>

        </div>

     <div class="form-group">
            <div class="col-sm-9">
                <asp:Button ID="CrearButton" runat="server" Text="Crear" CssClass="btn btn-primary" OnClick="CrearButton_Click" />    
            </div>
        </div>


</asp:Content>
